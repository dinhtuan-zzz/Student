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
    public partial class Danh_sách_học_phần : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public Danh_sách_học_phần(string sv)
        {
            InitializeComponent();
            label2.Text = sv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = String.Format("Server={0};Port={1};" +
                        "User Id={2};Password={3};Database={4};",
                        "localhost", 5432, "postgres",
                        "flsforever", "student");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "select * from trang_thai where ma_sv = '" + label2.Text + "' and ma_hoc_phan = '" + textBox1.Text.ToUpper() + "'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if( string.Compare(textBox2.Text, "Qua") != 0 && string.Compare(textBox2.Text, "Chưa qua") != 0)
                {
                    MessageBox.Show("Trạng thái học tập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    conn = new NpgsqlConnection(connstring);
                    NpgsqlCommand cmd;
                    conn.Open();
                    sql = "update trang_thai set trang_thai = '"+textBox2.Text+"' where ma_sv = '" + label2.Text + "' and ma_hoc_phan = @mahp";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add("@mahp", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox1.Text.ToUpper();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xãy ra. Hãy thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
