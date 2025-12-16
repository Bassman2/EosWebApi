namespace EosWebApiUnitTest;

[TestClass]
public class EosDeviceStatusUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStorageAsync()
    {
        using var camera = new Camera(host, appName);

        var storage = await camera.GetStorageAsync();

        Assert.IsNotNull(storage);
        Assert.HasCount(2, storage);

        Storage storage0 = storage[0];
        //Assert.IsNotNull(storage0);
        Assert.AreEqual("card1", storage0.Name, nameof(storage0.Name));
        Assert.IsNull(storage0.Url, nameof(storage0.Url));
        Assert.AreEqual("/ccapi/ver120/contents/card1", storage0.Path, nameof(storage0.Path));
        Assert.AreEqual("readwrite", storage0.AccessCapability, nameof(storage0.AccessCapability));
        Assert.AreNotEqual(0ul, storage0.MaxSize, nameof(storage0.MaxSize));
        Assert.AreNotEqual(0ul, storage0.SpaceSize, nameof(storage0.SpaceSize));
        Assert.AreNotEqual(0ul, storage0.ContentsNumber, nameof(storage0.ContentsNumber));

        Storage storage1 = storage[1];
        //Assert.IsNotNull(storage1);
        Assert.AreEqual("card2", storage1.Name, nameof(storage1.Name));
        Assert.IsNull(storage1.Url, nameof(storage1.Url));
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

    [TestMethod]
    public async Task TestMethodGetBatteryAsync()
    {
        using var camera = new Camera(host, appName);

        var battery = await camera.GetBatteryAsync();

        Assert.IsNotNull(battery);
        Assert.IsNull(battery.Position, nameof(battery.Position));
        Assert.AreEqual(BatteryKind.Batterygrip, battery.Kind, nameof(battery.Kind));
        Assert.AreEqual("", battery.Name, nameof(battery.Name));
        Assert.IsNull(battery.Quality, nameof(battery.Quality));
        Assert.IsNull(battery.LevelState, nameof(battery.LevelState));
        Assert.IsNull(battery.LevelValue, nameof(battery.LevelValue));
    }

    [TestMethod]
    public async Task TestMethodGetBatteriesAsync()
    {
        using var camera = new Camera(host, appName);

        var batteries = await camera.GetBatteriesAsync();

        Assert.IsNotNull(batteries);
        Assert.HasCount(2, batteries);

        var battery0 = batteries[0];
        Assert.IsNotNull(battery0);
        Assert.AreEqual(BatteryPosition.Grip02, battery0.Position, nameof(battery0.Position));
        Assert.AreEqual(BatteryKind.Battery, battery0.Kind, nameof(battery0.Kind));
        Assert.AreEqual("LP-E6NH", battery0.Name, nameof(battery0.Name));
        Assert.AreEqual(BatteryQuality.Good, battery0.Quality, nameof(battery0.Quality));
        Assert.IsNull(battery0.LevelState, nameof(battery0.LevelState));
        Assert.AreNotEqual(0, battery0.LevelValue, nameof(battery0.LevelValue));


        var battery1 = batteries[1];
        Assert.IsNotNull(battery1);
        Assert.AreEqual(BatteryPosition.Grip01, battery1.Position, nameof(battery1.Position));
        Assert.AreEqual(BatteryKind.Battery, battery1.Kind, nameof(battery1.Kind));
        Assert.AreEqual("LP-E6NH", battery1.Name, nameof(battery1.Name));
        Assert.AreEqual(BatteryQuality.Good, battery1.Quality, nameof(battery1.Quality));
        Assert.IsNull(battery1.LevelState, nameof(battery1.LevelState));
        Assert.AreNotEqual(0, battery1.LevelValue, nameof(battery1.LevelValue));
    }

    [TestMethod]
    public async Task TestMethodGetLensAsync()
    {
        using var camera = new Camera(host, appName);

        var lens = await camera.GetLensAsync();

        Assert.IsNotNull(lens);
        Assert.IsTrue(lens.Mount, nameof(lens.Mount));
        Assert.AreEqual("\u0002", lens.Name, nameof(lens.Name));
    }

    [TestMethod]
    public async Task TestMethodGetTemperaturAsync()
    {
        using var camera = new Camera(host, appName);

        var temperature = await camera.GetTemperatureAsync();

        Assert.IsNotNull(temperature);
        Assert.AreEqual(TemperatureStatus.Normal, temperature.Status, nameof(temperature.Status));
       
    }

    [TestMethod]
    [Ignore("PowerZoomStatus is not supported by EOS R5")]
    public async Task TestMethodGetPowerZoomStatusAsync()
    {
        using var camera = new Camera(host, appName);

        var powerZoomStatus = await camera.GetPowerZoomStatusAsync();

        Assert.IsNotNull(powerZoomStatus);
        //Assert.AreEqual(TemperatureStatus.Normal, temperature.Status, nameof(temperature.Status));

    }
}
