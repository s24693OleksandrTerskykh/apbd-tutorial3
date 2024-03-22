using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

    public class Ship
    {
        public string ShipName { get; set; }
        public List<Container> Containers;
        public double MaxSpeed { get;  set; } 
        public int MaxContainers { get;  set; } 
        public double MaxWeight { get;  set; }
    
        public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }
        
         public double GetWeightOfAllContainers()
    {
        double containersWeight = 0;
        foreach (Container container in Containers)
        {
            containersWeight += container.TareWeight + container.MassCargo;
        }
        return containersWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new TooManyContainersException($"Too many containers on the ship {ShipName}");
        }
        if (container.MassCargo + container.TareWeight + GetWeightOfAllContainers() > MaxWeight*1000)
            throw new ContainerTooHeavyException();
        Containers.Add(container);
    }

    public void UnloadContainer(string serialNumber)
    {
        foreach (var container in Containers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                container.Unload();
                Console.WriteLine("Container " + serialNumber+" unloaded");
            }
        }
    }
    public void LoadListOfContainers(List<Container> containers)
         {
             foreach (var container in containers)
             {
                 LoadContainer(container);
             }
         }
    
    public void RemoveContainer(string serialNumber)
    {
        foreach (var container in Containers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                Containers.Remove(container);
                Console.WriteLine("Container " + serialNumber + " removed.");
                return;
            }
        }
        Console.WriteLine("Container " + serialNumber + " doesnt exist" );
        
        
       
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = -1;
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber.Equals(serialNumber))
            {
                index = i;
                break;
            }
        }
        
        if (index != -1)
        {
            Containers[index] = newContainer;
            Console.WriteLine("Container " + serialNumber + " replaced successfully by " + newContainer.SerialNumber );
            return;
        }
        Console.WriteLine("Couldnt find an id of a container for replacement.");
        
    }
    
    public void PrintContainerInfo(string serialNumber)
    {
        foreach (var container in Containers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                Console.WriteLine(container);
            }
        }
    }

    public void GetShipInfo()
    {
        Console.WriteLine(this);
    }

    public void PrintAllContainers()
    {
        foreach (var container in Containers)
        {
            Console.WriteLine(container);
        }
    }

    public void TransferContainerToOtherShip(String serialNumber, Ship otherShip)
    { 
        foreach (var container in Containers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                try{otherShip.LoadContainer(container);}
                catch(Exception e){return;}
                RemoveContainer(container.SerialNumber);
                return;
            }
           
        }
    }

    public override string? ToString()
    {
        string info = "Speed: " + MaxSpeed + " knots\n" +
                      "Maximum number of containers: " + MaxContainers + " \n" +
                      "Maximum weight the ship can carry: " + MaxWeight + " tonns\n" +
                      "Current weight the ship is carrying: " + GetWeightOfAllContainers() + " kg\n";
        return info;
    }
    }
