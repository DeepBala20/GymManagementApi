using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class EquipmentValidation : AbstractValidator<EquipmentModel>
    {
        public EquipmentValidation() 
        {
            //RuleFor(r => r.EquipmentName);
            //RuleFor(r => r.EquipmentImage);
            //RuleFor(r => r.EquipmentPrice);
            //RuleFor(r => r.EquipmentPurchaseDate);
            //RuleFor(r => r.EquipmentWarranty);
            RuleFor(r => r.EquipmentName)
            .NotEmpty().WithMessage("Equipment name is required.")
            .MaximumLength(100).WithMessage("Equipment name must not exceed 100 characters.");

            RuleFor(r => r.EquipmentImage)
                .NotEmpty().WithMessage("Equipment image is required.");

            RuleFor(r => r.EquipmentPrice)
                .NotEmpty().WithMessage("Equipment price is required.")
                .GreaterThan(0).WithMessage("Equipment price must be a positive number.");

            RuleFor(r => r.EquipmentPurchaseDate)
                .NotEmpty().WithMessage("Equipment purchase date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Equipment purchase date cannot be in the future.");

            RuleFor(r => r.EquipmentWarranty)
                .GreaterThanOrEqualTo(0).WithMessage("Equipment warranty must be a positive number or zero.")
                .LessThanOrEqualTo(120).WithMessage("Equipment warranty must not exceed 120 months (10 years).");

        }

    }
}
