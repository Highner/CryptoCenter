using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelOHCL:Base.ItemViewModelBase<Model.OHCLData> , Interfaces.IIsChartItem
    {
        public double Open { get { return Data.Open; }}
        public double High { get { return Data.High; } }
        public double Low { get { return Data.Low; } }
        public double Close { get { return Data.Close; } }
        public double Volume { get { return Data.Volume; } }
        public int UnixTime { get { return Data.UnixTime; } }
        public DateTime Time { get { return Data.Time; } }
        public string XAxisValue { get { return Data.Time.ToString(); } }
    }
}
