using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            double cost = 256.0; //for an actual usecase, a shopping cart with another interface could be useful. It would then work in similar fashion as this example does.
            while (true)
            {
                Console.WriteLine("Cost of product: " + cost + "SEK");
                Console.WriteLine("Choose payment type: Credit Card, Cash or Check.");
                Pay(cost, SelectPayment());
            }

        }

        public static string SelectPayment() //might be an unneccesary method, however, to make it clear what makes what I added this
        {
            return Console.ReadLine();
        }

        public static void Pay(double cost, string paymentType)
        {
            PayContext context = new PayContext();
            switch (paymentType)
            {
                case "Credit Card":
                    context.setStrategy(new CreditCard());
                    break;
                case "Cash":
                    context.setStrategy(new Cash());
                    break;
                case "Check":
                    context.setStrategy(new Check());
                    break;
                default: //cannot be bothered to only make it accept valid input, but could be implemented using return and null
                    Console.WriteLine("That is not a valid input.");
                    break;
            }
            context.pay(cost);
        }
    }
}
