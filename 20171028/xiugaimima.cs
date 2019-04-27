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
    public partial class xiugaimima : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public xiugaimima()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "";
            if (panel_mstudent.Visible == true)
            {
                if (textBox1.Text == "")
                    MessageBox.Show("请输入用户名", "提示");
                else
                {
                    str = "select * from login where 用户名='" + textBox1.Text + "' and 类型='学员'";
                    OleDbCommand cmd = new OleDbCommand(str, conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    OleDbDataReader r = cmd.ExecuteReader();
                    if (r.Read() == false)
                    {
                        MessageBox.Show("该用户不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "login");
                        string name = ds.Tables["login"].Rows[0]["姓名"].ToString();
                        if (textBox3.Text == name)
                        {
                            if (textBox2.Text != "")
                            {
                                str = "update login set 密码='" + textBox2.Text + "' where 用户名='" + textBox1.Text + "'";
                                if (conn.State != ConnectionState.Open) conn.Open();
                                cmd = new OleDbCommand(str, conn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Hide();
                            }
                            else
                                MessageBox.Show("请输入新密码", "提示");
                        }
                        else
                            MessageBox.Show("请输入正确的姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (panel_mteacher.Visible == true)
            {
                if (textBox4.Text == "")
                    MessageBox.Show("请输入用户名", "提示");
                else
                {
                    str = "select * from login where 用户名='" + textBox4.Text + "' and 类型='教员'";
                    OleDbCommand cmd = new OleDbCommand(str, conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    OleDbDataReader r = cmd.ExecuteReader();
                    if (r.Read() == false)
                    {
                        MessageBox.Show("该用户不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "login");
                        string name = ds.Tables["login"].Rows[0]["编号"].ToString();
                        if (textBox6.Text == name)
                        {
                            if (textBox5.Text != "")
                            {
                                str = "update login set 密码='" + textBox5.Text + "' where 用户名='" + textBox4.Text + "'";
                                if (conn.State != ConnectionState.Open) conn.Open();
                                cmd = new OleDbCommand(str, conn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Hide();
                            }
                            else
                                MessageBox.Show("请输入新密码", "提示");
                        }
                        else
                            MessageBox.Show("请输入正确的教师编号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(textBox2.Text, out i) == false)
            {
                errorProvider1.SetError(textBox2, "请输入数字");
                textBox2.Text = "";
            }
            else
                errorProvider1.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(textBox5.Text, out i) == false)
            {
                errorProvider1.SetError(textBox5, "请输入数字");
                textBox5.Text = "";
            }
            else
                errorProvider1.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + textBox4.Text + "' and 类型='教员'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            string name = ds.Tables["login"].Rows[0]["编号"].ToString();
            if (textBox6.Text == name) pictureBox1.Image = imageList1.Images[1];
            else pictureBox1.Image = imageList1.Images[0];
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + textBox1.Text + "' and 类型='学员'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            string name = ds.Tables["login"].Rows[0]["姓名"].ToString();
            if (textBox3.Text == name) pictureBox2.Image = imageList1.Images[1];
            else pictureBox2.Image = imageList1.Images[0];
        }
    }
}
