using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Model
    {
        private List<string> stringNumbers = new List<string>();

        public List<string> TempNumbers
        {
            get { return stringNumbers; }
            set { stringNumbers = value; }
        }

        private List<float> floatNumbers = new List<float>();

        public List<float> CalcNumbers
        {
            get { return floatNumbers; }
            set { floatNumbers = value; }
        }

        private char calcChoice;

        public char Operator
        {
            get { return calcChoice; }
            set { calcChoice = value; }
        }
    }
}
