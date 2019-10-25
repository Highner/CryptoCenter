using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNTK;
using EasyCNTK;
using EasyCNTK.ActivationFunctions;
using EasyCNTK.Layers;
using EasyCNTK.Learning;
using EasyCNTK.Learning.Optimizers;
using EasyCNTK.LossFunctions;
using SinusoidRegressionLSTM;

namespace CryptoCenter.ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        #region public properties
        public string BaseCurrency = "USD";
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
        public Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> OHCLDay
        {
            get
            {
                return _OHCLDay;
            }
        }
        public Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData> SocialStatsDay
        {
            get
            {
                return _SocialStatsDay;
            }
        }
        public Base.ListViewModelBase<ItemViewModelChartValue, Model.SingleValueData> PredictedHour
        {
            get
            {
                return _PredictedHour;
            }
        }

        public List<Model.BitThought.SourceData> SourceData
        {
            get
            {
                return _SourceData;
            }
            set
            {
                _SourceData = value;
                OnPropertyChanged("SourceData");
            }
        }

        PercentagChangeIndicatorViewModel PercentageChangeIndicatorViewModel;

        public List<Model.BitThought.SourceData> _SourceData;

        public double ComputedCloseChange1
        {
            get
            {
                return _ComputedCloseChange1;
            }
            set
            {
                _ComputedCloseChange1 = value;
                OnPropertyChanged("ComputedCloseChange1");
            }
        }
        public double ComputedCloseChange2
        {
            get
            {
                return _ComputedCloseChange2;
            }
            set
            {
                _ComputedCloseChange2 = value;
                OnPropertyChanged("ComputedCloseChange2");
            }
        }
        public string TrainingStatus
        {
            get
            {
                return _TrainingStatus;
            }
            set
            {
                _TrainingStatus = value;
                OnPropertyChanged("TrainingStatus");
            }
        }
        public int InputSize
        {
            get
            {
                return _InputSize;
            }
            set
            {
                _InputSize = value;
                OnPropertyChanged("InputSize");
            }
        }
        public int FinishedTrainingEpochs
        {
            get
            {
                return _FinishedTrainingEpochs;
            }
            set
            {
                _FinishedTrainingEpochs = value;
                OnPropertyChanged("FinishedTrainingEpochs");
            }
        }
        public int TrainingEpochs
        {
            get
            {
                return _TrainingEpochs;
            }
            set
            {
                PercentageChangeIndicatorViewModel.TrainingEpochs = value;
                _TrainingEpochs = value;
                OnPropertyChanged("TrainingEpochs");
            }
        }
        #endregion

        #region private fields
        private ListViewModelTicker _Ticker = new ListViewModelTicker();
        private Base.ListViewModelBase<ItemViewModelNews, Model.NewsItemData> _News = new Base.ListViewModelBase<ItemViewModelNews, Model.NewsItemData>();
        private Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> _OHCLHour = new Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData>();
        private Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> _OHCLMinute = new Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData>();
        private Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData> _OHCLDay = new Base.ListViewModelBase<ItemViewModelOHCL, Model.OHCLData>();

        private Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData> _SocialStatsDay = new Base.ListViewModelBase<ItemViewModelSocialStats, Model.Main.SocialStatsData>();

        private Base.ListViewModelBase<ItemViewModelChartValue, Model.SingleValueData> _PredictedHour = new Base.ListViewModelBase<ItemViewModelChartValue, Model.SingleValueData>();

        Data.DataControllers.CryptoCompareOHCLDataController _CryptoCompareOHCLMinuteDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLMinuteRepositoryDataService;

        Data.DataControllers.CryptoCompareOHCLDataController _CryptoCompareOHCLHourDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLHourRepositoryDataService;

        Data.DataControllers.CryptoCompareOHCLDataController _CryptoCompareOHCLDayDataController;
        Services.DataServiceBase<Model.OHCLData> _CryptoCompareOHCLDayRepositoryDataService;

        Data.DataControllers.CryptoCompareNewsDataController _CryptoCompareNewsDataController;
        Services.DataServiceBase<Model.NewsItemData> _CryptoCompareNewsDataService;

        Data.DataControllers.CryptoCompareTickerDataController _CryptoCompareTickerDataController;
        Services.DataServiceBase<Model.Main.TickerData> _CryptoCompareTickerDataService;

        Data.DataControllers.CryptoCompareSocialStatsDataController _CryptoCompareSocialStatsDataController;
        Services.DataServiceBase<Model.Main.SocialStatsData> _CryptoCompareSocialStatsDataService;

        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLMinuteRepository;
        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLHourRepository;
        Model.DataRepositoryBase<Model.OHCLData> CryptoCompareOHCLDayRepository;
        Model.DataRepositoryBase<Model.NewsItemData> CryptoCompareNewsRepository;
        Model.DataRepositoryBase<Model.Main.TickerData> CryptoCompareTickerRepository;
        Model.DataRepositoryBase<Model.Main.SocialStatsData> CryptoCompareSocialStatsRepository;

        private double _ComputedCloseChange1;
        private double _ComputedCloseChange2;
        private string _TrainingStatus;
        private int _FinishedTrainingEpochs;
        private int _TrainingEpochs;
        private int _InputSize;
        #endregion

        #region constructor
        public MainViewModel()
        {
            CryptoCompareOHCLMinuteRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLMinuteDataController = new Data.DataControllers.CryptoCompareOHCLDataController(Enumerables.DataIntervalTypeEnum.Minute, "BTC", BaseCurrency, 1);
            _CryptoCompareOHCLMinuteRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLMinuteDataController, CryptoCompareOHCLMinuteRepository, 10000);

            CryptoCompareOHCLHourRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLHourDataController = new Data.DataControllers.CryptoCompareOHCLDataController(Enumerables.DataIntervalTypeEnum.Hour, "BTC", BaseCurrency, 5);
            _CryptoCompareOHCLHourRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLHourDataController, CryptoCompareOHCLHourRepository, 100000);

            CryptoCompareOHCLDayRepository = new Model.DataRepositoryBase<Model.OHCLData>();
            _CryptoCompareOHCLDayDataController = new Data.DataControllers.CryptoCompareOHCLDataController(Enumerables.DataIntervalTypeEnum.Day, "BTC", BaseCurrency, 1);
            _CryptoCompareOHCLDayRepositoryDataService = new Services.DataServiceBase<Model.OHCLData>(_CryptoCompareOHCLDayDataController, CryptoCompareOHCLDayRepository, 1000000);

            CryptoCompareSocialStatsRepository = new Model.DataRepositoryBase<Model.Main.SocialStatsData>();
            _CryptoCompareSocialStatsDataController = new Data.DataControllers.CryptoCompareSocialStatsDataController(Enumerables.DataIntervalTypeEnum.Day);
            _CryptoCompareSocialStatsDataService = new Services.DataServiceBase<Model.Main.SocialStatsData>(_CryptoCompareSocialStatsDataController, CryptoCompareSocialStatsRepository, 100000);

            CryptoCompareNewsRepository = new Model.DataRepositoryBase<Model.NewsItemData>();
            _CryptoCompareNewsDataController = new Data.DataControllers.CryptoCompareNewsDataController();
            _CryptoCompareNewsDataService = new Services.DataServiceBase<Model.NewsItemData>(_CryptoCompareNewsDataController, CryptoCompareNewsRepository, 300000);
            CryptoCompareNewsRepository.ReplaceOnly = true;

            CryptoCompareTickerRepository = new Model.DataRepositoryBase<Model.Main.TickerData>();
            _CryptoCompareTickerDataController = new Data.DataControllers.CryptoCompareTickerDataController(new string[] { "BTC,ETH,XRP,LTC,MIOTA,ADA,BNB,EOS,TRX,XLM" }, new string[] { BaseCurrency });
            _CryptoCompareTickerDataService = new Services.DataServiceBase<Model.Main.TickerData>(_CryptoCompareTickerDataController, CryptoCompareTickerRepository, 10000);
            CryptoCompareTickerRepository.ReplaceOnly = true;

            CryptoCompareTickerRepository.DataChanged += NewTickerDataAdded;
            CryptoCompareNewsRepository.DataChanged += NewNewsDataAdded;
            CryptoCompareOHCLHourRepository.DataChanged += NewOHCLHourDataAdded;
            CryptoCompareOHCLMinuteRepository.DataChanged += NewOHCLMinuteDataAdded;
            CryptoCompareOHCLDayRepository.DataChanged += NewOHCLDayDataAdded;
            CryptoCompareSocialStatsRepository.DataChanged += NewSocialStatsDataAdded;


            //PercentageChangeIndicatorViewModel = new PercentagChangeIndicatorViewModel(new NeuroNetworks.PrecentageChangeNetwork(20, 1));
            PercentageChangeIndicatorViewModel = new PercentagChangeIndicatorViewModel(new NeuroNetworks.LSTMPercentageChangeNetwork(DeviceDescriptor.CPUDevice, 3, 16));
            PercentageChangeIndicatorViewModel.EpochTrained += OnEpochTrained;

            TrainingEpochs = 10000;

            InputSize = 200;


        }
        #endregion

        #region private methods
        private void OnEpochTrained(object sender, Events.NeuroNetworkEpochTrainedEventArgs e)
        {
            Context.Post(delegate
            {
                TrainingStatus = "Trained " + e.Epoch.ToString() + " of " + TrainingEpochs + " cycles.";
                FinishedTrainingEpochs = e.Epoch;
            }, null);
        }
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
        }
        private void NewOHCLDayDataAdded(object sender, Services.DataServiceNewDataEventArgs<Model.OHCLData> e)
        {
            Context.Post(delegate
            {
                OHCLDay.ReplaceOrAddItemData(e.Items);
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
        public void GenerateSourceData()
        {
            SourceData = Helpers.Conversion.CreateSourceData(OHCLHour.Items.Take(OHCLHour.Items.Count() - InputSize).Select(x => x.Data).ToList());
        }
        public void TrainNetwork()
        {
            var dataset = SourceData
             .Segment(InputSize)
             .Select(p => (featureSequence: p.Take(InputSize - 1).Select(q => new[] { q.OpenChange, q.CloseChange, q.VolumeChange }).ToArray(),
             label: new[] { p[InputSize - 1].CloseChange }))
             .ToArray();


            dataset.Split(1, out var train, out var test);

            PercentageChangeIndicatorViewModel.SetTrainingData(train, test);

            PercentageChangeIndicatorViewModel.ExecuteTrainNetwork();
        }
        public void ComputeLast()
        {

            for (int i = 149; i >= 0; i--)
            {

                List<double[]> data = new List<double[]>();
                var testsource = Helpers.Conversion.CreateSourceData(OHCLHour.Items.Skip(OHCLHour.Items.Count() - InputSize - 2 - i).Take(InputSize + 1).Select(x => x.Data).ToList());

                foreach (Model.BitThought.SourceData item in testsource)
                {

                    data.Add(new double[] { item.OpenChange, item.CloseChange, item.VolumeChange });
                    //data.Add(item.VolumeChange);
                }

                var computed = PercentageChangeIndicatorViewModel.Compute(data.ToArray());
                var last = OHCLHour.Items[OHCLHour.Items.Count() - 1 - i];
                var prevlast = OHCLHour.Items[OHCLHour.Items.Count() - 2 - i];
                ComputedCloseChange1 = computed[0] * prevlast.Close + prevlast.Close;
                ComputedCloseChange2 = last.Close;

                PredictedHour.ReplaceOrAddItemData(new Model.SingleValueData() { Value = computed[0], Time = last.Time, UnixTime = last.UnixTime, ID = last.Time.ToString() });

            }



        }
        public void Test()
        {
            PercentageChangeIndicatorViewModel.ExecuteTestNetwork();
        }
        public void ChangeCoin(string coin)
        {
            StopOHCLService();
            ClearOHCLData();
            _CryptoCompareOHCLHourDataController.ChangeCurrencies(coin, BaseCurrency);
            _CryptoCompareOHCLMinuteDataController.ChangeCurrencies(coin, BaseCurrency);
            _CryptoCompareOHCLDayDataController.ChangeCurrencies(coin, BaseCurrency);
            StartOHCLService();
        }
        public void StartOHCLService()
        {
            _CryptoCompareOHCLMinuteRepositoryDataService.GetData();
            _CryptoCompareOHCLMinuteRepositoryDataService.Start();
            _CryptoCompareOHCLHourRepositoryDataService.GetData();
            _CryptoCompareOHCLHourRepositoryDataService.Start();
            _CryptoCompareOHCLDayRepositoryDataService.GetData();
            _CryptoCompareOHCLDayRepositoryDataService.Start();
        }
        public void StopOHCLService()
        {
            _CryptoCompareOHCLMinuteRepositoryDataService.Stop();
            _CryptoCompareOHCLHourRepositoryDataService.Stop();
            _CryptoCompareOHCLDayRepositoryDataService.Stop();
        }
        public void ClearOHCLData()
        {
            CryptoCompareOHCLMinuteRepository.Clear();
            CryptoCompareOHCLHourRepository.Clear();
            CryptoCompareOHCLDayRepository.Clear();
            OHCLHour.Items.Clear();
            OHCLMinute.Items.Clear();
            OHCLDay.Items.Clear();
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
            _CryptoCompareSocialStatsDataService.GetData();
            _CryptoCompareSocialStatsDataService.Start();
        }
        public void GetNews()
        {
            _CryptoCompareNewsDataService.GetData();
        }
        #endregion

    }
}
