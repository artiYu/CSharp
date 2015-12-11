using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcMaxi
{
    class ParseSimpleMode : Form
    {
        #region Fields
        Stack<double> stackOperands = new Stack<double>();
        string currentOperation;
        Calculation calc = new Calculation();
        #endregion

        #region Methods
        public string PerformParse(string bText, string tbText)
        {
            string result = "";

            //% = +-*/ √ ± . ←
            if (bText.Length == 1)
            {
                if (bText == "=")
                {
                    double operand = double.Parse(tbText);
                    stackOperands.Push(operand);
                    result = PerformCalc().ToString();
                }
                
                else if (bText.IndexOfAny("+-/*".ToCharArray()) >= 0)
                {
                    double operand = double.Parse(tbText);
                    stackOperands.Push(operand);
                    currentOperation = bText;
                }

                else if (bText.IndexOfAny("√±".ToCharArray()) >= 0)
                {
                    result = PerformCalc().ToString();
                }
            }

            else
            {

            }

            return result;
        }

        private double PerformCalc()
        {
            calc.SetOperands(currentOperation, stackOperands);
            return calc.performOperation();
        }
        #endregion
    }
}
