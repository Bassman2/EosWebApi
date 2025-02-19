namespace EosWebApi.Network.Model;

public class DeviceModel : IXSerializable
{
    public string? DeviceType { get; set; }

    public string? FriendlyName { get; set; }

    public string? Manufacturer { get; set; }

    public string? ManufacturerURL { get; set; }

    public string? ModelDescription { get; set; }

    public string? ModelName { get; set; }

    public string? SerialNumber { get; set; }

    public string? UDN { get; set; }

    public List<ServiceModel>? ServiceList { get; set; }

    public string? PresentationURL { get; set; }

    public void ReadX(XElement elm)
    {
        DeviceType = elm.ReadElementString("deviceType");
        FriendlyName = elm.ReadElementString("friendlyName");
        Manufacturer = elm.ReadElementString("manufacturer");
        ManufacturerURL = elm.ReadElementString("manufacturerURL");
        ModelDescription = elm.ReadElementString("modelDescription");
        ModelName = elm.ReadElementString("modelName");
        SerialNumber = elm.ReadElementString("serialNumber");
        UDN = elm.ReadElementString("UDN");
        ServiceList = elm.ReadElementList<ServiceModel>("serviceList", "service");
        PresentationURL = elm.ReadElementString("presentationURL");
    }

    //[XmlElement("X_compatibleId", Namespace = "http://schemas.microsoft.com/windows/pnpx/2005/11")]
    //public string? X_compatibleId { get; set; }

    //[XmlElement("X_deviceCategory", Namespace = "http://schemas.microsoft.com/windows/pnpx/2005/11")]
    //public string? X_deviceCategory { get; set; }

    //[XmlElement("X_deviceCategory", Namespace = "http://schemas.microsoft.com/windows/2008/09/devicefoundation")]
    //public string? X_deviceCategory { get; set; }
}
