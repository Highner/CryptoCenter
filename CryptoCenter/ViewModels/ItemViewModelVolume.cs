using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelVolume : Base.ItemViewModelBase<Model.OHCLData>
    {
        public double Value { get { return Data.Volume; } set { Data.Volume = value; } }
        public int UnixTime { get { return Data.UnixTime; } }
        public DateTime Time { get { return Data.Time; } }
        public string ListID { get { return Data.CurrencyFrom + Data.CurrencyTo + "volume"; } set { Data.ListID = value; } }
        public string ID { get { return Data.ID; } set { Data.ID = value; } }
        public string YAxisLabel { get { return "Volume " + Data.CurrencyFrom + " to " + Data.CurrencyTo; } }
    }
}
