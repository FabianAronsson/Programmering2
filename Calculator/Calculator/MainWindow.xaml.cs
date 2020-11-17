using System;
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
            Operators operators = new Operators();
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
                    default:
                        break;
                }
                   if (!model.OperatorPicked)
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
                        case "√":
                            if (String.IsNullOrEmpty(TextField.Text))
                            {
                                TextField.Text += button.Content;
                            }
                            break;
                        case "^":
                            if (String.IsNullOrEmpty(TextField.Text))
                            {
                                //Do nothing
                            }
                            else
                            {
                                TextField.Text += button.Content;
                            }
                            break;
                        case "CE":
                            TextField.Text = "";
                            break;

                        default:
                            break;
                    }
                }
                    switch (button.Content)
                    {
                        case "=":
                            if (String.IsNullOrEmpty(TextField.Text))
                            {
                                if (!(model.Operator == '^') || !(model.Operator == '√'))
                                {
                                    SplitString(TextField.Text);
                                }


                            }
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }

        private string[] SplitString(string text)
        {
            var splittedNumers = TextField.Text.Split(text);

            return splittedNumers;
        }
    }


