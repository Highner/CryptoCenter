
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoCenter.ViewModels.Base
{
    public abstract class IndicatorViewModelBase: ViewModelBase
    {

        #region constructor
        public IndicatorViewModelBase(Indicators.IndicatorBase indicator)
        {
            _Indicator = indicator;
            _Indicator.EpochTrained += OnEpochTrained;
        }
        #endregion

        #region public methods
        public void SetTrainingData(double[][] trainingdata, double[][] testdata)
        {
            _Indicator.SetTrainingData(trainingdata, testdata);
        }
        public void SetTrainingData(IList<(double[][] featuresequence, double[] label)> trainingdata, IList<(double[][] featuresequence, double[] label)> testdata)
        {
            _Indicator.SetTrainingData(trainingdata, testdata);
        }
        public double[] Compute(double[] data)
        {
            return _Indicator.Compute(data);
        }
        public double[] Compute(double[][] data)
        {
            return _Indicator.Compute(data);
        }
        #endregion

        #region async methods
        async void ExecuteLoadTrainingData()
        {
            SetBusyStatus("Loading trainingdata");

            await Task.Run(() => LoadTrainingData());

            _Indicator.SetTrainingData(_TrainingData.ToArray(), _TestData.ToArray());

            SetNotBusyStatus();
        }
        public async void ExecuteTrainNetwork()
        {
            SetBusyStatus("Training Network");

            await Task.Run(() => _Indicator.TrainNetwork());

            if (!(TrainingCompleted == null)) { TrainingCompleted(this, null); }

            SetNotBusyStatus();
        }
        public async void ExecuteTestNetwork()
        {
            SetBusyStatus("Testing Network");

            await Task.Run(() => _Indicator.Test());

            SetNotBusyStatus();
        }
        #endregion

        #region private methods
        void ResetStatus()
        {
            Status = "";
        }
        void SetBusyStatus(string status)
        {
            IsBusy = true;
            Status = status;
        }
        void SetNotBusyStatus()
        {
            IsBusy = false;
            ResetStatus();
        }
        #endregion

        #region overridable methods
        protected virtual void LoadTrainingData()
        {

        }
        #endregion

        #region private methods
        void OnEpochTrained(object sender, Events.NeuroNetworkEpochTrainedEventArgs e)
        {
            EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> tmpevent = EpochTrained;
            if (tmpevent != null)
            {
                tmpevent(this, new Events.NeuroNetworkEpochTrainedEventArgs() { Epoch = e.Epoch });
            }
        }
        #endregion

        #region events
        public event EventHandler TrainingCompleted;
        public event EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> EpochTrained;
        #endregion

        #region private properties
        List<double[]> _TrainingData { get; set; }
        List<double[]> _TestData { get; set; }
        Indicators.IndicatorBase _Indicator { get; set; }
        #endregion

        #region public properties
        string _Status;
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
        public int TrainingEpochs
        {
            get
            {
                return _Indicator.TrainingEpochs;
            }

            set
            {
                _Indicator.TrainingEpochs = value;
                OnPropertyChanged("TrainingEpochs");
            }
        }
        #endregion
    }
}
