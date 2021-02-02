using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class Cash : IPaymentInterface
    {
        public void Payment(double cost)
        {
            Console.WriteLine("The customer paid " + cost + "SEK using cash");
        }
    }
}
