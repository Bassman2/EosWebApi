namespace EosWebApi.Service.Model;

internal class UrlListModel
{
    [JsonPropertyName("url")]
    public List<string>? Urls { get; set; }
}
