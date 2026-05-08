using System;
using System.Collections.Generic;
using System.Text;
using PomodoroApp.Domain.Entities;

namespace PomodoroApp.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetByUserAsync();
        Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken ct);
        Task AddAsync(TaskItem task, CancellationToken ct);
        Task UpdateAsync(TaskItem task, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}
