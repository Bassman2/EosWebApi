namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<TemperatureStatus>))]
public enum TemperatureStatus
{
    Normal,
    Warning,
    Frameratedown,
    DisableLiveview,
    DisableRelease,
    StillQualityWarning,
    RestrictionMovierecording,
    Warning_And_RestrictionMovierecording,
    FramerateDown_And_RestrictionMovierecording,
    DisableLiveview_And_RestrictionMovierecording,
    DisableRelease_And_RestrictionMovierecording,
    StillQualityWarning_And_RestrictionMovierecording
}
