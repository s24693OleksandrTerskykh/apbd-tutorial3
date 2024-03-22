using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public abstract class Container : IContainer
{
    public static int IdSetter = 1;
    public double MassCargo { get;  set; }
    public int Height { get;  set; }
    public double TareWeight { get;  set; }
    public int Depth { get;  set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get;  set; }

    protected Container(double tareWeight, int height, int depth, string serialNumber, double maxPayload)
    {
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxPayload = maxPayload;
    }

    public virtual void Load(double cargoWeight)
    {
        throw new OverfillException();
    }

    public virtual void Unload()
    {
        throw new NotImplementedException();
    }
}
