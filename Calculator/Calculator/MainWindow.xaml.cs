using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void ButtonClick(object sender, RoutedEventArgs e)
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
                        break;
                    case "CE":
                        TextField.Text = "";
                        model.OperatorPicked = false;
                        break;
                    case ".":
                        if (!(TextField.Text[TextField.Text.Length - 1] == model.Operator))
                        {
                            TextField.Text += ".";
                        }
                        break;
                    case "=":
                        if (!String.IsNullOrWhiteSpace(TextField.Text))
                        {
                            ConvertToDoubleList(SplitString(model.Operator));
                            CalculateResult();
                        }
                        break;
                    default:
                        break;
                }
                    if (!model.OperatorPicked )
                    {
                        switch (value)
                        {
                            case "√":
                                if (!String.IsNullOrEmpty(TextField.Text))
                                {
                                    model.Operator = '√';
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    model.SpecialOperatorPicked = true;
                                }
                                break;
                            default:
                                break;
                        }
                    if (!String.IsNullOrEmpty(TextField.Text))
                        {
                            switch (value)
                            {
                                case "+":
                                    model.Operator = '+';
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "-":
                                    model.Operator = '-';
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                TextField.Text += "hej";
                                    break;
                                case "×":
                                    model.Operator = '×';
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "÷":
                                    model.Operator = '÷';
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "^":
                                    if (!String.IsNullOrEmpty(TextField.Text))
                                    {
                                        model.Operator = '^';
                                        TextField.Text += button.Content;
                                        model.OperatorPicked = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        
                        }   
                    }
                }
        }

        private void CalculateResult()
        {
            double result = 0;
            var number1 = model.CalcNumbers[0];
            var number2 = model.CalcNumbers[1];

            if (model.OperatorPicked)
            {
                

                switch (model.Operator)
                {
                    case '+':
                        result = _add.Add(number1, number2);
                        TextField.Text += 1;
                        break;
                    default:
                        break;
                }
            }
            else if(model.SpecialOperatorPicked == true)
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
            DisplayResult(result);
        }

        private string[] SplitString(char operation)
        {
            string text = TextField.Text;
            string[] splittedNumers = text.Split(operation);
            TextField.Text += splittedNumers;
            return splittedNumers;
        }

        private void DisplayResult(double result)
        {
            TextField.Text = result.ToString();
        }
        private List<double> ConvertToDoubleList(string[] numbers)
        {
            List<double> doubleNumbers = new List<double>();
            numbers.ToList();
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                doubleNumbers[i] = double.Parse(numbers[i]);
            }
            return doubleNumbers;
        }
        private void SaveList(List<double> numbers)
        {
            model.CalcNumbers = numbers;
        }
    }

}

        


