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
    public partial class fLogin : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public fLogin()
        {
            InitializeComponent();
        }
        public bool checkData()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập username.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập password.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(checkData())
            {
                string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "select * from account where username = '" + textBox1.Text + "' and pwd = '"+textBox2.Text+"'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();
                if( (dt.Rows.Count > 0) && string.Equals(textBox1.Text, "admin") && string.Equals(textBox2.Text, "admin") )
                {
                    fManagerAdmin f = new fManagerAdmin();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if((dt.Rows.Count > 0) && string.Compare(textBox1.Text, "0") > 0 && string.Compare(textBox1.Text, "1201") < 0
                    && string.Compare(textBox2.Text, "0") > 0 && string.Compare(textBox2.Text, "1201") < 0 )
                {
                    fManagergv f = new fManagergv();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if ((dt.Rows.Count > 0) && !string.Equals(textBox1.Text, "admin") && string.Compare(textBox1.Text, "1200") > 0 )
                {
                    fManagersv f = new fManagersv(textBox1.Text);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
                textBox1.Text = "";
                textBox2.Text = "";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        


        /*private void button1_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student") ;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "select ma_gv, email from gv";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView2.DataSource = dt;
            
            conn.Close();
        }*/
    }
}
