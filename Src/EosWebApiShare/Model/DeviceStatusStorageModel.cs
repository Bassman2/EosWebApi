namespace EosWebApi.Model;

internal class DeviceStatusStorageModel
{
    [JsonPropertyName("storagelist")]
    public List<StorageModel>? Storages { get; set; }
}