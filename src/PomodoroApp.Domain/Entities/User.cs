
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Build.Utilities;

namespace PomodoroApp.Domain.Entities;

public class User
{
    public Guid Id{ get; private set;}
    public string Email{get; private set;} = string.Empty;

    public string PasswordHash {get; private set;} = string.Empty;

    public string Name {get; private set;} = string.Empty;
    public DateTime CreatedAt {get; private set;}

    // IReadOnlyCollection expone las tareas sin permitir modificación externa
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    private readonly List<TaskItem> _tasks = [];

    private User(){}
    public static User Create(string email, string passwordHash, string name)
    {
         ArgumentException.ThrowIfNullOrWhiteSpace(email); 
         ArgumentException.ThrowIfNullOrWhiteSpace(name); 
         
         return new User 
         { 
            Id = Guid.NewGuid(), 
            Email = email.ToLowerInvariant().Trim(), 
            PasswordHash = passwordHash, 
            Name = name.Trim(), 
            CreatedAt = DateTime.UtcNow // siempre UTC en el servidor 
        };    
    }
}