namespace EosWebApi.Service.Model;

internal class CcBeepModel
{
    [JsonPropertyName("value")]
    public Beep? Value { get; set; }

    //[JsonPropertyName("ability")]
    //public List<Beep>? Ability { get; set; }
}
