﻿using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Multi_Console_Display.ViewModels
{
    internal class DesignDynamicGridViewModel : IDynamicGridViewModel
    {
        public ObservableCollection<ObservableCollection<ICellViewModel>> Cells { get; } = null;
        public int GridWidth { get; } = 5;
        public int GridHeight { get; } = 5;
        public Color StartColor { get; set; } = Colors.AliceBlue;
        public Color FinishColor { get; set; } = Colors.DarkBlue;
        public Color BorderColor { get; set; } = Colors.DarkGray;

    }
}
