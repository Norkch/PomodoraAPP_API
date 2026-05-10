using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PomodoroApp.Application.DTOs;

namespace PomodoroApp.Application.Validators
{
    public class StartPomodoroValidator :  AbstractValidator<StartPomodoroRequest>
    {
        
        public StartPomodoroValidator() 
        {
            RuleFor(x => x.TaskId)
                .NotEmpty().WithMessage("El Id de la tarea es obligatorio");
            
            // Valores válidos del enum SessionType como strings
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("El tipo de sesión es obligatorio")
                .Must(type => Enum.TryParse<SessionType>(type, true, out _))
                .WithMessage("Tipo de sesión inválido." + $"{string.Join(", ", Enum.GetNames<SessionType>())}");
        }

    }
}
