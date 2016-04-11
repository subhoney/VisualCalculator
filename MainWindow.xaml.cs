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
        bool isNewEntry = true;
        double currentValue = 0;
        enum Operation { Multiply, Divide, Add, Subtract, Modulo, Pow, Equals, LastOp, Start };
        Operation currentOp = Operation.Start;

        public MainWindow()
        {
            InitializeComponent();
            txtDisplay.Text = currentValue.ToString();
        }

        /// <summary>
        /// Takes button entry args, parses. 
        /// </summary>
        /// <param name="sender">Self-ref.</param>
        /// <param name="routedArgs">The event arguments.</param>
        private void btnEntry_Click(object sender, RoutedEventArgs routedArgs)
        {
            //dummy value for trying to parse the entry string
            int result; // leave empty 

            //Get the value from the button label
            Button btn = (Button)sender;
            string value = btn.Content.ToString();

            //special handling for decimal point
            if (value.Equals("."))
            {
                if (isNewEntry)
                {
                    return;
                }
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text += value;
                    isNewEntry = false;
                }
                return;
            }

            //try to parse entry as int; 
            //if successful, append to current entry
            if (Int32.TryParse(value, out result))
            {
                if (isNewEntry || txtDisplay.Text.Equals("0"))
                {
                    txtDisplay.Text = "";
                }
                txtDisplay.Text += value;
                isNewEntry = false;
            }
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

            switch (currentOp)
            {
                case Operation.Multiply:
                    if (currentValue == 0)
                    {
                        result = newValue;
                    }
                    else
                    {
                        result = currentValue * newValue;
                    }
                    break;

                case Operation.Divide:
                    if (newValue == 0)
                    {
                        txtDisplay.Text = "#DIV/0";
                        return;
                    }
                    else if (currentValue == 0)
                    {
                        currentValue = newValue;
                        txtDisplay.Text = ""; // must be zero or empty string because of concatenation later in the calculator - jbroughton
                        return;
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
                    if (currentValue == 0)
                    {
                        currentValue = newValue;
                        txtDisplay.Text = ""; // must be zero or empty string because of concatenation later in the calculator - jbroughton
                        return;
                    }
                    else
                    {
                        result = currentValue % newValue;
                    }
                    break;

                case Operation.Pow:
                    if (currentValue == 0)
                    {
                        currentValue = newValue;
                        txtDisplay.Text = ""; // must be zero or empty string because of concatenation later in the calculator - jbroughton
                        return;
                    }
                    else
                    {
                        result = Math.Pow(currentValue, newValue);
                    }
                    break;

                default:
                    return;
            }

            currentValue = result;
            txtDisplay.Text = result.ToString();
            isNewEntry = true;
        }

        #region event handlers
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Add);
        }
        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Subtract);
        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Multiply);
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Divide);
        }
        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Pow);
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Modulo);
        }

        //Clear the current results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            isNewEntry = true;
        }

        //Handle the Equals button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.LastOp);
        }
        #endregion event handlers
    }
}
