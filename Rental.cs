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
            Console.WriteLine($"=> {gear.GetType().Name} id: {gear.id} is already being rented by someone else.");
            return;
        } else if (gear.current_status == Status.NOT_AVAILABLE)
        {
            Console.WriteLine($"=> {gear.GetType().Name} id: {gear.id} is currently not available for rental.");
            return;
        }
        if (borrower.maxRentals == all_rentals.Count(r => r.borrower == borrower))
        {
            Console.WriteLine($"=> Limit of rentals for your role is {borrower.maxRentals}, you are trying to exceed it. Try returning some gear.");
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

    public void returnGear()
    {
        Console.WriteLine($"--------------RETURNING: {gearRented}--------------");
        double fine = FineMonitoring.calculateFine(dueTime: dueDate);
        if (fine > 0.0)
        {
            borrower.fineAmount += fine;
            Console.WriteLine($"${fine} fine has been applied to {borrower}, now he has to pay off {borrower.fineAmount} total.");
        }
        else
        {
            Console.WriteLine("No fine was issued, gear returned succesfully.");
        }
        gearRented.change_status(Status.IN_STOCK);
        all_rentals.Remove(this);
    }

    public static void showUserRentals(Person p)
    {
        Console.WriteLine($"--------------DISPLAYING ALL RENTALS OF: {p.firstName} {p.lastName}--------------");
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