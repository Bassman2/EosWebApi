namespace EosWebApi;

public class DeviceStatusStorage
{
    internal DeviceStatusStorage(DeviceStatusStorageModel model)
    {
        Storages = model.Storages.CastModel<Storage>();
    }
    public List<Storage>? Storages { get; }
}
