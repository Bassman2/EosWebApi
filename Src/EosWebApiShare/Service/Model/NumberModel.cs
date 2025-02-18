namespace EosWebApi.Service.Model;

internal class Number
{
    [JsonPropertyName("contentsnumber")]
    public ulong ContentsNumber { get; set; }

    [JsonPropertyName("pagenumber")]
    public ulong PageNumber { get; set; }
}
