using Multi_Console_Display.ViewModels;

namespace Multi_Console_Display.Models
{
    public interface ICell
    {
        /// <summary>
		/// State of the cell.
		/// </summary>
		bool State { get; set; }
    }
}