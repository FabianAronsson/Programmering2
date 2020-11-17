using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Operators
    {
    }

    class Multiplication : Operators
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
    class Addition : Operators
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

    class Exponention : Operators
    {
        public virtual double PowerOf(double num1, double num2)
        {
            double result = Math.Pow(num1, num2);
            return result;
        }
    }
    class SquareRoot : Exponention
    {
        public override double PowerOf(double number1, double number2)
        {

            return (base.PowerOf(number1, number2));
        }
    }
}
