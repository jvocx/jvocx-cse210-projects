using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void DisplayScore()
    {
        [cite_start]// Criatividade: Sistema de níveis [cite: 29, 66]
        int level = (_score / 1000) + 1;
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Rank: Level {level} Ninja");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            if (goal.IsComplete() && !(goal is EternalGoal))
            {
                Console.WriteLine("This goal is already completed!");
                return;
            }

            goal.RecordEvent(); // Polimorfismo [cite: 60]
            int pointsEarned = goal.GetPoints();

            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                pointsEarned += checklist.GetBonus(); // Bônus final [cite: 46]
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }

    public void SaveGoals(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }
    }

    public void LoadGoals(string file)
    {
        if (!File.Exists(file)) return;
        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                sg.SetComplete(bool.Parse(parts[4]));
                _goals.Add(sg);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]));
                cg.SetAmountCompleted(int.Parse(parts[6]));
                _goals.Add(cg);
            }
        }
    }
}