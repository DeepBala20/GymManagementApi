using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class MemberValidation : AbstractValidator<MemberModel>
    {
        public MemberValidation() 
        {
            Console.WriteLine("validation called..........");
            //RuleFor(r => r.MemberName);
            //RuleFor(r => r.MemberMobile);
            //RuleFor(r => r.MemberEmail);
            //RuleFor(r => r.MemberAge);
            //RuleFor(r => r.MemberWeight);
            //RuleFor(r => r.MemberHeight);
            //RuleFor(r => r.MemberBMI);
            //RuleFor(r => r.JoiningDate);
            //RuleFor(r => r.JoiningReasonID);
            //RuleFor(r => r.GymShift);
            //RuleFor(r => r.MemberShipID);
            //RuleFor(r => r.TrainerID);
            //RuleFor(r => r.IsAdmin);
            //RuleFor(r => r.username);
            //RuleFor(r => r.password);
            RuleFor(r => r.MemberName)
            .NotEmpty().WithMessage("Member name is required.");

            RuleFor(r => r.MemberMobile)
                .NotEmpty().WithMessage("Member mobile number is required.")
                .Matches(@"^\d{10}$").WithMessage("Member mobile number must be a valid 10-digit number.");

            RuleFor(r => r.MemberEmail)
                .NotEmpty().WithMessage("Member email is required.")
                .EmailAddress().WithMessage("Member email must be a valid email address.");

            RuleFor(r => r.MemberAge)
                .InclusiveBetween(16, 100).WithMessage("Member age must be between 16 and 100.");

            RuleFor(r => r.MemberWeight)
                .GreaterThan(20).WithMessage("Member weight must be greater than 20 kg.");

            RuleFor(r => r.MemberHeight)
                .GreaterThan(100).WithMessage("Member height must be greater than 100 cm.");

            RuleFor(r => r.MemberBMI)
                .NotEmpty().WithMessage("Member Bmi is required.");

            RuleFor(r => r.JoiningDate)
                .NotEmpty().WithMessage("Joining date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Joining date cannot be in the future.");

            RuleFor(r => r.JoiningReasonID)
                .NotEmpty().WithMessage("Joining reason is required.")
                .GreaterThan(0).WithMessage("Joining reason ID must be a positive number.");

            RuleFor(r => r.GymShift)
                .NotEmpty().WithMessage("Gym shift is required.");

            RuleFor(r => r.MemberShipID)
                .NotEmpty().WithMessage("Membership ID is required.")
                .GreaterThan(0).WithMessage("Membership ID must be a positive number.");

            RuleFor(r => r.TrainerID)
                .NotEmpty().WithMessage("Trainer ID is required.")
                .GreaterThan(0).WithMessage("Trainer ID must be a positive number.");

            RuleFor(r => r.IsAdmin)
                .NotNull().WithMessage("Admin status is required.");

            RuleFor(r => r.username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

            RuleFor(r => r.password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            //RuleFor(r => r.password)
            //    .NotEmpty().WithMessage("Password is required.")
            //    .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            //    .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            //    .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            //    .Matches(@"\d").WithMessage("Password must contain at least one number.")
            //    .Matches(@"[\@\!\#\$\%\^\&\*\(\)\_\+\-]").WithMessage("Password must contain at least one special character.");

        }
    }
}
