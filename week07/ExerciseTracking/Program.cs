using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A marcação foi removida daqui
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("04 Nov 2022", 45, 20.0));
        activities.Add(new Swimming("05 Nov 2022", 40, 30));

        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("--------------------------");

        foreach (Activity activity in activities)
        {
            // A marcação foi removida daqui
            Console.WriteLine(activity.GetSummary());
        }
    }
}