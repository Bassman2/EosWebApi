namespace EosWebApi.Service.Model;

[JsonSerializable(typeof(CcapisModel))]
[JsonSerializable(typeof(DeviceInformationModel))]
[JsonSerializable(typeof(DeviceStatusStorageModel))]
[JsonSerializable(typeof(CurrentStorageModel))]
[JsonSerializable(typeof(CurrentDirectoryModel))]
[JsonSerializable(typeof(BatteryListModel))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
