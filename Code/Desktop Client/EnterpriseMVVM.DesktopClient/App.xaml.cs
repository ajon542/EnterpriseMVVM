namespace EnterpriseMVVM.DesktopClient
{
    using System.Windows;
    using EnterpriseMVVM.DesktopClient.Views;
    using EnterpriseMVVM.DesktopClient.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow
            {
                DataContext = new CustomerViewModel()
            };
            window.Show();
        }
    }
}
