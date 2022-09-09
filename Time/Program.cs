using System;

public class DateArithmetic
{
    public static void Main()
    {
        DateTime date1, date2, littime;
        DateTimeOffset dateOffset1, dateOffset2;
        TimeSpan difference;

        // Find difference between Date.Now and Date.UtcNow
        date2 = DateTime.UtcNow;
        TimeSpan ts = new TimeSpan(03, 00, 00);
        littime = date2 + ts;
        Console.WriteLine(littime);

    }
}