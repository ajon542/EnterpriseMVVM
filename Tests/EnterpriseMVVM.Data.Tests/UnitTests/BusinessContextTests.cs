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
                var customer = new Customer
                {
                    Email = "ajon542@gmail.com",
                    FirstName = null,
                    LastName = "Jones"
                };

                bc.AddNewCustomer(customer);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewCustomer_ThrowsException_WhenFirstNameIsEmpty()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "ajon542@gmail.com",
                    FirstName = "",
                    LastName = "Jones"
                };
                bc.AddNewCustomer(customer);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewCustomer_ThrowsException_WhenLastNameIsNull()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "ajon542@gmail.com",
                    FirstName = "Andrew",
                    LastName = null
                };
                bc.AddNewCustomer(customer);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewCustomer_ThrowsException_WhenLastNameIsEmpty()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "ajon542@gmail.com",
                    FirstName = "Andrew",
                    LastName = ""
                };
                bc.AddNewCustomer(customer);
            }
        }
    }
}
