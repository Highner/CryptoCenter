using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Data.DataControllers
{
    abstract class TickerDataControllerBase: CryptoDataControllerBase<Model.Main.TickerData>
    {

        #region private fields
        protected string[] _CurrenciesFrom;
        protected string[] _CurrenciesTo;
        #endregion

        #region constructor

        #endregion

        protected abstract override List<Model.Main.TickerData> GetData(double since);
    }
}
