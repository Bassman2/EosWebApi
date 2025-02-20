namespace EosWebApiUnitTest;

[TestClass]
public class EosFunctionsRegisteredNameUnitTest : EosBaseUnitTest
{

    [TestMethod]
    public async Task TestMethodCopyrightAsync()
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

    [TestMethod]
    public async Task TestMethodAuthorAsync()
    {
        using var camera = new Camera(host, appName);

        var orgAuthor = await camera.GetAuthorAsync();

        await camera.DeleteAuthorAsync();
        await Task.Delay(waitTimeout);

        var emtAuthor = await camera.GetAuthorAsync();

        await camera.SetAuthorAsync("Dummy");
        await Task.Delay(waitTimeout);

        var dumAuthor = await camera.GetAuthorAsync();

        await camera.SetAuthorAsync(orgAuthor!);
        await Task.Delay(waitTimeout);

        var cmpAuthor = await camera.GetAuthorAsync();

        Assert.AreEqual("R. & S. Beckers", orgAuthor, nameof(orgAuthor));
        Assert.AreEqual("", emtAuthor, nameof(emtAuthor));
        Assert.AreEqual("Dummy", dumAuthor, nameof(dumAuthor));
        Assert.AreEqual("R. & S. Beckers", cmpAuthor, nameof(cmpAuthor));
    }

    [TestMethod]
    public async Task TestMethodOwnerNameAsync()
    {
        using var camera = new Camera(host, appName);

        var orgOwnerName = await camera.GetOwnerNameAsync();

        await camera.DeleteOwnerNameAsync();
        await Task.Delay(waitTimeout);

        var emtOwnerName = await camera.GetOwnerNameAsync();

        await camera.SetOwnerNameAsync("Dummy");
        await Task.Delay(waitTimeout);

        var dumOwnerName = await camera.GetOwnerNameAsync();

        await camera.SetOwnerNameAsync(orgOwnerName!);
        await Task.Delay(waitTimeout);

        var cmpOwnerName = await camera.GetOwnerNameAsync();

        Assert.AreEqual("R. & S. Beckers", orgOwnerName, nameof(orgOwnerName));
        Assert.AreEqual("", emtOwnerName, nameof(emtOwnerName));
        Assert.AreEqual("Dummy", dumOwnerName, nameof(dumOwnerName));
        Assert.AreEqual("R. & S. Beckers", cmpOwnerName, nameof(cmpOwnerName));
    }

    [TestMethod]
    public async Task TestMethodNicknameAsync()
    {
        using var camera = new Camera(host, appName);

        var orgNickname = await camera.GetNicknameAsync();

        await camera.DeleteNicknameAsync();
        await Task.Delay(waitTimeout);

        var emtNickname = await camera.GetNicknameAsync();

        await camera.SetNicknameAsync("Dummy");
        await Task.Delay(waitTimeout);

        var dumNickname = await camera.GetNicknameAsync();

        await camera.SetNicknameAsync(orgNickname!);
        await Task.Delay(waitTimeout);

        var cmpNickname = await camera.GetNicknameAsync();

        Assert.AreEqual("EOS R6 Mark II", orgNickname, nameof(orgNickname));
        Assert.AreEqual("EOSR6m2_95B4E2", emtNickname, nameof(emtNickname));
        Assert.AreEqual("Dummy", dumNickname, nameof(dumNickname));
        Assert.AreEqual("EOS R6 Mark II", cmpNickname, nameof(cmpNickname));
    }

}
