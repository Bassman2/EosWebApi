namespace EosWebApi.Model;

internal class LensModel
{
    [JsonPropertyName("mount")]
    public bool Mount { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

}
