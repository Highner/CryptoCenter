using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model
{
    public class OHCLData: Interfaces.IHasID, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public double Open;
        public double High;
        public double Low;
        public double Close;
        public double Volume;
        public double UnixTime { get; set; }
        public DateTime Time;
    }
}
