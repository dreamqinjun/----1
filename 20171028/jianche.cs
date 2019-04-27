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
    public partial class jianche : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public jianche()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + textBox1.Text + "'";
            OleDbCommand cmd = new OleDbCommand(str, conn);
            if (conn.State != ConnectionState.Open) conn.Open();
            OleDbDataReader r = cmd.ExecuteReader();//从数据库中查找输入的用户名
            if (r.Read())//如果查找到
            {
                MessageBox.Show("用户名" + textBox1.Text + "已被使用", "提示");
            }
            else//未查找到
            {
                MessageBox.Show("用户名" + textBox1.Text + "未被使用", "提示");
            }
        }
    }
}
