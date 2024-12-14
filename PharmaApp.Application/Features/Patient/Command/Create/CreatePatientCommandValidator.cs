using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PharmaApp.Application.Features.Command.Create;

public sealed class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        // Validations for Patient details
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d+$").WithMessage("Phone number must contain only digits.")
            .Length(10, 15).WithMessage("Phone number must be between 10 and 15 digits.");

       
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
            .Matches(@"^[a-zA-Z0-9\s,.\-]+$").WithMessage("Address can only contain alphanumeric characters, spaces, commas, periods, and hyphens.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required.")
            .Length(2, 50).WithMessage("State must be between 2 and 50 characters.")
            .Matches(@"^[a-zA-Z\s\-]+$").WithMessage("State can only contain letters, spaces, or hyphens.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .Length(1, 50).WithMessage("City must be between 1 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9\s\-]+$").WithMessage("City can only contain letters, numbers, spaces, or hyphens.");

    }
}