using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class ProductPriceValidator : AbstractValidator<ProductPrice>
    {
        public ProductPriceValidator()
        {
            RuleFor(x => x.PriceListId).NotEmpty();
            RuleFor(x => x.Discount).NotNull();
        }
    }
}
