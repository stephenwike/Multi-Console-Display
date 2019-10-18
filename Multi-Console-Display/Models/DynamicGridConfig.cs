namespace Multi_Console_Display.Models
{
    public class DynamicGridConfig
    {
        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
        public CellConfig[,] CellConfig { get; set; }
    }
}
