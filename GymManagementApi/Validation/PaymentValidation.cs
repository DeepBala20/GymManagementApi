using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class PaymentValidation : AbstractValidator<PaymentModel>
    {
        public PaymentValidation() 
        {
            //RuleFor(r => r.PaymentMethod);
            //RuleFor(r => r.PaymentDate);
            //RuleFor(r => r.MemberID);
            RuleFor(r => r.PaymentMethod)
            .NotEmpty().WithMessage("Payment method is required.")
            .WithMessage("Payment method must be one of the following: Cash, Card, or Online.");

            RuleFor(r => r.PaymentDate)
                .NotEmpty().WithMessage("Payment date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Payment date cannot be in the future.");

            RuleFor(r => r.MemberID)
                .NotEmpty().WithMessage("Member ID is required.")
                .GreaterThan(0).WithMessage("Member ID must be a positive number.");
        }
    }
}
