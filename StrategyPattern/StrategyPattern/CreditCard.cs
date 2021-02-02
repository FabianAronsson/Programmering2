using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class CreditCard : IPaymentInterface
    {
        public void Payment(double cost)
        {
            //potential properties such as card number and expiry date could be added
            Console.WriteLine("The customer paid " + cost + "SEK using credit card");
        }
    }
}
