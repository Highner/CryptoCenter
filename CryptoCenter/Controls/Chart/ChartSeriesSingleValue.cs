using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.ViewModels;

namespace CryptoCenter.Controls.Chart
{
    public class ChartSeriesSingleValue : ChartSeriesBase<ItemViewModelChartValue>
    {
        public ChartSeriesSingleValue(BindingList<ItemViewModelChartValue> items, string title, string yaxislabel, string type) : base(items, type, title, "Time", yaxislabel)
        {

        }
        protected override object GenerateChartSeriesValue(ItemViewModelChartValue item)
        {
            return item.Value;
        }
    }
}
