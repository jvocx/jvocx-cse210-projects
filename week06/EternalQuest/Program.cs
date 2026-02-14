GoalManager manager = new GoalManager();

bool running = true;

while (running)
{
    Console.WriteLine("\n==== Eternal Quest ====");
    Console.WriteLine("1. Create New Goal");
    Console.WriteLine("2. List Goals");
    Console.WriteLine("3. Record Event");
    Console.WriteLine("4. Show Score");
    Console.WriteLine("5. Quit");

    Console.Write("Select an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateGoal(manager);
            break;

        case "2":
            manager.DisplayGoals();
            break;

        case "3":
            manager.DisplayGoals();
            Console.Write("Which goal did you complete? ");
            int index = int.Parse(Console.ReadLine()) - 1;
            manager.RecordEvent(index);
            break;

        case "4":
            manager.DisplayScore();
            break;

        case "5":
            running = false;
            break;
    }
}


void CreateGoal(GoalManager manager)
{
    Console.WriteLine("\nSelect Goal Type:");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");

    string type = Console.ReadLine();

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Description: ");
    string description = Console.ReadLine();

    Console.Write("Points: ");
    int points = int.Parse(Console.ReadLine());

    if (type == "1")
    {
        manager.AddGoal(new SimpleGoal(name, description, points));
    }
    else if (type == "2")
    {
        manager.AddGoal(new EternalGoal(name, description, points));
    }
    else if (type == "3")
    {
        Console.Write("Target amount: ");
        int target = int.Parse(Console.ReadLine());

        Console.Write("Bonus points: ");
        int bonus = int.Parse(Console.ReadLine());

        manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
    }
}


void DisplayScore(int score)
{
    int level = (score / 1000) + 1;
    Console.WriteLine($"Seu Score atual é: {score}");
    [cite_start] Console.WriteLine($"Você é um Ninja Nível: {level}!"); [cite: 29]
}