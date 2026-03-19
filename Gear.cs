namespace apbd_cw2_cs_s33985;

public class Gear
{
    public static List<Gear> all_equipment = new List<Gear>();
    public int id;
    public Status current_status { get; set; }

    public Gear()
    {
        this.id = all_equipment.Count + 1;
        this.current_status = Status.IN_STOCK;
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

    public override string ToString()
    {
        return $"{GetType().Name} has id {id} and its current status is {current_status}";
    }
}


public class Laptop : Gear
{
    
}

public class Projector : Gear
{
    
}

public class Camera : Gear
{
    
}