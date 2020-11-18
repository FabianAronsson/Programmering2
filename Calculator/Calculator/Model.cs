using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Model
    {
        private List<double> Numbers = new List<double>();

        public List<double> CalcNumbers
        {
            get { return Numbers; }
            set { Numbers = value; }
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

        private bool specialOperator;

        public bool SpecialOperatorPicked
        {
            get { return specialOperator; }
            set { specialOperator = value; }
        }

    }
}
