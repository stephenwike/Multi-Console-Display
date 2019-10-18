using System.ComponentModel;
using Multi_Console_Display.ViewModels;

namespace Multi_Console_Display.Models
{
    public class Cell : BaseNotifyPropertyChanged, ICell
    {
        public Cell()
        {
            // this.SetDefaultValues();
        }

        #region Implementation ICell

        private bool _state;

        [DefaultValue(false)]
        public bool State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        #endregion

        public static ICell Empty => new Cell();
    }
}
