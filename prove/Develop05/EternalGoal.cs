public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }
    public override int RecordEvent()
    {
        Console.WriteLine($"Congrates! You have earned {_points} points!");
        return _points;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetDetailsString()
    {
        string details = $"[ ] {_name} ({_description})";
        return details;
    }
    public override GoalData ToGoalData()
    {
        GoalData goalData = new GoalData("EternalGoal", _name, _description, _points);
        return goalData;
    }
}