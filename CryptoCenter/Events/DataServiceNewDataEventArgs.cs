using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Services
{
    public class DataServiceNewDataEventArgs<t> : EventArgs where t : Interfaces.IHasUnixTime
    {
        public t[] Items;
    }
}
