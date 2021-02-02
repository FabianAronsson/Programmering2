using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    interface IPaymentInterface
    {
        public void Payment(double cost);
    }
}
