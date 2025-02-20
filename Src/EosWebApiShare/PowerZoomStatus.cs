namespace EosWebApi;

public class PowerZoomStatus
{
    internal PowerZoomStatus(PowerZoomStatusModel model)
    {
        Status = model.Status;
        SW = model.SW;
        Moving = model.Moving;
        Location = model.Location;
        Equip = model.Equip;
        Battery = model.Battery;
        Lock = model.Lock;
        Limit = model.Limit;
        Temperature = model.Temperature;
    }

    public bool Status { get; set; }

    public string? SW { get; set; }

    public bool Moving { get; set; }

    public string? Location { get; set; }

    public bool Equip { get; set; }

    public bool Battery { get; set; }

    public bool Lock { get; set; }

    public bool Limit { get; set; }

    public PowerZoomTemperature Temperature { get; }
}
