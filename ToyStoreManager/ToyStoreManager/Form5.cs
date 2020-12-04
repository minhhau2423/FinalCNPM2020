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
    public partial class FormNV : Form
    {
        SqlConnection conn;
        private String Key;// key để kiểm tra quyền hạn
        public FormNV(String key) : this()// lấy key từ lúc đăng nhập
        {
            Key = key;
        }
        public FormNV()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            MaximumSize = MinimumSize = new System.Drawing.Size(710, 480);
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;

            conn = new SqlConnection(@"Data Source=LAPTOP-7P911SC5;Initial Catalog=ToyStoreManager;Integrated Security=True");
            conn.Open();
            HienThiNV();
            HienThiUser();
        }
        public void HienThiNV()
        {
            string sqlSelect = "SELECT MaNV as 'Mã nhân viên', TenNV as 'Tên', GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh' , Email as 'Mail' , SDT as 'Số điện thoại', DiaChi as 'Địa chỉ', ViTri as 'Vị trí' FROM NhanVien";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataXemNV.DataSource = dt;
        }

       
        public void HienThiUser()
        {
            string sqlSelect = "SELECT MaNV as 'Mã nhân viên', NameLogin as 'Tên đăng nhập', PassW as 'Mật khẩu' , QuyenHan as 'Quyền Sử dụng'FROM Users";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataUser.DataSource = dt;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Class1 excel = new Class1();
                //DataTable dt = (DataTable)dataXemNV.DataSource;
                //excel.Export(dt, "Danh sach", "DANH SÁCH CÁC NHÂN VIÊN CỬA HÀNG");
                if (dataXemNV.Rows.Count > 0) {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Application.Workbooks.Add(Type.Missing);
                    //phần đầu
                    excelApp.Cells[1, dataXemNV.Columns.Count/2] = "DANH SÁCH NHÂN VIÊN";
                    excelApp.Cells[1, dataXemNV.Columns.Count / 2].Font.Bold = true;
                    excelApp.Cells[1, dataXemNV.Columns.Count / 2].Font.Size = "18";
                    //tiêu đề cột
                    for (int i=1; i < dataXemNV.Columns.Count + 1; i++)
                    {
                        excelApp.Cells[3, i] = dataXemNV.Columns[i - 1].HeaderText;
                        excelApp.Cells[3, i].Font.Bold = true;
                        excelApp.Cells[3, i].Interior.ColorIndex = 15;
                    }
                    //phần nội dung
                    for (int i = 0; i < dataXemNV.Rows.Count; i++)
                    {
                        for(int j = 0 ; j < dataXemNV.Columns.Count; j++)
                        {
                            if (dataXemNV.Rows[i].Cells[j].Value != null) {
                                excelApp.Cells[i + 4, j + 1] = "'"+dataXemNV.Rows[i].Cells[j].Value.ToString();
                            }
                            
                        }
                    }
                    excelApp.Columns.AutoFit();
                    excelApp.Visible = true;

                    releaseObject(excelApp);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
    

    private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataXemNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Class1 excel = new Class1();
                //DataTable dt = (DataTable)dataXemNV.DataSource;
                //excel.Export(dt, "Danh sach", "DANH SÁCH CÁC NHÂN VIÊN CỬA HÀNG");
                if (dataUser.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Application.Workbooks.Add(Type.Missing);
                    //phần đầu
                    excelApp.Cells[1, dataUser.Columns.Count / 2] = "DANH SÁCH CÁC TÀI KHOẢN";
                    excelApp.Cells[1, dataUser.Columns.Count / 2].Font.Bold = true;
                    excelApp.Cells[1, dataUser.Columns.Count / 2].Font.Size = "18";
                    //tiêu đề cột
                    for (int i = 1; i < dataUser.Columns.Count + 1; i++)
                    {
                        excelApp.Cells[3, i] = dataUser.Columns[i - 1].HeaderText;
                        excelApp.Cells[3, i].Font.Bold = true;
                        excelApp.Cells[3, i].Interior.ColorIndex = 15;
                    }
                    //phần nội dung
                    for (int i = 0; i < dataUser.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataUser.Columns.Count; j++)
                        {
                            if (dataUser.Rows[i].Cells[j].Value != null)
                            {
                                excelApp.Cells[i + 4, j + 1] = "'" + dataUser.Rows[i].Cells[j].Value.ToString();
                            }

                        }
                    }
                    excelApp.Columns.AutoFit();
                    excelApp.Visible = true;

                    releaseObject(excelApp);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
