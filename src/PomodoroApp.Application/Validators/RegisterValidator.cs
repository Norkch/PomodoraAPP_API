using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PomodoroApp.Application.DTOs;
namespace PomodoroApp.Application.Validators
{
    public class RegisterValidator :  AbstractValidator<RegisterRequest>
    {
        public RegisterValidator() 
        {
            // Email: obligatorio, formato válido, máximo 256 chars
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no es válido")
                .MaximumLength(256).WithMessage("Email demasiado largo");
            
            // Password: política de contraseñas
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(8).WithMessage("Minimo 8 caracteres")
                .Matches(@"[A-Z]").WithMessage("Debe contener al menos una letra mayúscula")
                .Matches(@"[0-9]").WithMessage("Debe contener al menos un número")
                .Matches(@"[^a-zA-Z0-9]").WithMessage("Debe contener al menos un caracter especial");

            // Name: no vacío, tamaño razonable
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Nombre demasiado largo");
        }
    }
}
