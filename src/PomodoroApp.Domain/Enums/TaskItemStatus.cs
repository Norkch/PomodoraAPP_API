namespace PomodoroApp.Domain.Enums;

/// <summary>
/// Representa el estado del ciclo de vida de una tarea.
/// Los valores son strings en la DB (HasConversion<string>() en EF Core)
/// para facilitar queries manuales y migraciones legibles.</summary>
public enum TaskItemStatus
{
    /// Recién creada, aún no iniciada
    Pending,

    /// El usuario está trabajando activamente en ella (tiene pomodoros en progreso)
    InProgress,

    /// Todos los pomodoros fueron completados o el usuario la marcó como hecha
    Completed,

    /// El usuario decidió no completarla
    Cancelled
}