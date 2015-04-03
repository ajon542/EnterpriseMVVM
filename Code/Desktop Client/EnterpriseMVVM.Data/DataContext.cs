namespace EnterpriseMVVM.Data
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext()
            : base("Default")
        {
            
        }
    }
}
