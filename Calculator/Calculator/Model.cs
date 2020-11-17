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

        private List<double> floatNumbers = new List<double>();

        public List<double> CalcNumbers
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

        private Boolean operators;

        public Boolean OperatorPicked
        {
            get { return operators; }
            set { operators = value; }
        }

    }
}
