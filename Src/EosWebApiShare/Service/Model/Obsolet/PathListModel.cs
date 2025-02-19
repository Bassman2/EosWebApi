namespace EosWebApi.Service.Model;

internal class PathListModel
{
    [JsonPropertyName("path")]
    public List<string>? Paths { get; set; }
}
