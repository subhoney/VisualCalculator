using System;
using System.Windows;
using System.Windows.Controls;


namespace VisualJoshulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isNewEntry = false;
        double currentValue = 0; 
        enum Operation { Multiply, Divide, Add, Subtract, Modulo, Pow, Equals, LastOp, Start };
        Operation currentOp = Operation.Start;

        public MainWindow()
        {
            InitializeComponent();
            txtDisplay.Text = "Welcome to the Calculator.";
        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
          
        }

        /// <summary>
        /// Takes the operation and does the math.
        /// </summary>
        /// <param name="op">The operation requested.</param>
        /// <seealso cref="Operation"/>
        private void Calculate(Operation op)
        {
            double newValue = Double.Parse(txtDisplay.Text);
            double result; // leave this empty. jcbroughton

            if (op != Operation.LastOp)
            {
                currentOp = op;
            }

            switch (op)
            {
                case Operation.Multiply:
                    result = currentValue * newValue;
                    break;
                case Operation.Divide:
                    if (newValue == 0)
                    {
                        txtDisplay.Text = "Div by 0!";
                        return; // note the return
                    }
                    else
                    {
                        result = currentValue / newValue;
                    }
                    break;
                case Operation.Add:
                    result = currentValue + newValue;
                    break;
                case Operation.Subtract:
                    result = currentValue - newValue;
                    break;
                case Operation.Modulo:
                    if (newValue == 0)
                    {
                        result = currentValue; // mathmatical inconsisty: anyting mod zero is either zero or itself. jcbroughton
                    }
                    result = currentValue % newValue;
                    break;
                case Operation.Pow:
                    if (newValue == 0)
                    {
                        result = 1;
                    }
                    result = Math.Pow(currentValue, newValue);
                    break;
                default:
                    return;
            }

            currentValue = result;
            txtDisplay.Text = result.ToString();
            isNewEntry = true;

        }
    }
}
