using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace VisualJoshulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isNewEntry = true;
        List<Double> entries = new List<Double>();
        double currentValue = 0;
        enum Operation { Multiply, Divide, Add, Subtract, Modulo, Pow, Equals, LastOp, Start };
        Operation currentOp = Operation.Start;
        private double memValue = 0;
        private int signFlag = 0;
        private Operation enterOP = Operation.Start;

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
            signFlag = 0;

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
                if (isNewEntry)
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
            double result; // leave this empty. jcbroughton
            entries.Add(Double.Parse(txtDisplay.Text));
           


            if (entries.Count > 1)
            {
                
            
            if (op == Operation.LastOp)
            {
                    if (signFlag < 1)
                    {
                        memValue = entries[1];
                    }

                    entries.Insert(1, memValue);
                }    
                switch (enterOP)
                {
                    case Operation.Multiply:
                     
                            result = entries[0] * entries[1];
                        
                        break;

                    case Operation.Divide:
                        if (entries[1].Equals(0))
                        {
                            txtDisplay.Text = "#DIV/0";
                            return;
                        }
                        
                        else
                        {
                            result = entries[0] / entries[1];
                        }
                        break;

                    case Operation.Add:

                        result = entries[0] + entries[1];

                        break;
                    case Operation.Subtract:
                       

                            result = entries[0] - entries[1];
                        
                        break;

                    case Operation.Modulo:
                       
                            result = entries[0] % entries[1];
                        
                        break;

                    case Operation.Pow:
                       
                            result = Math.Pow(entries[0], entries[1]);
                        
                        break;

                    default:
                        return;
                }           
                txtDisplay.Text = result.ToString();
                isNewEntry = true;
                memValue = entries[1];
                entries.Clear();
                entries.Add(result);
                signFlag = 1;

            }
            else
            {
                isNewEntry = true;
                currentOp = op;
                signFlag = 1;
            } 
        }

        #region event handlers
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Add;

        }
        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
           
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Subtract;
        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Multiply;
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Divide;
        }
        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Pow;
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            
            if (signFlag < 1)
            {
                Calculate(enterOP);
            }
            enterOP = Operation.Modulo;
        }

        //Clear the current results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            isNewEntry = true;
            entries.Clear();
            signFlag = 0;
        }

        //Handle the Equals button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            Calculate(Operation.LastOp);

        }
        #endregion event handlers
    }
}