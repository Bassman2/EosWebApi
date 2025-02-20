namespace EosWebApi.Service.Model;

internal class BatteryListModel
{
    [JsonPropertyName("batterylist")]
    public List<BatteryModel>? Batteries { get; set; }
}


