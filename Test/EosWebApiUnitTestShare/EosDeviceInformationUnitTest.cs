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
        Assert.AreEqual("Canon.Inc", deviceInformation.Manufacturer, nameof(deviceInformation.Manufacturer));
        Assert.AreEqual("Canon EOS R6m2", deviceInformation.ProductName, nameof(deviceInformation.ProductName));
        Assert.AreEqual("7bb7e995a3455324bc9ac49dc9b0af43", deviceInformation.Guid, nameof(deviceInformation.Guid));
        Assert.AreEqual("193021000208", deviceInformation.SerialNumber, nameof(deviceInformation.SerialNumber));
        Assert.AreEqual("a0:cd:f3:95:b4:e2", deviceInformation.MacAddress, nameof(deviceInformation.MacAddress));
        Assert.AreEqual("1.5.0", deviceInformation.FirmwareVersion, nameof(deviceInformation.FirmwareVersion));
    }

    [TestMethod]
    public async Task TestMethodGetStorageAsync()
    {
        using var camera = new Camera(host, appName);

        var storage = await camera.GetStorageAsync();

        Assert.IsNotNull(storage);
        Assert.AreEqual("Canon.Inc", storage.Name, nameof(storage.Name));
        Assert.AreEqual("Canon EOS R6m2", storage.Url, nameof(storage.Url));
        Assert.AreEqual("7bb7e995a3455324bc9ac49dc9b0af43", storage.Path, nameof(storage.Path));
        Assert.AreEqual("193021000208", storage.AccessCapability, nameof(storage.AccessCapability));
        Assert.AreEqual(0ul, storage.Maxize, nameof(storage.Maxize));
        Assert.AreEqual(0ul, storage.SpaceSize, nameof(storage.SpaceSize));
        Assert.AreEqual(0ul, storage.ContentsNumber, nameof(storage.ContentsNumber));
    }

}
