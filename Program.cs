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
        
        l2.change_status(Status.RENTED);

        Rental r1 = new Rental(l);

        Console.WriteLine(r1);
        
        // foreach (var VARIABLE in Gear.all_equipment)
        // {
        //     Console.WriteLine(VARIABLE);
        // }
        
        Employee e = new Employee("Jack","Smith");
        Student s = new Student("Alex", "jones");

        foreach (var VARIABLE in Person.all_people)
        {
            // Console.WriteLine(VARIABLE);
        }

    }
}