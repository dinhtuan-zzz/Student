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
    public partial class Themsv : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public Themsv()
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

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhập Khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }

            
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Bạn chưa nhập đường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Bạn chưa nhập huyện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Bạn chưa nhập thành phố.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Bạn chưa nhập Khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox9.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Bạn chưa nhập Lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Bạn chưa nhập Chương trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Focus();
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
                try
                {
                    conn.Open();
                    DateTime ngay = dateTimePicker1.Value;
                    string sql = "insert into sinhvien(ma_sv,ho_sv,ten_sv,ngay_sinh,k,duong,huyen,thanh_pho,khoa,lop,chuong_trinh) values(@masv, @hosv, @tensv, @ngaysinh, @k, @duong, @huyen, @thanhpho, @khoa, @lop, @ct)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add("@masv", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox1.Text;
                    cmd.Parameters.Add("@hosv", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox2.Text;
                    cmd.Parameters.Add("@tensv", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox3.Text;
                    cmd.Parameters.Add("@ngaysinh", NpgsqlTypes.NpgsqlDbType.Date).Value = ngay;
                    cmd.Parameters.Add("@k", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(textBox4.Text);
                    cmd.Parameters.Add("@duong", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox6.Text;
                    cmd.Parameters.Add("@huyen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox7.Text;
                    cmd.Parameters.Add("@thanhpho", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox8.Text;
                    cmd.Parameters.Add("@khoa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox9.Text;
                    cmd.Parameters.Add("@lop", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(textBox10.Text);
                    cmd.Parameters.Add("@ct", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(textBox11.Text);
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = "insert into account(username, pwd) values('" + textBox1.Text + "', '" + textBox1.Text + "')";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert done", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                }
                
            }
        }
    }
}
