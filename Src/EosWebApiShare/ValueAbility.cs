namespace EosWebApi;

public class ValueAbility
{
    internal ValueAbility(ValueAbilityModel model)
    {
        Value = model.Value;
        Ability = model.Ability;
    }
    public string? Value { get; set; }
    public List<string>? Ability { get; set; }
}
