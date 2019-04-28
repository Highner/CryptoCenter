using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.ViewModels;

namespace CryptoCenter.Controls.Chart
{
    class ChartSeriesOHCL : ChartSeriesBase<ItemViewModelOHCL>
    {
        public ChartSeriesOHCL(BindingList<ItemViewModelOHCL> items, string title, string yaxislabel) : base(items, "Candle", title, "Time", yaxislabel)
        {
        }

        protected override object GenerateChartSeriesValue(ItemViewModelOHCL item)
        {
            return new LiveCharts.Defaults.OhlcPoint(item.Open, item.High, item.Low, item.Close);
        }
    }
}
