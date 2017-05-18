using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class WarehouseValidator : AbstractValidator<Warehouse>
    {
		public WarehouseValidator()
        {
            RuleFor(warehouse => warehouse.Name).NotEmpty();
        }
    }
}
