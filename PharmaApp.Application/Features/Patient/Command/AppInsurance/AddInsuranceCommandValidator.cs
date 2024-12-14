using FluentValidation;
using Microsoft.AspNetCore.Http;
using PharmaApp.Application.Features.Command.AddInsurance;
using System.Linq;

namespace PharmaApp.Application.Features.Command.Create;

public sealed class AddInsuranceCommandValidator : AbstractValidator<AddInsuranceCommand>
{
    public AddInsuranceCommandValidator()
    {
        // Validations for Insurance details
        RuleFor(x => x.PatientId)
            .GreaterThan(0).WithMessage("Patient name is required.");

        RuleFor(x => x.PolicyNumber)
            .NotEmpty().WithMessage("PolicyNumber is required.");

        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("CompanyName is required.");

    }
}