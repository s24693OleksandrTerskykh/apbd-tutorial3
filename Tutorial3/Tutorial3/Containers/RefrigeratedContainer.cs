using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; } 
    public double Temperature { get; set; }

    public RefrigeratedContainer(double tareWeight, int height, int depth, string serialNumber, double maxPayload,
        string productType, double temperature)
        : base(tareWeight, height, depth, serialNumber, maxPayload)
    {
        SerialNumber = "KON-C-" + IdSetter;
        IdSetter++;
        ProductType = productType;
        Temperature = temperature;
    }

    public override void Load(double cargoWeight)
    {
        if (Temperature < PossibleProducts.Products[ProductType])
        {
            throw new TemperatureTooLowException(
                $"Temperature of the container is lower than required for {ProductType}");
        }
        else
        {
            MassCargo += cargoWeight;
        }
    }

    public override void Unload()
    {
        MassCargo = 0;
    }
}
public static class PossibleProducts
{
    public static Dictionary<string, double> Products = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Ice cream", -18 },
        { "Milk", 4 },
        { "Yogurt", 4 },
        { "Cheese", 7.2 },
        { "Sausages", 5 }
    };
}