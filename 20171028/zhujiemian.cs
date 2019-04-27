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
    public partial class zhujiemian : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public zhujiemian()
        {
            InitializeComponent();
            panel_tiezi.Visible = false;
            panel_home.Visible = true;
            panel_aboutus.Visible = false;
            panel_teacherintroduce.Visible = false;
            richTextBox2.Visible = false;
            panel_studentin.Visible = false;
            panel_stusearch.Visible = false;
            panel_tresearch.Visible = false;
            label32.Visible = false;
            label34.Visible = false;
            panel_teacherin.Visible = false;
            label35.Visible = false;
            button7.Visible = false;
            label36.Visible = false;
            panel_adminin.Visible = false;
            panel_admin.Visible = false;
            button9.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            richTextBox1.Text = "+四川大学\n+电子科技大学\n+西南交通大学\n+西南财经大学\n+四川农业大学\n+成都理工大学\n+四川师范大学\n+西南石油大学\n+成都中医药大学\n+成都工业学院 ";
        }
        private void label_aboutus_Click(object sender, EventArgs e)
        {
            panel_home.Visible = false;
            panel_teacherintroduce.Visible = false;
            panel_tresearch.Visible = false;
            panel_stusearch.Visible = false;
            panel_admin.Visible = false;
            panel_aboutus.Visible = true;
        }
        private void label1_teacherintroduce_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            search(dgvteacherintroduce);
            panel_home.Visible = false;
            panel_aboutus.Visible = false;
            panel_stusearch.Visible = false;
            panel_tresearch.Visible = false;
            panel_admin.Visible = false;
            panel_teacherintroduce.Visible = true;
            label16.Text = dgvteacherintroduce.Rows.Count.ToString();
            label18.Text = (dgvteacherintroduce.Rows.Count).ToString();
            if (dgvteacherintroduce.Rows.Count >= 1)
            {
                for (int i = 1; i <= dgvteacherintroduce.Rows.Count; i++)
                {
                    comboBox1.Items.Add(i);
                }
                comboBox1.Text = (dgvteacherintroduce.Rows.Count).ToString();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(comboBox1.SelectedItem) - 1;
            dgvteacherintroduce.Rows[x].Selected = true;
            label18.Text = (x + 1).ToString();
        }
        private void label1_teacherintroduce_MouseHover(object sender, EventArgs e)
        {
            label1_teacherintroduce.BackColor = Color.Coral;
        }
        private void label1_teacherintroduce_MouseLeave(object sender, EventArgs e)
        {
            label1_teacherintroduce.BackColor = Color.Transparent;
        }
        private void label_aboutus_MouseHover(object sender, EventArgs e)
        {
            label_aboutus.BackColor = Color.Coral;
        }
        private void label_aboutus_MouseLeave(object sender, EventArgs e)
        {
            label_aboutus.BackColor = Color.Transparent;
        }
        private void label_home_MouseHover(object sender, EventArgs e)
        {
            label_home.BackColor = Color.Coral;
        }
        private void label_home_MouseLeave(object sender, EventArgs e)
        {
            label_home.BackColor = Color.Transparent;
        }
        private void label_zhuce_MouseHover(object sender, EventArgs e)
        {
            label_zhuce.BackColor = Color.Coral;
        }
        private void label_zhuce_MouseLeave(object sender, EventArgs e)
        {
            label_zhuce.BackColor = Color.Transparent;
        }
        private void label_adminlogin_MouseHover(object sender, EventArgs e)
        {
            label_adminlogin.BackColor = Color.Coral;
        }
        private void label_adminlogin_MouseLeave(object sender, EventArgs e)
        {
            label_adminlogin.BackColor = Color.Transparent;
        }
        private void label41_MouseHover(object sender, EventArgs e)
        {
            label41.BackColor = Color.Coral;
        }
        private void label41_MouseLeave(object sender, EventArgs e)
        {
            label41.BackColor = Color.Transparent;
        }
        private void label_stusearch_MouseHover(object sender, EventArgs e)
        {
            label_stusearch.BackColor = Color.Coral;
        }
        private void label_stusearch_MouseLeave(object sender, EventArgs e)
        {
            label_stusearch.BackColor = Color.Transparent;
        }
        private void label_smodify_MouseHover(object sender, EventArgs e)
        {
            label_smodify.BackColor = Color.Coral;
        }
        private void label_smodify_MouseLeave(object sender, EventArgs e)
        {
            label_smodify.BackColor = Color.Transparent;
        }
        private void label_tmodify_MouseHover(object sender, EventArgs e)
        {
            label_tmodify.BackColor = Color.Coral;
        }
        private void label_tmodify_MouseLeave(object sender, EventArgs e)
        {
            label_tmodify.BackColor = Color.Transparent;
        }
        private void label31_MouseHover(object sender, EventArgs e)
        {
            label_tresearch.BackColor = Color.Coral;
        }
        private void label31_MouseLeave(object sender, EventArgs e)
        {
            label_tresearch.BackColor = Color.Transparent;
        }
        private void label_asin_MouseHover(object sender, EventArgs e)
        {
            label_asin.BackColor = Color.Coral;
        }
        private void label_asin_MouseLeave(object sender, EventArgs e)
        {
            label_asin.BackColor = Color.Transparent;
        }
        private void label_atin_MouseHover(object sender, EventArgs e)
        {
            label_atin.BackColor = Color.Coral;
        }

        private void label_atin_MouseLeave(object sender, EventArgs e)
        {
            label_atin.BackColor = Color.Transparent;
        }
        private void label_yuyue_MouseHover(object sender, EventArgs e)
        {
            label_yuyue.BackColor = Color.Coral;
        }

        private void label_yuyue_MouseLeave(object sender, EventArgs e)
        {
            label_yuyue.BackColor = Color.Transparent;
        }
        private void label_lookyuyue_MouseHover(object sender, EventArgs e)
        {
            label_lookyuyue.BackColor = Color.Coral;
        }

        private void label_lookyuyue_MouseLeave(object sender, EventArgs e)
        {
            label_lookyuyue.BackColor = Color.Transparent;
        }
        private void dgvteacherintroduce_Cell(object sender, DataGridViewCellEventArgs e)
        {
            label18.Text = (dgvteacherintroduce.CurrentCell.RowIndex + 1).ToString();
        }
        private void label_home_Click(object sender, EventArgs e)
        {
            panel_aboutus.Visible = false;
            panel_teacherintroduce.Visible = false;
            panel_stusearch.Visible = false;
            panel_tresearch.Visible = false;
            panel_admin.Visible = false;
            panel_tiezi.Visible = false;
            panel_home.Visible = true;
        }
        private void label_zhuce_Click(object sender, EventArgs e)
        {
            zhuce f = new zhuce();
            this.Hide();
            f.Show();
        }
        private void label_adminlogin_Click(object sender, EventArgs e)
        {
            denglu f = new denglu();
            f.Show();
            f.panel_student.Visible = true;
            f.panel_teacher.Visible = true;
            f.panel_admin.Visible = true;
            f.button1.Text = "管理员登录";
            f.textBox6.Focus();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            denglu f = new denglu();
            f.Show();
            f.panel_teacher.Visible = false;
            f.panel_admin.Visible = false;
            f.panel_student.Visible = true;
            f.button1.Text = "学员登录";
            f.textBox1.Focus();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            denglu f = new denglu();
            f.Show();
            f.panel_student.Visible = true;
            f.panel_admin.Visible = false;
            f.panel_teacher.Visible = true;
            f.button1.Text = "教员登录";
            f.textBox4.Focus();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            denglu f = new denglu();
            f.Show();
            f.panel_student.Visible = true;
            f.panel_teacher.Visible = true;
            f.panel_admin.Visible = true;
            f.button1.Text = "管理员登录";
            f.linkLabel1.Visible = false;
            f.textBox6.Focus();
            this.Hide();
        }
        public void search(DataGridView g)
        {
           
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from teacher";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            g.DataSource = dt;
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }
        private void label_stusearch_Click(object sender, EventArgs e)
        {
            panel_home.Visible = false;
            panel_yuyue.Visible = false;
            panel_aboutus.Visible = false;
            panel_teacherintroduce.Visible = false;
            panel_tresearch.Visible = false;
            panel_admin.Visible = false;
            panel_stusearch.Visible = true;
            search(dataGridView1); 
        }
        private void label_yuyue_Click(object sender, EventArgs e)
        {
            panel_home.Visible = false;
            panel_stusearch.Visible = true;
            panel_yuyue.Visible = true;
            search(dataGridView5);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string str = "";
            if ((radioButton1.Checked == true && textBox1.Text == "") || (radioButton2.Checked == true && textBox2.Text == "") || (radioButton3.Checked == true && textBox3.Text == ""))
            {
                str = "select * from teacher";
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    str = "select * from teacher where 性别='" + textBox1.Text + "'";
                }
                if (radioButton2.Checked == true)
                {
                    str = "select * from teacher where 学校='" + textBox2.Text + "'";
                }
                if (radioButton3.Checked == true)
                {
                    str = "select * from teacher where 专业='" + textBox3.Text + "'";
                }
            }
            OleDbConnection conn = new OleDbConnection(accesspath);
            OleDbDataAdapter da = null;
            try
            {
                da = new OleDbDataAdapter(str, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败");
            }
            conn.Close();
            conn.Dispose();
            da.Dispose();
            label32.Visible = true;
            label32.Text = "共查询到" + dataGridView1.RowCount + "条记录";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
        public void searchtostudent(DataGridView d)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from student";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
           d.DataSource = dt;
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }
        private void label_tresearch_Click(object sender, EventArgs e)
        {
            panel_home.Visible = false;
            panel_lookyuyue.Visible = false;
            panel_aboutus.Visible = false;
            panel_teacherintroduce.Visible = false;
            panel_stusearch.Visible = false;
            panel_admin.Visible = false;
            panel_tresearch.Visible = true;
            searchtostudent(dataGridView2);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string str = "";
            if ((radioButton4.Checked == true && textBox4.Text == "") || (radioButton5.Checked == true && textBox5.Text == "") || (radioButton6.Checked == true && textBox6.Text == ""))
            {
                str = "select * from student";
            }
            else
            {
                if (radioButton4.Checked)
                {
                    str = "select * from student where 年级='" + textBox4.Text + "'";
                }
                if (radioButton5.Checked == true)
                {
                    str = "select * from student where 上课时间='" + textBox5.Text + "'";
                }
                if (radioButton6.Checked == true)
                {
                    str = "select * from student where 科目='" + textBox6.Text + "'";
                }
            }
            OleDbConnection conn = new OleDbConnection(accesspath);
            OleDbDataAdapter da = null;
            try
            {
                da = new OleDbDataAdapter(str, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception)
            {

                MessageBox.Show("查询失败");
            }
            conn.Close();
            conn.Dispose();
            da.Dispose();
            label34.Visible = true;
            label34.Text = "共查询到" + dataGridView2.RowCount + "条记录";
        }
        private void label_smodify_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + label36.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            xiugaixinxi f = new xiugaixinxi();
            f.Show();
            f.button1.Text = "确认修改（学员）";
            f.textBox11.Text = ds.Tables["login"].Rows[0]["姓名"].ToString();
            f.panel_tmodify.Visible = true;
            f.panel_smodify.Visible = true;
        }
        private void label_tmodify_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + label36.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            xiugaixinxi f = new xiugaixinxi();
            f.Show();
            f.button1.Text = "确认修改（教员）";
            f.textBox1.Text = ds.Tables["login"].Rows[0]["编号"].ToString();
            f.panel_smodify.Visible = false;
            f.panel_tmodify.Visible = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认注销？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                panel_studentin.Visible = false;
                panel_stusearch.Visible = false;
                panel_teacherin.Visible = false;
                panel_teacherintroduce.Visible = false;
                panel_admin.Visible = false;
                panel_tresearch.Visible = false;
                richTextBox2.Visible = false;
                label35.Visible = false;
                label36.Visible = false;
                panel_home.Visible = true;
                panel_outlogin.Visible = true;
                groupBox1.Visible = true;
                button7.Visible = false;
                button11.Text = "查看帖子";
            }
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.baidu.com/");
        }
        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = imageList1.Images[i++];
            if (i > 3) i = 0;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("prj_8_1.html");
        }
        private void label_asin_Click(object sender, EventArgs e)
        {
            panel_home.Visible = false;
            panel_admin.Visible = true;
            label37.Visible = false;
            label38.Visible = true;
            label38.Text = "学员信息";
            button9.Visible = true;
            label39.Visible = true;
            radioButton7.Visible = true;
            radioButton8.Visible = true;
            dataGridView3.Visible = true;
            searchtostudent(dataGridView3);
        }
        private void label_atin_Click(object sender, EventArgs e)
        {
          
            label37.Visible = false;
            label38.Visible = true;
            label38.Text = "教员信息";
            button9.Visible = true;
            label39.Visible = true;
            search(dataGridView3);
            panel_home.Visible = false;
            panel_admin.Visible = true;
            radioButton7.Visible = true;
            radioButton8.Visible = true;
            dataGridView3.Visible = true;

        }
        private void button9_Click(object sender, EventArgs e)
        {
            int x = 0;
            OleDbConnection conn = new OleDbConnection(accesspath);
            string sql = "";
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView3.Rows[i].Cells["标记"].Value) == true)
                {
                    x++;
                }
            }
            if (dataGridView3.RowCount == 0)
                MessageBox.Show("没有可以删除的信息", "提示");
            else
            {
                if (x == 0)
                    MessageBox.Show("请选择要删掉的信息", "提示");
                else
                {
                    if (label38.Text == "学员信息")
                    {
                        if (MessageBox.Show("确认删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridView3.RowCount; i++)
                            {
                                if (Convert.ToBoolean(dataGridView3.Rows[i].Cells["标记"].Value) == true)
                                {
                                    string s = dataGridView3.Rows[i].Cells["姓名"].Value.ToString();
                                    sql = "delete from student where 姓名='" + s + "'";
                                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                                    if (conn.State != ConnectionState.Open)
                                        conn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                          
                        MessageBox.Show("删除成功");
                        }
                        searchtostudent(dataGridView3);
                    }
                    if (label38.Text == "教员信息")
                    {
                        if (MessageBox.Show("确认删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridView3.RowCount; i++)
                            {
                                if (Convert.ToBoolean(dataGridView3.Rows[i].Cells["标记"].Value) == true)
                                {
                                    string s = dataGridView3.Rows[i].Cells["教师编号"].Value.ToString();
                                    sql = "delete from teacher where 教师编号='" + s + "'";
                                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                                    if (conn.State != ConnectionState.Open)
                                        conn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                          
                        MessageBox.Show("删除成功");
                        }
                        search(dataGridView3);
                    }
                }
            }
        }
        int x = 480;
        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                dataGridView5.Rows[i].Cells["Column1"].Value = false;
                dataGridView5.CurrentRow.Cells["Column1"].Value = true;
            }

            if (radioButton7.Checked == true)
                for (int i = 0; i < dataGridView3.RowCount; i++)
                    dataGridView3.Rows[i].Cells["标记"].Value = true;
            label40.Location = new Point(x, label40.Location.Y);
            x += 2;
            if (x == 620)
            {
                label40.Visible = false;
                x = 480;
                label40.Visible = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            jianche f = new jianche();
            f.Show();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string s0 = dataGridView1.CurrentRow.Cells["教师编号"].Value.ToString();
            string s1 = dataGridView1.CurrentRow.Cells["教师姓名"].Value.ToString();
            string s2 = dataGridView1.CurrentRow.Cells["性别"].Value.ToString();
            string s3 = dataGridView1.CurrentRow.Cells["QQ"].Value.ToString();
            string s4 = dataGridView1.CurrentRow.Cells["学校"].Value.ToString();
            string s5 = dataGridView1.CurrentRow.Cells["年级"].Value.ToString();
            string s6 = dataGridView1.CurrentRow.Cells["专业"].Value.ToString();
            string s7 = dataGridView1.CurrentRow.Cells["价格"].Value.ToString();
            string s8 = dataGridView1.CurrentRow.Cells["电话"].Value.ToString();
            string s9 = dataGridView1.CurrentRow.Cells["自我描述"].Value.ToString();
            string s = "教师编号:" + s0 + "\n教师姓名:" + s1 + "\n性别:" + s2 + "\nQQ:" + s3 + "\n学校:" + s4 + "\n年级:" + s5 + "\n专业:" + s6 + "\n价格:" + s7 + "\n电话:" + s8 + "\n自我描述:" + s9;
            MessageBox.Show(s, "编号为" + s0 + "（教员）的详细信息");
        }
        private void dgvteacherintroduce_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string s0 = dgvteacherintroduce.CurrentRow.Cells["教师编号"].Value.ToString();
            string s1 = dgvteacherintroduce.CurrentRow.Cells["教师姓名"].Value.ToString();
            string s2 = dgvteacherintroduce.CurrentRow.Cells["性别"].Value.ToString();
            string s3 = dgvteacherintroduce.CurrentRow.Cells["QQ"].Value.ToString();
            string s4 = dgvteacherintroduce.CurrentRow.Cells["学校"].Value.ToString();
            string s5 = dgvteacherintroduce.CurrentRow.Cells["年级"].Value.ToString();
            string s6 = dgvteacherintroduce.CurrentRow.Cells["专业"].Value.ToString();
            string s7 = dgvteacherintroduce.CurrentRow.Cells["价格"].Value.ToString();
            string s8 = dgvteacherintroduce.CurrentRow.Cells["电话"].Value.ToString();
            string s9 = dgvteacherintroduce.CurrentRow.Cells["自我描述"].Value.ToString();
            string s = "教师编号:" + s0 + "\n教师姓名:" + s1 + "\n性别:" + s2 + "\nQQ:" + s3 + "\n学校:" + s4 + "\n年级:" + s5 + "\n专业:" + s6 + "\n价格:" + s7 + "\n电话:" + s8 + "\n自我描述:" + s9;
            MessageBox.Show(s, "编号为" + s0 + "（教员）的详细信息");
        }
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string s0 = dataGridView2.CurrentRow.Cells["姓名"].Value.ToString();
            string s1 = dataGridView2.CurrentRow.Cells["联系电话"].Value.ToString();
            string s2 = dataGridView2.CurrentRow.Cells["年级"].Value.ToString();
            string s3 = dataGridView2.CurrentRow.Cells["上课时间"].Value.ToString();
            string s4 = dataGridView2.CurrentRow.Cells["科目"].Value.ToString();
            string s5 = dataGridView2.CurrentRow.Cells["位置"].Value.ToString();
            string s = "姓名:" + s0 + "\n联系电话:" + s1 + "\n年级:" + s2 + "\n上课时间:" + s3 + "\n科目:" + s4 + "\n位置:" + s5;
            MessageBox.Show(s, s0 + "（学员）的详细信息");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string s = "";
            OleDbConnection conn = new OleDbConnection(accesspath);
            if (button11.Text == "查看帖子")
            {
                conn = new OleDbConnection(accesspath);
                panel_tiezi.Visible = true;
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tiezi", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //dt.Columns.Remove("ID");
                //  dt.Columns.Remove("发帖时间（数字）");
                dataGridView4.DataSource = dt;
                dataGridView4.Columns["ID"].Visible = false;
                dataGridView4.Columns["发帖时间（数字）"].Visible = false;
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
            if (button11.Text == "发表帖子")
            {
                string str = "select * from login where 用户名='" + label36.Text + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "login");
                s = ds.Tables["login"].Rows[0]["姓名"].ToString();
                tiezi f = new tiezi();
                f.Show();
                f.label1.Text = s;
                f.panel_ttiezi.Visible = false;
                f.panel_stiezi.Visible = true;
                conn.Open();
                conn.Dispose();
                da.Dispose();
            }
            if (button11.Text == "查看帖子 ")
            {
                string str = "select * from login where 用户名='" + label36.Text + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "login");
                s = ds.Tables["login"].Rows[0]["编号"].ToString();
                tiezi f = new tiezi();
                f.Show();
                f.label1.Text = s;
                f.panel_ttiezi.Visible = true;
                f.panel_stiezi.Visible = false;
                conn.Open();
                conn.Dispose();
                da.Dispose();
            }
        }
        private void label41_Click(object sender, EventArgs e)
        {
            tiezi f = new tiezi();
            f.Show();
            f.label1.Text = "管理员";
            f.panel_ttiezi.Visible = true;
            f.panel_stiezi.Visible = false;
            f.button4.Visible = true;
            f.dataGridView2.ReadOnly = false;
            f.dataGridView2.Columns["Column1"].Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        { int count = 0;
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView5.Rows[i].Cells["Column1"].Value) == true)
                {
                    count++;
                }
            }
            if (count == 0) MessageBox.Show("没有选中项");
            else {
                if (MessageBox.Show("是否预约?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OleDbConnection conn = new OleDbConnection(accesspath);
                    string username = label36.Text;
                    string teachernumber = dataGridView5.CurrentRow.Cells["教师编号"].Value.ToString();
                      string  str = "insert into yuyue(学员用户名,教师编号,时间) values('" + username + "','" + teachernumber+"','"+DateTime.Now.ToLocalTime()+"')";
                    OleDbCommand cmd = new OleDbCommand(str, conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("预约成功");
                    conn.Close();
                    conn.Dispose();
 
                }
            }
        }

        private void label_lookyuyue_Click(object sender, EventArgs e)
        {

            richTextBox3.Text = "";
            int count = 0;
            panel_home.Visible = false;
            panel_tresearch.Visible = true;
            panel_lookyuyue.Visible = true;
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "select * from login where 用户名='" + label36.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            string teacherno = ds.Tables["login"].Rows[0]["编号"].ToString();
            str = "select * from yuyue where 教师编号='" + teacherno + "'";
            OleDbCommand cmd = new OleDbCommand(str,conn);
            if (conn.State != ConnectionState.Open) conn.Open();
            OleDbDataReader r = cmd.ExecuteReader();
            da = new OleDbDataAdapter(str, conn);
            da.Fill(ds, "yuyue");
            while (r.Read())
            {

                string username = ds.Tables["yuyue"].Rows[count]["学员用户名"].ToString();
                string time = ds.Tables["yuyue"].Rows[count]["时间"].ToString();
                count++;
                richTextBox3.Text += "用户名为 " + username + " 的学员在 " + time + " 预约了您！\n";
            }
            if (count == 0) richTextBox3.Text = "暂时没有预约消息";
            label42.Text = "(" + count+")";
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "";
            if (textBox8.Text == "") MessageBox.Show("请输入要查询的用户名");
            else
            {
                str = "select * from login where 用户名='" + textBox8.Text + "'";
                OleDbCommand cmd = new OleDbCommand(str, conn);
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                DataTable dt = new DataTable();
                da.Fill(ds, "login");
                if (!r.Read())
                {
                    MessageBox.Show("没有找到该用户的信息");
                }
                else
                {
                    MessageBox.Show("用户名为 " + textBox8.Text + " 的学生的姓名为 " + ds.Tables["login"].Rows[0]["姓名"].ToString());
                    str = "select * from student where 姓名='" + ds.Tables["login"].Rows[0]["姓名"].ToString() + "'";
                    da = new OleDbDataAdapter(str, conn);
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    conn.Close();
                    conn.Dispose();
                    da.Dispose();
                }
            }
        }
    }
}
