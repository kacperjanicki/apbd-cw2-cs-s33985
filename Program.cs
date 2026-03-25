// See https://aka.ms/new-console-template for more information

using apbd_cw2_cs_s33985;

public class Program
{
    public static void Main()
    {
        // 1. Dodanie nowego użytkownika do systemu
        Person jack = new Employee("Jack","Smith");
        Person adam = new Student("Adam","Black");
        
        // 2. Dodanie nowego sprzętu danego typu, domyślnie każdy sprzęt ma status IN_STOCK
        Gear laptop1 = new Laptop(price: 2500, screenSize: 17.7, ram: 16);
        Gear projector1 = new Projector(price: 5000, resolution: "1920x1080", 3, status: Status.NOT_AVAILABLE);
        Gear camera1 = new Camera(price: 8500, brand: "Canon", "18mm");
        Gear camera2 = new Camera(price: 5000, brand: "Sony", "21mm");
        
        // 3. Wyświetlenie listy całego sprzętu z aktualnym statusem
        Gear.displayAllGear();
        // 5. Wypożyczenie sprzętu użytkownikowi.
        Rental r1 = new Rental(gear: laptop1,borrower: jack, rentalDate: new DateTime(2026,01,01));
        Rental r2 = new Rental(gear: laptop1, borrower: adam); // sprzęt jest już w wypożyczeniu więc nie zostanie wypożyczony
        Rental r3 = new Rental(gear: camera1, borrower: adam, rentalDate: new DateTime(2026, 03, 22)); 
        Rental r4 = new Rental(gear: camera2, borrower: adam, rentalDate: new DateTime(2026, 03, 19)); 
        Rental r5 = new Rental(gear: projector1, borrower: jack); // Jeżeli sprzęt ma status niedostępny - nie można go wypożyczyć 
        
        // 6. Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie
        r1.returnGear();
        
        // 8. Wyświetlenie aktualnych wypożyczeń danego użytkownika
        Rental.showUserRentals(p: adam);

        Rental r6 = new Rental(gear: laptop1, borrower: adam);

        //
        // Rental r2 = new Rental(gear: l,borrower:s); // -> won't be added cause gear: l is already being rented
        // Console.WriteLine(Rental.all_rentals.Count);
        //
        //
        // foreach (var VARIABLE in Person.all_people)
        // {
        //     Console.WriteLine(VARIABLE);
        // }

        // foreach (var VARIABLE in Gear.all_equipment)
        // {
        //     Console.WriteLine(VARIABLE);
        // }
    }
}