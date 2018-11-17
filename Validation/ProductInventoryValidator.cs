using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class ProductInventoryValidator : AbstractValidator<ProductInventory>
    {
        public ProductInventoryValidator()
        {
            RuleFor(x => x.WarehouseId).NotEmpty();
        }
    }
}