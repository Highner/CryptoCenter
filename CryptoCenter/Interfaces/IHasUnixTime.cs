using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Interfaces
{
    public interface IHasUnixTime
    {
        double UnixTime { get; set; }
    }
}
