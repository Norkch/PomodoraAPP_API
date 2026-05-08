namespace PomodoroApp.Domain.Entities;

public class PomodoroSession
{ 
    public Guid Id { get; private set; }
    public Guid TaskItemId { get; private set; }
    public Guid UserId { get; private set; }
    public SessionType Type { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public bool WasCompleted { get; private set; }
    public TimeSpan Duration => FinishedAt.HasValue ? FinishedAt.Value - StartedAt : TimeSpan.Zero;
    private PomodoroSession() { }

    public static PomodoroSession Start(Guid taskItemId, Guid userId, SessionType type)
    {
        if (taskItemId == Guid.Empty)
            throw new ArgumentException("TaskItemId no puede ser vacío", nameof(taskItemId));
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId no puede ser vacío", nameof(userId));

        return new PomodoroSession
        {
            Id = Guid.NewGuid(),
            TaskItemId = taskItemId,
            UserId = userId,
            Type = type,
            StartedAt = DateTime.UtcNow,
            WasCompleted = false
        };
    }

    public void Finish() 
    {
        if (WasCompleted) { throw new InvalidOperationException("La sesión ya fue finalizada"); }

        FinishedAt = DateTime.UtcNow;
        WasCompleted = true;
    }

    public void Abandon() 
    {
        if (WasCompleted) { throw new InvalidOperationException("La sesión ya fue finalizada"); }
        
        FinishedAt = DateTime.UtcNow;
        WasCompleted = false;
    }

}
