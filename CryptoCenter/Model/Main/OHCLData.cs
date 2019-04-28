using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model
{
    public class OHCLData: Interfaces.IIsListViewItem, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public string ListID { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public int UnixTime { get; set; }
        public DateTime Time;
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
    }
}
