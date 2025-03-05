namespace EosWebApi.Service.Model;

internal partial class Converter
{
    public static string PathToString(string? path)
    {
        ArgumentNullException.ThrowIfNull(path);

        Match match = PathRegex().Match(path);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        return string.Empty;
    }

    [GeneratedRegex(@"\/ccapi\/ver\d+(.*)")]
    private static partial Regex PathRegex();

    public static string UrlToString(string? url)
    {
        ArgumentNullException.ThrowIfNull(url);

        Match match = UrlRegex().Match(url);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        return string.Empty;
    }

    [GeneratedRegex(@"https?:\/\/[^\/]+(\/.*)")]
    private static partial Regex UrlRegex();

    public static List<string>? ContentsToStrings(ContentsModel? model)
    {
        return model is not null ?
               model.Path is not null ? model.Path.Select(p => PathToString(p)).ToList() :
               (model.Url is not null ? model.Url.Select(u => UrlToString(u)).ToList() : 
                throw new ArgumentNullException(nameof(model))) : null;
    }



}
