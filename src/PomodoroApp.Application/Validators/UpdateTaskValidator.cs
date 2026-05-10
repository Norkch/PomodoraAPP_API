using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PomodoroApp.Application.DTOs;
namespace PomodoroApp.Application.Validators
{
    public class UpdateTaskValidator: AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskValidator()
        {
            // Si Title viene, debe cumplir las mismas reglas que al crear
            RuleFor(x => x.Title)
                .MinimumLength(3).WithMessage("Mínimo 3 caracteres")
                .MaximumLength(500).WithMessage("Máximo 500 caracteres")
                .When(x => x.Title is not null);           // solo si fue enviado

            // Si Description viene, validar largo
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Máximo 1000 caracteres")
                .When(x => x.Description is not null);

            // Si EstimatedPomodoros viene, validar rango
            RuleFor(x => x.EstimatedPomodoros)
                .InclusiveBetween(1, 20).WithMessage("Entre 1 y 20 pomodoros")
                .When(x => x.EstimatedPomodoros.HasValue); // solo si no es null
        }
    }
}
