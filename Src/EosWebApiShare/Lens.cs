namespace EosWebApi;

public class Lens
{
    internal Lens(LensModel model)
    {
        Mount = model.Mount;
        Name = model.Name;
    }

    public bool Mount { get; }

    public string? Name { get; }
}
