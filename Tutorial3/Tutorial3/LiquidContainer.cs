namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double tareWeight, int height, int depth, string serialNumber, double maxPayload, bool isHazardous)
        : base(tareWeight, height, depth, serialNumber, maxPayload)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        if (IsHazardous && mass > MaxPayload*0.5 || !IsHazardous && mass > MaxPayload*0.9)
        {
            throw new OverfillException($"Cannot load cargo over {(IsHazardous ? "50%" : "90%")} of its capacity.");
        }
        MassCargo = mass;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazardous situation with container {SerialNumber}");
    }
    
    public override void EmptyCargo()
    {
        MassCargo = 0;
    }
}