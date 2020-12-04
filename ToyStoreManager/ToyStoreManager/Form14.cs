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
    public partial class Form14 : Form
    {

        SqlConnection conn;
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(816, 489);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            txtNam.Text = DateTime.Now.Year.ToString();
            txtThang.Text = DateTime.Now.Month.ToString();
            txtNgay.Text = DateTime.Now.Day.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSoDon.Text = "0";
            txtNhap.Text = "0";
            txtXuat.Text = "0";
            txtThu.Text = "0";
            txtChi.Text = "0";
            txtLoi.Text = "0";
            //số đơn
            string sqlSelect = "SELECT count(*)  FROM HoaDon WHERE YEAR(NgayLapHD)='"+txtNam.Text+"'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            //số sp nhập
            string sqlSelect1 = "SELECT SUM(SoLuongNhap)  FROM Kho WHERE YEAR(NgayNhap)='" + txtNam.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlSelect1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            //số sp bán
            string sqlSelect2 = "SELECT SUM(ChiTietHoaDon.SoLuong)  FROM ChiTietHoaDon,HoaDon WHERE ChiTietHoaDon.MaHD = HoaDon.MaHD  AND YEAR(NgayLapHD)='" + txtNam.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sqlSelect2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            // tổng thu
            string sqlSelect3 = "SELECT SUM(HoaDon.TongTien)  FROM HoaDon WHERE YEAR(NgayLapHD)='" + txtNam.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sqlSelect3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            //tổng chi
            string sqlSelect4 = "SELECT SUM(SoLuongNhap * GiaNhap)  FROM Kho WHERE YEAR(NgayNhap)='" + txtNam.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sqlSelect4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);



            if (dt.Rows[0][0].ToString() != "")
            {
                txtSoDon.Text = dt.Rows[0][0].ToString();
            }
            if (dt1.Rows[0][0].ToString() != "")
            {
                txtNhap.Text = dt1.Rows[0][0].ToString();
            }
            if (dt2.Rows[0][0].ToString() != "")
            {
                txtXuat.Text = dt2.Rows[0][0].ToString();
            }
            if (dt3.Rows[0][0].ToString() != "")
            {
                txtThu.Text = dt3.Rows[0][0].ToString();
            }
            if (dt4.Rows[0][0].ToString() != "")
            {
                txtChi.Text = dt4.Rows[0][0].ToString();

            }
            txtLoi.Text = (int.Parse(txtThu.Text) - int.Parse(txtChi.Text)).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSoDon.Text = "0";
            txtNhap.Text = "0";
            txtXuat.Text = "0";
            txtThu.Text = "0";
            txtChi.Text = "0";
            txtLoi.Text = "0";
            //số đơn
            string sqlSelect = "SELECT count(*)  FROM HoaDon WHERE YEAR(NgayLapHD)='" + txtNam.Text + "' AND MONTH(NgayLapHD)='" + txtThang.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            //số sp nhập
            string sqlSelect1 = "SELECT SUM(SoLuongNhap)  FROM Kho WHERE MONTH(NgayNhap)='" + txtThang.Text + "'  AND YEAR(NgayNhap)='" + txtNam.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlSelect1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            //số sp bán
            string sqlSelect2 = "SELECT SUM(ChiTietHoaDon.SoLuong)  FROM ChiTietHoaDon,HoaDon WHERE ChiTietHoaDon.MaHD = HoaDon.MaHD  AND MONTH(NgayLapHD)='" + txtThang.Text + "' AND YEAR(NgayLapHD)='" + txtNam.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sqlSelect2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            // tổng thu
            string sqlSelect3 = "SELECT SUM(HoaDon.TongTien)  FROM HoaDon WHERE YEAR(NgayLapHD)='" + txtNam.Text + "' AND MONTH(NgayLapHD)='" + txtThang.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sqlSelect3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            //tổng chi
            string sqlSelect4 = "SELECT SUM(SoLuongNhap * GiaNhap)  FROM Kho WHERE MONTH(NgayNhap)='" + txtThang.Text + "'  AND YEAR(NgayNhap)='" + txtNam.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sqlSelect4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            if (dt.Rows[0][0].ToString() != "")
            {
                txtSoDon.Text = dt.Rows[0][0].ToString();
            }
            if (dt1.Rows[0][0].ToString() != "")
            {
                txtNhap.Text = dt1.Rows[0][0].ToString();
            }
            if (dt2.Rows[0][0].ToString() != "")
            {
                txtXuat.Text = dt2.Rows[0][0].ToString();
            }
            if (dt3.Rows[0][0].ToString() != "")
            {
                txtThu.Text = dt3.Rows[0][0].ToString();
            }
            if (dt4.Rows[0][0].ToString() != "")
            {
                txtChi.Text = dt4.Rows[0][0].ToString();

            }
            txtLoi.Text = (int.Parse(txtThu.Text) - int.Parse(txtChi.Text)).ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSoDon.Text = "0";
            txtNhap.Text = "0";
            txtXuat.Text = "0";
            txtThu.Text = "0";
            txtChi.Text = "0";
            txtLoi.Text = "0";
            //số đơn
            string sqlSelect = "SELECT count(*)  FROM HoaDon WHERE YEAR(NgayLapHD)='" + txtNam.Text + "' AND MONTH(NgayLapHD)='" + txtThang.Text + "' AND DAY(NgayLapHD)='"+txtNgay.Text+"'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            //số sp nhập
            string sqlSelect1 = "SELECT SUM(SoLuongNhap)  FROM Kho WHERE MONTH(NgayNhap)='" + txtThang.Text + "'  AND YEAR(NgayNhap)='" + txtNam.Text + "'  AND DAY(NgayNhap)='" + txtNgay.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlSelect1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            //số sp bán
            string sqlSelect2 = "SELECT SUM(ChiTietHoaDon.SoLuong)  FROM ChiTietHoaDon,HoaDon WHERE ChiTietHoaDon.MaHD = HoaDon.MaHD  AND MONTH(NgayLapHD)='" + txtThang.Text + "' AND YEAR(NgayLapHD)='" + txtNam.Text + "'AND DAY(NgayLapHD)='" + txtNgay.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlSelect2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            // tổng thu
            string sqlSelect3 = "SELECT SUM(HoaDon.TongTien)  FROM HoaDon WHERE YEAR(NgayLapHD)='" + txtNam.Text + "' AND MONTH(NgayLapHD)='" + txtThang.Text + "' AND DAY(NgayLapHD)='" + txtNgay.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sqlSelect3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            //tổng chi
            string sqlSelect4 = "SELECT SUM(SoLuongNhap * GiaNhap)  FROM Kho WHERE MONTH(NgayNhap)='" + txtThang.Text + "'  AND YEAR(NgayNhap)='" + txtNam.Text + "' AND DAY(NgayNhap)='" + txtNgay.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sqlSelect4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            if (dt.Rows[0][0].ToString() != "")
            {
                txtSoDon.Text = dt.Rows[0][0].ToString();
            }
            if (dt1.Rows[0][0].ToString() != "")
            {
                txtNhap.Text = dt1.Rows[0][0].ToString();
            }
            if (dt2.Rows[0][0].ToString() != "")
            {
                txtXuat.Text = dt2.Rows[0][0].ToString();
            }
            if (dt3.Rows[0][0].ToString() != "")
            {
                txtThu.Text = dt3.Rows[0][0].ToString();
            }
            if (dt4.Rows[0][0].ToString() != "")
            {
                txtChi.Text = dt4.Rows[0][0].ToString();

            }
            txtLoi.Text = (int.Parse(txtThu.Text) - int.Parse(txtChi.Text)).ToString();
        }

        private void txtLoi_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
