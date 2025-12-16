namespace EosWebApiUnitTest;

[TestClass]
public class EsoContentsUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStoragesAsync()
    {
        using var camera = new Camera(host, appName);

        var storages = await camera.GetStoragesAsync();

        Assert.IsNotNull(storages);
        Assert.HasCount(2, storages, nameof(storages.Count));
        Assert.AreEqual("Canon.Inc", storages[0], nameof(storages) + "[0]");
        Assert.AreEqual("Canon.Inc", storages[1], nameof(storages) + "[1]");
    }

    [TestMethod]
    public async Task TestMethodGetDirectoriesAsync()
    {
        using var camera = new Camera(host, appName);

        var directories = await camera.GetDirectoriesAsync("card1");

        Assert.IsNotNull(directories);
        Assert.HasCount(2, directories, nameof(directories.Count));
        Assert.AreEqual("Canon.Inc", directories[0], nameof(directories) + "[0]");
        Assert.AreEqual("Canon.Inc", directories[1], nameof(directories) + "[1]");
    }

    [TestMethod]
    public async Task TestMethodGetFilesAsync()
    {
        using var camera = new Camera(host, appName);

        var files = await camera.GetFilesAsync("card1", "Folder").ToListAsync();

        Assert.IsNotNull(files);

        Assert.AreNotEqual(0, files.Count, nameof(files.Count));
        Assert.IsFalse(string.IsNullOrEmpty(files[0]), nameof(files) + "[0]");
    }
}
