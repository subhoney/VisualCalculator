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
using VisualJoshulator.Control;
using VisualJoshulator.Model;


namespace VisualJoshulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Operations { Multiply, Divide, Add, Subtract, Modulo, Pow, Equals, LastOp, Start }; 
        public MainWindow()
        {
            InitializeComponent();  
        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
