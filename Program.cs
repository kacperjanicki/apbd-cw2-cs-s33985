using apbd_cw2_cs_s33985;

public class Program
{
    public static void generateRaport()
    {
        Console.WriteLine("--------------GENERATING A RAPORT--------------");
        Console.WriteLine($"=> Our rental place has {Person.all_people.Count} clients/employees.");
        foreach (var p in Person.all_people)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("=> Our gear in stock consists of: ");
        Gear.displayAllGear(showMessage: false);
        Console.WriteLine("=> Current rentals of our customers: ");
        foreach (var p in Person.all_people)
        {
            Rental.showUserRentals(p);
        }

    }
    public static void Main()
    {
        // 1. Dodanie nowego użytkownika do systemu
        Person jack = new Employee("Jack","Smith");
        Person adam = new Student("Adam","Black");
        
        // 2. Dodanie nowego sprzętu danego typu, domyślnie każdy sprzęt ma status IN_STOCK
        Gear laptop1 = new Laptop(price: 2500, screenSize: 17.7, ram: 16);
        Gear laptop2 = new Laptop(price: 4800, screenSize: 14.4, 32);
        Gear projector1 = new Projector(price: 5000, resolution: "1920x1080", 3, status: Status.NOT_AVAILABLE);
        Gear projector2 = new Projector(price: 8000, resolution: "3840x2160", ports: 5);
        Gear camera1 = new Camera(price: 8500, brand: "Canon", "18mm");
        Gear camera2 = new Camera(price: 5000, brand: "Sony", "21mm");
        
        // 3. Wyświetlenie listy całego sprzętu z aktualnym statusem
        Gear.displayAllGear();
        
        // 4. Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia.
        // Gear.displayAllGear(showOnlyAvailable: true);
        
        // 5. Wypożyczenie sprzętu użytkownikowi.
        Rental.Rent(gear: laptop1,borrower: jack, rentalDate: new DateTime(2026,01,01));
        Rental.Rent(gear: laptop1, borrower: adam); // Sprzęt jest już w wypożyczeniu więc nie zostanie wypożyczony
        
        Rental.Rent(gear: camera1, borrower: adam, rentalDate: new DateTime(2026, 02, 22)); 
        Rental.Rent(gear: camera2, borrower: adam, rentalDate: new DateTime(2026, 03, 19));
        
        Rental.Rent(gear: projector1, borrower: jack); // Jeżeli sprzęt ma status niedostępny - nie można go wypożyczyć 
        
        // 6. Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie
        // Zwrot z karą
        Rental.Return(laptop1);
        // Zwrot bez kary
        Rental.Return(camera2);
        
        // Próba przekroczenia limitu wypożyczeń
        Rental.Rent(gear: projector2, borrower: adam);
        Rental.Rent(gear:laptop2, borrower:adam);
        
        // 7. Oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu
        laptop1.change_status(Status.NOT_AVAILABLE);
        
        // 8. Wyświetlenie aktualnych wypożyczeń danego użytkownika
        Rental.showUserRentals(p: adam);
        
        // 9. Wyświetlenie listy przeterminowanych wypożyczeń
        Rental.showDueRentals();
        
        // 10. Wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni
        // generateRaport();
    }
}