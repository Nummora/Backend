using FluentValidation;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Validators;

public class UserValidator : AbstractValidator<UserRegisterDto>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100);

        RuleFor(x => x.SecondName)
            .MaximumLength(100);

        RuleFor(x => x.FirstLastName)
            .MaximumLength(100);

        RuleFor(x => x.SecondLastName)
            .MaximumLength(100);

        RuleFor(x => x.Photo)
            .MaximumLength(255);

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.DocumentType)
            .IsInEnum().WithMessage("Invalid document type.");

        RuleFor(x => x.NumberDocument)
            .NotEmpty().WithMessage("Document number is required.")
            .MaximumLength(20);

        RuleFor(x => x.NumberPhone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{7,15}$").WithMessage("Invalid phone number format.");
    }
}