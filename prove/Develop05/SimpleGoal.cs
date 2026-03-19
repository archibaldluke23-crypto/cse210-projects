public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("Goal already completed");
            return 0;
        }
        else
        {
            Console.WriteLine($"Congrates! You have earned {_points} points!");
            _isComplete = true;
            return _points;
        }
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetDetailsString()
    {
        string marked = " ";
        if (_isComplete)
        {
            marked =  "X";
        }
        string details = $"[{marked}] {_name} ({_description})";
        return details;
    }
    public override GoalData ToGoalData()
    {
        GoalData goalData = new GoalData("SimpleGoal", _name, _description, _points, _isComplete);
        return goalData;
    }
}