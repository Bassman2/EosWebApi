namespace EosWebApi.Service.Model;

internal class TempStatusModel
{
    [JsonPropertyName("status")]
    public TemperatureStatus? Status { get; set; }
}

