using Multi_Console_Display.ViewModels;
using Project_Console_Driver;

namespace Multi_Console_Display
{
    internal class WindowBuilder
    {
        private MainWindow _window;
        private ConsoleDriverConfiguration _config;

        public WindowBuilder()
        {
            _window = new MainWindow();
        }

        public WindowBuilder SetConfig(ConsoleDriverConfiguration config)
        {
            _config = config;
            return this;
        }

        public MainWindow Build()
        {
            _window.DataContext = new DynamicGridViewModel(_config);
            return _window;
        }
    }
}