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
    public partial class Form13 : Form
    {
        SqlConnection conn;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(670, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiKH();
        }
        public void HienThiKH()
        {
            string sqlSelect = "SELECT MaKH as 'Mã khách hàng', TenKH as 'Tên Khách hàng', sdtKH as 'Số điện thoại', DiaChiKH as 'Địa chỉ' FROM KhachHang";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataKhachHang.DataSource = dt;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT Count(*) FROM KhachHang WHERE MaKH=@MaKH";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("MaKH", txtMaKH.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("Trùng mã Khách hàng");
            }
            else
            {

                String query = "INSERT INTO KhachHang VALUES(@MaKH, @TenKH, @SdtKH, @DiaChi)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("MaKH", txtMaKH.Text);
                command.Parameters.AddWithValue("TenKH", txtTenKH.Text);
                command.Parameters.AddWithValue("SdtKH", txtSDT.Text);
                command.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
                
                command.ExecuteNonQuery();
                HienThiKH();
            }
        }

        private void dataKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaKH.Text = dataKhachHang.Rows[numrow].Cells[0].Value.ToString();
            txtTenKH.Text = dataKhachHang.Rows[numrow].Cells[1].Value.ToString();
            txtSDT.Text = dataKhachHang.Rows[numrow].Cells[2].Value.ToString();
            txtDiaChi.Text = dataKhachHang.Rows[numrow].Cells[3].Value.ToString();

            txtMaKH.Enabled = false;
            btnThem.Enabled = false;
            btnLamMoi.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            
            txtMaKH.Enabled = true;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaKH", txtMaKH.Text);
            command.ExecuteNonQuery();
            HienThiKH();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            String query = "UPDATE KhachHang SET TenKH=@TenKH, SdtKH=@SdtKH, DiaChiKH=@DiaChiKH WHERE MaKH=@MaKH";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaKH", txtMaKH.Text);
            command.Parameters.AddWithValue("TenKH", txtTenKH.Text);
            command.Parameters.AddWithValue("SdtKH", txtSDT.Text);
            command.Parameters.AddWithValue("DiaChiKH", txtDiaChi.Text);
            
            command.ExecuteNonQuery();
            HienThiKH();
        }
    }
}
