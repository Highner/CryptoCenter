using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.ViewModels;

namespace CryptoCenter.Controls.Chart
{
    class ChartSeriesAverage : ChartSeriesBase<ItemViewModelOHCL>
    {
        public ChartSeriesAverage(BindingList<ItemViewModelOHCL> items, string title, string yaxislabel) : base(items, "Line", title, "Time", yaxislabel)
        {
        }

        protected override object GenerateChartSeriesValue(ItemViewModelOHCL item)
        {
            return (item.Close + item.Open + item.High + item.Low) / 4;
        }
    }
}