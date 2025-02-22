namespace EosWebApi.Service.Model;

internal class ActionModel
{
    [JsonPropertyName("action")]
    public Action Action { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
