using System;

namespace Project_Console_Driver
{
    [Serializable]
    public class ConsoleConfiguration
    {
        public string FileName { get; set; }
        public string Args { get; set; }
        public string Title { get; set; }
        public bool SeeInput { get; set; }
    }
}