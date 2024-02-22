using System;
namespace learning.model.lossFunction
{
	public interface ILossFunction
	{
		double CalculateLoss(double[] actualOut, double[] targetOut);
	}
}

