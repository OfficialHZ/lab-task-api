using lab_task_api.Models;

namespace lab_task_api.Services;

public class TaskService
{
    private readonly List<TaskItem> tasks =
    [
        new TaskItem
        {
            Id = 1,
            Title = "Learn ASP.NET Core",
            IsCompleted = false
        },
        new TaskItem
        {
            Id = 2,
            Title = "Build first API",
            IsCompleted = true
        }
    ];

    private int nextId = 3;

    public List<TaskItem> GetAll()
    {
        return tasks;
    }

    public TaskItem? GetById(int id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem Create(TaskItem task)
    {
        task.Id = nextId++;

        tasks.Add(task);

        return task;
    }

    public bool Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return false;
        }

        tasks.Remove(task);

        return true;
    }

    public TaskItem? Update(int id, TaskItem updatedTask)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return null;
        }

        task.Title = updatedTask.Title;
        task.IsCompleted = updatedTask.IsCompleted;

        return task;
    }
}