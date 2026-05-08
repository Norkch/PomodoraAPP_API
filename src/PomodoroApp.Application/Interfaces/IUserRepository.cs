using PomodoroApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);
        Task AddAsync(User user, CancellationToken ct);
    }
}
