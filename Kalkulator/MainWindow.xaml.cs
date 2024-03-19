using System.Windows;
using System.Windows.Controls;

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
            string TempOperationText = string.Empty;
        }


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
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "/";
        }

        private void ButtonMuyltiply_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "x";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "-";
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "+";
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += ",";
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;
            //var tempOperation = operation;
            //if (operation.Contains('%'))
            //{
            //    var elements = tempOperation.Split('%');
            //    var result = double.Parse(elements[0]) / 100;
            //    tempOperation = result.ToString();
            //}

            //if (operation.Contains(','))
            //{
            //    var elements = operation.Split(',');
            //    string result = elements[0] + elements[1];

            //    ResultText.Text = result;
            //}


            ResultText.Text = CalculateResult(operation).ToString();
            CurrentOperationText.Text = string.Empty;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text = string.Empty;
            ResultText.Text = string.Empty;
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += "%";
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            var tempOperationText = string.Empty;
            if(CurrentOperationText.Text.Length > 0)
            {
                tempOperationText = CurrentOperationText.Text.Substring(0, CurrentOperationText.Text.Length - 1);
                CurrentOperationText.Text = tempOperationText;

            }
        }

        private double CalculateResult(string operation)
        {
            
            if (operation.Contains('+'))
            {
                var elements = operation.Split('+');
                return double.Parse(elements[0]) + double.Parse(elements[1]);
            }
            if (operation.Contains('-'))
            {
                var elements = operation.Split('-');
                return double.Parse(elements[0]) - double.Parse(elements[1]);
            }
            if (operation.Contains('x'))
            {
                var elements = operation.Split('x');
                return double.Parse(elements[0]) * double.Parse(elements[1]);
            }
            if (operation.Contains('/'))
            {
                var elements = operation.Split('/');
                return double.Parse(elements[0]) / double.Parse(elements[1]);
            }
            if (operation.Contains('*'))
            {
                var elements = operation.Split('*');
                return double.Parse(elements[0]) + double.Parse(elements[1]);
            }

            return 0;
        }
    }
}