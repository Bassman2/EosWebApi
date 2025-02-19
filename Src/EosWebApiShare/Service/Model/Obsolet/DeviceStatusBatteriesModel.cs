namespace EosWebApi.Service.Model;

internal class DeviceStatusBatteriesModel
{
    [JsonPropertyName("batterylist")]
    public List<DeviceStatusBatteryModel>? Batteries { get; set; }
}


