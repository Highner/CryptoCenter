using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Services
{
    public class ChartSeriesEventArgs : EventArgs
    {
        public string Title;
    }

    public class ChartSeriesDataChangedEventArgs : ChartSeriesEventArgs
    {
        public object Item;
        public int ID;
        public int Index;
        public int ReversedIndex;
    }
    public class ChartSeriesNewDataEventArgs : ChartSeriesDataChangedEventArgs
    {
        public string LabelItem;
        public string XAxisLabel;
    }

}
