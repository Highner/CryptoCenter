using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Indicators
{
    public abstract class IndicatorBase : IIndicator
    {
        #region constructor
        public IndicatorBase()
        {
        }
        #endregion

        #region public methods

        public void SetTrainingData(double[][] trainingdata, double[][] testdata)
        {
            Network.SetTrainingData(trainingdata, testdata);
        }
        public void SetTrainingData(IList<(double[][] featuresequence, double[] label)> trainingdata, IList<(double[][] featuresequence, double[] label)> testdata)
        {
            Network.SetTrainingData(trainingdata, testdata);
        }

        public void Test()
        {
            Network.Test();
        }

        public void Validate()
        {
            Network.Validate();
        }

        public void TrainNetwork()
        {
            Network.Train(TrainingEpochs);
        }

        public double[] Compute(double[] data)
        {
            return Network.Compute(data);
        }
        public double[] Compute(double[][] data)
        {
            return Network.Compute(data);
        }
        public void CalculateSignals(double[][] data)
        {

        }
        #endregion

        #region private methods
        public void OnEpochTrained(object sender, Events.NeuroNetworkEpochTrainedEventArgs e)
        {
            EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> tmpevent = EpochTrained;
            if (tmpevent != null)
            {
                tmpevent(this, new Events.NeuroNetworkEpochTrainedEventArgs() { Epoch = e.Epoch });
            }
        }
        #endregion

        #region events
        public event EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> EpochTrained;
        #endregion

        #region properties
        protected NeuroNetworks.Base.INeuroNetwork Network { get; set; }
        public List<IndicatorSignal> Signals { get; set; } = new List<IndicatorSignal>();
        public List<double[]> TestResult { get { return Network.TestResult; } }
        public List<double[]> TestExpected { get { return Network.TestExpected; } }

        public int TrainingEpochs { get; set; }
        #endregion
    }
}
