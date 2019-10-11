using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1006_윈폼시험다시
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = comboBox1.SelectedItem.ToString();
            Form1 fa = (Form1)this.Owner;
            string str = comboBox1.SelectedItem.ToString();
            string[] result = str.Split(new char[] { '(' });
            fa.GetItem(result[0]);

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
