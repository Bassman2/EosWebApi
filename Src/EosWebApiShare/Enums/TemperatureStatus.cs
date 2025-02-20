namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<TemperatureStatus>))]
public enum TemperatureStatus
{
    Normal,
    warning,
    frameratedown,
    disableliveview,
    disablerelease,
    stillqualitywarning,
    restrictionmovierecording,
    warning_and_restrictionmovierecording,
    frameratedown_and_restrictionmovierecording,
    disableliveview_and_restrictionmovierecording,
    disablerelease_and_restrictionmovierecording,
    stillqualitywarning_and_restrictionmovierecording
}
