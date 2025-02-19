namespace EosWebApi.Network.Model;

public class DevDescModel : IXSerializable
{
    public VersionModel? SpecVersion { get; set; }

    public string? URLBase { get; set; }

    public DeviceModel? Device { get; set; }

    public void ReadX(XElement elm)
    {
        SpecVersion = elm.ReadElementItem<VersionModel>("specVersion");
        URLBase = elm.ReadElementString("URLBase");
        Device = elm.ReadElementItem<DeviceModel>("device"); 
    }
}





//public class Service : IXSerializable
//{
//    public string? ServiceType { get; set; }

//    public string? ServiceId { get; set; }

//    public string? SCPDURL { get; set; }

//    public string? ControlURL { get; set; }

//    public string? EventSubURL { get; set; }

//    public string? TargetId { get; set; }

//    public string? OnService { get; set; }

//    public string? AccessURL { get; set; }

//    public string? DeviceUsbId { get; set; }

//    public string? DeviceNickname { get; set; }

//    public void ReadX(XElement elm)
//    {
//        ServiceType = elm.ReadElementString("serviceType");
//        ServiceId = elm.ReadElementString("serviceId");
//        SCPDURL = elm.ReadElementString("SCPDURL");
//        ControlURL = elm.ReadElementString("controlURL");
//        EventSubURL = elm.ReadElementString("eventSubURL");
//        TargetId = elm.ReadElementString("X_targetId");
//        OnService = elm.ReadElementString("X_onService");
//        AccessURL = elm.ReadElementString("X_accessURL");
//        DeviceUsbId = elm.ReadElementString("X_deviceUsbId");
//        DeviceNickname = elm.ReadElementString("X_deviceNickname");
//    }
//}