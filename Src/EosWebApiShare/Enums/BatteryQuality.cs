namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<BatteryQuality>))]
public enum BatteryQuality
{
    //[EnumMember(Value = "")]
    //Empty,
    [EnumMember(Value = "bad")]
    Bad,
    [EnumMember(Value = "normal")]
    Normal,
    [EnumMember(Value = "good")]
    Good,
    [EnumMember(Value = "unknown")]
    Unknown
}
