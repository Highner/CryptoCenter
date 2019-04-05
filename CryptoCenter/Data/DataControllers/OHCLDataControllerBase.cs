using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCenter.Enumerables;
using CryptoCenter.Model;

namespace CryptoCenter.Data.DataControllers
{
    abstract class OHCLDataControllerBase : CryptoDataControllerBase<OHCLData>
    {
        #region private fields
        protected DataIntervalTypeEnum _Interval;
        protected string _Currency1;
        protected string _Currency2;
        #endregion

        #region constructor

        #endregion

        protected abstract override List<OHCLData> GetData(double since);

    }
}
