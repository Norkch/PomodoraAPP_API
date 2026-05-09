using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Application.DTOs
{
    public record StartPomodoroRequest(Guid TaskId, string Type);
    public record PomodoroSessionResponse(Guid Id, DateTime StartedAt,string Type, bool WasCompleted);
}
