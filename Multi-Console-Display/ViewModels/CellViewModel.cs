using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Multi_Console_Display.Models;
using Project_Console_Driver;

namespace Multi_Console_Display.ViewModels
{
    public class CellViewModel : BaseNotifyPropertyChanged, ICellViewModel
    {
        private ConsoleInputWriter _writer;
        private string _cellTitle;
        private string _cellInput = "";
        private string _cellText;
        private List<string> _commandsList = new List<string>();
        private int _commandsListIndex = 0;
        private bool _seeInput = false;

        public CellViewModel(ICell cell = null)
        {
            ChangeCellStateCommand = new DelegateCommand(ChangeCellState, CanChangeCellState);
            if (cell != null)
            {
                Cell = cell;
            }
        }

        private ICommand _enterKeyCommand;
        public ICommand EnterKeyCommand
        {
            get
            {
                if (_enterKeyCommand == null)
                {
                    _enterKeyCommand = new DelegateCommand((obj) =>
                    {
                        _writer.WriteLine(_cellInput);
                        _commandsList.Add(_cellInput);
                        _commandsListIndex = _commandsList.Count;

                        if (_seeInput)
                        {
                            CellTextBox = string.Concat("> ", _cellInput);
                        }

                        CellInput = "";
                    });
                }
                return _enterKeyCommand;
            }
        }

        private ICommand _upKeyCommand;
        public ICommand UpKeyCommand
        {
            get
            {
                if (_upKeyCommand == null)
                {
                    _upKeyCommand = new DelegateCommand((obj) =>
                    {
                        if (0 <= _commandsListIndex - 1)
                        {
                            CellInput = _commandsList[--_commandsListIndex];
                        }
                    });
                }
                return _upKeyCommand;
            }
        }

        private ICommand _downKeyCommand;
        public ICommand DownKeyCommand
        {
            get
            {
                if (_downKeyCommand == null)
                {
                    _downKeyCommand = new DelegateCommand((obj) =>
                    {
                        if (_commandsList.Count > _commandsListIndex + 1)
                        {
                            CellInput = _commandsList[++_commandsListIndex];
                        }
                        else
                        {
                            _commandsListIndex = _commandsList.Count;
                            CellInput = "";
                        }
                    });
                }
                return _downKeyCommand;
            }
        }

        public CellViewModel(ConsoleConfiguration config)
        {
            _cellTitle = config.Title;

            ConsoleDriver driver = new ConsoleDriver(config);

            driver.OutputData((sender, args) =>
            {
                CellTextBox = args.Data;
            });

            if (config.SeeInput)
            {
                _writer = driver.InputData();
            }

            _seeInput = config.SeeInput;

            var promise = driver.RunAsync();
        }

        #region Cell model

        private ICell _cell;

        public ICell Cell
        {
            get { return _cell; }
            set
            {
                if (value != _cell)
                {
                    _cell = value;
                    OnPropertyChanged("Cell");
                }
            }
        }

        [DefaultValue("")]
        public string CellTextBox
        {
            get { return _cellText; }
            set
            {
                if (value != null)
                {
                    var val = _cellText += string.Concat(value, Environment.NewLine);
                    _cellText = val;
                    OnPropertyChanged("CellTextBox");
                }
            }
        }

        [DefaultValue("Console")]
        public string CellTitle
        {
            get { return _cellTitle; }
            set { _cellTitle = value; }
        }

        [DefaultValue("")]
        public string CellInput
        {
            get { return _cellInput; }
            set
            {
                if (value != _cellInput)
                {
                    _cellInput = value;
                    OnPropertyChanged("CellInput");
                }
            }
        }

        public bool HasInputEvent
        {
            get { return _writer != null; }
        }

        public Visibility IsVisible
        {
            get { return (HasInputEvent) ? Visibility.Visible : Visibility.Collapsed; }
        }
        #endregion Cell model

        #region Commands

        public ICommand ChangeCellStateCommand { get; }

        private void ChangeCellState(object obj)
        {
            if (Cell != null)
                Cell.State = !Cell.State;
        }

        private static bool CanChangeCellState(object obj)
        {
            return true;
        }
        #endregion

        public Brush BackgroundColor { get; set; } = Brushes.Black;
        public Brush TitleBackgroundColor { get; set; } = Brushes.White;
        public Brush FontColor { get; set; } = new SolidColorBrush(Color.FromArgb(255, (byte)192, (byte)192, (byte)192));
        public FontFamily TitleFontFamily { get; set; } = new FontFamily("Times New Roman");
        public FontFamily TextFontFamily { get; set; } = new FontFamily("Aharoni");
    }
}