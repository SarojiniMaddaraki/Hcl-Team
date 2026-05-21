using FluentValidation;
using PatientPortalAPI.DTOs;

namespace PatientPortalAPI.Validators
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.DOB).NotEmpty().WithMessage("DOB is required");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        }
    }
}
