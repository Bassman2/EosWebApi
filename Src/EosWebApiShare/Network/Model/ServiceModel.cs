namespace EosWebApi.Network.Model;

public class ServiceModel : IXSerializable
{
    public string? ServiceType { get; set; }

    public string? ServiceId { get; set; }

    public string? SCPDURL { get; set; }

    public string? ControlURL { get; set; }

    public string? EventSubURL { get; set; }

    public string? TargetId { get; set; }

    public string? OnService { get; set; }

    public string? AccessURL { get; set; }

    public string? DeviceUsbId { get; set; }

    public string? DeviceNickname { get; set; }

    public void ReadX(XElement elm)
    {
        XNamespace nsSchema = "urn:schemas-canon-com:schema-upnp";
        ServiceType = elm.ReadElementString("serviceType");
        ServiceId = elm.ReadElementString("serviceId");
        SCPDURL = elm.ReadElementString("SCPDURL");
        ControlURL = elm.ReadElementString("controlURL");
        EventSubURL = elm.ReadElementString("eventSubURL");
        TargetId = elm.ReadElementString(nsSchema + "X_targetId");
        OnService = elm.ReadElementString(nsSchema + "X_onService");
        AccessURL = elm.ReadElementString(nsSchema + "X_accessURL");
        DeviceUsbId = elm.ReadElementString(nsSchema + "X_deviceUsbId");
        DeviceNickname = elm.ReadElementString(nsSchema + "X_deviceNickname");
    }
}