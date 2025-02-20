namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<BatteryPosition>))]
public enum BatteryPosition
{
    [EnumMember(Value = "camera")]
    Camera,
    [EnumMember(Value = "grip01")]
    Grip01,
    [EnumMember(Value = "grip02")]
    Grip02
}
