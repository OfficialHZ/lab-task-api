using System.ComponentModel.DataAnnotations;

namespace lab_task_api.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}