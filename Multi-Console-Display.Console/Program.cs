using Multi_Console_Display.Models;
using Multi_Console_Display.Views;
using Project_Console_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Console_Display.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiConsoleDisplayApp app = new MultiConsoleDisplayApp();

            var c_config = new CellConfig()
            {
                Title = "Echo Cmd",
                Args = "/c echo balkjaheflkjahrfgae",
                FileName = "cmd.exe"
            };

            var senderConfig = new CellConfig()
            {
                Title = "Demo-1 Sender",
                Args = "D:\\\\tutorials\\RabbitMQ-Tutorials\\src\\1-hello-world\\sender.js",
                FileName = "node.exe",
                SeeInput = true
            };

            var receiverConfig = new CellConfig()
            {
                Title = "Demo-1 Receiver",
                Args = "D:\\\\tutorials\\RabbitMQ-Tutorials\\src\\1-hello-world\\receiver.js",
                FileName = "node.exe",
                SeeInput = false
            };

            var cellConfig = new CellConfig[,]
            {
                {
                    senderConfig,
                    receiverConfig,
                    receiverConfig
                },
                {
                    senderConfig,
                    receiverConfig,
                    receiverConfig
                }
            };

            var config = new DynamicGridConfig()
            {
                // Exe = "node.exe",
                // Args = "D://tutorials/RabbitMQ-Tutorials/src/1-hello-world/sender.js"
                // Exe = "cmd.exe",
                // Args = "/C echo Hello World!"
                GridHeight = 2,
                GridWidth = 3,
                CellConfig = cellConfig
            };

            app.Start(config);
        }
    }
}
