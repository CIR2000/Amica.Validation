using System.Collections.Generic;
using Amica.Models;
using Amica.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests
{
    [TestClass]
    public class ProductInventoryValidation : BaseTestClass<ProductInventory, ProductInventoryValidator>
    {
        [TestMethod]
        public void WarehouseIdIsRequired()
        {
            AssertRequired(x => x.WarehouseId);
        }
    }
}