using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Indicators
{
    public class LSTMPrecentageChangeIndicator : IndicatorBase
    {
        #region contructor
        public LSTMPrecentageChangeIndicator()
        {
            Network = new NeuroNetworks.LSTMPercentageChangeNetwork(CNTK.DeviceDescriptor.CPUDevice, 1, 1);
            Network.EpochTrained += base.OnEpochTrained;
        }
        #endregion

        #region public properties
    
        #endregion
    }
}
