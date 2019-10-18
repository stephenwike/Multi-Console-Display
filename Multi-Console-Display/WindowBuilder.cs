using Multi_Console_Display.Models;
using Multi_Console_Display.ViewModels;

namespace Multi_Console_Display
{
    internal class WindowBuilder
    {
        private MainWindow _window;
        private DynamicGridConfig _config;

        public WindowBuilder()
        {
            _window = new MainWindow();
        }

        public WindowBuilder SetConfig(DynamicGridConfig config)
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