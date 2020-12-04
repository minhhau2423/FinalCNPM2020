using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ToyStoreManager
{
    public partial class FormSignUp : Form
    {

        SqlConnection conn;
        public FormSignUp()
        {
            InitializeComponent();
        }
        private void FormSignUp_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(660, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT MaNV FROM NhanVien ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbMaNV.DisplayMember = "MaNV";
            cbbMaNV.ValueMember = "MaNV";
            cbbMaNV.DataSource = dt;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioQL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioNV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (cbbMaNV.Text == "" || txtUserName.Text == "" || txtPass.Text == "" || txtPass2.Text == "" || cbbViTri.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!");
            }
            else
            {
                string sqlSelect = "SELECT count(*) FROM Users WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sqlSelect, conn);
                cmd.Parameters.AddWithValue("MaNV", cbbMaNV.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows[0][0].ToString() == "0")
                {
                    string sqlSelect2 = "SELECT count(*) FROM Users WHERE NameLogin = @NameLogin";
                    SqlCommand cmd2 = new SqlCommand(sqlSelect2, conn);
                    cmd2.Parameters.AddWithValue("NameLogin", txtUserName.Text);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(dr2);
                     if (dt2.Rows[0][0].ToString() == "0")
                    {
                        if (txtPass.Text == txtPass2.Text && txtPass.Text != "")
                        {
                            Add();
                            MessageBox.Show("Đăng ký tài khoản thành công.");
                        }
                        else MessageBox.Show("Xác nhận mật khẩu chưa đúng.");
                    }else MessageBox.Show("Tên đăng nhập đã tồn tại.");
                }
                else MessageBox.Show("Nhân viên này đã có tài khoản.");
            }
        }
        public void Add()
        {
            String query = "INSERT INTO Users VALUES(@MaNV, @NameLogin, @PassW ,@QuyenHan)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaNV", cbbMaNV.Text);
            command.Parameters.AddWithValue("NameLogin", txtUserName.Text);
            command.Parameters.AddWithValue("PassW", txtPass.Text);
            command.Parameters.AddWithValue("QuyenHan", cbbViTri.Text);
            command.ExecuteNonQuery();
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
