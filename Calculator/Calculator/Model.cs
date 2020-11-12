using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Model
    {
        private List<int> numbers = new List<int>();

        public List<int> Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        private List<char> calcChoice;

        public List<char> Operator
        {
            get { return calcChoice; }
            set { calcChoice = value; }
        }
    }
}
