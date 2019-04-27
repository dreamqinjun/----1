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
    public partial class zhuce : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public zhuce()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            if (radioButton1.Checked == true)//注册学员
            {
                string sql = "select * from login where 用户名='" + textBox1.Text + "'";//sql查询语句
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())//从数据库中查询到了我们即将要注册的用户名
                {
                    MessageBox.Show("该用户已存在,直接登录吧");
                }
                else
                {
                    string str1 = "insert  into login(用户名,密码,类型,姓名) values('" + textBox1.Text + "','" + textBox2.Text + "','学员','" + textBox3.Text + "')";
                    string str2 = "insert  into student values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";

                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")//用户名、密码、姓名不能为空
                    {
                        try
                        {
                            cmd = new OleDbCommand(str1, conn); ;
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd.ExecuteNonQuery();//往数据库login表中进行写入操作
                            MessageBox.Show("用户名注册成功");

                        }
                        catch (Exception w)
                        {
                            MessageBox.Show("遇到错误，用户名注册失败");
                        }
                        conn.Close();
                        conn.Dispose();

                        try
                        {
                            conn = new OleDbConnection(accesspath);
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd = new OleDbCommand(str2, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("详细信息注册成功");

                        }
                        catch (Exception w)
                        {

                            MessageBox.Show("遇到错误，详细信息注册失败");
                            MessageBox.Show("请重新注册用户");
                            string str = "delete from login where 用户名='" + textBox1.Text + "'";
                            cmd = new OleDbCommand(str, conn);
                            if (conn.State == ConnectionState.Closed)//如果数据库的连接状态为关闭状态
                                conn.Open();
                            cmd.ExecuteNonQuery();//往数据库student表中写入数据
                        }

                        conn.Close();
                        conn.Dispose();
                    }
                    else
                        MessageBox.Show("用户名、密码、姓名都不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (radioButton2.Checked == true)//注册教员
            {
                string sql = "select * from login where 用户名='" + textBox9.Text + "'";
                string str1 = "insert  into login(用户名,密码,类型,编号) values('" + textBox9.Text + "','" + textBox10.Text + "','教员','" + textBox11.Text + "')"; ;
                string str2 = "insert  into teacher(教师编号,教师姓名,性别,QQ,学校,年级,专业,价格,电话,自我描述) values('" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "','" + textBox20.Text + "')";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read()) { MessageBox.Show("该用户已存在,直接登录吧"); }
                else
                {
                    if (textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")//用户名、密码、教师编号不能为空
                    {
                        try
                        {
                            cmd = new OleDbCommand(str1, conn); ;
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("用户名注册成功");//往数据库login表中进行写入操作
                        }
                        catch (Exception w)
                        {

                            MessageBox.Show("遇到错误，用户名注册失败");
                        }

                        conn.Close();
                        conn.Dispose();
                        try
                        {
                            conn = new OleDbConnection(accesspath);
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd = new OleDbCommand(str2, conn);
                            cmd.ExecuteNonQuery();//往数据库teacher表中写入数据
                            MessageBox.Show("详细信息注册成功");
                        }
                        catch (Exception w)
                        {

                            MessageBox.Show("遇到错误，详细信息注册失败");
                            MessageBox.Show("请重新注册用户");
                            string str = "delete from login where 用户名='" + textBox9.Text + "'";
                            cmd = new OleDbCommand(str, conn);
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();//关闭数据库
                        conn.Dispose();//释放资源
                    }
                    else
                        MessageBox.Show("用户名、密码、教师编号都不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            zhujiemian f = new zhujiemian();
            f.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)//计时器
        {
            if (radioButton1.Checked == true)//选择注册学员
            {
                panel_tzhuce.Visible = false;//教员注册界面隐藏
                panel_szhuce.Visible = true;//显示学员注册界面

            }
            if (radioButton2.Checked == true)
            {
                panel_szhuce.Visible = true;
                panel_tzhuce.Visible = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox9.Text, out x) == false)
            {
                errorProvider1.SetError(textBox9, "请输入数字");
                textBox9.Text = "";
            }
            else
                errorProvider1.Clear();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)//用户名与密码均为数字
        {
            int x;
            if (int.TryParse(textBox10.Text, out x) == false)
            {
                errorProvider1.SetError(textBox10, "请输入数字");
                textBox10.Text = "";
            }
            else
                errorProvider1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//用户名与密码均为数字
        {
            int x;
            if (int.TryParse(textBox1.Text, out x) == false)
            {
                errorProvider1.SetError(textBox1, "请输入数字");
                textBox1.Text = "";
            }
            else
                errorProvider1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//用户名与密码均为数字
        {
            int x;
            if (int.TryParse(textBox2.Text, out x) == false)
            {
                errorProvider1.SetError(textBox2, "请输入数字");
                textBox2.Text = "";
            }
            else
                errorProvider1.Clear();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)//用户名与密码均为数字
        {
            int x;
            if (int.TryParse(textBox11.Text, out x) == false)
            {
                errorProvider1.SetError(textBox11, "请输入数字");
                textBox11.Text = "";
            }
            else
                errorProvider1.Clear();
        }
    }
}
