using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace learning.model
{
	public class Net
	{
		private int[] midLayerHeights;
		private int outputSize;
        private int inputSize;
		private Matrix<double>[] weights;

		private activationFunction.ActivationFunction activationFunction;
		private lossFunction.ILossFunction lossFunction;

        public Net(int[]layerHeights)
		{
			var M = Matrix<double>.Build;
			this.midLayerHeights = layerHeights[1..^1];
			this.outputSize = layerHeights[^1];
			this.inputSize = layerHeights[0];
			//initialisation of weights and necessary vectors
            this.weights = new Matrix[layerHeights.Length - 1];
			for(int i = 0; i < midLayerHeights.Length+1; i++)
			{
                weights[i] = M.Random(layerHeights[i], layerHeights[i + 1]); //Matrix<double>.Build.Random(layerHeights[i], layerHeights[i+1]);
				Debug.WriteLine("Matrix made: " + weights[i].ToString());
            }
			activationFunction = new activationFunction.Sigmoid();
			lossFunction = new lossFunction.L2Norm();
			Debug.WriteLine("loss of 3,4,5 and 3,5,9 should be 0, 1, 16 = 17 total. Actual: ");
            Debug.WriteLine(lossFunction.CalculateLoss(new double[]{ 3, 4, 5}, new double[]{ 3, 5, 9}));
			feedForward(new double[] { 1, 2, 3, 4, 4, 5, 6, 2, 9, 2, 3, 5, 4, 1, 1, 12, 2.009, 8, 8, 13});
        }

		public void feedForward(double[] input)
		{
			Matrix<double> inputMatrix = Matrix<double>.Build.Dense(1, input.Length, input);
            Debug.WriteLine("input matrix: " + inputMatrix);

            foreach (Matrix<double> weightMatrix in weights)
			{
				Debug.WriteLine("weight matrix: " + weightMatrix);
				inputMatrix = inputMatrix * weightMatrix;
				inputMatrix = inputMatrix.Map(x => activationFunction.function(x));
                Debug.WriteLine("resultant matrix: " + inputMatrix);
            }
			Debug.WriteLine("Multiplied! And resultant: " + inputMatrix.ToString());
		}

        public void backPropagate()
        {

        }
    }
}

