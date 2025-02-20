namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<PowerZoomTemperature>))]
public enum PowerZoomTemperature
{
    Normal,
    Warn,
    Stop
}
