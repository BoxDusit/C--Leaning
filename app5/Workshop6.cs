using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app5
{
    public partial class OrdersAndDetail : Form
    {
        public OrdersAndDetail()
        {
            InitializeComponent();
        }

        private void OrdersAndDetail_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBConnect.NorthwindConnection();

            String sql = "Select Distinct(Year(OrderDate)) As YearOrder From Orders Order By YearOrder";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboYear.DataSource = dt;
            cboYear.ValueMember = "YearOrder";
            cboYear.DisplayMember = "YearOrder";

            conn.Close();
        }

        void showOrderByYear(String year)
        {
            SqlConnection conn = DBConnect.NorthwindConnection();

            String sql = "Select * From Orders Where Year(Orderdate) = @year";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@year", year);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvOrders.DataSource = dt;
            conn.Close();
        }

        // โค้ดปุ่มแสดงข้อมูล (แก้ให้เรียกใช้งาน showOrderByYear แทน)
        private void btnShow_Click(object sender, EventArgs e)
        {
            string year = cboYear.Text;
            showOrderByYear(year);
        }

        // เมธอดแสดงรายละเอียดสินค้า (ย้ายโค้ดฐานข้อมูลจาก btnShow มาไว้ที่นี่)
        void showOrderDetail(int orderID)
        {
            SqlConnection conn = DBConnect.NorthwindConnection();

            String sql = "Select OD.ProductID, ProductName, CategoryName, OD.UnitPrice, Quantity, " +
                         "(OD.UnitPrice * Quantity) As SumPrice, discount, (OD.UnitPrice * Quantity * discount) As DiscountPrice, " +
                         "((OD.UnitPrice * Quantity)- (OD.UnitPrice * Quantity * discount)) As NetPrice " +
                         "From [Order Details] As OD inner join Products As P ON OD.ProductID = P.ProductID " +
                         "inner join Categories As C ON P.CategoryID = C.CategoryID Where OrderID = @orderID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvOrderDetail.DataSource = dt;
            conn.Close();
        }

        private void dgvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ปล่อยว่างไว้ได้ครับ ถ้าไม่ได้ใช้
        }

        // โค้ดสำหรับกดคลิกที่ตาราง Orders ด้านบน
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ป้องกัน Error กรณีคลิกโดนหัวตาราง (RowIndex จะเป็น -1)
            if (e.RowIndex >= 0)
            {
                int row = e.RowIndex;
                int orderID = Convert.ToInt32(dgvOrders.Rows[row].Cells[0].Value);

                showOrderDetail(orderID);
            }
        }
    }
}