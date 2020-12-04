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
    public partial class Form7 : Form
    {
        SqlConnection conn;
        public Form7()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(690, 415);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;

            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiSP();
        }
        public void HienThiSP()
        {
            string sqlSelect = "SELECT MaSP as 'Mã sản phẩm', TenSP as 'Tên sản phẩm', NSX as 'NSX', SoLuong as 'Số lượng' , DonGia as 'Đơn giá' FROM SanPham ";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn); 
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSanPham.DataSource = dt;
        }
    }
}
