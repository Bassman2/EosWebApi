namespace EosWebApi.Service.Model;

internal class CcAutoPowerOffModel
{
    [JsonPropertyName("value")]
    public AutoPowerOff? Value { get; set; }

    [JsonPropertyName("ability")]
    public List<AutoPowerOff>? Ability { get; set; }
}


