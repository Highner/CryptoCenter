using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.NeuroNetworks.Base
{
    public interface INeuroNetwork
    {
        void Train(int epochs);

        void Test();

        void Validate();

        void SetTrainingData(double[][] trainingdata, double[][] testdata);

        void SetTrainingData(IList<(double[][] featuresequence, double[] label)> trainingdata, IList<(double[][] featuresequence, double[] label)> testdata);

        double[] Compute(double[] value);

        double[] Compute(double[][] value);

        event EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> EpochTrained;

        List<double> ErrorFunction { get; set; }
        List<double[]> TestResult { get; set; }
        List<double[]> TestExpected { get; set; }
    }
}
