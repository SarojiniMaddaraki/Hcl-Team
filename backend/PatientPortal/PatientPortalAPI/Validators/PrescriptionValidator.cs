using FluentValidation;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Validators
{
    public class PrescriptionValidator : AbstractValidator<Prescription>
    {
        public PrescriptionValidator()
        {
            RuleFor(x => x.RecordID).GreaterThan(0);
            RuleFor(x => x.Medicine).NotEmpty();
            RuleFor(x => x.Dosage).NotEmpty();
        }
    }
}
