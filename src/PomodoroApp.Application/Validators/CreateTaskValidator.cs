using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PomodoroApp.Application.DTOs;

namespace PomodoroApp.Application.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskValidator() 
        {
            // Title: obligatorio, entre 3 y 200 chars
            RuleFor(x => x.Title).NotEmpty().WithMessage("El titulo es obligatorio").
                MinimumLength(3).WithMessage("El titulo debe tener al menos 3 caracteres").
                MaximumLength(500).WithMessage("El titulo no puede tener mas de 500 caracteres");

            // Description: opcional, pero si se envía no puede exceder 1000 chars
            RuleFor(x => x.Description)
                .MaximumLength(1000)
                    .WithMessage("La descripción no puede superar 1000 caracteres")
                .When(x => x.Description is not null);   // solo valida si no es null

            // EstimatedPomodoros: entre 1 y 20 (técnica Pomodoro estándar)
            RuleFor(x => x.EstimatedPomodoros)
                .InclusiveBetween(1, 20)
                    .WithMessage("Los pomodoros estimados deben estar entre 1 y 20");
        }
    }
}
