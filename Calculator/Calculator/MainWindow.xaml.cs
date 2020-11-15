﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Model model = new Model();
            if (e.Source is Button button)
            {
                switch (button.Content)
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
                    case "+":
                        model.Numbers.Add(Int32.Parse(TextField.Text));
                        model.Operator = '+';
                        break;
                    case "-":
                        model.Numbers.Add(Int32.Parse(TextField.Text));
                        model.Operator = '-';
                        break;
                    case "EXE":

                        if (model.Numbers.Count > 1)
                        {
                            double result = 0;

                            if (model.Operator == '+')
                            {
                                result += Addition(model.CalcNumbers[0], model.Numbers[1]);
                            }
                            else if (model.Operator == '+')
                            {
                                result += Subtraction(model.Numbers[0], model.Numbers[1]);
                            }
                            else if (model.Operator == '+')
                            {
                                result += Multiplication(model.Numbers[0], model.Numbers[1]);
                            }
                            else if (model.Operator == '+')
                            {
                                result += Division(model.CalcNumbers[0], model.Numbers[1]);
                            }


                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private double Addition(double firstNumber, double secondNumber)
        {
            return (firstNumber + secondNumber);
        }

        private double Subtraction(double firstNumber, double secondNumber)
        {
            return (firstNumber - secondNumber);
        }

        private double Multiplication(double firstNumber, double secondNumber)
        {
            return (firstNumber * secondNumber);
        }

        private double Division(double firstNumber, double secondNumber)
        {
            return (firstNumber / secondNumber);
        }

        private double SquareRoot(double number)
        {
            double temp = number; 
            double result;
            for (int i = 0; i < 4; i++)
            {
                result = 0.5 * (temp + (number / temp));
                temp = result;
            }
            return temp;
        }

        private double PercentageOf(double number)
        {
            return (number / 100);
        }

    }
}

