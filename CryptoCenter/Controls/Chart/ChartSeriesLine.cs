using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.ViewModels;

namespace CryptoCenter.Controls.Chart
{
    class ChartSeriesVolume : ChartSeriesBase<ItemViewModelOHCL>
    {
        public ChartSeriesVolume(BindingList<ItemViewModelOHCL> items, string title, string yaxislabel) : base(items, "Column", title, "Time", yaxislabel)
        {
        }

        protected override object GenerateChartSeriesValue(ItemViewModelOHCL item)
        {
            return item.Volume;
        }
    }

}