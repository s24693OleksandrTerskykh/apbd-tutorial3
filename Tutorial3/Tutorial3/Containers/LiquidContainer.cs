using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;


public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double tareWeight, int height, int depth, string serialNumber, double maxPayload, bool isHazardous)
        : base(tareWeight, height, depth, serialNumber, maxPayload)
    {
        IsHazardous = isHazardous;
        SerialNumber = "KON-L-" + IdSetter;
        IdSetter++;
        
    }

    public override void Load(double cargoWeight)
    {
        if (IsHazardous && cargoWeight > MaxPayload*0.5 || !IsHazardous && cargoWeight > MaxPayload*0.9)
        {
            throw new OverfillException($"Cannot load cargo over {(IsHazardous ? "50%" : "90%")} of its capacity.");
        }
        MassCargo = cargoWeight;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazardous situation with container {SerialNumber}");
    }
    
    public override void Unload()
    {
        MassCargo = 0;
    }
    public override string? ToString()
    {
        string info = "________________________________________________\n"
                      + "Serial number: " + SerialNumber + "\n" +
                      "Height: " + Height + " cm\n" +
                      "Tare Weight: " + TareWeight + " kg\n" +
                      "Depth: " + Depth + " cm\n" +
                      "Maximum Payload: " + MaxPayload + " kg\n" +
                      "Cargo Mass: " + MassCargo + " kg\n" + 
                      "________________________________________________";
        return info;
    }
}