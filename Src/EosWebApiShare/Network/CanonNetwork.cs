namespace EosWebApi.Network;

internal class CanonNetwork
{
    private const int timeout = 500;

    private static List<Camera> GetCameras()
    {
        return FindCameras()?.Select(d => new Camera(d)).ToList() ?? [];
    }

    public static bool PingCamera(Uri url) => PingCamera(url.Host);

    public static bool PingCamera(string host)
    {
        PingReply rep = new Ping().SendPingAsync(host, 1000).Result;
        return rep.Status == IPStatus.Success;
    }

    internal static List<DevDescModel>? FindCameras()
    {
        IPAddress? gateway = GetDefaultGateway();
        if (gateway != null)
        {
            var pingList = FindActiveNetworkDevices(gateway);
            return FindCanonDevices(pingList);
        }
        return null;
    }

    private static List<IPAddress> FindActiveNetworkDevices(IPAddress gateway)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var pingTasks = GetIPAddressRange(gateway).Select(a => PingAsync(a)).ToArray();
        Task.WaitAll(pingTasks);

        stopWatch.Stop();
        Debug.WriteLine($"FindActiveNetworkDevices: {stopWatch.Elapsed}");

        var list = pingTasks.Where(p => p.Result.Status == IPStatus.Success).Select(p => p.Result.Address).ToList();

        foreach (var p in list)
        {
            Debug.WriteLine($"Active Ping {p}");
        }

        return list;
    }

    private static IPAddress? GetDefaultGateway()
    {
        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            Debug.WriteLine($"{networkInterface.Name} {networkInterface.Id} {networkInterface.OperationalStatus} {networkInterface.NetworkInterfaceType}");
        }

        var addr = NetworkInterface.GetAllNetworkInterfaces().Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback).Select(n => GetGateway(n)).FirstOrDefault();
        return addr;
    }    

    private static IEnumerable<IPAddress> GetIPAddressRange(IPAddress address)
    {
        byte[] addrBytes = address.GetAddressBytes();
        for (int i = 2; i <= 255; i++)
        {
            addrBytes[3] = (byte)i;
            yield return new IPAddress(addrBytes);
        }
    }

    private static Task<PingReply> PingAsync(IPAddress address) => new Ping().SendPingAsync(address, timeout);

    private static List<DevDescModel> FindCanonDevices(List<IPAddress> addresses)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        var devDescTasks = addresses.Select(a => CheckDevDesc(a)).ToArray();
        Task.WaitAll(devDescTasks);

        stopWatch.Stop();

        Debug.WriteLine($"FindCanonDevices: {stopWatch.Elapsed}");

        var list = devDescTasks.Where(t => t.Result.IsCanonCamera).Select(t => t.Result.CameraDevDesc!).ToList();

        foreach (var d in list)
        {
            Debug.WriteLine($"DevDesc {d.Device!.ServiceList![0].DeviceNickname}");
        }
        return list;
    }

    private static IPAddress? GetGateway(NetworkInterface networkInterface)
    {
        foreach (var gateway in networkInterface.GetIPProperties().GatewayAddresses)
        {
            Debug.WriteLine($"{gateway.Address} {gateway.Address.AddressFamily}");
        }

        var addr = networkInterface.GetIPProperties().GatewayAddresses.Select(a => a.Address).FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
        return addr;
    }


   

    private class DevDesc(IPAddress addr, DevDescModel? devDesc = null)
    {
        public IPAddress? Address { get; } = addr;
        public DevDescModel? CameraDevDesc { get; } = devDesc;

        public bool IsCanonCamera => CameraDevDesc is not null;
    }


    private static Task<DevDesc> CheckDevDesc(IPAddress addr)
    {
        return Task<DevDesc>.Run<DevDesc>(() =>
        {
            try
            {
                Uri upnpUri = new UriBuilder("http", addr.ToString(), 49152, "/upnp/CameraDevDesc.xml").Uri;
                using HttpClient upnp = new HttpClient() { Timeout = new TimeSpan(0, 0, 0, 0, timeout) };

                string text = upnp.GetStringAsync(upnpUri).Result;

                var cameraDevDesc = text.XDeserialize<DevDescModel>("root");   // Namespace="urn:schemas-upnp-org:device-1-0"

                //XmlSerializer serializer = new XmlSerializer(typeof(CameraDevDesc));
                //CameraDevDesc? cameraDevDesc = (CameraDevDesc?)serializer.Deserialize(new StringReader(text));
                Debug.WriteLine($"******************************** {addr}");
                return new DevDesc(addr, cameraDevDesc);
            }
            catch
            {
                Debug.WriteLine($"Failed {addr}");
                return new DevDesc(addr);
            }
        });

    }

    public static async Task<DevDescModel?> GetDevDescAsync(Uri url, CancellationToken cancellationToken) 
        => await GetDevDescAsync(url.Host, cancellationToken);

    public static async Task<DevDescModel?> GetDevDescAsync(string host, CancellationToken cancellationToken)
    {
        Uri upnpUri = new UriBuilder("http", host, 49152, "/upnp/CameraDevDesc.xml").Uri;
        using var upnp = new HttpClient();

        string text = await upnp.GetStringAsync(upnpUri);

        XNamespace devns = "urn:schemas-upnp-org:device-1-0";           // XNamespace Get
        var cameraDevDesc = text.XDeserialize<DevDescModel>(devns + "root");   
        return cameraDevDesc;
    }

}
