public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int targetAmount, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }
    public override int RecordEvent()
    {
        if (_amountCompleted == _targetAmount)
        {
            Console.WriteLine("Goal already completed");
            return 0;
        }
        else
        {
            Console.WriteLine($"Congrates! You have earned {_points} points!");
            _amountCompleted += 1;
            if (_targetAmount == _amountCompleted)
            {
                Console.WriteLine($"You met your goal and got a bonus of {_bonus} extra points!");
                return _points + _bonus;
            }
            else
                return _points;
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted == _targetAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string GetDetailsString()
    {
        string marked = " ";
        if (_amountCompleted == _targetAmount)
        {
            marked =  "X";
        }
        string details = $"[{marked}] {_name} ({_description}) -- Currently Completed: {_amountCompleted}/{_targetAmount}";
        return details;
    }
    public override GoalData ToGoalData()
    {
        GoalData goalData = new GoalData("ChecklistGoal", _name, _description, _points, _bonus, _targetAmount,  _amountCompleted);
        return goalData;
    }
}