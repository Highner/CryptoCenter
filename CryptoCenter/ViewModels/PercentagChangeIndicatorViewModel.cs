using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class PercentagChangeIndicatorViewModel: Base.IndicatorViewModelBase
    {
        public PercentagChangeIndicatorViewModel(NeuroNetworks.Base.INeuroNetwork network) : base(new Indicators.PrecentageChangeIndicator(network))
        {
        }
    }
}
