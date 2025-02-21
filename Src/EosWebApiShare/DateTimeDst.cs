namespace EosWebApi;

public class DateTimeDst
{
    internal DateTimeDst(DateTimeDstModel model)
    {
        DateTime = model.DateTime;
        Dst = model.Dst;
    }

    public static implicit operator DateTime?(DateTimeDst? d) => d?.DateTime;
    
    public DateTime? DateTime { get; set; }

    public bool Dst { get; set; }
}
