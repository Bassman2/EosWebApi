namespace EosWebApi.Service.Model;

internal class ValuePutModel
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
