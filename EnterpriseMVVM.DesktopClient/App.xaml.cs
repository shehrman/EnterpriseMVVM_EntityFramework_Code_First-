using EnterpriseMVVM.DesktopClient.ViewModels;
using EnterpriseMVVM.DesktopClient.Views;
using System.Windows;

namespace EnterpriseMVVM.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
            {
                DataContext = new CustomerViewModel()
            };

            window.ShowDialog();
        }
    }
}
