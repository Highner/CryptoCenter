using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelChartValue : Base.ItemViewModelBase<Model.SingleValueData>, Interfaces.IIsChartItem
    {
        public double Value { get { return Data.Value; } }
        public int UnixTime { get { return Data.UnixTime; } }
        public DateTime Time { get { return Data.Time; } }
        public string XAxisValue { get { return Data.Time.ToString(); } }
    }
}
