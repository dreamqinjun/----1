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
    public partial class xiugaixinxi : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public xiugaixinxi()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            OleDbConnection conn = new OleDbConnection(accesspath);
            OleDbCommand cmd = null;
            if (button1.Text == "确认修改（学员）")
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                str = "update student set 联系电话='" + textBox12.Text + "',年级='" + textBox13.Text + "',上课时间='" + textBox14.Text + "',科目='" + textBox15.Text + "',位置='" + textBox16.Text + "' where 姓名='" + textBox11.Text + "'";

                cmd = new OleDbCommand(str, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功");
            }
            if (button1.Text == "确认修改（教员）")
            {
                str = "update teacher set 教师姓名='" + textBox2.Text + "',性别='" + textBox3.Text + "',QQ='" + textBox4.Text + "',学校='" + textBox5.Text + "',年级='" + textBox6.Text + "',专业='" + textBox7.Text + "',价格='" + textBox8.Text + "',电话='" + textBox9.Text + "',自我描述='" + textBox10.Text + "' where 教师编号='" + textBox1.Text + "'";
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = new OleDbCommand(str, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功");
            }
            conn.Close();
            conn.Dispose();
            this.Hide();

        }
        private void button_s_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "";
            if (button1.Text == "确认修改（学员）")
            {
                str = "select * from student where 姓名='" + textBox11.Text + "'";
                OleDbCommand cmd = new OleDbCommand(str, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "student");
                    textBox12.Text = ds.Tables["student"].Rows[0]["联系电话"].ToString();
                    textBox13.Text = ds.Tables["student"].Rows[0]["年级"].ToString();
                    textBox14.Text = ds.Tables["student"].Rows[0]["上课时间"].ToString();
                    textBox15.Text = ds.Tables["student"].Rows[0]["科目"].ToString();
                    textBox16.Text = ds.Tables["student"].Rows[0]["位置"].ToString();
                    conn.Close();
                    conn.Dispose();
                    da.Dispose();
                    button1.Enabled = true;
                }
                else
                {
                    tianjiaxinxi f = new tianjiaxinxi();
                    if (MessageBox.Show("没有此条信息，是否要添加", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        f.Show();
                        f.panel_tadd.Visible = false;
                        f.panel_sadd.Visible = true;
                        f.textBox11.Text = textBox11.Text;
                        f.button1.Text = "确认添加（学员）";
                    }
                    else
                        this.Hide();
                }
            }
            if (button1.Text == "确认修改（教员）")
            {
                str = "select * from teacher where 教师编号='" + textBox1.Text + "'";
                OleDbCommand cmd = new OleDbCommand(str, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "teacher");
                    textBox2.Text = ds.Tables["teacher"].Rows[0]["教师姓名"].ToString();
                    textBox3.Text = ds.Tables["teacher"].Rows[0]["性别"].ToString();
                    textBox4.Text = ds.Tables["teacher"].Rows[0]["QQ"].ToString();
                    textBox5.Text = ds.Tables["teacher"].Rows[0]["学校"].ToString();
                    textBox6.Text = ds.Tables["teacher"].Rows[0]["年级"].ToString();
                    textBox7.Text = ds.Tables["teacher"].Rows[0]["专业"].ToString();
                    textBox8.Text = ds.Tables["teacher"].Rows[0]["价格"].ToString();
                    textBox9.Text = ds.Tables["teacher"].Rows[0]["电话"].ToString();
                    textBox10.Text = ds.Tables["teacher"].Rows[0]["自我描述"].ToString();
                    conn.Close();
                    conn.Dispose();
                    da.Dispose();
                    button1.Enabled = true;
                }
                else
                {
                    tianjiaxinxi f = new tianjiaxinxi();
                    if (MessageBox.Show("没有此条信息，是否要添加", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        f.Show();
                        f.panel_sadd.Visible = false;
                        f.panel_tadd.Visible = true;
                        f.textBox1.Text = textBox1.Text;
                        f.button1.Text = "确认添加（教员）";
                    }
                    else
                        this.Hide();

                }
            }
        }
    }
}
