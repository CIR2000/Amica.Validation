using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class WarehouseValidation : BaseTestClass<Warehouse, WarehouseValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
    }
}
