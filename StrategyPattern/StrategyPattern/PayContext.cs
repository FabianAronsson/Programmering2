using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class PayContext
    {
        private IPaymentInterface _strategy;

        public void setStrategy(IPaymentInterface strategy)
        {
            this._strategy = strategy;
        }

        public void pay(double cost)
        {
            _strategy.Payment(cost);
        }
    }
}
