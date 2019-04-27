using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace _20171028
{
    public partial class tianjiaxinxi : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public tianjiaxinxi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            OleDbConnection conn = new OleDbConnection(accesspath);
            if (button1.Text == "确认添加（学员）")
            {
                if (MessageBox.Show("确认添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    str = "insert into student values('" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(str, conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示");
                    this.Hide();
                }
            }
            if (button1.Text == "确认添加（教员）")
            {
                if (MessageBox.Show("确认添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    str = "insert into teacher values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(str, conn);//执行sql语句。
                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();//往数据库写入数据
                    MessageBox.Show("添加成功", "提示");
                    this.Hide();
                }
            }
            conn.Close();
            conn.Dispose();
        }
    }
}
