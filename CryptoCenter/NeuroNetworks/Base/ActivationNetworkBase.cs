using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.NeuroNetworks.Base
{
    public abstract class ActivationNetworkBase: NeuroNetworkBase
    {
        #region contructor
        public ActivationNetworkBase(Accord.Neuro.IActivationFunction function, int inputneurons, int[] hiddenlayers)
        {
            CreateNetwork(function, inputneurons, hiddenlayers);

            CreateTeacher();

        }
        #endregion

        #region private methods
        void CreateNetwork(Accord.Neuro.IActivationFunction function, int inputneurons, int[] hiddenlayers)
        {
            _Network = new Accord.Neuro.ActivationNetwork(function, inputneurons, hiddenlayers);
            _InputNeurons = inputneurons;
        }
        void CreateTeacher()
        {
            Accord.Neuro.ActivationNetwork net = (Accord.Neuro.ActivationNetwork)_Network;
           _Teacher = new Accord.Neuro.Learning.ParallelResilientBackpropagationLearning(net);
        }
        #endregion

        #region abstract methods
        protected override abstract void Convert(double[][] source_ohlcv, out double[][] input, out double[][] output);
        #endregion
    }
}
