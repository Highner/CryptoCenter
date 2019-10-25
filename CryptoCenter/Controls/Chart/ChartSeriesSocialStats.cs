using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.ViewModels;

namespace CryptoCenter.Controls.Chart
{
    public class ChartSeriesSocialStats : ChartSeriesBase<ItemViewModelSocialStats>
    {
        private string _ValueProperty;
        public ChartSeriesSocialStats(BindingList<ItemViewModelSocialStats> items, string title, string yaxislabel, string valueproperty) : base(items, "Line", title, "Time", yaxislabel)
        {
            _ValueProperty = valueproperty;
        }

        protected override object GenerateChartSeriesValue(ItemViewModelSocialStats item)
        {
            return item.GetType().GetProperty(_ValueProperty).GetValue(item, null);
        }
    }
}
