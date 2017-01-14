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
    public partial class FormHistory : Form
    {
        ArrayList dataArray = new ArrayList();

        public FormHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            libCoreData lib = new libCoreData();
            this.dataArray = lib.load();
            refreshDisplay();
        }

        private void refreshDisplay()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.listBox1.Items.Clear();
            foreach (clsCoreData cls in this.dataArray)
            {
                int pos = this.listBox1.Items.Add(new KeyValuePair<string, clsCoreData>(getZivaEngineShortName(cls.dataType) + ":" + cls.title, cls));
            }
            this.listBox1.DisplayMember = "Key";
            this.listBox1.ValueMember = "Value";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem == null)
            {
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                return;
            }

            KeyValuePair<string, clsCoreData> obj = (KeyValuePair<string, clsCoreData>)this.listBox1.SelectedItem;

            clsCoreData cls = obj.Value;

            this.textBox1.Text = getZivaEngineFullName(cls.dataType);
            this.textBox2.Text = cls.title;
        }

        private string getZivaEngineShortName(clsCoreData.coreDataType typ)
        {
            return typ == clsCoreData.coreDataType.ZivaTypeA ? "（チャージ済み）" : "（　　　不安定）";
        }
        private string getZivaEngineFullName(clsCoreData.coreDataType typ)
        {
            return typ == clsCoreData.coreDataType.ZivaTypeA ? "ＺＩＶＡエンジン（チャージ済み）" : "ＺＩＶＡエンジン（不安定）";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("データをリストから選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KeyValuePair<string, clsCoreData> obj = (KeyValuePair<string, clsCoreData>)this.listBox1.SelectedItem;
            clsCoreData cls = obj.Value;

            if (cls.dataType == clsCoreData.coreDataType.ZivaTypeA)
            {
                FrmCalcA frm = new FrmCalcA();
                frm.swdShowUpdate = true;
                frm.coreData = cls;
                frm.ShowDialog();
            }
            else
            {
                FrmCalcB frm = new FrmCalcB();
                frm.swdShowUpdate = true;
                frm.coreData = cls;
                frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("データをリストから選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ( MessageBox.Show("選択されたデータを消去します。よろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK )
            {
                return;
            }

            KeyValuePair<string, clsCoreData> obj = (KeyValuePair<string, clsCoreData>)this.listBox1.SelectedItem;
            clsCoreData cls = obj.Value;

            this.dataArray.Remove(cls);
            this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);

            libCoreData lib = new libCoreData();
            lib.save(this.dataArray);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("データ保存用の内部ファイルを削除します。よろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            libCoreData lib = new libCoreData();
            lib.purge();
            this.dataArray = lib.load();
            refreshDisplay();
            MessageBox.Show("データを削除しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
