namespace EosWebApi.Service.Model;

internal class NetworkSettingModel
{
    [JsonPropertyName("action")]
    public NetworkConnectionAction Action { get; set; }
}
