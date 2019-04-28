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
            if(repository.Items.Any())
            {
                var maxtime = repository.Items.Max(x => x.UnixTime);
                var mintime = repository.Items.Min(x => x.UnixTime);
                _LastTimeStamp = maxtime;
            } else { _LastTimeStamp = 0; }
            List<t> latestdata;
            try
            {
                latestdata = GetData(_LastTimeStamp);
                if (latestdata.Any())
                {
                    repository.AddItems(latestdata.ToArray());
                    return latestdata.ToArray();
                }
            }
            catch
            { }

            return new t[] { };
        }
    }
}
