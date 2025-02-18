namespace EosWebApi.Service.Model;

internal class ValueGetModel
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("ability")]
    public List<string>? Ability { get; set; }
}
