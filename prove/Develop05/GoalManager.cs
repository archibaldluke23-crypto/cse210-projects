using System.Drawing;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;
    private bool _loadedIn;
    private GoalFileHandler goalFileHandler = new GoalFileHandler();
    public GoalManager()
    {
        _score = 0;
        _level = 1;
        _loadedIn = false;
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void DeleteGoal(int index)
    {
        _goals.RemoveAt(index);
    }
    public List<Goal> GetGoals()
    {
        return _goals;
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou are level {_level} and have a score {_score}.\nYou need {1000 - _score} more points to make it to the next level\n");
    }
    public void ListGoalDetails(bool simpleDetails = false)
    {
        int index = 1;
        if (simpleDetails)
        {
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"  {index}. {goal.GetName()}");
                index += 1;
            }
        }
        else
        {
            foreach (Goal goal in _goals)
            {
                    
                Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
                index += 1;
            }
        }
    }
    public void RecordEvent(int goalIndex)
    {
        Goal goal = _goals[goalIndex];
        int points = goal.RecordEvent();
        _score += points;
        if (_score >= 1000)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        _score -= 950;
        _level += 1;
        Console.WriteLine("You leveled up! Here's an extra 50 points for all your hard work!");
    }
    public void SaveGoals(string filename)
    {
        goalFileHandler.Save(filename,_level, _score, _goals);
        Console.WriteLine("Saved!");
        _loadedIn = true;
    }
    public void LoadGoals(string filename)
    {
        if (_loadedIn)
        {
            Console.WriteLine("Can not load in your file again");
        }
        else
        {
            SaveData savedata = goalFileHandler.Load(filename);
            List<GoalData> goals = savedata.goals;
            _score = savedata.score;
            _level = savedata.level;
            foreach (GoalData goaldata in goals)
            {
                Goal goal = goalFileHandler.CreateGoalFromData(goaldata);
                _goals.Add(goal);
            }
            _loadedIn = true;
        }
        
    }
}