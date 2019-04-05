using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Interfaces
{
    public interface IHasGetNewData<t> where t : Interfaces.IHasUnixTime
    {
        t[] GetNewData(Model.DataRepositoryBase<t> repository);
    }
}
