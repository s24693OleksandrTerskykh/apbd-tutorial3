namespace Tutorial3;

public abstract class Container
{
    public double MassCargo { get; protected set; }
    public int Height { get; private set; }
    public double TareWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public double MaxPayload { get; private set; }

    protected Container(double tareWeight, int height, int depth, string serialNumber, double maxPayload)
    {
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxPayload = maxPayload;
    }

    public abstract void LoadCargo(double mass);
    public abstract void EmptyCargo();
}
