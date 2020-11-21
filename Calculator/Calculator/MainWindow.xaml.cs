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
                        TextField.Text += button.Content;
                        model.isNumberUsed = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SpecialButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "CE":
                        TextField.Text = "";
                        model.OperatorPicked = false;
                        break;
                    case ".":
                        
                            if (!model.CommaUsed)
                            {
                                model.CommaUsed = true;
                                TextField.Text += ",";
                            }
                        
                        break;
                    case "+/−":
                        if (String.IsNullOrEmpty(TextField.Text))
                        {
                            TextField.Text += "-";
                        }
                        else if(model.OperatorPicked || model.SpecialOperatorPicked)
                        {
                            TextField.Text += "-";
                        }
                        break;
                    case "=":
                        if (!String.IsNullOrWhiteSpace(TextField.Text))
                        {
                            if ((model.OperatorPicked && model.isNumberUsed) || (model.SpecialOperatorPicked && model.isNumberUsed))
                            {
                                SaveList(ConvertToDoubleList(SplitString(model.Operator)));
                                CalculateResult();
                            }
                        }
                        break;
                }
            }
        }


        private void OperandButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                if (!model.OperatorPicked)
                {

                    switch (button.Content)
                    {
                        case "√":
                            if (String.IsNullOrEmpty(TextField.Text))
                            {
                                model.Operator = '√';
                                TextField.Text += button.Content;
                                model.OperatorPicked = true;
                                model.SpecialOperatorPicked = true;
                                model.CommaUsed = false;
                            }
                            break;
                        default:
                            break;
                    }

                    if (!String.IsNullOrEmpty(TextField.Text))
                    {
                        if (!(TextField.Text[TextField.Text.Length - 1] == '.'))
                        {
                            switch (button.Content)
                            {
                                case "+":
                                    model.Operator = '+';
                                    TextField.Text += button.Content;
                                    break;
                                case "-":
                                    model.Operator = '-';
                                    TextField.Text += button.Content;
                                    break;
                                case "×":
                                    model.Operator = '×';
                                    TextField.Text += button.Content;
                                    break;
                                case "÷":
                                    model.Operator = '÷';
                                    TextField.Text += button.Content;
                                    break;
                                case "^":
                                    if (!String.IsNullOrEmpty(TextField.Text))
                                    {
                                        model.Operator = '^';
                                        TextField.Text += button.Content;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            setBooleans();
                        }
                    }
                }
            }
        }

        private void CalculateResult()
        {
            double result = 0;
            var number1 = model.CalcNumbers[0];
            if (model.SpecialOperatorPicked == true)
            {
                switch (model.Operator)
                {
                    case '√':
                        result = _sqrt.PowerOf(number1, 0.5);
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
                        TextField.Text += 1;
                        break;
                    case '-':
                        result = _remove.Add(number1, number2);
                        TextField.Text += 1;
                        break;
                    case '×':
                        result = _multiplicate.Multiplicate(number1, number2);
                        TextField.Text += 1;
                        break;
                    case '÷':
                        result = _divide.Multiplicate(number1, number2);
                        TextField.Text += 1;
                        break;
                    case '^':
                        result = _powerOf.PowerOf(number1, number2);
                        TextField.Text += 1;
                        break;
                    default:
                        break;
                }
            }
            DisplayResult(result);
        }

        private string[] SplitString(char operation)
        {
            string text = TextField.Text;
            string[] splittedNumers = text.Split(operation);
            return splittedNumers;
        }

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
                    if(numbers[i] == ",")
                    {
                        doubleNumbers.Add(0);
                    }
                    else{
                        doubleNumbers.Add(Convert.ToDouble(numbers[i]));
                    }                }
                return doubleNumbers;
            }

        }

        private void DisplayResult(double result)
        {
            TextField.Text = result.ToString();
            resetValues();
        }

        private void SaveList(List<double> numbers)
        {
            model.CalcNumbers.AddRange(numbers);
        }

        private void setBooleans()
        {
            model.CommaUsed = false;
            model.OperatorPicked = true;
            model.isNumberUsed = false;
        }

        private void resetValues()
        {
            model.CalcNumbers = new List<double>();
            model.CommaUsed = false;
            model.OperatorPicked = false;
            model.SpecialOperatorPicked = false;

        }
    }
}




