using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentStatusValidator : AbstractValidator<Status>
    {
		public DocumentStatusValidator()
        {
            RuleFor(status => status.Code).NotEmpty();
            RuleFor(status => status.Description).NotEmpty();
        }
    }
}
