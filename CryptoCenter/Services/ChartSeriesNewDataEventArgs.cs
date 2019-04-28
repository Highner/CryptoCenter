using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Services
{
    public class ChartSeriesDataChangedEventArgs : EventArgs
    {
        public object Item;
        public int ID;
        public string Title;
        public int Index;
    }
    public class ChartSeriesNewDataEventArgs : ChartSeriesDataChangedEventArgs
    {
        public string LabelItem;
        public string XAxisLabel;
    }
}
