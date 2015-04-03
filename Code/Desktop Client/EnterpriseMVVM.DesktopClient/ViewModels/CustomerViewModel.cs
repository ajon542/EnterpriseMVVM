namespace EnterpriseMVVM.DesktopClient.ViewModels
{
    using EnterpriseMVVM.Windows;
    using System.ComponentModel.DataAnnotations;

    public class CustomerViewModel : ViewModel
    {
        private string customerName;

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                NotifyPropertyChanged();
            }
        }

        protected override string OnValidate(string propertyName)
        {
            if (CustomerName != null && !CustomerName.Contains(" "))
            {
                return "Customer name must include both a first and last name.";
            }

            return base.OnValidate(propertyName);
        }
    }
}
