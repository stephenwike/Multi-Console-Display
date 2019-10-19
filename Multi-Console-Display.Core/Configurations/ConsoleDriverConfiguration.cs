using System;

namespace Project_Console_Driver
{
    [Serializable]
    public class ConsoleDriverConfiguration
    {
        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
        public ConsoleConfiguration[,] ConsoleConfig { get; set; }
    }
}
