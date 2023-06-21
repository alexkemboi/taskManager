using System;
using System.Collections.Generic;

class Program
{
    static List<Task> taskList = new List<Task>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Task Manager!\n");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Complete a task");
            Console.WriteLine("4. Quit");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddTask()
    {
        Console.Write("\nEnter the task description: ");
        string description = Console.ReadLine();

        int taskId = taskList.Count + 1;

        Task newTask = new Task(taskId, description);
        taskList.Add(newTask);

        Console.WriteLine("\nTask added successfully!");
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nTasks:");

        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            foreach (Task task in taskList)
            {
                Console.WriteLine($"Task ID: {task.Id}");
                Console.WriteLine($"Description: {task.Description}\n");
            }
        }
    }

    static void CompleteTask()
    {
        Console.Write("\nEnter the ID of the task to complete: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            Task taskToRemove = taskList.Find(task => task.Id == taskId);

            if (taskToRemove != null)
            {
                taskList.Remove(taskToRemove);
                Console.WriteLine("\nTask completed and removed successfully!");
            }
            else
            {
                Console.WriteLine("\nTask not found.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid task ID. Please try again.");
        }
    }
}

class Task
{
    public int Id { get; set; }
    public string Description { get; set; }

    public Task(int id, string description)
    {
        Id = id;
        Description = description;
    }
}
