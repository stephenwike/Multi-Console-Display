using Json.Net;
using Multi_Console_Display.ViewModels;
using Newtonsoft.Json;
using Project_Console_Driver;
using System.Windows;

namespace Multi_Console_Display
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void MultiConsoleDisplayAppStartUp(object sender, StartupEventArgs e)
        {
            //var config = JsonNet.Deserialize<ConsoleDriverConfiguration>(e.Args[0]);
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Arrays };
            var config = JsonConvert.DeserializeObject<ConsoleDriverConfiguration>(e.Args[0], settings);
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new DynamicGridViewModel(config);
            mainWindow.Show();
        }
    }
}
