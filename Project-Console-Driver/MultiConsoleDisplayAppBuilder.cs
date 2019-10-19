namespace Project_Console_Driver
{
    public class MultiConsoleDisplayAppBuilder
    {
        public MultiConsoleConfigurable DefineDimensions(int height, int width)
        {
            return new MultiConsoleConfigurable(height, width);
        }
    }

    public class MultiConsoleConfigurable
    {
        private ConsoleDriverConfiguration _consoleDriverConfig;

        public MultiConsoleConfigurable(int height, int width)
        {
            _consoleDriverConfig = new ConsoleDriverConfiguration()
            {
                GridHeight = height,
                GridWidth = width,
                ConsoleConfig = new ConsoleConfiguration[height, width]
            };
        }

        public MultiConsoleConfigurable AddConsole(int row, int col, ConsoleConfiguration config)
        {
            if (row > _consoleDriverConfig.GridHeight - 1 || row < 0) return null;
            if (col > _consoleDriverConfig.GridWidth - 1 || col < 0) return null;

            _consoleDriverConfig.ConsoleConfig[row, col] = config;

            return this;
        }

        public void Run()
        {
            ApplicationDriver driver = new ApplicationDriver(_consoleDriverConfig);
            driver.Initialize();
            driver.Start();
        }
    }
}
