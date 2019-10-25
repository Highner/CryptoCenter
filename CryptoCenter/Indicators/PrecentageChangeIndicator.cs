using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Indicators
{
    public class PrecentageChangeIndicator : IndicatorBase
    {
        #region contructor
        public PrecentageChangeIndicator(NeuroNetworks.Base.INeuroNetwork network)
        {
            Network = network;
            Network.EpochTrained += base.OnEpochTrained;
        }
        #endregion

        #region public properties
    
        #endregion
    }
}
