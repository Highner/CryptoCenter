using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ListViewModelTicker: Base.ListViewModelBase<ItemViewModelTicker, Model.Main.TickerData>
    {
        public void AddOHCLData(Model.OHCLData[] newdata, string id)
        {
            if(Items.Where(x => x.Data.ID == id).Any())
            {
                var item = Items.Where(x => x.Data.ID == id).Single();
                item.Data.OHCLData = newdata;
            }
        }
    }
}
