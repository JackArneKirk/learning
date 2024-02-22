using System;
namespace learning.model.activationFunction
{
	public interface ActivationFunction
	{
		double function(double x);
		double derivative(double x);
	}
}

