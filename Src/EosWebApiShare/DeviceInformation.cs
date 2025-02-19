namespace EosWebApi;

public class DeviceInformation
{
    internal DeviceInformation(DeviceInformationModel model)
    {
        Manufacturer = model.Manufacturer;
        ProductName = model.ProductName;
        Guid = model.Guid;
        SerialNumber = model.SerialNumber;
        MacAddress = model.MacAddress;
        FirmwareVersion = model.FirmwareVersion;
    }

    public string? Manufacturer { get; }

    public string? ProductName { get; }

    public string? Guid { get; }

    public string? SerialNumber { get; }

    public string? MacAddress { get; }

    public string? FirmwareVersion { get; }
}
