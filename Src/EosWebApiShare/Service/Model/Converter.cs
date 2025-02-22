namespace EosWebApi.Service.Model;

internal partial class Converter
{
    public static string UrlToPath(string url)
    {
        Match match = UrlRegex().Match(url);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        return string.Empty;
    }

    [GeneratedRegex(@"https?:\/\/[^\/]+(\/.*)")]
    private static partial Regex UrlRegex();

}
