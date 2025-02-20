namespace EosWebApi;

public class CurrentStorage
{
    internal CurrentStorage(CurrentStorageModel model)
    {
        Name = model.Name;
        Path = model.Path;
    }

    public string? Name { get; }

    public string? Path { get; }
}
