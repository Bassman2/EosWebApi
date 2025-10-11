namespace EosWebApi.Model;

internal class PowerZoomStatusModel
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("sw")]
    public string? SW { get; set; }

    [JsonPropertyName("moving")]
    public bool Moving { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("equip")]
    public bool Equip { get; set; }

    [JsonPropertyName("battery")]
    public bool Battery { get; set; }

    [JsonPropertyName("lock")]
    public bool Lock { get; set; }

    [JsonPropertyName("limit")]
    public bool Limit { get; set; }

    [JsonPropertyName("temperature")]
    public PowerZoomTemperature Temperature { get; set; }
}
