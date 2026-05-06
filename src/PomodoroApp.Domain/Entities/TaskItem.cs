using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Build.Utilities;

namespace PomodoroApp.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public TaskItemStatus Status { get; private set; }
    public int EstimatedPomodoros { get; private set; }
    public int CompletedPomodoros { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private TaskItem() { }

    public static TaskItem Create(string title, string? description, int estimatedPomodoros, Guid userId) => new()
    {
        Id = Guid.NewGuid(),
        Title = title,
        Description = description,
        EstimatedPomodoros = estimatedPomodoros,
        UserId = userId,
        Status = TaskItemStatus.Pending,
        CreatedAt = DateTime.UtcNow
    };

    public void IncrementPomodoro()
    {
        if (Status == TaskItemStatus.Completed) throw new InvalidOperationException("La tarea ya está completada"); 
        CompletedPomodoros++; 
        if (CompletedPomodoros >= EstimatedPomodoros) Complete(); // transición de estado controlada }
    }

    public void Complete() { Status = TaskItemStatus.Completed; CompletedAt = DateTime.UtcNow; }
    public void UpdateTitle(string newTitle) { ArgumentException.ThrowIfNullOrWhiteSpace(newTitle); Title = newTitle.Trim(); }
    public enum TaskItemStatus { Pending, InProgress, Completed, Cancelled }
    public enum SessionType { Work, ShortBreak, LongBreak }
}
