using System;
using System.Data;
using System.Data.SqlClient;

namespace app5
{
    internal class DBConnect
    {
        // ใช้กับ Workshop เดิมที่เชื่อมต่อ Northwind
        public static SqlConnection NorthwindConnection()
        {
            string connectionString = "Server=MSI\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            return con;
        }

        // ใช้กับ Workshop10 (Ex.3) ที่เชื่อมต่อ Company_DB
        public static SqlConnection Company_DB_Connect()
        {
            string connectionString = "Server=MSI\\SQLEXPRESS;Database=Company_DB;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            return con;
        }
    }
}