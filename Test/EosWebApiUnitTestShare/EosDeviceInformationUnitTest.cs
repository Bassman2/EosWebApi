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

        var storage = await camera.GetStoragesAsync();

        Assert.IsNotNull(storage);
        Assert.AreEqual(2, storage.Count);

        Storage storage0 = storage[0];
        Assert.IsNotNull(storage0);
        Assert.AreEqual("card1", storage0.Name, nameof(storage0.Name));
        Assert.AreEqual(null, storage0.Url, nameof(storage0.Url));
        Assert.AreEqual("/ccapi/ver120/contents/card1", storage0.Path, nameof(storage0.Path));
        Assert.AreEqual("readwrite", storage0.AccessCapability, nameof(storage0.AccessCapability));
        Assert.AreNotEqual(0ul, storage0.MaxSize, nameof(storage0.MaxSize));
        Assert.AreNotEqual(0ul, storage0.SpaceSize, nameof(storage0.SpaceSize));
        Assert.AreNotEqual(0ul, storage0.ContentsNumber, nameof(storage0.ContentsNumber));

        Storage storage1 = storage[1];
        Assert.IsNotNull(storage1);
        Assert.AreEqual("card2", storage1.Name, nameof(storage1.Name));
        Assert.AreEqual(null, storage1.Url, nameof(storage1.Url));
        Assert.AreEqual("/ccapi/ver120/contents/card2", storage1.Path, nameof(storage1.Path));
        Assert.AreEqual("readwrite", storage1.AccessCapability, nameof(storage1.AccessCapability));
        Assert.AreNotEqual(0ul, storage1.MaxSize, nameof(storage1.MaxSize));
        Assert.AreNotEqual(0ul, storage1.SpaceSize, nameof(storage1.SpaceSize));
        Assert.AreNotEqual(0ul, storage1.ContentsNumber, nameof(storage1.ContentsNumber));
    }

}
