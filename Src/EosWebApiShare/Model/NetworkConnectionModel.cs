namespace EosWebApi.Model;

internal class NetworkConnectionModel
{
    [JsonPropertyName("action")]
    public NetworkConnectionAction Action { get; set; }
}
