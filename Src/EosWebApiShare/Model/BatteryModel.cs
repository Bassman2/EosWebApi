namespace EosWebApi.Model;

internal class BatteryModel
{
    /// <summary>
    /// Gets or sets the position of the battery.
    /// </summary>
    /// <remarks>Only in battery list</remarks>
    [JsonPropertyName("position")]
    public BatteryPosition? Position { get; set; }

    [JsonPropertyName("kind")]
    [JsonConverter(typeof(JsonStringEnumConverter<BatteryKind>))]
    public BatteryKind Kind { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    // TODO: workaround for empty string handling
    [JsonPropertyName("quality")]
    //[JsonConverter(typeof(JsonStringEnumConverter<BatteryQuality>))]
    //public BatteryQuality? Quality { get; set; }
    public string? Quality { get; set; }

    // TODO: workaround for empty string handling
    [JsonPropertyName("level")]
    public string? Level { get; set; }
   
}




