namespace EosWebApi.Service.Model;

internal class CameraDateTimeModel
{
    [JsonPropertyName("datetime")]
    public DateTime? DateTime { get; set; }

    [JsonPropertyName("dst")]
    public bool Dst { get; set; }

    public static implicit operator DateTime?(CameraDateTimeModel? d) 
    {
        return d?.DateTime;
    }

    public static explicit operator CameraDateTimeModel?(DateTime? d)
    {
        return d is null ? null : new CameraDateTimeModel() { DateTime = d };
    }
}
