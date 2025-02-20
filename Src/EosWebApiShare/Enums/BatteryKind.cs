namespace EosWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<BatteryKind>))]
public enum BatteryKind
{
    [EnumMember(Value = "battery")]    
    Battery,
    [EnumMember(Value = "not_inserted")]
    NotInserted,
    [EnumMember(Value = "ac_adapter")]
    AcAdapter,
    [EnumMember(Value = "dc_coupler")]
    DcCoupler,
    [EnumMember(Value = "unknown")]
    Unknown,
    // only for devicestatus/battery
    [EnumMember(Value = "batterygrip")]
    Batterygrip
}

