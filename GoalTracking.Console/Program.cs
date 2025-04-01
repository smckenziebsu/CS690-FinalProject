using System;

namespace GoalTracking;

public class Goal
{
    public string Title {get; set; }
    public int Progress {get; set; }
    public bool Completed {get; set; }
    public int Points {get; set; }

    public Goal(string title)
    {
        Title = title;
        Progress = 0;
        Completed = false;
        Points = 0;
    }

    public void UpdateProgress(int progress)
    {
        if (progress < 0)
        {
            Progress = 0;
        }
        else if (progress > 100)
        {
            Progress = 100;
        }
        else
        {
            Progress = progress;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        while (true)
        {
            Console.WriteLine("Welcome to Goal Tracking!");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Update Goal Progress");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Exit");
            
            Console.Write("Enter your choice :");
            )
            {
                
            }}
    }
    
      
    }
}