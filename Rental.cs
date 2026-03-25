namespace apbd_cw2_cs_s33985;

public enum Status
{
    IN_STOCK,
    RENTED,
    NOT_AVAILABLE
}

public class Rental
{
    public int id { get; set;}
    public static List<Rental> all_rentals = new List<Rental>();
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Gear GearRented { get; set; }
    public Person Borrower { get; set; }

    public Rental(Gear gear, Person borrower, DateTime? rentalDate = null)
    {
        if (gear.current_status == Status.RENTED)
        {
            Console.WriteLine($"=> {gear.GetType().Name} id: {gear.id} is already being rented by someone else.");
            return;
        } else if (gear.current_status == Status.NOT_AVAILABLE)
        {
            Console.WriteLine($"=> {gear.GetType().Name} id: {gear.id} is currently not available for rental.");
            return;
        }
        this.id = all_rentals.Count + 1;
        this.RentalDate = rentalDate ?? DateTime.Now;
        this.DueDate = RentalDate.AddMonths(1);
        this.ReturnDate = null;
        this.GearRented = gear;
        this.Borrower = borrower;


        
        gear.change_status(Status.RENTED);
        all_rentals.Add(this);
    }

    public void returnGear()
    {
        double fine = FineMonitoring.calculateFine(dueTime:DueDate);
        Console.WriteLine(fine);
    }

    public static void showUserRentals(Person p)
    {
        Console.WriteLine($"--------------DISPLAYING ALL RENTALS OF: {p.firstName} {p.lastName}--------------");
        foreach (var rental in all_rentals)
        {
            if (rental.Borrower == p)
            {
                Console.WriteLine(rental);            
            }
        }
    }

    public override string ToString()
    {
        string dueInfo = "";
        if (DateTime.Now > DueDate)
        {
            dueInfo = "DUE: ";
        }
        
        return
            $"{dueInfo}{GearRented.GetType().Name} id: {GearRented.id} was rented by {Borrower.firstName} {Borrower.lastName} on {RentalDate.ToShortDateString()} and is due to be returned on {DueDate.ToShortDateString()}";
    }

}