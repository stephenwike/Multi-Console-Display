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
            var config = new ConsoleConfiguration()
            {
                FileName = "cmd.exe",
                Args = "/C echo Hello World!"
            };

            ConsoleDriver driver = new ConsoleDriver(config);
            var promise = driver.RunAsync();
        }
    }
}
