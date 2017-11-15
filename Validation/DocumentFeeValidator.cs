using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentFeeValidator : AbstractValidator<DocumentFee>
    {
		public DocumentFeeValidator()
        {
            RuleFor(fee => fee.Name).NotEmpty();
            RuleFor(fee => fee.Vat).SetValidator(new VatValidator());
            RuleFor(fee => fee.Amount).NotEqual(0);
        }
    }
}
