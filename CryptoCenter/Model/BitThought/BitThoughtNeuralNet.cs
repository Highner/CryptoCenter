using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNTK;
using RNNSharp;

namespace CryptoCenter.Model.BitThought
{
    class BitThoughtNeuralNet
    {

        #region constructor
        public BitThoughtNeuralNet(int inDim, int outDim, int LSTMDim, int cellDim, string featuresName, string labelsName)
        {
            // build the model
            var feature = Variable.InputVariable(new int[] { inDim }, DataType.Float, featuresName, null, false);
            var label = Variable.InputVariable(new int[] { outDim }, DataType.Float, labelsName, new List<CNTK.Axis>() { CNTK.Axis.DefaultBatchAxis() }, false);

            var device = DeviceDescriptor.CPUDevice;

            var lstmModel = BitThoughtFactory.CreateModel(feature, outDim, LSTMDim, cellDim, device, "timeSeriesOutput");

            

            Function trainingLoss = CNTKLib.SquaredError(lstmModel, label, "squarederrorLoss");
            Function prediction = CNTKLib.SquaredError(lstmModel, label, "squarederrorEval");


            // prepare for training
            TrainingParameterScheduleDouble learningRatePerSample = new TrainingParameterScheduleDouble(0.0005, 1);
            TrainingParameterScheduleDouble momentumTimeConstant = CNTKLib.MomentumAsTimeConstantSchedule(256);

            IList<Learner> parameterLearners = new List<Learner>() {
            Learner.MomentumSGDLearner(lstmModel.Parameters(), learningRatePerSample, momentumTimeConstant, /*unitGainMomentum = */true)  };

            //create trainer
            Trainer = Trainer.CreateTrainer(lstmModel, trainingLoss, prediction, parameterLearners);
            

        }
        #endregion

        #region properties
        public CNTK.Trainer Trainer;
        #endregion
    }
}
