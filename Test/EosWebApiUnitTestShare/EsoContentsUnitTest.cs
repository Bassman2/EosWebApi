namespace EosWebApiUnitTest;

[TestClass]
public class EsoContentsUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetContentsAsync()
    {
        using var camera = new Camera(host, appName);

        var contents = await camera.GetContentsAsync();

        Assert.IsNotNull(contents);
        Assert.IsNotNull(contents.Path);
        Assert.AreEqual(2, contents.Path.Count, nameof(contents.Path.Count));
        Assert.AreEqual("Canon.Inc", contents.Path[0], nameof(contents.Path) + "[0]");
        Assert.AreEqual("Canon.Inc", contents.Path[1], nameof(contents.Path) + "[1]");
    }

    [TestMethod]
    public async Task TestMethodGetDirectoriesAsync()
    {
        using var camera = new Camera(host, appName);

        var directories = await camera.GetDirectoriesAsync("card1");

        Assert.IsNotNull(directories);
        Assert.IsNotNull(directories.Path);
        Assert.AreEqual(2, directories.Path.Count, nameof(directories.Path.Count));
        Assert.AreEqual("Canon.Inc", directories.Path[0], nameof(directories.Path) + "[0]");
        Assert.AreEqual("Canon.Inc", directories.Path[1], nameof(directories.Path) + "[1]");
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
