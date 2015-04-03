namespace EnterpriseMVVM.Data.Tests.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BusinessContextTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewCustomer_ThrowsException_WhenFirstNameIsNull()
        {
            using (var bc = new BusinessContext())
            {
                bc.AddNewCustomer(null, "Jones");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewCustomer_ThrowsException_WhenFirstNameIsEmpty()
        {
            using (var bc = new BusinessContext())
            {
                bc.AddNewCustomer("", "Jones");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewCustomer_ThrowsException_WhenLastNameIsNull()
        {
            using (var bc = new BusinessContext())
            {
                bc.AddNewCustomer("Andrew", null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewCustomer_ThrowsException_WhenLastNameIsEmpty()
        {
            using (var bc = new BusinessContext())
            {
                bc.AddNewCustomer("Andrew", "");
            }
        }
    }
}
