using PomodoroApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
