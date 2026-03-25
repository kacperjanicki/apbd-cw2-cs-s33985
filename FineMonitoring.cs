namespace apbd_cw2_cs_s33985;

public class FineMonitoring
{
    public static double finePerDay = 20.0;

    public static double calculateFine(DateTime dueTime)
    {
        DateTime now = DateTime.Now;
        double totalFine = 0.0;

        if (now > dueTime)
        {
            TimeSpan diff = now - dueTime;
            int days = (int)diff.TotalDays;

            totalFine = days * finePerDay;
            // Console.WriteLine($"Due time passed {days} days ago, total fine is: {totalFine}.");
            
        }

        return totalFine;

    }
}