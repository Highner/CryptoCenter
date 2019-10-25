using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNTK;



namespace CryptoCenter.Model.BitThought
{
    public static class BitThoughtFactory
    {
        public static Function CreateModel(Variable input, int outDim, int LSTMDim, int cellDim, DeviceDescriptor device, string outputName)
        {

            Func<Variable, Function> pastValueRecurrenceHook = (x) => CNTKLib.PastValue(x);

            //creating LSTM cell for each input variable
            Function LSTMFunction = LSTMSequenceClassifier.LSTMPComponentWithSelfStabilization<float>(
                input,
                new int[] { LSTMDim },
                new int[] { cellDim },
                pastValueRecurrenceHook,
                pastValueRecurrenceHook,
                device).Item1;

            //after the LSTM sequence is created return the last cell in order to continue generating the network
            Function lastCell = CNTKLib.SequenceLast(LSTMFunction);

            //implement drop out for 10%
            var dropOut = CNTKLib.Dropout(lastCell, 0.2, 1);

            //create last dense layer before output
            var outputLayer = TestHelper.FullyConnectedLinearLayer(dropOut, outDim, device, outputName);
            
            return outputLayer;
        }

        static float[] asBatch(float[][] data, int start, int count)
        {
            var lst = new List<float>();
            for (int i = start; i < start + count; i++)
            {
                if (i >= data.Length)
                    break;

                lst.AddRange(data[i]);
            }
            return lst.ToArray();
        }

        static IEnumerable<Tuple<float[], float[]>> nextBatch(float[][] X, float[][] Y, int mMSize)
        {

            for (int i = 0; i <= X.Length - 1; i += mMSize)
            {
                var size = X.Length - i; if (size > 0 && size > mMSize)
                    size = mMSize;

                var x = asBatch(X, i, size);
                var y = asBatch(Y, i, size);

                var ret = new Tuple<float[], float[]>(x, y);
                yield return ret;
            }
        }


    }


}
