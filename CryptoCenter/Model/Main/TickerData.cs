using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model.Main
{
    public class TickerData : Interfaces.IIsListViewItem, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public string ListID { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double Price { get; set; }
        public double High24Hour { get; set; }
        public double Low24Hour { get; set; }
        public double Open24Hour { get; set; }
        public double Close24Hour { get; set; }
        public double Volume24Hour { get; set; }
        public double Volume24HourTo { get; set; }
        public int UnixTime { get; set; }
        public double Change24Hour { get; set; }
        public DateTime Time { get; set; }
        public System.Drawing.Image Image { get; set; }
        public Model.OHCLData[] OHCLData { get; set; }
    }
}
