using System.Diagnostics;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("Debugging message");
            myCalculator.OutputBox["TempWaitNum_forms"] += "0";
            Refresh();

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "1";
            Refresh();
        }
        private void btn_2_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "2";
            Refresh();
        }
        private void btn_3_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "3";
            Refresh();
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "4";
            Refresh();
        }
        private void btn_5_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "5";
            Refresh();
        }
        private void btn_6_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "6";
            Refresh();
        }
        private void btn_7_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "7";
            Refresh();
        }
        private void btn_8_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "8";
            Refresh();
        }
        private void btn_9_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += "9";
            Refresh();
        }
        private void btn_dot_Click(object sender, EventArgs e)
        {
            myCalculator.OutputBox["TempWaitNum_forms"] += ".";
            Refresh();
        }

        // --- --- --- --- --- --- --- --- --- --- --- ---
        // --- --- --- --- --- --- --- --- --- --- --- ---

        private void btn_add_Click(object sender, EventArgs e)
        {

            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " + ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();

        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " - ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();

        }

        private void Refresh()
        {
            Result_forms.Text = myCalculator.OutputBox["Result_forms"];
            TempWaitNum_forms.Text = myCalculator.OutputBox["TempWaitNum_forms"];
            History_forms.Text = myCalculator.OutputBox["History_forms"];
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            myCalculator.reset();
            Refresh();
        }

        private void btn_amount_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " = ");


            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (myCalculator.OutputBox["TempWaitNum_forms"].Length > 0)
            {
                myCalculator.OutputBox["TempWaitNum_forms"] = myCalculator.OutputBox["TempWaitNum_forms"].Substring(0, myCalculator.OutputBox["TempWaitNum_forms"].Length - 1);
            }
            else
            {
                return;
            }
            Refresh();
        }

        private void btc_multiply_Click(object sender, EventArgs e)
        {

            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " * ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " / ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();

        }

        private void btn_modulus_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " % ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();

        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " ** ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();

        }

        private void btn_square_root_Click(object sender, EventArgs e)
        {
            myCalculator.handle(myCalculator.OutputBox["TempWaitNum_forms"], " ¡Ì£þ ");
            myCalculator.OutputBox["TempWaitNum_forms"] = "";
            Refresh();
        }
    }
}
