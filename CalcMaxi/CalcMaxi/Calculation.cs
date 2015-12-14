using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace CalcMaxi
{
    class Calculation : Form
    {
        #region Fields
        string _binOperation;
        string _unOperation;
        double _operand1;
        double _operand2;
        bool _isFirstEqual;
        TypeOperation typeop;

        enum TypeOperation
        {
            UNARY,
            BINARY
        }

        Dictionary<string, Func<double, double, double>> binaryOperations =
            new Dictionary<string, Func<double, double, double>>
            {
                { "+", (a, b) => a + b },
                { "-", (a, b) => a - b },
                { "*", (a, b) => a * b },
                { "/", (a, b) => a / b }
            };

        Dictionary<string, Func<double, double>> unaryOperations =
            new Dictionary<string, Func<double, double>>
            {
                { "±", a => -a },
                { "√", a => Math.Sqrt(a) }
            };
        #endregion

        #region Properties
        public string BinOperation
        {
            get { return _binOperation; }
            set { _binOperation = value; }
        }

        public string UnOperation
        {
            get { return _unOperation; }
            set { _unOperation = value; }
        }

        public double Operand1
        {
            get { return _operand1; }
            set { _operand1 = value; }
        }

        public double Operand2
        {
            get { return _operand2; }
            set { _operand2 = value; }
        }
        #endregion

        #region Methods
        public void SetOperands(string operation, Stack<double> operands,
                                bool isBinaryOp, bool isFirstEqual)
        {
            if (isBinaryOp)
            {
                typeop = TypeOperation.BINARY;

                if (!isFirstEqual)
                {
                    UnOperation = operation;
                    Operand1 = operands.Pop();
                }
                else
                {
                    BinOperation = operation;
                    Operand2 = operands.Pop();
                    Operand1 = operands.Pop();
                }
            }

            else
            {
                typeop = TypeOperation.UNARY;
                UnOperation = operation;
                Operand1 = operands.Pop();
            }
            //if (operands.Count == 2)
            //{
            //    typeop = TypeOperation.BINARY;
            //    BinOperation = operation;
            //    Operand2 = operands.Pop();
            //    Operand1 = operands.Pop();
            //}

            //else if (operands.Count == 1)
            //{
            //    if (isFirstEqual)
            //    {
            //        typeop = TypeOperation.UNARY;
            //        UnOperation = operation;
            //        Operand1 = operands.Pop();
            //    }
            //    else
            //    {
            //        typeop = TypeOperation.BINARY;
            //        UnOperation = operation;
            //        Operand1 = operands.Pop();
            //    }
            //}
        }

        public double performOperation()
        {
            double resultoperation = 0;

            if (typeop == TypeOperation.UNARY)
                resultoperation = unaryOperations[UnOperation](Operand1);

            else if (typeop == TypeOperation.BINARY)
                resultoperation = binaryOperations[BinOperation](Operand1, Operand2);
            return resultoperation;
        }
        #endregion
    }
}
