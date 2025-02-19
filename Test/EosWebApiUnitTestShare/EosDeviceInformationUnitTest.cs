namespace EosWebApiUnitTest;

[TestClass]
public class EosDeviceInformationUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetDeviceInformationAsync()
    {
        using var camera = new Camera(host, appName);

        var deviceInformation = await camera.GetDeviceInformationAsync();

        Assert.IsNotNull(deviceInformation);
        Assert.AreEqual("", deviceInformation.Manufacturer, nameof(deviceInformation.Manufacturer));
        Assert.AreEqual("", deviceInformation.ProductName, nameof(deviceInformation.ProductName));
        Assert.AreEqual("", deviceInformation.Guid, nameof(deviceInformation.Guid));
        Assert.AreEqual("", deviceInformation.SerialNumber, nameof(deviceInformation.SerialNumber));
        Assert.AreEqual("", deviceInformation.MacAddress, nameof(deviceInformation.MacAddress));
        Assert.AreEqual("", deviceInformation.FirmwareVersion, nameof(deviceInformation.FirmwareVersion));
    }
}
