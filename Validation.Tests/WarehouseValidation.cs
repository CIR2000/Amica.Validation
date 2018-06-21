using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class WarehouseValidation : BaseTestClass<Warehouse, WarehouseValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
    }
}
