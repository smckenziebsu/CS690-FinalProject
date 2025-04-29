using Xunit;
using GoalTracking;

namespace GoalTracking.Tests;

public class UnitTest1
{
    [Fact]
    public void AddGoal()
    {
        List<Goal> goals = new List<Goal>();
        string goalTitle = "Read a Book";

        using var sw = new StringWriter();
        Console.SetOut(sw);

        GoalManager.AddGoal(goals, goalTitle);

        Assert.Single(goals);
        Assert.Equal(goalTitle, goals[0].Title);
    }

    [Fact]

    public void UpdateGoalProgressCorrectly()
    {
       
        Goal goal = new Goal ("Read a book");

        goal.UpdateProgress(50);

        Assert.Equal(50, goal.Progress);
        Assert.False(goal.Completed);

        goal.UpdateProgress(100);

        Assert.Equal(100, goal.Progress);
        Assert.True(goal.Completed);
    }

    [Fact]

    public void UpdateProgressNotMoreThan100()
    {
        Goal goal = new Goal ("Run 2 Miles");
        goal.UpdateProgress(150);

        Assert.Equal (100, goal.Progress);
        Assert.True(goal.Completed);
    }

    [Fact]

    public void GoalIsCompleteAt100()
    {
        Goal goal = new Goal ("Finish Cooking");
        goal.UpdateProgress(100);

        Assert.True(goal.Completed);
    }

    [Fact]
    public void GetAwardReturnsGold()
{
    var goals = new List<Goal>();
    for (int i = 0; i < 5; i++)
        goals.Add(new Goal($"Goal {i}") { Completed = true });

    var award = typeof(GoalManager)
        .GetMethod("GetAward", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
        ?.Invoke(null, new object[] { goals }) as string;

    Assert.Equal("Gold", award);
}

    [Fact]

    public void DisplayGoalsShowsTitleProgress()
    {
        var goals = new List<Goal> {new Goal("Exercise") {Progress = 70}};
        
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        GoalManager.DisplayGoals(goals);
        
        string output = sw.ToString();
        Assert.Contains("Exercise", output);
        Assert.Contains("70%", output)  ; 
    }

    
}