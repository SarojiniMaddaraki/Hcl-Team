using FluentValidation;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Validators
{
    public class MedicalRecordValidator : AbstractValidator<MedicalRecord>
    {
        public MedicalRecordValidator()
        {
            RuleFor(x => x.PatientID).GreaterThan(0);
            RuleFor(x => x.Diagnosis).NotEmpty();
            RuleFor(x => x.VisitDate).NotEmpty();
        }
    }
}
