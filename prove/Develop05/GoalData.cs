public class GoalData
{
    public string _type;
    public string _name;
    public string _description;
    public int _points;
    public bool _isComplete;
    public int _amountCompleted;
    public int _targetAmount;
    public int _bonus;
    public GoalData()
    {
        
    }
    public GoalData(string type, string name, string description, int points)
    {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
    }
    public GoalData(string type, string name, string description, int points, bool isComplete)
    {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }
    public GoalData(string type, string name, string description, int points, int bonus, int targetAmount, int amountCompleted)
    {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
        _bonus = bonus;
        _targetAmount = targetAmount;
        _amountCompleted = amountCompleted;
    }
    public void LineToGoalData(string line)
    {
        string[] parts = line.Split(",");
        string[] typeAndTitle = parts[0].Split(":");
        _type = typeAndTitle[0];
        _name = typeAndTitle[1];
        _description = parts[1];
        _points = int.Parse(parts[2]);
        if (_type == "SimpleGoal")
        {
            _isComplete = bool.Parse(parts[3]);
        }
        else if (_type == "ChecklistGoal")
        {
            _bonus = int.Parse(parts[3]);
            _targetAmount = int.Parse(parts[4]);
            _amountCompleted = int.Parse(parts[5]);
        }
        
    }
    public string ToString()
    {
        if (_type == "SimpleGoal")
            return $"{_type}:{_name},{_description},{_points},{_isComplete}\n";
        else if (_type == "EternalGoal")
            return $"{_type}:{_name},{_description},{_points}\n";
        else
            return $"{_type}:{_name},{_description},{_points},{_bonus},{_targetAmount},{_amountCompleted}\n";
    }
}