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
    public partial class FormLogin : Form
    {
        SqlConnection conn;
        String K;
        public FormLogin()
        {
            InitializeComponent();
        }

        public void Connect() {
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(660, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;

            Connect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSignUp f = new FormSignUp();
            f.ShowDialog();
            this.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //lẩy tk đăng nhập để kiểm tra
            string sqlSelect = "SELECT count(*)  FROM Users WHERE NameLogin = @NameLogin and PassW=@PassW";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("NameLogin", txtUserName.Text.ToString());
            cmd.Parameters.AddWithValue("PassW", txtPass.Text.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            if (dt.Rows[0][0].ToString() == "1")
            {
                //lấy quyền hạn để xem có phải quản lý không
                string sql = "SELECT QuyenHan  FROM Users WHERE NameLogin = @NameLogin and PassW=@PassW";
                SqlCommand cm = new SqlCommand(sql, conn);
                cm.Parameters.AddWithValue("NameLogin", txtUserName.Text.ToString());
                cm.Parameters.AddWithValue("PassW", txtPass.Text.ToString());
                SqlDataReader dtr = cm.ExecuteReader();
                DataTable dtt = new DataTable();
                dtt.Load(dtr);

                if (dtt.Rows[0][0].ToString() == "Quản lý")
                {
                    K = "QL";//
                } else if (dtt.Rows[0][0].ToString() == "Kế toán")
                {
                    K = "KT";//
                }
                else if (dtt.Rows[0][0].ToString() == "Bán hàng")
                {
                    K = "BH";//
                }
                else if (dtt.Rows[0][0].ToString() == "Kho")
                {
                    K = "K";//
                }
                //đăng nhập thành công
                // vào trang chủ
                this.Hide();
                FormTrangChu f = new FormTrangChu(K);
                f.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Error: Tên đăng nhập hoặc mật khẩu không đúng");
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void ForgetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ với Quản lý để cấp lại mật khẩu!");
        }
    }
}
