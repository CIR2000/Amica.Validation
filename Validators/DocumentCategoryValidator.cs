using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentCategoryValidator : AbstractValidator<Category>
    {
		public DocumentCategoryValidator()
        {
            RuleFor(status => status.Code).NotEmpty();
            RuleFor(status => status.Description).NotEmpty();
        }
    }
}
