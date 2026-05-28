using Microsoft.AspNetCore.Mvc;
using lab_task_api.Models;

namespace lab_task_api.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private static List<TaskItem> tasks = new()
    {
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
    };

    private static int nextId = 3;

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public IActionResult CreateTask(TaskItem task)
    {
        task.Id = nextId++;

        tasks.Add(task);

        return Created($"/tasks/{task.Id}", task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskItem updatedTask)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        task.Title = updatedTask.Title;
        task.IsCompleted = updatedTask.IsCompleted;

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        tasks.Remove(task);

        return NoContent();
    }
}