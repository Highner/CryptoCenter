using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCenter.ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        #region public properties
        public ListViewModelTicker Ticker
        {
            get
            {
                return _Ticker;
            }
        }
        public Base.ListViewModelBase<ItemViewModelNews, Model.NewsItemData> News
        {
            get
            {
                return _News;
            }
        }
        public Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> OHCLHour
        {
            get
            {
                return _OHCLHour;
            }
        }
        public Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> OHCLMinute
        {
            get
            {
                return _OHCLMinute;
            }
        }
        public ListViewModelVolume VolumeMinute
        {
            get
            {
                return _VolumeMinute;
            }
        }
        public Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData> SocialStatsDay
        {
            get
            {
                return _SocialStatsDay;
            }
        }

        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLMinuteRepository;
        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLHourRepository;
        Model.DataRepositoryBase<Model.NewsItemData> CryptoCompareNewsRepository;
        Model.DataRepositoryBase<Model.Main.TickerData> CryptoCompareTickerRepository;
        Model.DataRepositoryBase<Model.Main.SocialStatsData> CryptoCompareSocialStatsRepository;
        #endregion

        #region private fields
        private ListViewModelTicker _Ticker = new ListViewModelTicker();
        private Base.ListViewModelBase<ItemViewModelNews, Model.NewsItemData> _News = new Base.ListViewModelBase<ItemViewModelNews, Model.NewsItemData>();
        private Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> _OHCLHour = new Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData>();
        private Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> _OHCLMinute = new Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData>();
        private ListViewModelVolume _VolumeMinute = new ListViewModelVolume();

        private Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData> _SocialStatsDay = new Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData>();

        Data.DataControllers.CryptoCompareOHCLDataController _CryptoCompareOHCLMinuteDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLMinuteRepositoryDataService;

        Data.DataControllers.CryptoCompareOHCLDataController _CryptoCompareOHCLHourDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLHourRepositoryDataService;

        Data.DataControllers.CryptoCompareNewsDataController _CryptoCompareNewsDataController;
        Services.DataServiceBase<Model.NewsItemData> _CryptoCompareNewsDataService;

        Data.DataControllers.CryptoCompareTickerDataController _CryptoCompareTickerDataController;
        Services.DataServiceBase<Model.Main.TickerData> _CryptoCompareTickerDataService;

        Data.DataControllers.CryptoCompareSocialStatsDataController _CryptoCompareSocialStatsDataController;
        Services.DataServiceBase<Model.Main.SocialStatsData> _CryptoCompareSocialStatsDataService;
        #endregion

        #region constructor
        public MainViewModel()
        {
            CryptoCompareOHCLMinuteRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLMinuteDataController = new Data.DataControllers.CryptoCompareOHCLDataController(Enumerables.DataIntervalTypeEnum.Minute, "BTC", "USD");
            _CryptoCompareOHCLMinuteRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLMinuteDataController, CryptoCompareOHCLMinuteRepository, 10000);

            CryptoCompareOHCLHourRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLHourDataController = new Data.DataControllers.CryptoCompareOHCLDataController(Enumerables.DataIntervalTypeEnum.Hour, "BTC", "USD");
            _CryptoCompareOHCLHourRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLHourDataController, CryptoCompareOHCLHourRepository, 10000);

            CryptoCompareSocialStatsRepository = new Model.DataRepositoryBase<Model.Main.SocialStatsData>();
            _CryptoCompareSocialStatsDataController = new Data.DataControllers.CryptoCompareSocialStatsDataController(Enumerables.DataIntervalTypeEnum.Day);
            _CryptoCompareSocialStatsDataService = new Services.DataServiceBase<Model.Main.SocialStatsData>(_CryptoCompareSocialStatsDataController, CryptoCompareSocialStatsRepository, 10000);

            CryptoCompareNewsRepository = new Model.DataRepositoryBase<Model.NewsItemData>();
            _CryptoCompareNewsDataController = new Data.DataControllers.CryptoCompareNewsDataController();
            _CryptoCompareNewsDataService = new Services.DataServiceBase<Model.NewsItemData>(_CryptoCompareNewsDataController, CryptoCompareNewsRepository, 300000);
            CryptoCompareNewsRepository.ReplaceOnly = true;

            CryptoCompareTickerRepository = new Model.DataRepositoryBase<Model.Main.TickerData>();
            _CryptoCompareTickerDataController = new Data.DataControllers.CryptoCompareTickerDataController(new string[] { "BTC,ETH,XRP,LTC,IOT,ADA" }, new string[] { "USD" });
            _CryptoCompareTickerDataService = new Services.DataServiceBase<Model.Main.TickerData>(_CryptoCompareTickerDataController, CryptoCompareTickerRepository, 10000);
            CryptoCompareTickerRepository.ReplaceOnly = true;

            CryptoCompareTickerRepository.DataChanged += NewTickerDataAdded;
            CryptoCompareNewsRepository.DataChanged += NewNewsDataAdded;
            CryptoCompareOHCLHourRepository.DataChanged += NewOHCLHourDataAdded;
            CryptoCompareOHCLMinuteRepository.DataChanged += NewOHCLMinuteDataAdded;
            CryptoCompareSocialStatsRepository.DataChanged += NewSocialStatsDataAdded;

        }
        #endregion

        #region private methods
        private void NewTickerDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.Main.TickerData> e)
        {
            Context.Post(delegate
            {
                Ticker.ReplaceOrAddItemData(e.Items);
            }, null);
        }
        private void NewNewsDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.NewsItemData> e)
        {
            Context.Post(delegate
            {
                News.ReplaceOrAddItemData(e.Items);
            }, null);
        }
        private void NewOHCLHourDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.OHCLData> e)
        {
            Context.Post(delegate
            {
                OHCLHour.ReplaceOrAddItemData(e.Items);
            }, null);
        }
        private void NewOHCLMinuteDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.OHCLData> e)
        {
            Context.Post(delegate
            {
                OHCLMinute.ReplaceOrAddItemData(e.Items);
            }, null);
            Context.Post(delegate
            {
                VolumeMinute.ReplaceOrAddItemData(e.Items);
            }, null);
        }
        private void NewSocialStatsDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.Main.SocialStatsData> e)
        {
            Context.Post(delegate
            {
                SocialStatsDay.ReplaceOrAddItemData(e.Items);
            }, null);
        }
        #endregion

        #region public methods
        public void StartOHCLService()
        {
            _CryptoCompareOHCLMinuteRepositoryDataService.GetData();
            _CryptoCompareOHCLMinuteRepositoryDataService.Start();
            //_CryptoCompareOHCLHourRepositoryDataService.GetData();
            //_CryptoCompareOHCLHourRepositoryDataService.Start();
        }
        public void StopOHCLService()
        {
            _CryptoCompareOHCLMinuteRepositoryDataService.Stop();
        }
        public void ClearOHCLData()
        {
            CryptoCompareOHCLMinuteRepository.Clear();
        }
        public void StartTickerService()
        {
            _CryptoCompareTickerDataService.GetData();
           _CryptoCompareTickerDataService.Start();
        }
        public void StopTickerService()
        {
            _CryptoCompareTickerDataService.Start();
        }
        public void StartSocialStatsService()
        {
            _CryptoCompareSocialStatsDataService.Start();
        }
        public void GetNews()
        {
            _CryptoCompareNewsDataService.GetData();
        }
        #endregion

    }
}
