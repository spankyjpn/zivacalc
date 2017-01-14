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
    public partial class FormInput : Form
    {
        public string inputData { get; set; }

        public string message { get; set; }

        public FormInput()
        {
            InitializeComponent();

            this.inputData = string.Empty;
            this.message = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("なにか入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.inputData = this.textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            this.label1.Text = this.message;
        }
    }
}
