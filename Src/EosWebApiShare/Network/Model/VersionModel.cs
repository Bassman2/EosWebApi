namespace EosWebApi.Network.Model;

public class VersionModel : IXSerializable
{
    public int Major { get; set; }

    public int Minor { get; set; }

    public void ReadX(XElement elm)
    {
        Major = elm.ReadElementInt("major") ?? 0;
        Minor = elm.ReadElementInt("minor") ?? 0;
    }
}
