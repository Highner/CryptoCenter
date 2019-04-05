using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Data.DataControllers
{
    public abstract class CryptoDataControllerBase<t>: Interfaces.IHasGetNewData<t> where t : Interfaces.IHasUnixTime
    {
        private Enumerables.DataIntervalTypeEnum _Interval;
        private double _LastTimeStamp = 0;

        protected abstract List<t> GetData(double since);
  
        public t[] GetNewData(Model.DataRepositoryBase<t> repository)
        {
            List<t> latestdata = GetData(_LastTimeStamp);
            var newdata = latestdata.Where(x => x.UnixTime > _LastTimeStamp).ToArray();
            if (newdata.Any())
            {
                repository.AddItems(newdata);
                _LastTimeStamp = newdata.Max(x => x.UnixTime);
                return newdata;
            }
            return new t[] { };
        }
    }
}
