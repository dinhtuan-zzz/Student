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
    public partial class Deletesv : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public Deletesv()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool checkData()
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
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
                NpgsqlCommand cmd;
                conn.Open();

                string sql = "delete from sinhvien where ma_sv = @masv";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add("@masv", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox1.Text;
                cmd.ExecuteNonQuery();
                sql = "delete from account where username = '"+textBox1.Text+"'";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
        
                conn.Close();
                MessageBox.Show("Delete done", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
