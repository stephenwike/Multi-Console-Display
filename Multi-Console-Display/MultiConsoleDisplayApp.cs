using Project_Console_Driver;
using System;
using System.Threading;

namespace Multi_Console_Display
{
    public class MultiConsoleDisplayApp
    {
        private ConsoleDriverConfiguration _config;

        public void Start(ConsoleDriverConfiguration config)
        {
            _config = config;
            var thread = new Thread(new ThreadStart(DisplayFormThread));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            // thread.Join();
        }

        private void DisplayFormThread()
        {
            try
            {
                WindowBuilder builder = new WindowBuilder();
                var mainWindow = builder.SetConfig(_config).Build();
                mainWindow.Show();
                mainWindow.Closed += (s, e) => System.Windows.Threading.Dispatcher.ExitAllFrames();

                System.Windows.Threading.Dispatcher.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
