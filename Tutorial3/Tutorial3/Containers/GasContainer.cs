using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get;  set; }

    public GasContainer(double tareWeight, int height, int depth, string serialNumber, double maxPayload, double pressure)
        : base(tareWeight, height, depth, serialNumber, maxPayload)
    {
        SerialNumber = "KON-G-" + IdSetter;
        IdSetter++;
        Pressure = pressure;
    }
    
    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxPayload)
        {
            throw new OverfillException($"Cannot load cargo exceeding {MaxPayload} kg.");
        }
        MassCargo = cargoWeight;
    }
    
    public void NotifyHazard()
    {
        Console.WriteLine($"Hazard Alert: Gas container {SerialNumber} is in a hazardous state.");
    }

    public override void Unload()
    {
        MassCargo *= 0.05;
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
                      "Pressure: " + Pressure + " atmospheres\n" + 
                      "________________________________________________";
        return info;
    }
}