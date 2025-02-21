namespace EosWebApi.Service.Model;

internal class NetworkConnectionModel
{
    [JsonPropertyName("action")]
    public NetworkConnectionAction Action { get; set; }
}
