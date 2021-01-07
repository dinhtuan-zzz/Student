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
    public partial class hpAdmin : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public hpAdmin(string sv)
        {
            InitializeComponent();
            label2.Text = sv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "select * from trang_thai where ma_sv = '" + label2.Text + "' and trang_thai = 'Qua'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", 5432, "postgres",
                    "flsforever", "student");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sql = "select * from trang_thai where ma_sv = '" + label2.Text + "' and trang_thai = 'Chưa qua'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Danh_sách_học_phần f = new Danh_sách_học_phần(label2.Text);
            f.ShowDialog();
        }
    }
}
