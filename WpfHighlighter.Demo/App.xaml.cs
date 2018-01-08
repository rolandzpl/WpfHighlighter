using System.Windows;
using WpfHighlighter.Demo.Presenters;

namespace WpfHighlighter.Demo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Window mainWindow = new MainWindow();
            SamplePresenter presenter = new SamplePresenter();
            mainWindow.DataContext = presenter.ViewModel;
            MainWindow.Show();
            MainWindow = mainWindow;
        }
    }
}
