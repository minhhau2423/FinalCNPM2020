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

    public partial class FormTrangChu : Form
    {
        SqlConnection conn;
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private String Key;// key để kiểm tra quyền hạn
        public FormTrangChu(String key) : this()// lấy key từ lúc đăng nhập
        {
            Key = key;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            if (Key != "QL")
            {
                createNewUser.Enabled = false;
                menuNV.Enabled = false;
                nhânViênToolStripMenuItem.Enabled = false;

            }
            if (Key == "BH") {
                menuKho.Enabled = false;
                menuThongKe.Enabled = false;
            }
            if(Key == "K")
            {
                menuHoaDon.Enabled = false;
                menuThongKe.Enabled = false;
            }
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();

        }
        public void HienThiNV()
        {
            string sqlSelect = "SELECT MaNV as 'Mã nhân viên', TenNV as 'Tên', GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh' , Email as 'Mail' , SDT as 'Số điện thoại', DiaChi as 'Địa chỉ', ViTri as 'Vị trí' FROM NhanVien WHERE TenNV like '%"+txtKey.Text+ "%' OR MaNV like '%"+txtKey.Text+ "%' OR NgaySinh  like '%" + txtKey.Text + "%' OR SDT like '%" + txtKey.Text + "%' OR DiaChi like '%" + txtKey.Text + "%' OR Email like '%" + txtKey.Text + "%' OR GioiTinh like '%" + txtKey.Text + "%' OR ViTri like '%" + txtKey.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSearch.DataSource = dt;
        }
        public void HienThiSP()
        {
            string sqlSelect = "SELECT MaSP as 'Mã sản phẩm', TenSP as 'Tên sản phẩm', NSX as 'NSX', SoLuong as 'Số lượng' , DonGia as 'Đơn giá' FROM SanPham WHERE TenSP like '%" + txtKey.Text + "%' OR MaSP like '%" + txtKey.Text + "%' OR NSX like '%" + txtKey.Text + "%' OR SoLuong like '%" + txtKey.Text + "%' OR DonGia like '%" + txtKey.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSearch.DataSource = dt;
        }
        public void HienThiKH()
        {
            string sqlSelect = "SELECT MaKH as 'Mã khách hàng', TenKH as 'Tên Khách hàng', sdtKH as 'Số điện thoại', DiaChiKH as 'Địa chỉ' FROM KhachHang WHERE TenKH like '%" + txtKey.Text + "%' OR MaKH like '%" + txtKey.Text + "%' OR SdtKH like '%" + txtKey.Text + "%' OR DiaChiKH like '%" + txtKey.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSearch.DataSource = dt;
        }
        public void HienThiHD()
        {
            string sqlSelect = "SELECT MaHD as 'Mã hóa đơn', MaNV as 'Mã nhân viên', MaKH as 'Mã khách hàng', NgayLapHD as 'Ngày lập', TongTien as 'Tổng tiền' FROM HoaDon WHERE MaKH like '%" + txtKey.Text + "%' OR MaNV like '%" + txtKey.Text + "%' OR NgayLapHD like '%" + txtKey.Text + "%' OR TongTien like '%" + txtKey.Text + "%' ";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSearch.DataSource = dt;
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass f = new FormChangePass();
            f.ShowDialog();
        }

        private void tạoUserMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSignUp f = new FormSignUp();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            this.Close();
            f.ShowDialog();

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNV f = new FormNV();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8(Key);
            f.ShowDialog();
        }

        private void menuHoaDon_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(!rdbNV.Checked && !rdbSP.Checked && !rdbHD.Checked && !rdbKH.Checked)
            {
                MessageBox.Show("Chưa chọn mục tìm kiếm.");
            }
            if (rdbNV.Checked)
            {
                    HienThiNV();
            }
            if (rdbSP.Checked)
            {
                    HienThiSP();
            }
            if (rdbKH.Checked)
            {
                    HienThiKH();
            }
            if (rdbHD.Checked)
            {
                    HienThiHD();
            }

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void menuKho_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.ShowDialog();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HỔ TRỢ HỆ THỐNG\n" +
                "Liên hệ:\n" +
                " - Admin: Trương Minh Hậu\n" +
                " - Số điện thoại: 0394294439\n" +
                " - Mail: minhhau2423@gmail.com\n");
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            f.ShowDialog();
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.ShowDialog();
        }
    }
}
