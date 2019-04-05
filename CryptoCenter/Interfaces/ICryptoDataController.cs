using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Interfaces
{
     interface ICryptoDataController<t>: IHasGetNewData<t> where t : IHasUnixTime
    {
         List<t> GetData(DateTime since, Enumerables.DataIntervalTypeEnum interval);

    }

}
