using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace destinycalc01
{
    public partial class FormBinary : Form
    {
        public FormBinary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBinary_Load(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();


            for (int i = 0; i < 10; i++)
            {
                String[] item = new String[2];
                String temp = String.Empty;
                temp = "00000" + Convert.ToString(i, 2);
                item[0] = temp.Substring(temp.Length - 4, 4);
                item[1] = i.ToString();
                this.listView1.Items.Add(new ListViewItem(item));
            }
        }
    }
}
