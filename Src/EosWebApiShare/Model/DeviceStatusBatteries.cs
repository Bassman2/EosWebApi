namespace EosWebApi.Service.Model;

internal class DeviceStatusBatteries
{
    [JsonPropertyName("batterylist")]
    public List<DeviceStatusBattery>? Batteries { get; set; }
}


