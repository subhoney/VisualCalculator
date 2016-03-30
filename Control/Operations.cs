using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualJoshulator.Control
{
    class Operations
    {

        //All operations in this class are bogus. 
        public static double Add(double val1, double val2)
        {
            return val1 + val2; 
        }
        
        public static double Subtract(double val1, double val2)
        {
            return val1 - val2;
        }
        public static double Mod(double val1, double val2)
        {
            return val1 % val2;
        }
        public static double Pow(double val1, double val2)
        {
            return Math.Pow(val1, val2); 
        }
        public static double Divide(double val1, double val2)
        {
            double result = 0; 
            try
            {
               result = val1 / val2;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message.ToString()); 
            }
            return result;
        }
    }
}
