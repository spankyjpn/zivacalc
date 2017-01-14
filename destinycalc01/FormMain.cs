using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace destinycalc01
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCalcA frm = new FrmCalcA();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCalcB frm = new FrmCalcB();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            FormBinary frm = new FormBinary();
            frm.FormClosed += frm_FormAClosed;
            frm.Show();
        }

        void frm_FormAClosed(object sender, FormClosedEventArgs e)
        {
            this.button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = false;
            FormCanister frm = new FormCanister();
            frm.FormClosed += frm_FormBClosed;
            frm.Show();
        }

        void frm_FormBClosed(object sender, FormClosedEventArgs e)
        {
            this.button3.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormHistory frm = new FormHistory();
            frm.ShowDialog();
        }

        private void makeTestData()
        {
            libCoreData lib = new libCoreData();
            ArrayList ary = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                clsCoreData cd = new clsCoreData();
                cd.title = String.Format("data title {0}", i);
                cd.sttValue = i;
                cd.endValue = 10 - i;
                cd.dataType = i % 2 == 0 ? clsCoreData.coreDataType.ZivaTypeA : clsCoreData.coreDataType.ZivaTypeB;
                cd.coreData[0] = i;
                cd.coreData[1] = i * 2;
                cd.coreData[2] = i * 3;
                cd.coreData[3] = i * 4;
                cd.coreData[4] = i * -1;
                cd.coreData[5] = i * -2;
                cd.coreData[6] = i * -2;
                ary.Add(cd);
            }
            lib.save(ary);
            ary = lib.load();
        }
    }
}
