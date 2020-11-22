using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Addition _add = new Addition();
        private Subtraction _remove = new Subtraction();
        private Multiplication _multiplicate = new Multiplication();
        private Division _divide = new Division();
        private Exponentiation _powerOf = new Exponentiation();
        private SquareRoot _sqrt = new SquareRoot();
        private Model model = new Model();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method listens to NumberButtonClick and inserts in this case a number to the Input Textfield. It also changes a Boolean to true for use in other methods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                var value = button.Content;
                switch (value)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        Input.Text += button.Content;
                        model.isNumberUsed = true;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// The SpecialButtonClick listens for any special actions by the user. This can be whether the user wants to clear the input field, 
        /// change the number to negative or simply calculate the result. There are also a bunch of different Booleans in place in order to 
        /// limit the user from entering illegal input which otherwise would make the program crash. If all the Booleans have the correct value,
        /// then the input textfield would the corresponding information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecialButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "CE":
                        Input.Text = "";
                        model.OperatorPicked = false;
                        model.SpecialOperatorPicked = false;
                        model.isNumberUsed = false;
                        model.CommaUsed = false;
                        break;
                    case ".":
                        if (!model.CommaUsed)
                        {
                            model.CommaUsed = true;
                            Input.Text += ",";
                        }
                        break;
                    case "+/−":
                        if (String.IsNullOrEmpty(Input.Text))
                        {
                            Input.Text += "-";
                        }
                        else if ((model.OperatorPicked || model.SpecialOperatorPicked) && !model.isNumberUsed)
                        {
                            Input.Text += "-";
                        }
                        break;
                    case "=":
                        if (!String.IsNullOrEmpty(Input.Text))
                        {
                            if ((model.OperatorPicked || model.SpecialOperatorPicked) && model.isNumberUsed)
                            {
                                SaveList(ConvertToDoubleList(SplitString(model.Operator)));
                                CalculateResult();
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// The final button is for operations. It works by checking which kind of operation was entered first and then executing 
        /// corresponding code. The method first checks for special cases and then normal operations. This is to avoid crashes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperandButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "√":
                        if (String.IsNullOrEmpty(Input.Text))
                        {
                            model.Operator = '√';
                            Input.Text += button.Content;
                            model.OperatorPicked = true;
                            model.SpecialOperatorPicked = true;
                        }
                        break;
                    default:
                        break;
                }

                if (!String.IsNullOrEmpty(Input.Text))
                {
                    if (!(Input.Text[Input.Text.Length - 1] == '.'))
                    {
                        if (model.isNumberUsed == true)
                        {
                            switch (button.Content)
                            {
                                case "+":
                                    model.Operator = '+';
                                    Input.Text += button.Content;
                                    break;
                                case "−":
                                    model.Operator = '−';
                                    Input.Text += button.Content;
                                    break;
                                case "×":
                                    model.Operator = '×';
                                    Input.Text += button.Content;
                                    break;
                                case "÷":
                                    model.Operator = '÷';
                                    Input.Text += button.Content;
                                    break;
                                case "^":
                                    if (!String.IsNullOrEmpty(Input.Text))
                                    {
                                        model.Operator = '^';
                                        Input.Text += button.Content;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            SetBooleans();
                        }
                    }
                }

            }
        }

        /// <summary>
        /// CalculateResult is the bread and butter of this calculator. It takes all the parts of the input field and evaluates it. 
        /// If a result is undefined or imaginary an error is "thrown" and also tells the user what kind of illegal action it took.
        /// Aside from this the method calculates the corresponding operations based on the input provided from the user.
        /// While the calculator cannot handle chain additon or chain multiplication (as that requires the shunting yard
        /// algorithm for more complex operations, eg. 3+2*6), it uses ANS as the next value if the user needs to use the result for something else.
        /// In that sense you CAN do chain addition or chain multiplication, but you cannot execute several different operations at the same time.
        /// </summary>
        private void CalculateResult()
        {
            double result = 0;
            var number1 = model.CalcNumbers[0];
            if (model.SpecialOperatorPicked == true)
            {
                switch (model.Operator)
                {
                    case '√':
                        Boolean isNumberNegative = number1 < 0;
                        if (isNumberNegative)
                        {
                            result = 0; //As result becomes an imaginary double
                            MessageBox.Show("NaN", "Error");
                        }
                        else
                        {
                            result = _sqrt.PowerOf(number1, 0.5);
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (model.OperatorPicked)
            {
                var number2 = model.CalcNumbers[1];

                switch (model.Operator)
                {
                    case '+':
                        result = _add.Add(number1, number2);
                        break;
                    case '−':
                        result = _remove.Add(number1, number2);
                        break;
                    case '×':
                        result = _multiplicate.Multiplicate(number1, number2);
                        break;
                    case '÷':
                        if (number2 == 0)
                        {
                            result = 0; //Result becomes an undefined answer
                            MessageBox.Show("Undefined", "Error");
                        }
                        else
                        {
                            result = _divide.Multiplicate(number1, number2);
                        }
                        break;
                    case '^':
                        result = _powerOf.PowerOf(number1, number2);
                        break;
                    default:
                        break;
                }
            }
            DisplayResult(result);
        }

        private string[] SplitString(char operation)
        {
            string text = Input.Text;
            string[] splittedNumers = text.Split(operation);
            return splittedNumers;
        }

        /// <summary>
        /// Depending on what kind of operation that has been chosen, the converting changes slightly. The idea is that for special operators you can pick and 
        /// choose exactly what kind of items you need for that operation, while normal operations such as addition can simply use a for-loop.
        /// This is for future expandability.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private List<double> ConvertToDoubleList(string[] numbers)
        {
            List<double> doubleNumbers = new List<double>();
            if (model.SpecialOperatorPicked)
            {
                switch (model.Operator)
                {
                    case '√':
                        doubleNumbers.Add(Convert.ToDouble(numbers[1]));
                        break;
                }
                return doubleNumbers;
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == ",") //This one and the one below are special cases, their value means nothing, but the program cannot interpret it.
                    {
                        doubleNumbers.Add(0);
                    }
                    else if (numbers[i] == "-,")
                    {
                        doubleNumbers.Add(0);
                    }
                    else
                    {
                        doubleNumbers.Add(Convert.ToDouble(numbers[i]));
                    }
                }
                return doubleNumbers;
            }
        }

        private void DisplayResult(double result)
        {
            Input.Text = result.ToString(); //Shared I/O
            if (model.CommaUsed)
            {
                ResetValues();
            }
            else
            {
                ResetValues();
                model.CommaUsed = true;
            }

        }

        private void SaveList(List<double> numbers)
        {
            model.CalcNumbers.AddRange(numbers);
        }

        private void SetBooleans()
        {
            model.CommaUsed = false;
            model.OperatorPicked = true;
            model.isNumberUsed = false;
        }

        private void ResetValues()
        {
            model.CalcNumbers = new List<double>();
            model.OperatorPicked = false;
            model.SpecialOperatorPicked = false;
        }
    }
}




