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
    public partial class Form10 : Form
    {
        SqlConnection conn;
        string MaHD;
        public Form10(string key) : this()// lấy key từ lúc đăng nhập
        {
            MaHD = key;
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiChiTiet();
            HienThiNDHD();
        }

        public void HienThiChiTiet()
        {
            string sqlSelect = "SELECT DISTINCT SanPham.TenSP as 'Sản phẩm', ChiTietHoaDon.SoLuong as 'Số lượng', ThanhTien as 'Thành Tiền' FROM HoaDon, SanPham, ChiTietHoaDon WHERE ChiTietHoaDon.SanPham = SanPham.MaSP AND ChiTietHoaDon.MaHD=@MaHD";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("MaHD",MaHD);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataCTHD.DataSource = dt;


        }

        public void HienThiNDHD()
        {
            string sqlSelect = "SELECT DISTINCT TenKH,SdtKH,DiaChiKH,NgayLapHD, TongTien FROM KhachHang, HoaDon WHERE HoaDon.MaKH =KhachHang.MaKH AND  MaHD=@MaHD";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("MaHD", MaHD);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            txtTen.Text = dt.Rows[0][0].ToString();
            txtSDT.Text = dt.Rows[0][1].ToString();
            txtDC.Text = dt.Rows[0][2].ToString();
            txtNgay.Text = dt.Rows[0][3].ToString();
            txtTong.Text = dt.Rows[0][4].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
