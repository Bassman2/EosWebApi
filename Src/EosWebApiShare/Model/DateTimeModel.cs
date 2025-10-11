namespace EosWebApi.Service.Model;

internal class DateTimeModel
{
    [JsonPropertyName("datetime")]
    public DateTime? DateTime { get; set; }

    [JsonPropertyName("dst")]
    public bool Dst { get; set; }

    public static implicit operator DateTime?(DateTimeModel? d) 
    {
        return d?.DateTime;
    }

    public static explicit operator DateTimeModel?(DateTime? d)
    {
        return d is null ? null : new DateTimeModel() { DateTime = d };
    }
}
