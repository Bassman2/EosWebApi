namespace EosWebApi;

public partial class Contents
{
    internal Contents(ContentsModel model)
    {
        Path = model.Path ?? model.Url?.Select(u => UrlRegex().Match(u).Groups[1].Value).ToList();
    }


    [GeneratedRegex(@"https?:\/\/[^\/]+(\/.*)")]
    private static partial Regex UrlRegex();


    public List<string>? Path { get; }

}

