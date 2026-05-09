using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PomodoroApp.Application.DTOs
{
    public record CreateTaskRequest(string Title, string? Description, int EstimatedPomodoros);
    public record UpdateTaskRequest(string? Title, string? Description, int? EstimatedPomodoros);
    public record TaskResponse(Guid Id, string Title, string? Description, string Status, int EstimatedPomodoros, int CompletedPomodoros, DateTime CreatedAt, DateTime? CompletedAt);

}
