using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace _20171028
{
    public partial class tiezi : Form
    {
        string accesspath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\jiajiaoxitong.mdb";
        public tiezi()
        {
            InitializeComponent();
            panel_sftiezi.Visible = false;
            button2.Visible = false;
            OleDbConnection conn = new OleDbConnection(accesspath);
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tiezi", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //   dt.Columns.Remove("ID");
            // dt.Columns.Remove("发帖时间（数字）");
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["发帖时间（数字）"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["发帖时间（数字）"].Visible = false;
            conn.Close();
            conn.Dispose();
            da.Dispose();
            button4.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel_sftiezi.Visible = true;
            button2.Visible = true;
            textBox1.Text = label1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || richTextBox1.Text == "" || richTextBox1.Text.Trim(' ').Length == 0)
                MessageBox.Show("请填完所有选项", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string s = "";
                string[] array = dateTimePicker1.Text.Split('/');
                for (int i = 0; i < array.Length; i++)//将发帖时间年月日转化成数字用于按时间查询帖子。
                    s += array[i];
                OleDbConnection conn = new OleDbConnection(accesspath);
                string str = "insert into tiezi(发帖人,帖子主题,帖子内容,发帖时间) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Text + "')";
                OleDbCommand cmd = new OleDbCommand(str, conn);
                if (conn.State != ConnectionState.Open) conn.Open();
                cmd.ExecuteNonQuery();
                str = "update tiezi set 发帖时间（数字）=" + Convert.ToInt32(s) + " where 发帖时间='" + dateTimePicker1.Text + "'";
                cmd = new OleDbCommand(str, conn);
                if (conn.State != ConnectionState.Open) conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("帖子添加成功", "提示");
                richTextBox1.Text = "";
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tiezi", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Remove("ID");
                dt.Columns.Remove("发帖时间（数字）");
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                panel_sftiezi.Visible = false;
                panel_stiezi.Visible = true;
                button1.Visible = true;
                button2.Visible = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "", s = "";
            string[] array = dateTimePicker2.Text.Split('/');
            for (int i = 0; i < array.Length; i++)
                s += array[i];
            if (comboBox2.Text == "" || comboBox2.Text == "全部")
                str = "select * from tiezi where 发帖时间（数字）>=" + Convert.ToInt32(s);
            else
                str = "select * from tiezi where 发帖时间（数字）>=" + Convert.ToInt32(s) + "and 帖子主题='" + comboBox2.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //  dt.Columns.Remove("ID");
            //  dt.Columns.Remove("发帖时间（数字）");
            dataGridView2.DataSource = dt;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["发帖时间（数字）"].Visible = false;
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = "共查询到" + dataGridView2.RowCount + "条记录";
        }
        private void button4_Click(object sender, EventArgs e)//删除帖子
        {
            int m = 0;
            OleDbConnection conn = new OleDbConnection(accesspath);
            string str = "";
            if (dataGridView2.RowCount == 0)
                MessageBox.Show("没有可以删除的数据", "提示");
            else
            {
                if (MessageBox.Show("确认删除选中的内容", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["Column1"].Value) == true)
                            {
                                m++;
                                int x = Convert.ToInt32(dataGridView2.Rows[i].Cells["ID"].Value);

                                str = "delete from tiezi where ID=" + x;//ID为存储帖子表的主键，选中项的ID删除该条帖子
                                OleDbCommand cmd = new OleDbCommand(str, conn);
                                if (conn.State != ConnectionState.Open) conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (m == 0) MessageBox.Show("没有要删除的内容", "提示");
                        else
                        {
                            str = "select * from tiezi";
                            OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView2.DataSource = dt;
                            conn.Close();
                            conn.Dispose();
                            da.Dispose();

                            MessageBox.Show("删除成功", "提示");
                        }
                    }
                    catch (Exception w)
                    {
                        MessageBox.Show(w.Message);
                    }
                }
            }
        }
    }
}
