using System;
using System.Linq;

namespace OOP
{
    class Program
    {
        public Customer customer = new Customer();
        public Products product = new Products();

        static void Main(string[] args)
        {
            Program con = new Program();

            con.AddCustomer();
            con.ShowProducts();
            con.MakeAnOrder();
            con.CurrentOrder();
        }

        private void AddCustomer()
        {
            Console.WriteLine("Please enter your name");
            customer._name = Console.ReadLine();
        }
        private void ShowProducts()
        {
            Console.WriteLine("This is our current fresh stock of fine milk.");
            Console.WriteLine(product._product);
        }

        private void MakeAnOrder()
        {
            bool madeOrder = false;
            Console.WriteLine("Would you like to order milk?");
            if(Console.ReadLine() == "yes")
            {
                customer._orders.Add(product._product);
            }
            else
            {
                Console.WriteLine("Either you did not want to order or you're being an idiot. \nPlease make an order! We need money");
                MakeAnOrder();
            }

            Console.WriteLine("Do you want to order more milk?");
            if(Console.ReadLine() == "yes")
            {
                while (!madeOrder)
                {
                    customer._orders.Add(product._product);
                    Console.WriteLine("More milk!");
                    Console.WriteLine("Do you want to order more milk? You currently have " + customer._orders.Count + " " + product._product + " in your cart.");
                    if (Console.ReadLine() == "no")
                    {
                        Console.WriteLine("Alright no more milk for you.");
                        madeOrder = true;  
                    }
                    
                }
            }
            else 
            {
                Console.WriteLine("No more milk for you.");
            }
           
        }
        private void CurrentOrder()
        {
            Console.WriteLine("Hello " + customer._name + "!");
            Console.WriteLine("Your current order is: \n" + customer._orders.Count + " " + product._product);
            Console.WriteLine("Would you like to make a purchase?");
            Environment.Exit(0);
        }
    }
}
