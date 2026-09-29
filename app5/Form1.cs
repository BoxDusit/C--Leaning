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
    public partial class ProductByCategory : Form
    {
        public ProductByCategory()
        {
            InitializeComponent();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cboCategory.SelectedValue);
            if (cid == 0)
            {
                showProducts();
            }
            else
            {
                showProducts(cid);
            }
        }

        private void ProductByCategory_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBConnect.NorthwindConnection();
            String sql = "Select CategoryID, CategoryName From Categories Order By CategoryName ASC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboCategory.DataSource = dt;
            cboCategory.ValueMember = "CategoryID";
            cboCategory.DisplayMember = "CategoryName";

            // เพิ่มรายการเลือกแบบทุกประเภท
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "All Categories";
            dt.Rows.Add(row);

            conn.Close();

            cboCategory.SelectedIndex = cboCategory.Items.Count - 1;
        }

        void showProducts()
        {
            SqlConnection conn = DBConnect.NorthwindConnection();

            String sql = "Select * From Products";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvResult.DataSource = dt;
            conn.Close();
        }

        void showProducts(int cid)
        {
            SqlConnection conn = DBConnect.NorthwindConnection();

            String sql = "Select * From Products Where CategoryID=@categoryID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@categoryID", cid);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvResult.DataSource = dt;
            conn.Close();
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
