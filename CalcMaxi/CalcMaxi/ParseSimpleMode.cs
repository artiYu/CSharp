using System.Collections.Generic;
using System.Windows.Forms;

namespace CalcMaxi
{
    class ParseSimpleMode : Form
    {
        #region Fields
        Stack<double> stackOperands = new Stack<double>();
        string currentOperation;
        Calculation calc = new Calculation();
        bool isFirstEqual = true;
        bool isBinaryOp = true;
        #endregion

        #region Methods
        public string PerformParse(string bText, string tbText)
        {
            string result = tbText;

            //% = +-*/ √ ± . ←
            if (bText.Length == 1)
            {
                PushingOperands(tbText);

                if (bText == "=")
                {
                    result = PerformCalc().ToString();
                    isFirstEqual = false;
                }
                
                else if (bText.IndexOfAny("+-/*".ToCharArray()) >= 0)
                {
                    currentOperation = bText;
                    isBinaryOp = true;
                    isFirstEqual = true;
                }

                else if (bText.IndexOfAny("√±".ToCharArray()) >= 0)
                {
                    currentOperation = bText;
                    isBinaryOp = false;
                    result = PerformCalc().ToString();
                    isFirstEqual = true;
                }
            }

            else
            {

            }

            return result;
        }

        private void PushingOperands(string tbText)
        {
            double operand = double.Parse(tbText);
            stackOperands.Push(operand);
        }

        private double PerformCalc()
        {
            calc.SetOperands(currentOperation, stackOperands, isBinaryOp, isFirstEqual);
            return calc.performOperation();
        }
        #endregion
    }
}
