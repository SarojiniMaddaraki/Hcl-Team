using FluentValidation;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.PatientID).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GeneratedDate).NotEmpty();
        }
    }
}
