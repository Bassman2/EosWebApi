namespace EosWebApi.Service.Model;

internal class CcapisModel
{
    [JsonPropertyName("ver100")]
    public List<CcapiMOdel>? Ver100 { get; set; }

    [JsonPropertyName("ver110")]
    public List<CcapiMOdel>? Ver110 { get; set; }

    [JsonPropertyName("ver120")]
    public List<CcapiMOdel>? Ver120 { get; set; }

    [JsonPropertyName("ver130")]
    public List<CcapiMOdel>? Ver130 { get; set; }
}

internal class CcapiMOdel
{
    // version 1.0.0
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    // >= version 1.1.0
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("get")]
    public bool Get { get; set; }

    [JsonPropertyName("post")]
    public bool Post{ get; set; }

    [JsonPropertyName("put")]
    public bool Put { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }
}