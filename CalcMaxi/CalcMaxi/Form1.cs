using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

namespace CalcMaxi
{
    public partial class Form1 : Form
    {
        #region Fields
        ParseSimpleMode psm = new ParseSimpleMode();
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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach (Control control in Controls)
            {
                Button button = control as Button;

                //check if digit
                if (e.KeyChar == button.Text[0])
                {
                    Button_Click(button, e);
                    return;
                }

                //check if Enter
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    //Button_Click
                }
                else
                    return;
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
                textBoxResult.Text += buttonText;

            else
                textBoxResult.Text = psm.PerformParse(buttonText, textBoxResult.Text);
            
        }
        #endregion
    }
}
