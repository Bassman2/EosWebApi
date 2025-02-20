namespace EosWebApi.Service.Model;

internal class TemperatureModel
{
    [JsonPropertyName("status")]
    public TemperatureStatus? Status { get; set; }
}
