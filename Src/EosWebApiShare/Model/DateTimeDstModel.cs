namespace EosWebApi.Model;

internal class DateTimeDstModel
{
    [JsonPropertyName("datetime")]
    public DateTime? DateTime { get; set; }

    [JsonPropertyName("dst")]
    public bool Dst { get; set; }

    
    //public static implicit operator DateTimeDstModel?(DateTimeDst? d)
    //{
    //    return d is null ? null : new DateTimeDstModel() { DateTime = d.DateTime, Dst = d.Dst };
    //}
    
    public static implicit operator DateTimeDstModel(DateTimeDst d)
    {
        return new DateTimeDstModel() { DateTime = d.DateTime, Dst = d.Dst };
    }
}
