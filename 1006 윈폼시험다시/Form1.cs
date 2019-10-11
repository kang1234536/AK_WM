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
    public partial class Form1 : Form
    {
        Machine machine = new Machine();

        public Form1()
        {
            InitializeComponent();
            machine.Getlist(listView1);

            SetText();

        }

        private void 프로그램종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 금액투입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.Show();
        }

        private void 제품선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f1 = new Form3();
            f1.Owner = this;
            f1.comboBox1.Items.AddRange(SetCombo());
            f1.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = this.listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                string name = item.SubItems[0].Text;
                Drink d = machine.Drinkinfo(name);
                
                textBox4.Text = string.Format("제품명 : {0}\r\n", d.Name);
                textBox4.Text += string.Format("가격 : {0}\r\n", d.Price);
                textBox4.Text += string.Format("재고량 : {0}\r\n", d.Count);
                textBox4.Text += string.Format("판매수량 : {0}\r\n", d.Selcount);
                textBox4.Text += string.Format("판매총액 : {0}\r\n", d.GetSal());
            }
        
    }
        private void SetText()
        {
            textBox1.Text = string.Format("{0}", machine.SelCount);
            textBox2.Text = string.Format("{0}", machine.SelMoney);
            textBox3.Text = string.Format("{0}", machine.Money);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            machine.GetMoney();
            SetText();
        }
        public void SetMoney(int val)
        {
            machine.InputMoney(val);
            SetText();
        }
        public void GetItem(string name)
        {
            machine.SelectDrink(name);
            SetText();
        }
        private string[] SetCombo()
        {
            return machine.PrintAll();
        }
    }
}
