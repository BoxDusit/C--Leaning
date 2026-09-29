using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace app5
{
    public partial class WorkShop7 : Form
    {
        public WorkShop7()
        {
            InitializeComponent();
        }

        void showAllCustomer()
        {
            using (SqlConnection con = DBConnect.NorthwindConnection())
            {
                string sql = "Select * From CustomerOrderReport";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGridView.DataSource = dt;
            }
        }

        void showCustomerByID(string id)
        {
            using (SqlConnection conn = DBConnect.NorthwindConnection())
            {
                string sql = "Select * From CustomerOrderReport WHERE [รหัสลูกค้า] = @customerID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@customerID", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGridView.DataSource = dt;
            }
        }

        // 2. ค้นหาตามชื่อบริษัท
        void showCustomerOrderByCompanyName(string companyName)
        {
            using (SqlConnection conn = DBConnect.NorthwindConnection())
            {
                string sql = "Select * From CustomerOrderReport WHERE [ชื่อบริษัทลูกค้า] LIKE @companyName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@companyName", companyName + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGridView.DataSource = dt;
            }
        }

        // 3. ค้นหาตามประเทศ
        void showCustomerOrderByCountry(string country)
        {
            using (SqlConnection conn = DBConnect.NorthwindConnection())
            {
                string sql = "Select * From CustomerOrderReport WHERE [ประเทศ] LIKE @country";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@country", country + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGridView.DataSource = dt;
            }
        }

        private void WorkShop7_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 3;
            showAllCustomer();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (cboSearch.SelectedIndex == 0)
            {
                showCustomerByID(keyword);
            }
            else if (cboSearch.SelectedIndex == 1)
            {
                showCustomerOrderByCompanyName(keyword);
            }
            else if (cboSearch.SelectedIndex == 2)
            {
                showCustomerOrderByCountry(keyword);
            }
            else if (cboSearch.SelectedIndex == 3)
            {
                showAllCustomer();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSearch.SelectedIndex == 3)
            {
                txtSearch.Clear(); 
            }
            else
            {
                txtSearch.Focus();
            }
        }
    }
}