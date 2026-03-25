namespace apbd_cw2_cs_s33985;

public class Gear
{
    public static List<Gear> all_equipment = new List<Gear>();
    public int id;
    public decimal marketPrice { get; set; }
    public Status current_status { get; set; }

    public Gear(decimal marketPrice, Status status = Status.IN_STOCK)
    {
        this.id = all_equipment.Count + 1;
        this.current_status = status;
        this.marketPrice = marketPrice;
        all_equipment.Add(this);
    }

    public void change_status(Status new_status)
    {
        if (new_status == current_status)
        {
            Console.WriteLine("It already has that status!");
            return;
        }
        
        current_status = new_status;
    }

    public static void displayAllGear(bool showOnlyAvailable = false, bool showMessage = true)
    {
        if(showMessage) Console.WriteLine("--------------DISPLAYING AVAILABLE GEAR IN OUR STORAGE--------------");
        foreach (var eq in all_equipment)
        {
            if (showOnlyAvailable && eq.current_status != Status.IN_STOCK) continue;
            Console.WriteLine(eq);
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} id: {id} // current_status: {current_status}";
    }
}


public class Laptop : Gear
{
    public double screenSize { get; set; }
    public int ramGB { get; set; }

    public Laptop(decimal price, double screenSize, int ram, Status status = Status.IN_STOCK) 
        : base(price, status)
    {
        this.screenSize = screenSize;
        this.ramGB = ram;
    }
}

public class Projector : Gear
{
    public string maxResolution { get; set; }
    public int portsCount { get; set; }

    public Projector(decimal price, string resolution, int ports, Status status = Status.IN_STOCK) 
        : base(price, status)
    {
        this.maxResolution = resolution;
        this.portsCount = ports;
    }
}

public class Camera : Gear
{
    public string brand { get; set; }
    public string lensSpec { get; set; }

    public Camera(decimal price, string brand, string lens, Status status = Status.IN_STOCK) 
        : base(price, status)
    {
        this.brand = brand;
        this.lensSpec = lens;
    }
}