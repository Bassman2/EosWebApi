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
        Assert.AreEqual("Canon.Inc", contents.Path[0], nameof(contents.Path[0]));
        Assert.AreEqual("Canon.Inc", contents.Path[1], nameof(contents.Path[1]));
    }
}
