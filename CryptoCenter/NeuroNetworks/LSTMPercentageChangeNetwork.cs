using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNTK;
using CryptoCenter.Events;
using EasyCNTK;
using EasyCNTK.ActivationFunctions;
using EasyCNTK.Layers;
using EasyCNTK.Learning;
using EasyCNTK.Learning.Optimizers;
using EasyCNTK.LossFunctions;

namespace CryptoCenter.NeuroNetworks
{
    public class LSTMPercentageChangeNetwork : Base.INeuroNetwork
    {
        #region constructor
        public LSTMPercentageChangeNetwork(DeviceDescriptor device, int inputDimension, int minibatchSize)
        {
            _Model = new Sequential<double>(device, new[] { inputDimension }, inputName: "Input");
            _Model.Add(new LSTM(inputDimension, selfStabilizerLayer: new SelfStabilization()));

            _Model.Add(new Residual2(50, new Sigmoid()));
            _Model.Add(new Residual2(1, new Tanh()));


            MinibatchSize = minibatchSize;
            Device = device;
        }
        #endregion

        #region public properties
        public List<double> ErrorFunction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<double[]> TestResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<double[]> TestExpected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MinibatchSize;
        public DeviceDescriptor Device;
        #endregion

        #region private fields
        Sequential<double> _Model;
        IList<(double[][] featureSequence, double[] label)> _TrainingData;
        IList<(double[][] featureSequence, double[] label)> _TestData;

        #endregion

        #region events
        public event EventHandler<NeuroNetworkEpochTrainedEventArgs> EpochTrained;
        #endregion

        #region public methods
        public double[] Compute(double[] value)
        {
            return _Model.Predict<double>(value, Device);
        }

        public double[] Compute(double[][] value)
        {
            return _Model.Predict<double>(value, Device);
        }
        public void SetTrainingData(double[][] trainingdata, double[][] testdata)
        {
        }

        public void SetTrainingData(IList<(double[][] featuresequence, double[] label)> trainingdata, IList<(double[][] featuresequence, double[] label)> testdata)
        {
            _TrainingData = trainingdata;
            _TestData = testdata;
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        public void Train(int epochs)
        {
            var fitResult = _Model.Fit(features: _TrainingData.Select(p => p.featureSequence).ToArray(),
                labels: _TrainingData.Select(p => p.label).ToArray(),
                 minibatchSize: MinibatchSize,
                 lossFunction: new AbsoluteError(),
                 evaluationFunction: new AbsoluteError(),
                 optimizer: new Adam(0.005, 0.9, MinibatchSize),
                 epochCount: epochs,
                 device: Device,
                 shuffleSampleInMinibatchesPerEpoch: true,
                 ruleUpdateLearningRate: (epoch, learningRate) => learningRate % 50 == 0 ? 0.95 * learningRate : learningRate,
                 actionPerEpoch: (epoch, loss, eval) =>
                 {
                     Console.WriteLine($"Loss: {loss:F10} Eval: {eval:F5} Epoch: {epoch}");

                     EventHandler<Events.NeuroNetworkEpochTrainedEventArgs> tmpevent = EpochTrained;
                     if (tmpevent != null)
                     {
                         tmpevent(this, new Events.NeuroNetworkEpochTrainedEventArgs() { Epoch = epoch });
                     }

                     //if (loss < 0.0005)
                     if (epoch == epochs)
                     {
                                     //model.SaveModel($"{model}.model", saveArchitectureDescription: false);
                                     return true;
                     }
                     return false;
                 },
                 inputName: "Input");
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }




        #endregion


    }
}
