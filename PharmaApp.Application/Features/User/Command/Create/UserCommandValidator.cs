using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PharmaApp.Application.Features.Command.Create;

public sealed class UserCommandValidator : AbstractValidator<UserCommand>
{
    public UserCommandValidator()
    {
        // Validations for UserDetail
        RuleFor(x => x.UserDetail.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.")
            .Matches(@"^[a-zA-Z\s\-]+$").WithMessage("First name can only contain letters, spaces, or hyphens.");

        RuleFor(x => x.UserDetail.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.")
            .Matches(@"^[a-zA-Z\s\-]+$").WithMessage("Last name can only contain letters, spaces, or hyphens.");

        RuleFor(x => x.UserDetail.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.UserDetail.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d+$").WithMessage("Phone number must contain only digits.")
            .Length(10, 15).WithMessage("Phone number must be between 10 and 15 digits.");

        RuleFor(x => x.UserDetail.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .Length(1, 50).WithMessage("Company name must be between 1 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9\s\-]+$").WithMessage("Company name can only contain letters, numbers, spaces, or hyphens.");

        RuleFor(x => x.UserDetail.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
            .Matches(@"^[a-zA-Z0-9\s,.\-]+$").WithMessage("Address can only contain alphanumeric characters, spaces, commas, periods, and hyphens.");

        RuleFor(x => x.UserDetail.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .Matches(@"^\d{5}$").WithMessage("Postal code must be exactly 5 digits.");

        RuleFor(x => x.UserDetail.State)
            .NotEmpty().WithMessage("State is required.")
            .Length(2, 50).WithMessage("State must be between 2 and 50 characters.")
            .Matches(@"^[a-zA-Z\s\-]+$").WithMessage("State can only contain letters, spaces, or hyphens.");

        RuleFor(x => x.UserDetail.City)
            .NotEmpty().WithMessage("City is required.")
            .Length(1, 50).WithMessage("City must be between 1 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9\s\-]+$").WithMessage("City can only contain letters, numbers, spaces, or hyphens.");

        RuleFor(x => x.UserDetail.Fax)
            .Matches(@"^\d{10}$").When(x => !string.IsNullOrEmpty(x.UserDetail.Fax))
            .WithMessage("Fax must be exactly 10 digits.");

        RuleFor(x => x.UserDetail.Logo)
            .Must(BeAValidImage)
            .When(x => x.UserDetail.Logo != null)
            .WithMessage("Logo must be a valid image file (e.g., .jpg, .png) and under the allowed size.");

        // Carrier Specific Validations (if Carrier is provided)
        //When(x => x.Carrier != null, () =>
        //{
        //    RuleFor(x => x.Carrier.CarrierId)
        //        .GreaterThan(0).WithMessage("CarrierId must be a positive integer.");

        //    RuleForEach(x => x.Carrier.EquipmentTypes)
        //        .ChildRules(equipment =>
        //        {
        //            equipment.RuleFor(e => e.Id)
        //                .GreaterThan(0).WithMessage("Equipment type Id must be a positive integer.");
        //            equipment.RuleFor(e => e.Name)
        //                .NotEmpty().WithMessage("Equipment type name is required.");
        //        });

        //    RuleForEach(x => x.Carrier.LanePreferences)
        //        .ChildRules(lane =>
        //        {
        //            lane.RuleFor(l => l.PickupLocation)
        //                .NotEmpty().WithMessage("Pickup location is required.");
        //            lane.RuleFor(l => l.DropLocation)
        //                .NotEmpty().WithMessage("Drop location is required.");
        //        });

        //    RuleForEach(x => x.Carrier.InsuranceDocuments)
        //        .ChildRules(doc =>
        //        {
        //            doc.RuleFor(d => d.File)
        //                .NotNull().WithMessage("Insurance document file is required.");
        //            doc.RuleFor(d => d.Name)
        //                .NotEmpty().WithMessage("Insurance document name is required.");
        //        });

        //    RuleForEach(x => x.Carrier.Signatures)
        //        .ChildRules(signature =>
        //        {
        //            signature.RuleFor(s => s.File)
        //                .NotNull().WithMessage("Signature file is required.");
        //            signature.RuleFor(s => s.Name)
        //                .NotEmpty().WithMessage("Signature name is required.");
        //        });
        //});
    }

    private bool BeAValidImage(IFormFile file)
    {
        // Allowed file types
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var maxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB

        if (file == null || file.Length == 0)
            return false;

        // Check file size
        if (file.Length > maxFileSizeInBytes)
            return false;

        // Check file extension
        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!allowedExtensions.Contains(extension))
            return false;

        return true;
    }
}