using System.Runtime.CompilerServices;

namespace EnterpriseMVVM.Data
{
    using System;

    public sealed class BusinessContext : IDisposable
    {
        private readonly DataContext context;
        private bool disposed;

        public DataContext DataContext
        {
            get { return context; }
        }

        public BusinessContext()
        {
            context = new DataContext();
        }

        public void AddNewCustomer(Customer customer)
        {
            Check.Require(customer.FirstName);
            Check.Require(customer.LastName);
            Check.Require(customer.Email);

            context.Customers.Add(customer);
            context.SaveChanges();
        }

        private static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Trim().Length == 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
            {
                return;
            }

            if (context != null)
            {
                context.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
