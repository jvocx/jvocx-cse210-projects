public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public void SetAmountCompleted(int amount) => _amountCompleted = amount;

    public override void RecordEvent() => _amountCompleted++;
    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        [cite_start]
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetSaveString() => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";

    public int GetBonus() => _bonus;
}