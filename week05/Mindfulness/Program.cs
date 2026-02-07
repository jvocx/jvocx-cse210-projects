using System;

/* * EXTRA REQUIREMENTS IMPLEMENTED:
 * 1. Activity Logging: Added a static system in the base Activity class to track how many times 
 * each activity is performed. The summary is displayed when the user quits the program.
 * 2. Reflection Question Logic: In ReflectingActivity, questions are selected randomly 
 * and tracked in an 'unused' list to ensure no repetition occurs until all questions 
 * have been presented at least once in a cycle.
 * 3. Loop Consistency: Updated ReflectingActivity to continue asking questions for the 
 * full duration specified by the user, matching the behavior of other activities.
 */

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            choice = Console.ReadLine();

            if (choice == "1")
                new BreathingActivity().Run();
            else if (choice == "2")
                new ListingActivity().Run();
            else if (choice == "3")
                new ReflectingActivity().Run();
            else if (choice == "4")
            {
                Console.WriteLine("\nThank you for using the Mindfulness Program!");
                Activity.DisplayLog();
            }
        }
    }
}