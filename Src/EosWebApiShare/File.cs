namespace EosWebApi;

public class File 
{
    private readonly Camera service;

    //private readonly string? volume;
    //private readonly string? folder;

    internal File(Camera service, FileModel model, string file)
    {
        this.service = service;
        Name = file;
        FullName = file;
        Size = model.FileSize;
        //string[] arr = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        //if (arr.Length != 6) throw new Exception("Wrong path length");

        //this.volume = arr[3];
        //this.folder = arr[4];
        //this.Name = arr[5];
        //this.FullName = $"{arr[3]}/{arr[4]}/{arr[5]}";
    }

    public string Name { get; }

    public string FullName { get; }

    public ulong Size { get; }

    public DateTime CreationTime { get; }

    public static bool IsFolder => false;

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Download(string filePath)
    {
        throw new NotImplementedException();
    }

    public void DownloadThumbnail(string filePath)
    {
        throw new NotImplementedException();
    }

    public void Refresh()
    {
        throw new NotImplementedException();
    }
}
