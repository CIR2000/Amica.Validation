using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(warehouse => warehouse.Name).NotEmpty();
        }
    }
}
