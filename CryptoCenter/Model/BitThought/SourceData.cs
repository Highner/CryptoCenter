using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model.BitThought
{
    public class SourceData
    {
        public int UnixTime { get; set; }
        public double Open { get; set; }
        public double OpenChange { get; set; }
        public double High { get; set; }
        public double HighChange { get; set; }
        public double Low { get; set; }
        public double LowChange { get; set; }
        public double Close { get; set; }
        public double CloseChange { get; set; }
        public double Volume { get; set; }
        public double VolumeChange { get; set; }
    }
}
