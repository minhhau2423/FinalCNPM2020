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

   
    public partial class Form6 : Form
    {
        SqlConnection conn;
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(670, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
        
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiNV();
        }
        public void HienThiNV()
        {
            string sqlSelect = "SELECT MaNV as 'Mã nhân viên', TenNV as 'Tên', GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh' , Email as 'Mail' , SDT as 'Số điện thoại', DiaChi as 'Địa chỉ', ViTri as 'Vị trí' FROM NhanVien";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataQLNV.DataSource = dt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT Count(*) FROM NhanVien WHERE MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.Parameters.AddWithValue("MaNV", txtMaNV.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("Trùng mã nhân viên");
            }
            else
            {

                String query = "INSERT INTO NhanVien VALUES(@MaNV, @TenNV, @NgaySinh ,@Email, @SDT, @DiaChi, @ViTri, @GioiTinh)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("MaNV", txtMaNV.Text);
                command.Parameters.AddWithValue("TenNV", txtTenNV.Text);
                command.Parameters.AddWithValue("NgaySinh", NgaySinhNV.Value);
                command.Parameters.AddWithValue("Email", txtEmail.Text);
                command.Parameters.AddWithValue("SDT", txtSDT.Text);
                command.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
                command.Parameters.AddWithValue("ViTri", cbbViTri.Text);
                command.Parameters.AddWithValue("GioiTinh", txtGioiTinh.Text);
                command.ExecuteNonQuery();
                HienThiNV();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaNV", txtMaNV.Text);
            command.ExecuteNonQuery();
            HienThiNV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "UPDATE NhanVien SET TenNV=@TenNV, NgaySinh=@NgaySinh ,Email=@Email, SDT=@SDT, DiaChi=@DiaChi, ViTri=@ViTri, GioiTinh=@GioiTinh  WHERE MaNV=@MaNV";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaNV", txtMaNV.Text);
            command.Parameters.AddWithValue("TenNV", txtTenNV.Text);
            command.Parameters.AddWithValue("NgaySinh", NgaySinhNV.Value);
            command.Parameters.AddWithValue("Email", txtEmail.Text);
            command.Parameters.AddWithValue("SDT", txtSDT.Text);
            command.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
            command.Parameters.AddWithValue("ViTri", cbbViTri.Text);
            command.Parameters.AddWithValue("GioiTinh", txtGioiTinh.Text);
            command.ExecuteNonQuery();
            HienThiNV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtGioiTinh.Text="";
            txtEmail.Clear();
            txtSDT.Clear();
            cbbViTri.Text = "";
            NgaySinhNV.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dataQLNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaNV.Text = dataQLNV.Rows[numrow].Cells[0].Value.ToString();
            txtTenNV.Text = dataQLNV.Rows[numrow].Cells[1].Value.ToString();
            txtGioiTinh.Text = dataQLNV.Rows[numrow].Cells[2].Value.ToString();
            NgaySinhNV.Value = DateTime.ParseExact(dataQLNV.Rows[numrow].Cells[3].Value.ToString(), "dd/MM/yyyy h:mm:ss tt", null);
            txtEmail.Text = dataQLNV.Rows[numrow].Cells[4].Value.ToString();
            txtSDT.Text = dataQLNV.Rows[numrow].Cells[5].Value.ToString();
            txtDiaChi.Text = dataQLNV.Rows[numrow].Cells[6].Value.ToString();
            cbbViTri.Text = dataQLNV.Rows[numrow].Cells[7].Value.ToString();
            txtMaNV.Enabled = false;
            btnThem.Enabled = false;
            btnLamMoi.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbbViTri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
