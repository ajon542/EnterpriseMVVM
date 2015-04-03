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

        public Customer AddNewCustomer(string firstName, string lastName)
        {
            #region Validation

            if (firstName == null)
            {
                throw new ArgumentNullException("firstName", "firstName should not be null");
            }

            if (lastName == null)
            {
                throw new ArgumentNullException("lastName", "lastName should not be null");
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("firstName should not be empty");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("lastName should not be empty");
            }

            #endregion

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
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
