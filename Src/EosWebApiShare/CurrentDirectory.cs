namespace EosWebApi;

public class CurrentDirectory
{
    internal CurrentDirectory(CurrentDirectoryModel model)
    {
        Name = model.Name;
        Path = model.Path;
    }

    public string? Name { get; }

    public string? Path { get; }
}
