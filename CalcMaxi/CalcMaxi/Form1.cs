using System;
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
                if (e.KeyChar == button.Text[0] || e.KeyChar == (char)Keys.Enter)
                {
                    Button_Click(button, e);
                    return;
                }
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
