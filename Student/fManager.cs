using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class fManagerAdmin : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        
        public fManagerAdmin()
        {
            InitializeComponent();
           
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            svData s = new svData();
            s.Show();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM ct";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM khoa";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM gv";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView3.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM gv";
            if ( comboBox1.Text == "Tên")
            {
                sql = "SELECT * FROM gv where ten_gv like '%" + textBox1.Text + "%' ";
                
                
            }

            if (comboBox1.Text == "Email")
            {
                sql = "SELECT * FROM gv where gv.email like '%" + textBox1.Text + "%' ";
                
                
            }
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView3.DataSource = dt;
            conn.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM sinhvien";
            try
            {
                if (comboBox2.Text == "Tên")
                {
                    sql = "SELECT * FROM sinhvien where ten_sv like '%" + textBox2.Text + "%'";

                }
                if (comboBox2.Text == "Chương trình" && !string.IsNullOrEmpty(textBox2.Text))
                {
                    int ct = Int32.Parse(textBox2.Text);
                    sql = "select * from sinhvien where chuong_trinh = " + ct;

                }
                if (comboBox2.Text == "Khoa" && !string.IsNullOrEmpty(textBox2.Text))
                {

                    sql = "select * from sinhvien where khoa like '%" + textBox2.Text + "%'";

                }
                if (comboBox2.Text == "Khóa" && !string.IsNullOrEmpty(textBox2.Text))
                {
                    int k = Int32.Parse(textBox2.Text);
                    sql = "select * from sinhvien where k = " + k;

                }
                if (comboBox2.Text == "Lớp" && !string.IsNullOrEmpty(textBox2.Text))
                {
                    int lop = Int32.Parse(textBox2.Text);
                    sql = "select * from sinhvien where lop = " + lop;

                }
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView4.DataSource = dt;
                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Themsv them = new Themsv();
            them.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM sinhvien";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView4.DataSource = dt;
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Deletesv d = new Deletesv();
            d.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            updatesv up = new updatesv();
            up.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sv = textBox3.Text.ToLower();
            
            try
            {
                string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                
                conn.Open();
                string sql = "select * from sinhvien where ma_sv = '" +sv+ "'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hpAdmin hp = new hpAdmin(sv);
                    hp.ShowDialog();
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Không tìm thấy sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
