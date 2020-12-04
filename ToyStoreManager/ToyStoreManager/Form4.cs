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
    public partial class FormChangePass : Form
    {
        SqlConnection conn;
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChangePass_Load(object sender, EventArgs e)
        {
            MaximumSize= MinimumSize = new System.Drawing.Size(410,400);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width  - this.Width)/ 2;
            this.Top = (scr.WorkingArea.Height - this.Height)/ 2;

            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT count(*)  FROM Users WHERE NameLogin = @NameLogin and PassW=@PassW";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("NameLogin", txtUserName.Text.ToString());
            cmd.Parameters.AddWithValue("PassW", txtOldPass.Text.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtUserName.Text == "" || txtOldPass.Text == "" || txtNewPass.Text == "" || txtNewPass2.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin.");
                }
                else
                {
                    if (txtNewPass.Text != txtNewPass2.Text)
                    {
                        MessageBox.Show("Mật khẩu mới chưa khớp");
                    }
                    else
                    {
                        String query = "UPDATE Users SET  PassW = @PassW WHERE NameLogin = @NameLogin";
                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("PassW", txtNewPass.Text);
                        command.Parameters.AddWithValue("NameLogin", txtUserName.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công.");
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu củ không đúng.");
            }

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtNewPass2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChangePass.PerformClick();
            }
        }

        private void btnChangePass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChangePass.PerformClick();
            }
        }

        private void btnExit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnExit.PerformClick();
            }
        }
    }
}
