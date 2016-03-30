using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualJoshulator.Model
{
    class CalculationFactory
    {
        private List<string> userInput;

        public List<string> UserInput
        {
            get
            {
                return userInput;
            }

            set
            {
                userInput = value;
            }
        }
    }
}
