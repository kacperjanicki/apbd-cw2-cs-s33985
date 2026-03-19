namespace apbd_cw2_cs_s33985;

public enum Status
{
    IN_STOCK,
    RENTED
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
            Console.WriteLine($"{gear.GetType().Name} id: {gear.id} is already being rented by someone else.");
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
        
    }

    public override string ToString()
    {
        return
            $"{GearRented.GetType().Name} id: {GearRented.id} was rented by {Borrower.firstName} {Borrower.lastName} on {RentalDate.ToShortDateString()} and is due to be returned on {DueDate.ToShortDateString()}";
    }

}