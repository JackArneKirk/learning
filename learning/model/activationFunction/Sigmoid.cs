using System;
namespace learning.model.activationFunction
{
	public class Sigmoid : ActivationFunction
	{
		public Sigmoid()
		{
            Console.WriteLine("new Sigmoid instance made");
		}

        public double function(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double derivative(double x)
        {
            return function(x) * (1 - function(x));
        }
    }
}

