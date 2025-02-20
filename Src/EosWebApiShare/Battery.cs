namespace EosWebApi;

public class Battery
{
    internal Battery(BatteryModel model)
    {
        Position = model.Position;
        Kind = model.Kind;
        Name = model.Name;

        Quality = Enum.TryParse<BatteryQuality>(model.Quality, true, out var batteryQuality) ? batteryQuality : null;
        //Quality = Enum.TryParse(BatteryQuality.model.Quality;
        LevelValue = int.TryParse(model.Level, out var levelValue) ? levelValue : null;
        LevelState = Enum.TryParse<BatteryLevel>(model.Level, true, out var batteryLevel) ? batteryLevel : null;
    }
    public BatteryPosition? Position { get; }
    public BatteryKind? Kind { get; }
    public string? Name { get; }
    public BatteryQuality? Quality { get; }
    public int? LevelValue { get; }
    public BatteryLevel? LevelState { get; }
}
