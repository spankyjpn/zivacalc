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
    public partial class FormCanister : Form
    {
        public FormCanister()
        {
            InitializeComponent();
        }

        private void FormCanister_Load(object sender, EventArgs e)
        {
            this.Height = 850;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
