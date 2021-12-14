using System;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class frmMain : Form
    {
        #region variables
        
        Operation activeOperation = Operation.None;
        Operation lastAction = Operation.None;
        double? num1;
        double? num2;
        bool modified = false;

        #endregion

        #region frmMain
        public frmMain()
        {
            InitializeComponent();
            txt_Screen.Text = "0";
            btn_0.Click += Btn_Numbers_Click;
            btn_1.Click += Btn_Numbers_Click;
            btn_2.Click += Btn_Numbers_Click;
            btn_3.Click += Btn_Numbers_Click;
            btn_4.Click += Btn_Numbers_Click;
            btn_5.Click += Btn_Numbers_Click;
            btn_6.Click += Btn_Numbers_Click;
            btn_7.Click += Btn_Numbers_Click;
            btn_8.Click += Btn_Numbers_Click;
            btn_9.Click += Btn_Numbers_Click;
            btn_Dot.Click += Btn_Numbers_Click;

            btn_Add.Click += Btn_Operations_Click;
            btn_Sub.Click += Btn_Operations_Click;
            btn_Mul.Click += Btn_Operations_Click;
            btn_Div.Click += Btn_Operations_Click;
            btn_Enter.Click += Btn_Operations_Click;

            btn_MinusAdd.Click += Btn_MinusAdd_Click;
            btn_Del.Click += Btn_Del_Click;
            btn_AC.Click += Btn_AC_Click;

            this.KeyDown += FrmMain_KeyDown;

            txt_Screen.ForeColor = System.Drawing.Color.Black;
            
        }


        #endregion

        #region Btn_MinusAdd_Click
        private void Btn_MinusAdd_Click(object sender, EventArgs e)
        {
            if (txt_Screen.Text != "0" && txt_Screen.Text != "")
            {
                if (!txt_Screen.Text.Contains("-"))
                {
                    txt_Screen.Text = "-" + txt_Screen.Text;
                }
                else
                    txt_Screen.Text = txt_Screen.Text.Replace("-", "");
            }
            btn_Enter.Focus();
        }
        #endregion

        #region FrmMain_KeyDown
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                btn_0.PerformClick();
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                btn_1.PerformClick();
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                btn_2.PerformClick();
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                btn_3.PerformClick();
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                btn_4.PerformClick();
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                btn_5.PerformClick();
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                btn_6.PerformClick();
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                btn_7.PerformClick();
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                btn_8.PerformClick();
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                btn_9.PerformClick();
            if (e.KeyCode == Keys.Decimal )
                btn_Dot.PerformClick();

            if (e.KeyCode == Keys.Add)
                btn_Add.PerformClick();
            if (e.KeyCode == Keys.Subtract)
                btn_Sub.PerformClick();
            if (e.KeyCode == Keys.Multiply)
                btn_Mul.PerformClick();
            if (e.KeyCode == Keys.Divide)
                btn_Div.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btn_Enter.PerformClick();
            if (e.KeyCode == Keys.Escape)
                btn_AC.PerformClick();
            if (e.KeyCode == Keys.Back)
                btn_Del.PerformClick();
        }
        #endregion

        #region Btn_AC_Click
        private void Btn_AC_Click(object sender, EventArgs e)
        {
            activeOperation = Operation.None;
            lastAction = Operation.None;
            num1=null;
            num2=null;
            txt_Screen.Text = "0";
            btn_Enter.Focus();
        }
        #endregion

        #region Btn_Del_Click
        private void Btn_Del_Click(object sender, EventArgs e)
        {

            if (txt_Screen.Text.Length == 1)
            {
                txt_Screen.Text = "0";
            }
            else
            {
                txt_Screen.Text = txt_Screen.Text.Substring(0, txt_Screen.Text.Length - 1);
            }

            if (activeOperation == Operation.None)
            {
                num1 = txt_Screen.Text.ToDouble(0);
            }
            else
            {
                num2 = txt_Screen.Text.ToDouble(0);
            }
            btn_Enter.Focus();

        }
        #endregion

        #region Btn_Operations_Click
        private void Btn_Operations_Click(object sender, EventArgs e)
        {
            string senderText = ((Button)sender).Text;
            double? returned;

            switch (senderText)
            {
                case "+":
                    {
                        lastAction = Operation.Add;
                        activeOperation = Operation.Add;

                        
                        break;
                    }
                case "-":
                    {
                        lastAction = Operation.Subbtraction;
                        activeOperation = Operation.Subbtraction;
                        break;
                    }
                case "x":
                    {
                        lastAction = Operation.Multiply;
                        activeOperation = Operation.Multiply;
                        break;
                    }
                case "/":
                    {
                        lastAction = Operation.Divide;
                        activeOperation = Operation.Divide;
                        break;
                    }
                case "=":
                    {
                        lastAction = activeOperation;
                        break;
                    }
                default:
                    break;
            }

            if (modified)
            {
                if (num1 == null)
                {
                    num1 = txt_Screen.Text.ToDouble(0);
                }
                else if (num2 == null)
                {
                    num2 = txt_Screen.Text.ToDouble(0);
                }
            }
            

            if (num1 != null && num2 != null)
            {
                returned = MyFunctions.Calc(num1, num2, activeOperation);
                if (returned != null)
                {
                    num1 = returned;
                    num2 = null;
                    if (returned.ToString().Length > 8)
                        txt_Screen.Text = string.Format("{0:N8}",returned); 
                    else
                        txt_Screen.Text = returned.ToString();
                }
            }
            modified = false;
            btn_Enter.Focus();
        }
        #endregion

        #region Btn_Numbers_Click
        private void Btn_Numbers_Click(object sender, EventArgs e)
        {
            modified = true;

            string senderText = ((Button)sender).Text.Replace(",",".");
            if (txt_Screen.Text == "0" || lastAction != Operation.None)
                txt_Screen.Text = "";

            if (txt_Screen.Text == "" && senderText == ".")
            {
                txt_Screen.Text = "0.";
            }
            else
            {
                if (senderText == ".")
                {
                    if (!txt_Screen.Text.Contains("."))
                        txt_Screen.Text += senderText;
                }
                else
                    txt_Screen.Text += senderText;
            }
            
            lastAction = Operation.None;
            btn_Enter.Focus();

        }
        #endregion
    }
}
