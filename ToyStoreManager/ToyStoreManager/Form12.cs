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
    public partial class Form12 : Form
    {
        SqlConnection conn;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(670, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;

            

            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT MaSP FROM Kho  ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbMaSP.DisplayMember = "MaSP";
            cbbMaSP.ValueMember = "MaSP";
            cbbMaSP.DataSource = dt;

            HienThiKho();
            HienThiSP();
        }

        public void HienThiKho()
        {
            string sqlSelect = "SELECT Kho.MaSP as 'Mã sản phẩm', NgayNhap as 'Ngày nhập', SoLuongNhap as 'Số lượng nhập',SanPham.SoLuong as 'Số lượng còn',NgayXuatGanNhat as 'Ngày Xuất gần nhất' , SoLuongXuatGanNhat as 'Số lượng xuất gần nhất' , GiaNhap as 'Giá nhập' FROM Kho, SanPham WHERE Kho.MaSP=SanPham.MaSP";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataKho.DataSource = dt;
        }
        public void HienThiSP()
        {
            string sqlSelect = "SELECT MaSP as 'Mã sản phẩm', TenSP as 'Tên sản phẩm', NSX as 'NSX', SoLuong as 'Số lượng' , DonGia as 'Đơn giá' FROM SanPham ";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataSP.DataSource = dt;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT Count(*) FROM Kho WHERE MaSP=@MaSP";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("MaSP", txtMaSP.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("Trùng mã sản phẩm");
            }
            else
            {
                if (txtMaSP.Text == "" || txtGiaNhap.Text == "" || txtSLN.Text == "" || txtSLX.Text == "")
                {
                    MessageBox.Show("Hãy điền đủ thông tin.");
                }
                else {
                    String query1 = "INSERT INTO SanPham(MaSP,SoLuong) VALUES(@MaSP, @SoLuong)";
                    SqlCommand command1 = new SqlCommand(query1, conn);
                    command1.Parameters.AddWithValue("MaSP", txtMaSP.Text);
                    command1.Parameters.AddWithValue("SoLuong", int.Parse(txtSLN.Text.ToString()));
                    command1.ExecuteNonQuery();

                    String query = "INSERT INTO Kho VALUES(@MaSP, @NgayNhap, @SoLuongNhap ,@NgayXuatGanNhat, @SoLuongXuatGanNhat, @GiaNhap)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("MaSP", txtMaSP.Text);
                    command.Parameters.AddWithValue("NgayNhap", NgayNhap.Text);
                    command.Parameters.AddWithValue("SoLuongNhap", int.Parse(txtSLN.Text.ToString()));
                    command.Parameters.AddWithValue("NgayXuatGanNhat", NgayXuat.Text);
                    command.Parameters.AddWithValue("SoLuongXuatGanNhat", int.Parse(txtSLX.Text.ToString()));
                    command.Parameters.AddWithValue("GiaNhap", int.Parse(txtGiaNhap.Text.ToString()));
                    command.ExecuteNonQuery();



                    HienThiKho();
                    HienThiSP();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Kho WHERE MaSP = @MaSP";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaSP", txtMaSP.Text);
            command.ExecuteNonQuery();
            string query1 = "DELETE FROM SanPham WHERE MaSP = @MaSP";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.Parameters.AddWithValue("MaSP", txtMaSP.Text);
            command1.ExecuteNonQuery();
            HienThiKho();
            HienThiSP();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            String query1 = "UPDATE SanPham SET SoLuong=@SoLuong WHERE MaSP=@MaSP";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.Parameters.AddWithValue("MaSP", txtMaSP.Text);
            command1.Parameters.AddWithValue("SoLuong", int.Parse(txtSLN.Text.ToString()));
            command1.ExecuteNonQuery();

            String query = "UPDATE  Kho SET  NgayNhap = @NgayNhap, SoLuongNhap = @SoLuongNhap ,NgayXuatGanNhat = @NgayXuatGanNhat, SoLuongXuatGanNhat = @SoLuongXuatGanNhat, GiaNhap = @GiaNhap WHERE MaSP = @MaSP";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaSP", txtMaSP.Text);
            command.Parameters.AddWithValue("NgayNhap", NgayNhap.Value);
            command.Parameters.AddWithValue("SoLuongNhap", int.Parse(txtSLN.Text.ToString()));
            command.Parameters.AddWithValue("NgayXuatGanNhat", NgayXuat.Value);
            command.Parameters.AddWithValue("SoLuongXuatGanNhat", int.Parse(txtSLX.Text.ToString()));
            command.Parameters.AddWithValue("GiaNhap", int.Parse(txtGiaNhap.Text.ToString()));
            command.ExecuteNonQuery();


            HienThiSP();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtSLN.Clear();
            NgayNhap.Value = DateTime.Now;
            txtSLX.Clear();
            NgayXuat.Value = DateTime.Now;
            txtGiaNhap.Clear();
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaSP.Text = dataKho.Rows[numrow].Cells[0].Value.ToString();
            NgayNhap.Value = DateTime.ParseExact(dataKho.Rows[numrow].Cells[1].Value.ToString(), "dd/MM/yyyy h:mm:ss tt", null);
            txtSLN.Text = dataKho.Rows[numrow].Cells[2].Value.ToString();
            NgayXuat.Value = DateTime.ParseExact(dataKho.Rows[numrow].Cells[4].Value.ToString(), "dd/MM/yyyy h:mm:ss tt", null);
            txtSLX.Text = dataKho.Rows[numrow].Cells[5].Value.ToString();
            txtGiaNhap.Text = dataKho.Rows[numrow].Cells[6].Value.ToString();
            txtMaSP.Enabled = false;
            btnThem.Enabled = false;
            btnLamMoi.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy cập nhật những sản phẩm từ kho.");
        }

        private void btnCapNhat1_Click(object sender, EventArgs e)
        {
            String query1 = "UPDATE SanPham SET TenSP = @TenSP, NSX= @NSX,SoLuong=@SoLuong, DonGia=@DonGia WHERE MaSP=@MaSP";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.Parameters.AddWithValue("MaSP", cbbMaSP.Text);
            command1.Parameters.AddWithValue("TenSP", txtTenSP.Text);
            command1.Parameters.AddWithValue("NSX", txtNSX.Text);
            command1.Parameters.AddWithValue("SoLuong", int.Parse(txtSL.Text.ToString()));
            command1.Parameters.AddWithValue("DonGia", int.Parse(txtDonGia.Text.ToString()));

           
            command1.ExecuteNonQuery();
            HienThiSP();
            HienThiKho();

        }

        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            cbbMaSP.Text = dataSP.Rows[numrow].Cells[0].Value.ToString();
            txtTenSP.Text = dataSP.Rows[numrow].Cells[1].Value.ToString();
            txtNSX.Text = dataSP.Rows[numrow].Cells[2].Value.ToString();
            txtSL.Text = dataSP.Rows[numrow].Cells[3].Value.ToString();
            txtDonGia.Text = dataSP.Rows[numrow].Cells[4].Value.ToString();

            cbbMaSP.Enabled = false;
            btnThem1.Enabled = false;
            btnLamMoi1.Enabled = true;
            btnCapNhat1.Enabled = true;
            btnXoa1.Enabled = true;
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Kho WHERE MaSP = @MaSP";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaSP", cbbMaSP.Text);
            command.ExecuteNonQuery();
            string query1 = "DELETE FROM SanPham WHERE MaSP = @MaSP";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.Parameters.AddWithValue("MaSP", cbbMaSP.Text);
            command1.ExecuteNonQuery();
            HienThiSP();
            HienThiKho();
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
            cbbMaSP.Text = "";
            txtNSX.Clear();
            txtDonGia.Clear();
            txtSL.Clear();
            txtTenSP.Clear();
            cbbMaSP.Enabled = true;
            btnThem1.Enabled = true;
            btnLamMoi1.Enabled = false;
            btnCapNhat1.Enabled = true;
            btnXoa1.Enabled = false;

        }

        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT TenSP, DonGia, Soluong, NSX FROM SanPham WHERE MaSP=@MaSP", conn);
            cmd.Parameters.AddWithValue("MaSP", cbbMaSP.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(dr);
            txtTenSP.Text = d.Rows[0][0].ToString();
            txtNSX.Text = d.Rows[0][3].ToString();
            txtSL.Text = d.Rows[0][2].ToString();
            txtDonGia.Text = d.Rows[0][1].ToString();
            btnXoa1.Enabled = true;


        }
    }
}
