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
}