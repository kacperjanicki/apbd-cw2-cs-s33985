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
    public DateTime rentalDate { get; set; }
    public DateTime dueDate { get; set; }
    public DateTime? returnDate { get; set; }
    public Gear gearRented { get; set; }
    public Person borrower { get; set; }

    public Rental(Gear gear, Person borrower, DateTime? rentalDate = null)
    {
        if (gear.current_status == Status.RENTED)
        {
            Console.WriteLine($"ERROR => {gear.GetType().Name} id: {gear.id} is already being rented by someone else.");
            return;
        } else if (gear.current_status == Status.NOT_AVAILABLE)
        {
            Console.WriteLine($"ERROR => {gear.GetType().Name} id: {gear.id} is currently not available for rental.");
            return;
        }
        if (borrower.maxRentals == all_rentals.Count(r => r.borrower == borrower))
        {
            Console.WriteLine($"ERROR => Limit of rentals for your role is {borrower.maxRentals}, you are trying to exceed it. Try returning some gear.");
            return;
        }
        this.id = all_rentals.Count + 1;
        this.rentalDate = rentalDate ?? DateTime.Now;
        this.dueDate = this.rentalDate.AddMonths(1);
        this.returnDate = null;
        this.gearRented = gear;
        this.borrower = borrower;
        
        gear.change_status(Status.RENTED);
        all_rentals.Add(this);
    }

    public static void Rent(Gear gear, Person borrower, DateTime? rentalDate = null)
    {
        new Rental(gear, borrower, rentalDate);
    }
    public static void Return(Gear gear)
    {
        var rental = all_rentals.FirstOrDefault(r => r.gearRented == gear);

        if (rental != null)
        {
            rental.returnGear();
        }
        else
        {
            Console.WriteLine("=> This gear is not currently rented.");
        }
    }

    public void returnGear()
    {
        Console.WriteLine($"--------------RETURNING: {gearRented} rented by: {borrower.firstName} {borrower.lastName}--------------");
        double fine = FineMonitoring.calculateFine(dueTime: dueDate);
        if (fine > 0.0)
        {
            borrower.fineAmount += fine;
            Console.WriteLine($"=> ${fine} fine has been applied to {borrower}, now he has to pay off {borrower.fineAmount} total.");
        }
        else
        {
            Console.WriteLine("No fine was issued, gear returned succesfully.");
        }
        gearRented.change_status(Status.IN_STOCK);
        all_rentals.Remove(this);
    }

    public static void showDueRentals()
    {
        Console.WriteLine($"--------------DISPLAYING ALL DUE RENTALS--------------");
        foreach (var rental in all_rentals)
        {
            if (DateTime.Now > rental.dueDate)
            {
                Console.WriteLine(rental);
            }
        }
    }

    public static void showUserRentals(Person p)
    {
        int rental_count = all_rentals.Count(r => r.borrower == p);
        if (rental_count > 0)
        {
            Console.WriteLine($"--------------DISPLAYING ALL RENTALS OF: {p.firstName} {p.lastName}--------------");
        }
        else
        {
            Console.WriteLine($"{p.firstName} {p.lastName} is not renting any items at the moment.");
        }
        foreach (var rental in all_rentals)
        {
            if (rental.borrower == p)
            {
                Console.WriteLine(rental);            
            }
        }
    }

    public override string ToString()
    {
        string dueInfo = "";
        if (DateTime.Now > dueDate)
        {
            dueInfo = "DUE: ";
        }
        return
            $"{dueInfo}{gearRented.GetType().Name} id: {gearRented.id} was rented by {borrower.firstName} {borrower.lastName} on {rentalDate.ToShortDateString()} and is due to be returned on {dueDate.ToShortDateString()}";
    }

}