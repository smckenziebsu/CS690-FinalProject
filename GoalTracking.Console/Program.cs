﻿using System;

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

        Completed = (Progress >= 100);
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
            string choice = Console.ReadLine();

        
             if (choice == "1")
            {
                AddGoal(goals);
            }
            else if (choice == "2")
            {
                UpdateGoalProgress(goals);
            }
           else if (choice == "3")
             {
                DisplayGoals(goals);
            }
            else if (choice == "4")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Choice. Please try again.");
            }
        }
    }
    
   static void AddGoal(List<Goal> goals)
    {
        Console.Write("Enter Goal Title: ");
        string title = Console.ReadLine();

        if (title != null)
        {
            goals.Add(new Goal(title));
            Console.WriteLine($"Goal '{title}' added.");
        }
        else
        {
            Console.WriteLine("Invalid Title.");
        }
    }

    static void UpdateGoalProgress(List<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No Goals!");
            return;
        }

        Console.WriteLine("Please Select a Goal to Update: ");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Title}");
        }

        Console.Write("Enter goal number: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber <= goals.Count)
        {
            Console.Write("Enter the percentage of progress made (e.g., 25 for 25%): ");
            if (int.TryParse(Console.ReadLine(), out int progress))
            {
                goals[goalNumber - 1].UpdateProgress(goals[goalNumber - 1].Progress + progress);
                Console.WriteLine($"Goal '{goals[goalNumber - 1].Title}' updated."); 
            }
            else
            {
                Console.WriteLine("Invalid Value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Goal");
        }

    }

    static void DisplayGoals(List<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No Goals!");
            return;
        }

        Console.WriteLine("Your Goals Are: ");
        for (int i =0; i <goals.Count; i++)
        {
            Console.WriteLine($"- {goals[i]. Title} (Progress: {goals[i].Progress}%)");
        }
        
    }

    static string GetAward(List<Goal> goals)
    {
        int completedGoals = 0;
        foreach (Goal goal in goals)
        {
            if (goal.Completed)
            {
                completedGoals++;
            }
        }

        if (completedGoals >= 5)
        {
            return "Gold";
        }
        else if (completedGoals >= 3)
        {
            return "Silver";
        }
        else if (completedGoals >= 1)
        {
            return "Bronze";
        }
        else
        {
            return "";
        }
    }
}