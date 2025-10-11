namespace EosWebApi.Model;

internal class CurrentStorageModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
