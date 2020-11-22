using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Operators //Sample class for categorization
    {
    }

    /// <summary>    
    /// Essentially each class works by utilizing polymorphism, except the original classes. These are Additon, Multiplication and Exponentiation.
    /// The reason for this is because the other operations are the inverse of each other. 
    /// </summary>
    class Multiplication 
    {
        public virtual double Multiplicate(double number1, double number2)
        {
            double result = (number1 * number2);
            return result;
        }
    }

    class Division : Multiplication
    {
        public override double Multiplicate(double number1, double number2)
        {
            return (base.Multiplicate(number1, (1 / number2)));
        }
    }

    class Addition
    {
        public virtual double Add(double number1, double number2)
        {
            double result = (number1 + number2);
            return result;
        }
    }

    class Subtraction : Addition
    {
        public override double Add(double number1, double number2)
        {
            return (base.Add(number1, -number2));
        }
    }

    class Exponentiation
    {
        public virtual double PowerOf(double num1, double num2)
        {
            double result = Math.Pow(num1, num2);
            return result;
        }
    }

    class SquareRoot : Exponentiation
    {
        public override double PowerOf(double number1, double number2)
        {

            return (base.PowerOf(number1, number2));
        }
    }
}
