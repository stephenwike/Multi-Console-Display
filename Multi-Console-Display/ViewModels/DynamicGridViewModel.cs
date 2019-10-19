using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using Multi_Console_Display.Models;
using Project_Console_Driver;

namespace Multi_Console_Display.ViewModels
{
    public class DynamicGridViewModel : BaseNotifyPropertyChanged, IDynamicGridViewModel
    {
        private ConsoleDriverConfiguration _consoleConfig;

        public DynamicGridViewModel()
        {
            // this.SetDefaultValues();
        }

        public DynamicGridViewModel(ConsoleDriverConfiguration config)
        {
            _consoleConfig = config;
        }

        #region Initialization and recreating

        /// <summary>
        /// Create 2-dimensional array of cells.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ObservableCollection<ICellViewModel>> CreateCells()
        {
            var cells = new ObservableCollection<ObservableCollection<ICellViewModel>>();
            for (var posRow = 0; posRow < GridHeight; posRow++)
            {
                var row = new ObservableCollection<ICellViewModel>();
                for (var posCol = 0; posCol < GridWidth; posCol++)
                {
                    var cellViewModel = new CellViewModel(_consoleConfig.ConsoleConfig[posRow, posCol]);
                    row.Add(cellViewModel);
                }
                cells.Add(row);
            }
            return cells;
        }

        #endregion

        #region IDynamicGridViewModel

        private ObservableCollection<ObservableCollection<ICellViewModel>> _cells;
        private int _gridWidth;
        private int _gridHeight;

        private Color _startColor;                  // = Colors.AliceBlue;
        private Color _finishColor;                 // = Colors.DarkBlue;
        private Color _borderColor;                 // = Colors.Gray;

        public ObservableCollection<ObservableCollection<ICellViewModel>> Cells
        {
            get { return _cells; }
            set
            {
                if (_cells != value)
                {
                    _cells = value;
                    OnPropertyChanged("Cells");
                }
            }
        }

        [DefaultValue(5)]
        public int GridWidth
        {
            get { return _gridWidth; }
            set
            {
                var oldValue = _gridWidth;
                _gridWidth = value;
                OnPropertyChanged("GridWidth");

                if (oldValue != value)
                    Cells = CreateCells();
            }
        }

        [DefaultValue(5)]
        public int GridHeight
        {
            get { return _gridHeight; }
            set
            {
                var oldValue = _gridHeight;
                _gridHeight = value;
                OnPropertyChanged("GridHeight");

                if (oldValue != value)
                    Cells = CreateCells();
            }
        }

        /// <summary>
        /// Start, the lighter, color of cells.
        /// </summary>
        [DefaultValue(typeof(Color), "#FFF0F8FF")]
        public Color StartColor
        {
            get { return _startColor; }
            set
            { 
                if (_startColor != value)
                {
                    _startColor = value;
                    OnPropertyChanged("StartColor");
                }
            }
        }

        /// <summary>
        /// Finish, the darker, color of cells.
        /// </summary>
        [DefaultValue(typeof(Color), "#FF00008B")]
        public Color FinishColor
        {
            get { return _finishColor; }
            set
            {
                if (_finishColor != value)
                {
                    _finishColor = value;
                    OnPropertyChanged("FinishColor");
                }
            }
        }

        /// <summary>
        /// Color of borders around cells.
        /// </summary>
        [DefaultValue(typeof(Color), "#FF808080")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    OnPropertyChanged("BorderColor");
                }
            }
        }

        #endregion
    }
}
