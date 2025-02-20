namespace EosWebApiUnitTest;

[TestClass]
public class EosDeviceStatusUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStoragesAsync()
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

    [TestMethod]
    public async Task TestMethodGetCurrentStorageAsync()
    {
        using var camera = new Camera(host, appName);

        var storage = await camera.GetCurrentStorageAsync();

        Assert.IsNotNull(storage);
        Assert.AreEqual("card1", storage.Name, nameof(storage.Name));
        Assert.AreEqual("/ccapi/ver120/contents/card1", storage.Path, nameof(storage.Path));
    }

    [TestMethod]
    public async Task TestMethodGetCurrentDirectoryAsync()
    {
        using var camera = new Camera(host, appName);

        var storage = await camera.GetCurrentDirectoryAsync();

        Assert.IsNotNull(storage);
        Assert.AreEqual("102SUSIB", storage.Name, nameof(storage.Name));
        Assert.AreEqual("/ccapi/ver120/contents/card1/102SUSIB", storage.Path, nameof(storage.Path));
    }
}
