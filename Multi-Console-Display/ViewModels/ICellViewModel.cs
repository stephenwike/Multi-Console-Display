using System.Windows.Input;
using Multi_Console_Display.Models;

namespace Multi_Console_Display.ViewModels
{
    public interface ICellViewModel
    {
        ICell Cell { get; set; }
        ICommand ChangeCellStateCommand { get; }
    }
}