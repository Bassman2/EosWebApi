namespace EosWebApi.Service.Model;

[JsonSerializable(typeof(CcapisModel))]
[JsonSerializable(typeof(DeviceInformationModel))]
[JsonSerializable(typeof(DeviceStatusStorageModel))]
[JsonSerializable(typeof(CurrentStorageModel))]
[JsonSerializable(typeof(CurrentDirectoryModel))]
[JsonSerializable(typeof(BatteryListModel))]
[JsonSerializable(typeof(LensModel))]
[JsonSerializable(typeof(TemperatureModel))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
