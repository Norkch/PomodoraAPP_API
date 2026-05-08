using PomodoroApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Application.Interfaces
{
    public interface IPomodoroRepository
    {
        Task<PomodoroSession?> GetActiveSessinAsync(Guid userId, CancellationToken ct);
        Task AddAsync(PomodoroSession session, CancellationToken ct);
        Task<IEnumerable<PomodoroSession>> GetByTaskAsync(Guid taskId, CancellationToken ct);
    }
}
