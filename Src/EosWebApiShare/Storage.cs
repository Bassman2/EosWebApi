namespace EosWebApi;

public class Storage
{
    internal Storage(StorageModel model)
    {
        Name = model.Name;
        Url = model.Url;
        Path = model.Path;
        AccessCapability = model.AccessCapability;
        Maxize = model.Maxize;
        SpaceSize = model.SpaceSize;
        ContentsNumber = model.ContentsNumber;
    }

    public string? Name { get; }

    public string? Url { get; set; }

    public string? Path { get; }

    public string? AccessCapability { get; }

    public ulong Maxize { get; }

    public ulong SpaceSize { get; }

    public ulong ContentsNumber { get; }
}
