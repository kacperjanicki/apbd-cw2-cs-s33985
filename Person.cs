namespace apbd_cw2_cs_s33985;

public class Person
{
    public int id;
    public static List<Person> all_people = new List<Person>();
    public string firstName;
    public string lastName;
    public double fineAmount { get; set; }
    public virtual int maxRentals => 0;

    public Person()
    {
        
    }
    public Person(string firstName, string lastName)
    {
        this.id = all_people.Count + 1;
        this.firstName = firstName;
        this.lastName = lastName;
        this.fineAmount = 0.0;
        all_people.Add(this);
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} o id {id}";
    }
}

public class Student : Person
{
    public override int maxRentals => 2;
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
    
    public override string ToString()
    {
        return $"STUDENT: {firstName} {lastName} o id {id}";
    }
}

public class Employee : Person
{
    public override int maxRentals => 5;
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }
    
    public override string ToString()
    {
        return $"EMPLOYEE: {firstName} {lastName} o id {id}";
    }
}