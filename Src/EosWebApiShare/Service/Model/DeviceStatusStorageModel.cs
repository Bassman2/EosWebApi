namespace EosWebApi.Service.Model;

internal class DeviceStatusStorageModel
{
    [JsonPropertyName("storagelist")]
    public List<Storage>? Storages { get; set; }
}