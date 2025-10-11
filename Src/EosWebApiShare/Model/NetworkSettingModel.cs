namespace EosWebApi.Model;

internal class NetworkSettingModel
{
    [JsonPropertyName("action")]
    public NetworkConnectionAction Action { get; set; }
}
