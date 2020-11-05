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

namespace Numpad
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
            if(sender is Button button)
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
                        model.Operator.Add('+');
                        break;
                    case "-":
                        model.Numbers.Add(Int32.Parse(TextField.Text));
                        model.Operator.Add('-');
                        break;
                    case "EXE":

                        if(model.Numbers.Count > 1)
                        {
                            var result = 0;
                            for (int i = 0; i < model.Numbers.Count; i++)
                            {
                                
                                var operators = model.Operator[i];
                                result += model.Numbers[i] operators model.Numbers[i + 1];

                            }

                        }
                        break;
                    default:
                        break;
                }
            }
        }


        
    }
}
