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
            //output_forms.Text = myCalculator.ConvertInputType("0");
            myCalculator.ConvertInputType("0");
            foreach (var item in myCalculator.list)
            {
                myCalculator.UserSetData += item.ToString();
            }
            output_forms.Text = myCalculator.UserSetData;

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            //output_forms.Text = myCalculator.input_text("1");
        }
    }
}
