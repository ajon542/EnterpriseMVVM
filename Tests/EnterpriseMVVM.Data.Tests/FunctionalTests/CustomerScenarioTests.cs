
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
                var customer = new Customer
                {
                    Email = "ajon542@gmail.com",
                    FirstName = "Andrew",
                    LastName = "Jones"
                };

                bc.AddNewCustomer(customer);

                bool exists = bc.DataContext.Customers.Any(c => c.Id == customer.Id);
                Assert.IsTrue(exists);
            }
        }
    }
}
