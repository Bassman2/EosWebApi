namespace EosWebApi.Model;

internal class ContentsModel
{
    /// <summary>
    /// Gets or sets the url.
    /// </summary>
    /// <remarks>for ver100</remarks>
    [JsonPropertyName("url")]
    public List<string>? Url { get; set; }

    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    /// <remarks>for ver110 or greather</remarks>
    [JsonPropertyName("path")]
    public List<string>? Path { get; set; }
}
