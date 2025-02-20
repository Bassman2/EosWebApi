namespace EosWebApi;

public class Temperature
{
    internal Temperature(TemperatureModel model)
    {
        Status = model.Status;
    }

    public TemperatureStatus? Status { get; }

}
