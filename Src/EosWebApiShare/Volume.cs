namespace EosWebApi;

public class Volume 
{
    private readonly CanonService service;

    internal Volume(CanonService service, StorageModel storage)
    {
        this.service = service;
        this.Name = storage.Name ?? "";
        this.MaxCapacity = storage.MaxSize;
        this.FreeSpaceInBytes = storage.SpaceSize;
        //var colList = this.service.GetDirectories(this.Name);

    }
      
    public string Name { get; }

    //public EdsStorageType StorageType { get; }

    //public EdsAccess Access { get; }

    public ulong MaxCapacity { get; }

    public ulong FreeSpaceInBytes { get; }

    private List<Directory>? directories;

    //public override IEnumerable<EosFileSystemItem>? FileSystemItems 
    //    => Directories;

    //public override IEnumerable<CcDirectory>? Directories 
    //    => directories ??= service.GetDirectoriesAsync(this.Name, default).Result?.Select(d => new CcDirectory(this.service, d)).ToList();

    //public override IEnumerable<EosFileSystemItem>? Files 
    //    => null; 

    public void Format()
    {
        throw new NotImplementedException();
    }

    public void Refresh()
    {
        directories = null; // reset
    }
}
