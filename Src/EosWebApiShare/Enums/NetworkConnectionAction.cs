namespace EosWebApi;

public enum NetworkConnectionAction
{
    [EnumMember(Value = "connect")]
    Disconnect,
    [EnumMember(Value = "reboot")]
    Reboot
}
