using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class JoiningReasonValidation : AbstractValidator<JoiningReasonModel>
    {
        public JoiningReasonValidation() 
        {
            //RuleFor(r => r.DietPlanID);
            //RuleFor(r => r.DietType);
            //RuleFor(r => r.JoiningReason);
            RuleFor(r => r.DietPlanID)
            .NotEmpty().WithMessage("Diet Plan ID is required.")
            .GreaterThan(0).WithMessage("Diet Plan ID must be a positive number.");

            //RuleFor(r => r.DietType)
            //    .NotEmpty().WithMessage("Diet type is required.")
            //    .Must(type => new[] { "Vegetarian", "Non-Vegetarian", "Vegan", "Keto", "Paleo" }.Contains(type))
            //    .WithMessage("Diet type must be one of the following: Vegetarian, Non-Vegetarian, Vegan, Keto, or Paleo.");

            RuleFor(r => r.JoiningReason)
                .NotEmpty().WithMessage("Joining reason is required.")
                .MaximumLength(200).WithMessage("Joining reason must not exceed 200 characters.");

        }
    }
}
