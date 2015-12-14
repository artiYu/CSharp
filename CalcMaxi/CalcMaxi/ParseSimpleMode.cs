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
        TypeButton typeB;

        enum TypeButton
        {
            BinaryOperation,
            UnaryOperation,
            Equal,
            NotOperation
        }
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
                    typeB = TypeButton.Equal;
                }

                else if (bText.IndexOfAny("+-/*".ToCharArray()) >= 0)
                {
                    currentOperation = bText;
                    isBinaryOp = true;
                    isFirstEqual = true;
                    typeB = TypeButton.BinaryOperation;
                }

                else if (bText.IndexOfAny("√±".ToCharArray()) >= 0)
                {
                    currentOperation = bText;
                    isBinaryOp = false;
                    result = PerformCalc().ToString();
                    isFirstEqual = true;
                    typeB = TypeButton.UnaryOperation;
                }

                else if (bText == "←")
                {
                    //TODO: if tbText is the result of calculations - don't touch
                    result = (tbText == "0" || string.IsNullOrEmpty(tbText)) ? 
                                        "0" : tbText.Substring(0, tbText.Length - 1);
                    typeB = TypeButton.NotOperation;
                }

                //don't work
                else if (bText == ",")
                {
                    typeB = TypeButton.NotOperation;
                }

                //don't work
                else if (bText == "%")
                {
                    double operand2 = stackOperands.Pop();
                    double operand1 = stackOperands.Pop();
                    MessageBox.Show(operand1 + " " + operand2);
                    operand2 = operand1 * operand2 / 100;
                    stackOperands.Push(operand1);
                    stackOperands.Push(operand2);
                    result = operand2.ToString();
                }

                else if (bText == "C")
                {
                    result = "0";
                    currentOperation = null;
                    while (stackOperands.Count > 0)
                        stackOperands.Pop();
                    typeB = TypeButton.NotOperation;
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
                    typeB = TypeButton.UnaryOperation;
                }

                else if (bText == "CE")
                {
                    stackOperands.Pop();
                    result = "0";
                }
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
            if (typeB != TypeButton.NotOperation)
            {
                calc.SetOperands(currentOperation, stackOperands, isBinaryOp, isFirstEqual);
                return calc.performOperation();
            }
            return 0;
        }
        #endregion
    }
}
