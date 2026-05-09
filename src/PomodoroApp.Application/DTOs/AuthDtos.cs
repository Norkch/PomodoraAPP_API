using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Application.DTOs
{
    public record RegisterRequest(string Email, string Password, string Name);
    public record LoginRequest(string Email, string Password, string Name);
    public record AuthResponse(string Token, string Email,string Name);


}
