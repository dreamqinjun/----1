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
    public partial class denglu : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public denglu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zhujiemian f = new zhujiemian();
            string str = "";
            if (button1.Text == "学员登录")
            {
                str = "select * from login where 用户名='" + textBox1.Text + "' and 密码='" + textBox2.Text + "' and 类型='学员'";
                f.richTextBox2.Text = "欢迎" + textBox1.Text + "学员,有什么宝贵的意见或建议，请联系******@qq.com";
                f.groupBox1.Visible = true;

            }
            if (button1.Text == "教员登录")
            {
                f.richTextBox2.Text = "欢迎" + textBox4.Text + "教员,有什么宝贵的意见或建议，请联系******@qq.com";
                f.groupBox1.Visible = true;
                str = "select * from login where 用户名='" + textBox4.Text + "' and 密码='" + textBox3.Text + "' and 类型='教员'";
            }
            if (button1.Text == "管理员登录")
            {
                if (textBox5.Text == "admin" && textBox6.Text == "admin")
                {
                    this.Hide();
                    f.Show();
                    f.panel_studentin.Visible = true;
                    f.panel_teacherin.Visible = true;
                    f.panel_adminin.Visible = true;
                    f.panel_admin.Visible = true;
                    f.dataGridView3.Visible = false;
                    f.richTextBox2.Visible = true;
                    f.richTextBox2.Text = "欢迎您，管理员,有什么宝贵的意见或建议，请联系******@qq.com";
                    f.groupBox1.Visible = true;
                }
                else
                {
                    MessageBox.Show("输入有误，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Text = "";
                    textBox6.Text = "";
                }

            }
            if (button1.Text == "学员登录" || button1.Text == "教员登录")
            {
                OleDbConnection conn = new OleDbConnection(accesspath);
                try
                {
                    OleDbCommand cmd = new OleDbCommand(str, conn);
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())//如果输入的数据和数据库中存储的数据匹配，登录成功，跳到主界面
                    {
                        f.label35.Visible = true;
                        f.label36.Visible = true;
                        this.Hide();
                        f.Show();
                        f.richTextBox2.Visible = true;
                        if (button1.Text == "学员登录")
                        {
                            f.label36.Text = textBox1.Text;
                            f.panel_studentin.Visible = true;
                            f.button11.Text = "发表帖子";
                        }
                        if (button1.Text == "教员登录")
                        {
                            f.label36.Text = textBox4.Text;
                            f.panel_studentin.Visible = true;
                            f.panel_teacherin.Visible = true;
                            f.button11.Text = "查看帖子 ";
                        }
                    }
                    else { MessageBox.Show("登录失败"); }
                }
                catch (Exception w)
                {
                    MessageBox.Show(w.Message);

                }
                conn.Close();//关闭数据库
                conn.Dispose();//释放资源
            }
            f.button7.Visible = true;//注销按钮显示
            f.notifyIcon1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//返回主界面
        {
            zhujiemian f = new zhujiemian();
            f.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xiugaimima f = new xiugaimima();
            if (button1.Text == "学员登录")
            {
                f.Show();
                f.panel_mteacher.Visible = false;
                f.panel_mstudent.Visible = true;//学员修改密码界面显示
                f.textBox1.Text = textBox1.Text;
            }
            if (button1.Text == "教员登录")
            {
                f.Show();
                f.panel_mteacher.Visible = true;//教员修改密码界面显示
                f.panel_mstudent.Visible = false;
                f.textBox4.Text = textBox4.Text;
            }
        }
    }
}
