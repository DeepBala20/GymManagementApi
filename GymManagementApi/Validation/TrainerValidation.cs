using FluentValidation;
using GymManagementApi.Model;

namespace GymManagementApi.Validation
{
    public class TrainerValidation : AbstractValidator<TrainerModel>
    {
        public TrainerValidation() 
        {
            //RuleFor(r => r.TrainerName);
            //RuleFor(r => r.TrainerMobile);
            //RuleFor(r => r.TrainerEmail);
            //RuleFor(r => r.TrainerAge);
            //RuleFor(r => r.TrainerWeight);
            //RuleFor(r => r.TrainerHeight);
            //RuleFor(r => r.JoiningDate);
            //RuleFor(r => r.Experience);
            //RuleFor(r => r.Salary);
            //RuleFor(r => r.GymShift);
            //RuleFor(r => r.username);
            //RuleFor(r => r.password);
            RuleFor(r => r.TrainerName)
            .NotEmpty().WithMessage("Trainer name is required.")
            .MaximumLength(50).WithMessage("Trainer name must not exceed 50 characters.");

            RuleFor(r => r.TrainerImage)
                .NotEmpty().WithMessage("Equipment image is required.");

            RuleFor(r => r.TrainerMobile)
                .NotEmpty().WithMessage("Trainer mobile number is required.")
                .Matches(@"^\d{10}$").WithMessage("Trainer mobile number must be a valid 10-digit number.");

            RuleFor(r => r.TrainerEmail)
                .NotEmpty().WithMessage("Trainer email is required.")
                .EmailAddress().WithMessage("Trainer email must be a valid email address.");

            RuleFor(r => r.TrainerAge)
                .InclusiveBetween(18, 65).WithMessage("Trainer age must be between 18 and 65.");

            RuleFor(r => r.TrainerWeight)
                .GreaterThan(30).WithMessage("Trainer weight must be greater than 30 kg.");

            RuleFor(r => r.TrainerHeight)
                .GreaterThan(100).WithMessage("Trainer height must be greater than 100 cm.");

            RuleFor(r => r.JoiningDate)
                .NotEmpty().WithMessage("Joining date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Joining date cannot be in the future.");

            RuleFor(r => r.Experience)
                .GreaterThanOrEqualTo(0).WithMessage("Experience must be 0 or more.")
                .LessThanOrEqualTo(50).WithMessage("Experience cannot exceed 50 years.");

            RuleFor(r => r.Salary)
                .GreaterThan(0).WithMessage("Salary must be a positive value.");

            RuleFor(r => r.GymShift)
                .NotEmpty().WithMessage("Gym shift is required.");

            RuleFor(r => r.username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

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
