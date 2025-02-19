namespace EosWebApi.Service.Model;

internal class DeviceStatusStorageModel
{
    [JsonPropertyName("storagelist")]
    public List<StorageModel>? Storages { get; set; }
}