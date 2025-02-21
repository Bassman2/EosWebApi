
namespace EosWebApi;

public sealed class Camera : IDisposable
{
    private CanonService? service;
    private DevDescModel? devDesc;
    private DeviceInformationModel? deviceInformation;

    public Camera()
    { }

    public Camera(string host, string appName)
    {
        DevDescModel devDesc = CanonNetwork.GetDevDescAsync(host, default).Result ?? throw new Exception("No connected Canon device");

        var uri = new Uri(devDesc.Device!.ServiceList![0].AccessURL!);

        this.service = new CanonService(uri, null, appName);
    }

    internal Camera(DevDescModel devDesc)
    {
        _ = Open(devDesc) ? 0 : throw new Exception($"Failed to open {devDesc?.Device?.ServiceList?[0].AccessURL}");
    }

    public void Dispose()
    {
        if (service is not null)
        {
            service.Dispose();
            service = null;
        }
    }
    
    
    public bool IsOpen => this.service is not null;

    public bool Open(string host)
    {
        //_ = CanonService.PingCamera(host) ? 0 : throw new Exception(host, "No connected device");

        DevDescModel cameraDevDesc = CanonNetwork.GetDevDescAsync(host, default).Result ?? throw new Exception("No connected Canon device");
        return Open(cameraDevDesc);
    }

    public bool Open(DevDescModel devDesc)
    {
        this.devDesc = devDesc;

        var uri = new Uri(devDesc.Device!.ServiceList![0].AccessURL!);

        this.service = new CanonService(uri, null,  "xxx");
        //if (this.service.Connect(uri) ==  false)
        //{
        //    return false;
        //}

        this.deviceInformation = this.service.GetDeviceInformationAsync(default).Result;
        return true;
    }

    public void Close()
    {
        if (this.service is not null)
        {
            this.service.Dispose();
            this.service = null;
        }
    }
        

    public async Task<DeviceInformation?> GetDeviceInformationAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetDeviceInformationAsync(cancellationToken);
        return res.CastModel<DeviceInformation>();
    }

    public async Task<List<Storage>?> GetStoragesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetStoragesAsync(cancellationToken);
        return res.CastModel<Storage>();
    }

    public async Task<CurrentStorage?> GetCurrentStorageAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCurrentStorageAsync(cancellationToken);
        return res.CastModel<CurrentStorage>();
    }

    public async Task<CurrentDirectory?> GetCurrentDirectoryAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCurrentDirectoryAsync(cancellationToken);
        return res.CastModel<CurrentDirectory>();
    }

    public async Task<Battery?> GetBatteryAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetBatteryAsync(cancellationToken);
        return res.CastModel<Battery>();
    }

    public async Task<List<Battery>?> GetBatteriesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetBatteriesAsync(cancellationToken);
        return res.CastModel<Battery>();
    }

    public async Task<Lens?> GetLensAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetLensAsync(cancellationToken);
        return res.CastModel<Lens>();
    }

    public async Task<Temperature?> GetTemperatureAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetTemperatureAsync(cancellationToken);
        return res.CastModel<Temperature>();
    }

    public async Task<PowerZoomStatus?> GetPowerZoomStatusAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPowerZoomStatusAsync(cancellationToken);
        return res.CastModel<PowerZoomStatus>();
    }

    public async Task<string?> GetCopyrightAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCopyrightAsync(cancellationToken);
        return res;
    }

    public async Task SetCopyrightAsync(string copyright, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetCopyrightAsync(copyright, cancellationToken);
    }

    public async Task DeleteCopyrightAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteCopyrightAsync(cancellationToken);
    }

    public async Task<string?> GetAuthorAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAuthorAsync(cancellationToken);
        return res;
    }

    public async Task SetAuthorAsync(string? author, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetAuthorAsync(author, cancellationToken);
    }

    public async Task DeleteAuthorAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteAuthorAsync(cancellationToken);
    }

    public async Task<string?> GetOwnerNameAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetOwnerNameAsync(cancellationToken);
        return res;
    }

    public async Task SetOwnerNameAsync(string? ownerName, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetOwnerNameAsync(ownerName, cancellationToken);
    }

    public async Task DeleteOwnerNameAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteOwnerNameAsync(cancellationToken);
    }

    public async Task<string?> GetNicknameAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetNicknameAsync(cancellationToken);
        return res;
    }

    public async Task SetNicknameAsync(string nickname, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetNicknameAsync(nickname, cancellationToken);
    }

    public async Task DeleteNicknameAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteNicknameAsync(cancellationToken);
    }

    public async Task<DateTimeDst?> GetDateTimeAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetDateTimeAsync(cancellationToken);
        return res.CastModel<DateTimeDst>();
    }

    public async Task SetDateTimeAsync(DateTimeDst dateTimeDst, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetDateTimeAsync(dateTimeDst, cancellationToken);
    }

    public async Task FormatAsync(string cardName, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.FormatAsync(cardName, cancellationToken);
    }

    public async Task<ValueAbility?> GetBeepAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetBeepAsync(cancellationToken);
        return res.CastModel<ValueAbility>();
    }

    public async Task SetBeepAsync(string value, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetBeepAsync(new ValueAbilityModel() { Value = value }, cancellationToken);
    }

    /*

    #region information

    //public ConnectionType ConnectionType => ConnectionType.WiFi;
    public string? Name  => cameraDevDesc?.Device?.ServiceList?[0].DeviceNickname;
    public string? ProductName => deviceInformation?.ProductName; 
    public string? FirmwareVersion => deviceInformation?.FirmwareVersion;
    public string? BodyIDEx => deviceInformation?.SerialNumber;
    public string? LensName => service?.GetDeviceStatusLensAsync(default).Result?.Name;
    public string? CurrentStorage => service?.GetDeviceStatusCurrentStorageAsync(default).Result?.Name;
    public string? CurrentFolder => service?.GetDeviceStatusCurrentDirectoryAsync(default).Result?.Name;
    //public TemperatureStatus? TemperatureStatus => service?.GetDeviceStatusTemperatureAsync(default).Result;
    //public List<BatteryInfo>? Batteries => service?.GetDeviceStatusBatteriesAsync(default).Result?.Batteries?.Select(b => new BatteryInfo(b)).ToList();

    private List<Volume>? volumes;
    public List<Volume>? Volumes => volumes ??= service?.GetDeviceStatusStorageAsync(default).Result?.Select(s => (EosVolume)new CcVolume(this.service, s)).ToList();

    //public List<Property> Properties { get; } = [];

    #endregion

    #region settings

    public string? Copyright
    {
        get => service?.GetCopyrightAsync(default).Result;
        set => service?.SetCopyrightAsync(value, default).Wait();
    }

    public string? Author
    {
        get => service?.GetAuthorAsync(default).Result;
        set => service?.SetAuthorAsync(value, default).Wait();
    }

    public string? Owner
    {
        get => service?.GetOwnerAsync(default).Result;
        set => service?.SetOwnerAsync(value, default).Wait();
    }

    public string? Nickname
    {
        get => service?.GetNicknameAsync(default).Result;
        set => service?.SetNicknameAsync(value, default).Wait();
    }

    public DateTime? DateTime 
    { 
        get => service?.GetDateTimeAsync(default).Result; 
        set => service?.SetDateTimeAsync(value, default).Wait();
    }

    public string? Beep
    {
        get => service?.GetBeepAsync(default).Result.Ability(out beepValues);
        set => service?.SetBeepAsync(value!, default).Wait();
    }

    private string[]? beepValues;
    public string[]? BeepValues => beepValues ??= service?.GetBeepAsync(default).Result?.Ability?.ToArray();
    
    public string? DisplayOff
    {
        get => service?.GetDisplayOffAsync(default).Result.Ability(out displayOffValues);
        set => service?.SetDisplayOffAsync(value!, default).Wait();
    }

    private string[]? displayOffValues;
    public string[]? DisplayOffValues => displayOffValues ??= service?.GetDisplayOffAsync(default).Result?.Ability?.ToArray();

    public string? AutoPowerOff
    {
        get => service?.GetAutoPowerOffAsync(default).Result.Ability(out autoPowerOffValues);
        set => service?.SetAutoPowerOffAsync(value, default).Wait();
    }

    private string[]? autoPowerOffValues;
    public string[]? AutoPowerOffValues => autoPowerOffValues ??= service?.GetAutoPowerOffAsync(default).Result?.Ability?.ToArray();

    #endregion
    */
}
