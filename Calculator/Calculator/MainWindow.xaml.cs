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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Model model = new Model();

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
                    case "=":
                        //if (String.IsNullOrWhiteSpace(TextField.Text))
                        
                            CalculateResult(ConvertToDoubleArray(SplitString(model.Operator)));
                        
                        break;
                    default:
                        break;
                }
                    if (!model.OperatorPicked)
                    {
                        if (!String.IsNullOrEmpty(TextField.Text))
                        {
                            switch (value)
                            {
                                case "+":
                                    model.Operator = "+";
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "-":
                                    model.Operator = "-";
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "×":
                                    model.Operator = "×";
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "÷":
                                    model.Operator = "÷";
                                    TextField.Text += button.Content;
                                    model.OperatorPicked = true;
                                    break;
                                case "^":
                                    if (!String.IsNullOrEmpty(TextField.Text))
                                    {
                                        model.Operator = "^";
                                        TextField.Text += button.Content;
                                        model.OperatorPicked = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }   
                            else
                            {
                            switch (value)
                            {
                                case "√":
                                    if (String.IsNullOrEmpty(TextField.Text))
                                    {
                                        model.Operator = "√";
                                        TextField.Text += button.Content;
                                        model.OperatorPicked = false;
                                        model.SpecialOperatorPicked = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

        private void CalculateResult(List<double> numbers)
        {
            Model model = new Model();

            var number1 = numbers[0];
            var number2 = numbers[1];
            double result = 0;

            if (model.OperatorPicked)
            {

            }
            else
            {
                switch (model.Operator)
                {
                    case "√":
                        result = _sqrt.PowerOf(numbers[0], 0.5);
                        break;
                    default:
                        break;
                }
            }
            DisplayResult(result);
        }

        private string[] SplitString(string text)
        {
            var splittedNumers = TextField.Text.Split(text);
            Console.WriteLine(splittedNumers);
            return splittedNumers;
        }

        private void DisplayResult(double result)
        {
            TextField.Text = result.ToString();
        }
        private List<double> ConvertToDoubleArray(string[] numbers)
        {
            List<double> doubleNumbers = new List<double>();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                doubleNumbers[i] = double.Parse(numbers[i]);
            }
            return doubleNumbers;
        }
    }

}

        


