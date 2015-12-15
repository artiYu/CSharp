using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalcMaxi
{
    public partial class Form1 : Form
    {
        #region Fields
        ParseSimpleMode psm = new ParseSimpleMode();
        bool isFirstOperation = false;

        //for removing initial 0
        bool isStart = true;

        Dictionary<string, string> namesOperations = new Dictionary<string, string>()
        {
            { "Add", "+" },
            { "Substract", "-" },
            { "Multiplication", "*" },
            { "Division", "/" },
            { "gfd", "%" },
            { "gffff", "=" },
        };
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Events handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            SetEventsToNumbers();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Clicking(button.Text);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            string possibleOperations = ".+-*/%";
            string keyCodeString = keyCode.ToString();
            char lastChar = keyCodeString[keyCodeString.Length - 1];

            if (char.IsDigit(lastChar))
                Clicking(lastChar.ToString());

            else
            {
                if (keyCode == Keys.Add || keyCode == Keys.Oemplus && e.Shift)
                    Clicking("+");
                else if (keyCode == Keys.Subtract || keyCode == Keys.OemMinus && e.Shift)
                    Clicking("-");
                else if (keyCode == Keys.Multiply || keyCode == Keys.D8 && e.Shift)
                    Clicking("*");
                else if (keyCode == Keys.Divide || keyCode == Keys.OemQuestion)
                    Clicking("/");
                else if (keyCode == Keys.D5 && e.Shift)
                    Clicking("%");
                else if (keyCode == Keys.OemPeriod || keyCode == Keys.Decimal || keyCode == Keys.Oemcomma)
                    Clicking(",");
                else if (keyCode == Keys.Oemplus || keyCode == Keys.Enter || keyCode == Keys.Return)
                    Clicking("=");
                else if (keyCode == Keys.Back)
                    Clicking("←");
            }
        }
        #endregion

        #region Methods
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

        private void Clicking(string buttonText)
        {
            if (buttonText.Length == 1 && Char.IsDigit(buttonText[0]))
            {
                if (isFirstOperation)
                {
                    textBoxResult.Text = "";
                    isFirstOperation = false;
                }
                if (isStart)
                {
                    textBoxResult.Text = "";
                    isStart = false;
                }
                textBoxResult.Text += buttonText;
            }

            else
            {
                isFirstOperation = true;
                textBoxResult.Text = psm.PerformParse(buttonText, textBoxResult.Text);
            }
            
        }
        #endregion
    }
}
