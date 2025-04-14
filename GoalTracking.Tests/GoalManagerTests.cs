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
}