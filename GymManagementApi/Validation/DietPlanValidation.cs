using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class DietPlanValidation : AbstractValidator<DietPlanModel>
    {
        public DietPlanValidation() 
        {
            //RuleFor(r => r.DietType);
            //RuleFor(r => r.Sunday);
            //RuleFor(r => r.Monday);
            //RuleFor(r => r.Tuesday);
            //RuleFor(r => r.Wednesday);
            //RuleFor(r => r.Thursday);
            //RuleFor(r => r.Friday);
            //RuleFor(r => r.Saturday);
            RuleFor(r => r.DietType)
            .NotEmpty().WithMessage("Diet type is required.")
            .Must(type => new[] { "Vegetarian", "Non-Vegetarian", "Vegan", "Keto", "Paleo" }.Contains(type))
            .WithMessage("Diet type must be one of the following: Vegetarian, Non-Vegetarian, Vegan, Keto, or Paleo.");

            RuleFor(r => r.Sunday)
                .NotEmpty().WithMessage("Sunday diet plan is required.")
                .MaximumLength(500).WithMessage("Sunday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Monday)
                .NotEmpty().WithMessage("Monday diet plan is required.")
                .MaximumLength(500).WithMessage("Monday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Tuesday)
                .NotEmpty().WithMessage("Tuesday diet plan is required.")
                .MaximumLength(500).WithMessage("Tuesday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Wednesday)
                .NotEmpty().WithMessage("Wednesday diet plan is required.")
                .MaximumLength(500).WithMessage("Wednesday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Thursday)
                .NotEmpty().WithMessage("Thursday diet plan is required.")
                .MaximumLength(500).WithMessage("Thursday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Friday)
                .NotEmpty().WithMessage("Friday diet plan is required.")
                .MaximumLength(500).WithMessage("Friday diet plan must not exceed 500 characters.");

            RuleFor(r => r.Saturday)
                .NotEmpty().WithMessage("Saturday diet plan is required.")
                .MaximumLength(500).WithMessage("Saturday diet plan must not exceed 500 characters.");

        }
    }
}
