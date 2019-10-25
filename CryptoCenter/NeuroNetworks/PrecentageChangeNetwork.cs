using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.NeuroNetworks
{
    public class PrecentageChangeNetwork : Base.ActivationNetworkBase 
    {
        #region constructor
        public PrecentageChangeNetwork(int inputneurons, int advanceintervall) : base(new Accord.Neuro.IdentityFunction(), inputneurons, new int[] { 50, 40, 30, 20, 10, 1})
        {
            AdvanceIntervall = advanceintervall;
        }
        #endregion

        #region base methods
        protected override void Convert(double[][] source_ohlcv, out double[][] input, out double[][] output)
        {
            int inputperitem = source_ohlcv.FirstOrDefault().Count();
            List<double[]> _input = new List<double[]>();
            List<double[]> _output = new List<double[]>();

            for(int i = 0; i < source_ohlcv.Count() - _InputNeurons - AdvanceIntervall; i++)
            {
                List<double> _neuronlist = new List<double>();
                List<double> _followlist = new List<double>();

                for(int y = i; y < i + (_InputNeurons / inputperitem); y++)
                {
                    for (int z = 0; z < inputperitem; z++)
                    {
                        _neuronlist.Add(source_ohlcv[y][z]);
                    }
  
                }

                for (int x = i + _InputNeurons; x < i + _InputNeurons + AdvanceIntervall; x++)
                {
                    _followlist.Add(source_ohlcv[x][1]);
                }

                _input.Add(_neuronlist.ToArray());

                _output.Add(_followlist.ToArray());

            }

            input = _input.ToArray();
            output = _output.ToArray();
        }

        public override void Test()
        {
            TestResult.Clear();
            TestExpected.Clear();

            int testlength = _TestInput.Length;
            for (int i = 0; i < testlength; i++)
            {
                double[] computed = Compute(_TestInput[i]);
                //double[] result = new double[] { computed[0], computed[1], _TestInput[i][4] };
                double[] result = new double[] { computed[0], _TestInput[i][1] };
                TestResult.Add(result);
                TestExpected.Add(_TestOutput[i]);
            }
        }
        #endregion

        #region private methods
 
        #endregion

        #region properties
        public int AdvanceIntervall { get; set; }
        #endregion
    }
}