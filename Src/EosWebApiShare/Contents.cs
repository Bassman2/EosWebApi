namespace EosWebApi;

public class Contents
{
    internal Contents(ContentsModel model)
    {
        Path = model.Path ?? model.Url?.Select(u => Converter.UrlToPath(u)).ToList();
    }

    public List<string>? Path { get; }

}

