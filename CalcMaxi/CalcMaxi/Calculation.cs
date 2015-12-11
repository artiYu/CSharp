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
        BigInteger _operand1;
        BigInteger _operand2;
        TypeOperation typeop;

        enum TypeOperation {
            UNARY,
            BINARY
        }

        Dictionary<string, Func<BigInteger, BigInteger, BigInteger>> binaryOperations =
            new Dictionary<string, Func<BigInteger, BigInteger, BigInteger>>
            {
                { "+", (a, b) => a + b },
                { "-", (a, b) => a - b },
                { "*", (a, b) => a * b },
                { "/", (a, b) => a / b },
                { "%", (a, b) => a % b }
            };

        Dictionary<string, Func<BigInteger, BigInteger>> unaryOperations =
            new Dictionary<string, Func<BigInteger, BigInteger>>
            {
                { "±", a => -a }
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

        public BigInteger Operand1
        {
            get { return _operand1; }
            set { _operand1 = value; }
        }

        public BigInteger Operand2
        {
            get { return _operand2; }
            set { _operand2 = value; }
        }
        #endregion

        #region Constructors
        public Calculation(string unOperation, BigInteger operand)
        {
            typeop = TypeOperation.UNARY;
            UnOperation = unOperation;
            Operand1 = operand;
        }

        public Calculation(string binOperation, BigInteger operand1, BigInteger operand2)
        {
            typeop = TypeOperation.BINARY;
            BinOperation = binOperation;
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public Calculation(string operation, Stack<BigInteger> operands)
        {
            if (operands.Count == 1)
            {
                typeop = TypeOperation.UNARY;
                UnOperation = operation;
                Operand1 = operands.Pop();
            }
            else if (operands.Count == 2)
            {
                typeop = TypeOperation.BINARY;
                BinOperation = operation;
                Operand2 = operands.Pop();
                Operand1 = operands.Pop(); 
            }
        }
        #endregion

        #region Methods
        public BigInteger performOperation()
        {
            BigInteger resultoperation = 0;

            if (typeop == TypeOperation.UNARY)
                resultoperation = unaryOperations[UnOperation](Operand1);
            else if (typeop == TypeOperation.BINARY)
                resultoperation = binaryOperations[BinOperation](Operand1, Operand2);
            return resultoperation;
        }
        #endregion
    }
}
