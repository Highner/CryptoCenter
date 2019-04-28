using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelTicker: Base.ItemViewModelBase<Model.Main.TickerData>
    {
        public string Coin
        {
            get
            {
                return Data.CurrencyFrom;
            }
        }
        public string Price
        {
            get
            {
                return Data.CurrencyTo + " " + Data.Price.ToString("N2");
            }
        }
        public string Change
        {
            get
            {
                return Data.Change24Hour.ToString("N2") + " %";
            }
        }
        public string Volume
        {
            get
            {
                return Data.CurrencyTo + " " + Data.Volume24HourTo.ToString("N2");
            }
        }
        public System.Drawing.Image Image
        {
            get
            {
                return Data.Image;
            }
        }
    }
}
