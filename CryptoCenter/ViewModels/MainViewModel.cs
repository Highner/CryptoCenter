using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        #region private fields
        Data.DataControllers.CryptoCompareDataController _CryptoCompareOHCLMinuteDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLRepositoryDataService;
        #endregion

        #region public properties
        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLRepository;
        #endregion

        #region constructor
        public MainViewModel()
        {
            _CryptoCompareOHCLMinuteDataController = new Data.DataControllers.CryptoCompareDataController(Enumerables.DataIntervalTypeEnum.Minute, "BTC", "USD");
            CryptoCompareOHCLRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLMinuteDataController, CryptoCompareOHCLRepository, 10000);
        }
        #endregion

        #region private methods

        #endregion

        #region public methods

        #endregion
    }
}
