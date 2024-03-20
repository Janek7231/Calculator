using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ResultText.Text = string.Empty;
            CurrentOperationText.Text = string.Empty;
            
        }
        int calc = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            var button = sender as Button;
            var currenNumber = button.Name[button.Name.Length - 1];
            var lastButOne = button.Name[button.Name.Length - 2];

            if (lastButOne == '0')
            {
                CurrentOperationText.Text += '0';
            }
            CurrentOperationText.Text += currenNumber;

            if(calc != 0)
            {
                var operation = CurrentOperationText.Text;
                ResultText.Text = CalculateResult(operation).ToString();
            }
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperatioin(operation) && calc != 0)
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "/";
        }

        private void ButtonMuyltiply_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperatioin(operation) && calc != 0)
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "x";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperatioin(operation) && calc != 0)
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "-";
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if(ContainsOperatioin(operation) && calc != 0)
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "+";
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += ",";
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            ResultText.Text = CalculateResult(operation).ToString();
            //CurrentOperationText.Text = string.Empty;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text = string.Empty;
            ResultText.Text = string.Empty;
            calc = 0;
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "%";
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            var tempOperationText = string.Empty;
            if(CurrentOperationText.Text != string.Empty)
            {
                calc = 0;
            }
            if(CurrentOperationText.Text.Length > 0)
            {
                tempOperationText = CurrentOperationText.Text.Substring(0, CurrentOperationText.Text.Length - 1);
                CurrentOperationText.Text = tempOperationText;

            }
        }

        private string checkingPercent(string element)
        {
            if (element.Contains('%') && element[element.Length-1] == '%')
            {
                string Telement = element.Substring(0, element.Length - 1);

                double result1 = double.Parse(Telement) / 100;
                Telement = result1.ToString();
                return Telement;
            }
            return element;
        }

        private double CalculateResult(string operation)
        {
            calc += 1;
            double result = 0;
            if (operation[0] != '-')
            {
                if (operation.Contains('+'))
                {
                    var elements = operation.Split('+');
                    result = double.Parse(checkingPercent(elements[0])) + double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('-'))
                {
                    var elements = operation.Split('-');
                    result = double.Parse(checkingPercent(elements[0])) - double.Parse(checkingPercent(elements[1]));

                }
                else if (operation.Contains('x'))
                {
                    var elements = operation.Split('x');
                    result = double.Parse(checkingPercent(elements[0])) * double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('/'))
                {
                    var elements = operation.Split('/');
                    result = double.Parse(checkingPercent(elements[0])) / double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('%'))
                {
                    var result1 = result / 100;
                    result = result1;
                }
            } else
            {
                operation = operation.Remove(0, 1);

                if (operation.Contains('+'))
                {
                    var elements = operation.Split('+');
                    result = (-double.Parse(checkingPercent(elements[0]))) + double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('-'))
                {
                    var elements = operation.Split('-');
                    result = (-double.Parse(checkingPercent(elements[0]))) - double.Parse(checkingPercent(elements[1]));

                }
                else if (operation.Contains('x'))
                {
                    var elements = operation.Split('x');
                    result = (-double.Parse(checkingPercent(elements[0]))) * double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('/'))
                {
                    var elements = operation.Split('/');
                    result = (-double.Parse(checkingPercent(elements[0]))) / double.Parse(checkingPercent(elements[1]));
                }
                else if (operation.Contains('%'))
                {
                    var result1 = result / 100;
                    result = -result1;
                }
            }
            var separators = new[] { '-','x','/','+' };
            bool sep = false;
            foreach (char separator in separators)
            {
                if (operation.Contains(separator))
                {
                    sep = true;
                }
            }
            if (operation.Contains('%') && sep == false)
            {
                result = double.Parse(checkingPercent(operation));
            }


            return Math.Round(result,4);
        }

        private bool ContainsOperatioin(string operation)
        {
            return operation.Contains("+") || operation.Contains("-") || operation.Contains("x") || operation.Contains("/");
        }


    }
}