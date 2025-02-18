namespace EosWebApi.Service.Model;

internal class CcDisplayOffModel
{
    [JsonPropertyName("value")]
    public DisplayOff? Value { get; set; }

    [JsonPropertyName("ability")]
    public List<DisplayOff>? Ability { get; set; }
}

