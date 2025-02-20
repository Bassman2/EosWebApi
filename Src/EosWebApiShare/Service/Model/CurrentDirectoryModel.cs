namespace EosWebApi.Service.Model;

internal class CurrentDirectoryModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
