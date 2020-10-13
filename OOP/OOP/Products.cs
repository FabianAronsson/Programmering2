using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Products
    {
        public virtual void product()
        {
            Console.WriteLine("Product");
        }
    }

    class Water : Products
    {
        public override void product()
        {
            Console.WriteLine("Water");
        }
    }

    class Butter : Products
    {
        public override void product()
        {
            Console.WriteLine("Butter");
        }
    }

    class Milk : Products
    {
        public override void product()
        {
            Console.WriteLine("Milk");
        }
    }
}
