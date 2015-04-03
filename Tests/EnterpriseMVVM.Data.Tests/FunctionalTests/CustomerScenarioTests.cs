
namespace EnterpriseMVVM.Data.Tests.FunctionalTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomerScenarioTests : FunctionalTest
    {
        [TestMethod]
        public void AddNewCustomerIsPersisted()
        {
            using (var bc = new BusinessContext())
            {
                Customer entity = bc.AddNewCustomer("Andrew", "Jones");

                Assert.IsNotNull(entity);

                bool exists = bc.DataContext.Customers.Any(c => c.Id == entity.Id);
                Assert.IsTrue(exists);
            }
        }
    }
}
