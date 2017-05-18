using Amica.Models;
using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentNumberValidator : AbstractValidator<DocumentNumber>
    {
		public DocumentNumberValidator()
        {
            RuleFor(number => number.Numeric).NotEmpty();
        }

    }
}
