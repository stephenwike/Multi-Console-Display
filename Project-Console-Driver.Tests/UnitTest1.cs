using Xunit;

namespace Project_Console_Driver.Tests
{
    public class UnitTest1
    {
        /* 
         * 
         * 
         * 
         * 
         */


        [Fact]
        public void Test1()
        {
            var config = new ConsoleDriverConfiguration()
            {
                // Exe = "node.exe",
                // Args = "D://tutorials/RabbitMQ-Tutorials/src/1-hello-world/sender.js"
                Exe = "cmd.exe",
                Args = "/C echo Hello World!"
            };

            ConsoleDriver driver = new ConsoleDriver(config);
            var promise = driver.RunAsync();
        }
    }
}
