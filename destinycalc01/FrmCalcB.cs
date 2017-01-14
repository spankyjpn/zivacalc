using System;
using System.Collections;
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
    public partial class FrmCalcB : Form
    {
        public bool swdShowUpdate { get; set; }
        public clsCoreData coreData { get; set; }

        public FrmCalcB()
        {
            InitializeComponent();

            this.swdShowUpdate = false;
            this.coreData = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startCalc();
        }

        private void startCalc()
        {
            try
            {
                this.listView1.Items.Clear();

                int stt = int.Parse(this.textBox1.Text);
                int end = int.Parse(this.textBox22.Text);

                int[,] cel = new int[10, 10];

                cel[0, 0] = int.Parse(this.textBox2.Text);
                cel[0, 1] = int.Parse(this.textBox3.Text);
                cel[0, 2] = int.Parse(this.textBox4.Text);
                cel[0, 3] = int.Parse(this.textBox5.Text);
                cel[0, 4] = int.Parse(this.textBox27.Text);

                cel[1, 0] = int.Parse(this.textBox6.Text);
                cel[1, 1] = int.Parse(this.textBox7.Text);
                cel[1, 2] = int.Parse(this.textBox8.Text);
                cel[1, 3] = int.Parse(this.textBox9.Text);
                cel[1, 4] = int.Parse(this.textBox26.Text);

                cel[2, 0] = int.Parse(this.textBox10.Text);
                cel[2, 1] = int.Parse(this.textBox11.Text);
                cel[2, 2] = int.Parse(this.textBox12.Text);
                cel[2, 3] = int.Parse(this.textBox13.Text);
                cel[2, 4] = int.Parse(this.textBox25.Text);

                cel[3, 0] = int.Parse(this.textBox14.Text);
                cel[3, 1] = int.Parse(this.textBox15.Text);
                cel[3, 2] = int.Parse(this.textBox16.Text);
                cel[3, 3] = int.Parse(this.textBox17.Text);
                cel[3, 4] = int.Parse(this.textBox24.Text);

                cel[4, 0] = int.Parse(this.textBox18.Text);
                cel[4, 1] = int.Parse(this.textBox19.Text);
                cel[4, 2] = int.Parse(this.textBox20.Text);
                cel[4, 3] = int.Parse(this.textBox21.Text);
                cel[4, 4] = int.Parse(this.textBox23.Text);

                for (int na = 0; na < 5; na++)
                {
                    for (int nb = 0; nb < 5; nb++)
                    {
                        for (int nc = 0; nc < 5; nc++)
                        {
                            for (int nd = 0; nd < 5; nd++)
                            {
                                for (int ne = 0; ne < 5; ne++)
                                {
                                    if (stt + cel[0, na] + cel[1, nb] + cel[2, nc] + cel[3, nd] + cel[4, ne] == end)
                                    {
                                        System.Diagnostics.Debug.WriteLine(String.Format("Result={0} - {1} - {2} - {3} - {4}", na + 1, nb + 1, nc + 1, nd + 1, ne + 1));

                                        String[] item = new String[5];

                                        item[0] = (na + 1).ToString();
                                        item[1] = (nb + 1).ToString();
                                        item[2] = (nc + 1).ToString();
                                        item[3] = (nd + 1).ToString();
                                        item[4] = (ne + 1).ToString();

                                        this.listView1.Items.Add(new ListViewItem(item));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("エラーが発生しました。項目には数字のみ入力可能です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCalcB_Load(object sender, EventArgs e)
        {
            this.textBox22.Text = "730";

            if ( this.swdShowUpdate == true )
            {
                refreshDisplay();
                startCalc();
                enableButtons(false);
            }
            else
            {
                enableButtons(true);
            }
        }

        private void enableButtons(bool p)
        {
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = p;
            this.button4.Enabled = p;
        }

        private void refreshDisplay()
        {
            if ( this.coreData == null )
            {
                return;
            }

            this.textBox1.Text = this.coreData.sttValue.ToString();
            this.textBox22.Text = this.coreData.endValue.ToString();

            this.textBox2.Text = this.coreData.coreData[0].ToString();
            this.textBox3.Text = this.coreData.coreData[1].ToString();
            this.textBox4.Text = this.coreData.coreData[2].ToString();
            this.textBox5.Text = this.coreData.coreData[3].ToString();
            this.textBox27.Text = this.coreData.coreData[4].ToString();

            this.textBox6.Text = this.coreData.coreData[5].ToString();
            this.textBox7.Text = this.coreData.coreData[6].ToString();
            this.textBox8.Text = this.coreData.coreData[7].ToString();
            this.textBox9.Text = this.coreData.coreData[8].ToString();
            this.textBox26.Text = this.coreData.coreData[9].ToString();

            this.textBox10.Text = this.coreData.coreData[10].ToString();
            this.textBox11.Text = this.coreData.coreData[11].ToString();
            this.textBox12.Text = this.coreData.coreData[12].ToString();
            this.textBox13.Text = this.coreData.coreData[13].ToString();
            this.textBox25.Text = this.coreData.coreData[14].ToString();

            this.textBox14.Text = this.coreData.coreData[15].ToString();
            this.textBox15.Text = this.coreData.coreData[16].ToString();
            this.textBox16.Text = this.coreData.coreData[17].ToString();
            this.textBox17.Text = this.coreData.coreData[18].ToString();
            this.textBox24.Text = this.coreData.coreData[19].ToString();

            this.textBox18.Text = this.coreData.coreData[20].ToString();
            this.textBox19.Text = this.coreData.coreData[21].ToString();
            this.textBox20.Text = this.coreData.coreData[22].ToString();
            this.textBox21.Text = this.coreData.coreData[23].ToString();
            this.textBox23.Text = this.coreData.coreData[24].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHistory frm = new FormHistory();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormInput frm = new FormInput();

            frm.message = "保存するデータの名前を入力してください";

            frm.ShowDialog();

            if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                clsCoreData cls = new clsCoreData();

                cls.dataType = clsCoreData.coreDataType.ZivaTypeB;
                cls.title = frm.inputData;
                cls.sttValue = int.Parse(this.textBox1.Text);
                cls.endValue = int.Parse(this.textBox22.Text);
                cls.coreData[0] = int.Parse(this.textBox2.Text);
                cls.coreData[1] = int.Parse(this.textBox3.Text);
                cls.coreData[2] = int.Parse(this.textBox4.Text);
                cls.coreData[3] = int.Parse(this.textBox5.Text);
                cls.coreData[4] = int.Parse(this.textBox27.Text);

                cls.coreData[5] = int.Parse(this.textBox6.Text);
                cls.coreData[6] = int.Parse(this.textBox7.Text);
                cls.coreData[7] = int.Parse(this.textBox8.Text);
                cls.coreData[8] = int.Parse(this.textBox9.Text);
                cls.coreData[9] = int.Parse(this.textBox26.Text);

                cls.coreData[10] = int.Parse(this.textBox10.Text);
                cls.coreData[11] = int.Parse(this.textBox11.Text);
                cls.coreData[12] = int.Parse(this.textBox12.Text);
                cls.coreData[13] = int.Parse(this.textBox13.Text);
                cls.coreData[14] = int.Parse(this.textBox25.Text);

                cls.coreData[15] = int.Parse(this.textBox14.Text);
                cls.coreData[16] = int.Parse(this.textBox15.Text);
                cls.coreData[17] = int.Parse(this.textBox16.Text);
                cls.coreData[18] = int.Parse(this.textBox17.Text);
                cls.coreData[19] = int.Parse(this.textBox24.Text);

                cls.coreData[20] = int.Parse(this.textBox18.Text);
                cls.coreData[21] = int.Parse(this.textBox19.Text);
                cls.coreData[22] = int.Parse(this.textBox20.Text);
                cls.coreData[23] = int.Parse(this.textBox21.Text);
                cls.coreData[24] = int.Parse(this.textBox23.Text);

                libCoreData lib = new libCoreData();

                ArrayList ary = lib.load();
                ary.Add(cls);
                lib.save(ary);

                MessageBox.Show("データを保存しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました。項目には数字のみ入力可能です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
