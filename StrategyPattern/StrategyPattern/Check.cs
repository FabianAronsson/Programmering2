using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class Check : IPaymentInterface
    {
        public void Payment(double cost)
        {
            Console.WriteLine("The customer paid " + cost + "SEK using a check");
        }
    }
}
