namespace EnterpriseMVVM.DesktopClient.Tests.UnitTests
{
    using ViewModels;
    using Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomerViewModelTests
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(CustomerViewModel).BaseType == typeof(ViewModel));
        }

        [TestMethod]
        public void ValidationErrorWhenCustomerNameExceeds32Characters()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerName = "1234567890123456789 012345678901234567890"
            };

            Assert.IsNotNull(viewModel["CustomerName"]);
        }

        [TestMethod]
        public void ValidationErrorWhenCustomerIsNotGreaterThanOrEqualTo2Characters()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerName = "B"
            };

            Assert.IsNotNull(viewModel["CustomerName"]);
        }
    }
}
