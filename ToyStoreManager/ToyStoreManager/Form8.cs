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

    
    public partial class Form8 : Form
    {
        SqlConnection conn;
        string MaHD;
        public Form8()
        {
            InitializeComponent();
        }
        private String Key;// key để kiểm tra quyền hạn
        public Form8(String key) : this()// lấy key từ lúc đăng nhập
        {
            Key = key;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            MaHD = cbbMaHD.Text;
            Form10 f = new Form10(MaHD);
            f.ShowDialog();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new System.Drawing.Size(690, 415);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiHD();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT MaHD FROM HoaDon ", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbbMaHD.DisplayMember = "MaHD";
            cbbMaHD.ValueMember = "MaHD";
            cbbMaHD.DataSource = dt1;
            if (Key != "QL")
            {
                button1.Enabled = false;
            }
        }
        public void HienThiHD()
        {
            string sqlSelect = "SELECT MaHD as 'Mã hóa đơn', MaNV as 'Mã nhân viên', MaKH as 'Mã khách hàng', NgayLapHD as 'Ngày lập', TongTien as 'Tổng tiền' FROM HoaDon";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataHoaDon.DataSource = dt;
        }

        private void dataHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            cbbMaHD.Text = dataHoaDon.Rows[numrow].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.Parameters.AddWithValue("MaHD", cbbMaHD.Text);
            command1.ExecuteNonQuery();

            string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("MaHD", cbbMaHD.Text);
            command.ExecuteNonQuery();
            
            HienThiHD();

        }
    }
}
