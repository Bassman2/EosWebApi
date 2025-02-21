namespace EosWebApiUnitTest;

[TestClass]
public class EosFunctionsUnitTest : EosBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodDateTimeAsync()
    {
        using var camera = new Camera(host, appName);

        var orgCopyright = await camera.GetCopyrightAsync();

        await camera.DeleteCopyrightAsync();
        await Task.Delay(waitTimeout);

        var emtCopyright = await camera.GetCopyrightAsync();

        await camera.SetCopyrightAsync("Dummy");
        await Task.Delay(waitTimeout);

        var dumCopyright = await camera.GetCopyrightAsync();

        await camera.SetCopyrightAsync(orgCopyright!);
        await Task.Delay(waitTimeout);

        var cmpCopyright = await camera.GetCopyrightAsync();

        Assert.AreEqual("R. & S. Beckers", orgCopyright, nameof(orgCopyright));
        Assert.AreEqual("", emtCopyright, nameof(emtCopyright));
        Assert.AreEqual("Dummy", dumCopyright, nameof(dumCopyright));
        Assert.AreEqual("R. & S. Beckers", cmpCopyright, nameof(cmpCopyright));
    }
}
