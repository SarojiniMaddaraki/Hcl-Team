using FluentValidation;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Validators
{
    public class LabResultValidator : AbstractValidator<LabResult>
    {
        public LabResultValidator()
        {
            RuleFor(x => x.PatientID).GreaterThan(0);
            RuleFor(x => x.TestName).NotEmpty();
            RuleFor(x => x.TestDate).NotEmpty();
        }
    }
}
