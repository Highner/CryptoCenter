using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Indicators
{
    public interface IIndicator
    {

        void Test();

        List<IndicatorSignal> Signals { get; set; }

    }
}


