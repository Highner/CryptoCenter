using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Interfaces
{
    public interface IHasNewDataAdded<t> where t : IHasUnixTime
    {
        event EventHandler<Services.DataServiceNewDataEventArgs<t>> NewDataAdded;
    }
}
