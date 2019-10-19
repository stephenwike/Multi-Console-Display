using Project_Console_Driver;

namespace Multi_Console_Display.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var c_config = new CellConfig()
            //{
            //    Title = "Echo Cmd",
            //    Args = "/c echo balkjaheflkjahrfgae",
            //    FileName = "cmd.exe"
            //};

            //var senderConfig = new CellConfig()
            //{
            //    Title = "Demo-1 Sender",
            //    Args = "D:\\\\tutorials\\RabbitMQ-Tutorials\\src\\1-hello-world\\sender.js",
            //    FileName = "node.exe",
            //    SeeInput = true
            //};

            //var receiverConfig = new CellConfig()
            //{
            //    Title = "Demo-1 Receiver",
            //    Args = "D:\\\\tutorials\\RabbitMQ-Tutorials\\src\\1-hello-world\\receiver.js",
            //    FileName = "node.exe",
            //    SeeInput = false
            //};

            var senderConfig = new ConsoleConfiguration()
            {
                Title = "NServiceBus Client",
                Args = "C:\\\\Dev\\POC.NServiceBus\\src\\POC.NServiceBus.Client\\bin\\Debug\\netcoreapp2.2\\POC.NServiceBus.Client.dll",
                FileName = "dotnet.exe",
                SeeInput = true
            };

            var receiverConfig = new ConsoleConfiguration()
            {
                Title = "NServiceBus ServiceA",
                Args = "C:\\\\Dev\\POC.NServiceBus\\src\\POC.NServiceBus.ServiceA\\bin\\Debug\\netcoreapp2.2\\POC.NServiceBus.ServiceA.dll",
                FileName = "dotnet.exe",
                SeeInput = false
            };

            new MultiConsoleDisplayAppBuilder()
                .DefineDimensions(
                    height: 1,
                    width: 2)
                .AddConsole(
                    row: 0,
                    col: 0,
                    config: senderConfig)
                .AddConsole(
                    row: 0,
                    col: 1,
                    config: receiverConfig)
                .Run();
        }
    }
}
