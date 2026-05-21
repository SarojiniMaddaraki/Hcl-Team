using FluentValidation;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Validators
{
    public class VitalsValidator : AbstractValidator<Vitals>
    {
        public VitalsValidator()
        {
            RuleFor(x => x.PatientID).GreaterThan(0);
            RuleFor(x => x.BP).NotEmpty();
            RuleFor(x => x.Temperature).GreaterThan(0);
        }
    }
}
