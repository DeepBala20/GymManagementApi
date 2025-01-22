using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class MemberShipValidation : AbstractValidator<MemberShipModel>
    {
        public MemberShipValidation() 
        {
            //RuleFor(r => r.MemberShipName);
            //RuleFor(r => r.MemberShipPrice);
            //RuleFor(r => r.MemberShipDuration);
            RuleFor(r => r.MemberShipName)
            .NotEmpty().WithMessage("Membership name is required.")
            .MaximumLength(100).WithMessage("Membership name must not exceed 100 characters.");

            RuleFor(r => r.MemberShipPrice)
                .NotEmpty().WithMessage("Membership price is required.")
                .GreaterThan(0).WithMessage("Membership price must be a positive number.");

            RuleFor(r => r.MemberShipDuration)
                .NotEmpty().WithMessage("Membership duration is required.")
                .GreaterThan(0).WithMessage("Membership duration must be a positive number.")
                .LessThanOrEqualTo(365).WithMessage("Membership duration must not exceed 365 days.");

        }

    }
}
