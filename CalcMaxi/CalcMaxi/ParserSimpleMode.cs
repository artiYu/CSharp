using System.Collections.Generic;
using System.Windows.Forms;

namespace CalcMaxi
{
    class ParserSimpleMode : Form
    {
        #region Fields
        Stack<double> stackOperands = new Stack<double>();
        string currentOperation;
        Calculation calc = new Calculation();
        bool isFirstEqual = true;
        bool isBinaryOp = true;
        double memory = 0.0d;
        bool isUsingMemory = false;
        #endregion

        #region Methods
        public string PerformParse(string bText, string tbText)
        {
            string result = tbText;

            if (!string.IsNullOrEmpty(tbText))
                PushingOperands(tbText);

            //% = +-*/ √ ± . ←
            if (bText.Length == 1)
            {
                if (bText == "=")
                {
                    if (stackOperands.Count > 0)
                    {
                        result = PerformCalc().ToString();
                        isFirstEqual = false;
                    }
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

                else if (bText == "←")
                {
                    //TODO: if tbText is the result of calculations - don't touch
                    result = (tbText == "0" || string.IsNullOrEmpty(tbText)) ?
                                        "0" : tbText.Substring(0, tbText.Length - 1);
                }

                //don't work
                else if (bText == ",")
                {
                    MessageBox.Show("Not implementation yet");
                }

                else if (bText == "%")
                {
                    double operand2 = stackOperands.Pop();
                    double operand1 = stackOperands.Pop();

                    operand2 *= operand1 / 100;
                    stackOperands.Push(operand1);
                    stackOperands.Push(operand2);
                    result = PerformCalc().ToString();
                }

                else if (bText == "C")
                {
                    result = "0";
                    currentOperation = null;
                    while (stackOperands.Count > 0)
                        stackOperands.Pop();
                }
            }

            else
            {
                if (bText == "1/x")
                {
                    currentOperation = bText;
                    isBinaryOp = false;
                    result = PerformCalc().ToString();
                    isFirstEqual = true;
                }

                else if (bText == "CE")
                {
                    stackOperands.Pop();
                    result = "0";
                }

                else if (bText == "MR")
                {
                    result = memory.ToString();
                    isUsingMemory = true;
                }

                else if (bText == "MC")
                {
                    memory = 0.0d;
                    isUsingMemory = false;
                }

                else if (bText == "MS")
                {
                    memory = stackOperands.Peek();
                    isUsingMemory = true;
                }

                else if (bText == "M+")
                {
                    memory += stackOperands.Peek();
                    result = memory.ToString();
                    isUsingMemory = true;
                }

                else if (bText == "M-")
                {
                    memory -= stackOperands.Peek();
                    result = memory.ToString();
                    isUsingMemory = true;
                }
            }

            return result;
        }

        public bool IsUsingMemory()
        {
            return isUsingMemory;
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
