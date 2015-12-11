using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

namespace CalcMaxi
{
    public partial class Form1 : Form
    {
        Stack<BigInteger> stackOperands = new Stack<BigInteger>();
        string currentOperation;
        Calculation calc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetEventsToNumbers();
        }

        private void SetEventsToNumbers()
        {
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    button.Click += new EventHandler(Button_Click);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var buttonText = button.Text;
            Clicking(buttonText);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach (Control control in Controls)
            {
                Button button = control as Button;
                if (e.KeyChar == button.Text[0])
                {
                    Button_Click(button, e);
                    return;
                }
            }
        }

        private void Clicking(string text)
        {
            if (text.Length == 1)
            {
                if (Char.IsDigit(text[0]))
                {
                    textBoxResult.Text += text;
                }

                else if (text != "=")
                {
                    if (text == "√")
                        MessageBox.Show("No implementation yet ))");
                    int operand = int.Parse(textBoxResult.Text);
                    stackOperands.Push(operand);
                    currentOperation = text;
                    textBoxResult.Text = "";
                }

                else if (text == "=")
                {
                    int operand = int.Parse(textBoxResult.Text);
                    stackOperands.Push(operand);
                    calc = new Calculation(currentOperation, stackOperands);
                    textBoxResult.Text = "";
                    textBoxResult.Text = calc.performOperation().ToString();
                }
            }
        }
    }
}
