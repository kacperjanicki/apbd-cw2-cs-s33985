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

    public Rental(Gear gear, DateTime? rentalDate = null)
    {
        this.id = all_rentals.Count + 1;
        this.RentalDate = rentalDate ?? DateTime.Now;
        this.DueDate = RentalDate.AddMonths(1);
        this.ReturnDate = null;
        this.GearRented = gear;
        
        gear.change_status(Status.RENTED);
    }

    public void returnGear()
    {
        
    }

    public override string ToString()
    {
        return
            $"{GearRented.GetType().Name} id: {GearRented.id} was rented on {RentalDate.ToShortDateString()} and is due to be returned on {DueDate.ToShortDateString()}";
    }

}