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
            textDisplay.Text = "Welcome to the Calculator.";
        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
