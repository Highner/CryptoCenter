using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model
{
    public class SingleValueData : Interfaces.IIsListViewItem, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public string ListID { get; set; }
        public double Value { get; set; }
        public int UnixTime { get; set; }
        public DateTime Time;
    }
}
