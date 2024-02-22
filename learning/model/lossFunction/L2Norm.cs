using System.Diagnostics;
namespace learning.model.lossFunction
{
	public class L2Norm : ILossFunction
	{
		public L2Norm()
		{
		}

		double ILossFunction.CalculateLoss(double[] actualOut, double[] targetOut)
        {
			var squareDifferences = from i in Enumerable.Range(0, actualOut.Length) select Math.Pow(actualOut[i] - targetOut[i], 2);
			return squareDifferences.Sum();
        }
    }
}

