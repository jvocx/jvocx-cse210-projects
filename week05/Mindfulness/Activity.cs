using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;


    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

        if (!_activityCounts.ContainsKey(_name))
        {
            _activityCounts[_name] = 0;
        }
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());


        _activityCounts[_name]++;

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public static void DisplayLog()
    {
        Console.WriteLine("\n--- Session Summary ---");
        foreach (var entry in _activityCounts)
        {
            Console.WriteLine($"{entry.Key} Activity: {entry.Value} times");
        }
        Console.WriteLine("-----------------------");
    }
}