namespace EosWebApi.Model;

internal class TemperatureModel
{
    [JsonPropertyName("status")]
    public TemperatureStatus? Status { get; set; }
}
