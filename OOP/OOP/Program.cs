using System;
using System.Linq;
using System.Reflection.Metadata;

namespace OOP
{
    class Program
    {
        public Customer customer = new Customer();
        

        static void Main(string[] args)
        {
            Program con = new Program();

            con.AddCustomer();
            con.MakeAnOrder();
            con.CurrentOrder();
        }

        private void AddCustomer()
        {
            Console.WriteLine("Please enter your name");
            customer._name = Console.ReadLine();
        }
        

        private void MakeAnOrder()
        {
            Boolean madeOrder = false;

            while (!madeOrder)
            {
                var choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "milk":
                        var milk = new Milk();<<
                        customer._orders.Add(milk);
                        break;
                    case "butter":
                        var butter = new Butter();
                        customer._orders.Add(butter);
                        break;

                    case "water":
                        var water = new Water();
                        customer._orders.Add(water);
                        break;

                    case "exit":
                        madeOrder = true;
                        break;
                    default:
                        break;
                }
            }
           
        }

        private void CurrentOrder()
        {
            Console.WriteLine("Hello " + customer._name + "!");
            foreach (var item in customer._orders)
            {
                item.product();
            }
            Environment.Exit(0);
        }
    }
}
