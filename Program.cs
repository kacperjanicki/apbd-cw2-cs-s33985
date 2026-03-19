// See https://aka.ms/new-console-template for more information

using apbd_cw2_cs_s33985;

public class Program
{
    public static void Main()
    {
        Gear l = new Laptop();
        Gear l2 = new Projector();
        // Console.WriteLine(l.id);        
        // Console.WriteLine(l2.id);
        

        Employee e = new Employee("Jack","Smith");
        Student s = new Student("Alex", "jones");


        Rental r1 = new Rental(gear: l,borrower: e);
        Console.WriteLine(r1);
        
        Rental r2 = new Rental(gear: l,borrower:s); // -> won't be added cause gear: l is already being rented
        Console.WriteLine(Rental.all_rentals.Count);

        
        foreach (var VARIABLE in Person.all_people)
        {
            // Console.WriteLine(VARIABLE);
        }
        
        // foreach (var VARIABLE in Gear.all_equipment)
        // {
        //     Console.WriteLine(VARIABLE);
        // }
    }
}