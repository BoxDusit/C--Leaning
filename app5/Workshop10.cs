using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace app5
{
    public partial class Workshop10 : Form
    {
        // ข้อ 6. ประกาศตัวแปรของคลาส
        string dept_id = "";
        string action = "";

        public Workshop10()
        {
            InitializeComponent();

            // ถอด event ก่อนแล้วค่อยผูกใหม่ เพื่อให้แน่ใจว่าแต่ละ event ทำงานแค่ครั้งเดียว
            // (ป้องกันกรณีที่ Designer ผูกไว้แล้ว ทำให้กดปุ่มครั้งเดียวแต่โค้ดรัน 2 รอบ)
            this.Load -= Workshop10_Load;
            this.Load += Workshop10_Load;

            dgvDepartment.CellMouseUp -= dgvDepartment_CellMouseUp;
            dgvDepartment.CellMouseUp += dgvDepartment_CellMouseUp;

            btnNew.Click -= btnNew_Click;
            btnNew.Click += btnNew_Click;

            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;
        }

        // ข้อ 7. แสดงข้อมูลทั้งหมดใน DataGridView
        private void ShowAllDepartment()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DBConnect.Company_DB_Connect())
            using (SqlDataAdapter da = new SqlDataAdapter("Select * From Department Order By dept_id", conn))
            {
                da.Fill(dt);
            }

            dgvDepartment.DataSource = dt;

            //----format dgvDepartment---
            //แสดง-ซ่อนคอลัมน์
            dgvDepartment.Columns[0].Visible = true;
            dgvDepartment.Columns[1].Visible = true;
            dgvDepartment.Columns[2].Visible = false;
            dgvDepartment.Columns[3].Visible = false;
            dgvDepartment.Columns[4].Visible = false;

            //กำหนดข้อความบนส่วนหัวตาราง
            dgvDepartment.Columns[0].HeaderText = "รหัสแผนก";
            dgvDepartment.Columns[1].HeaderText = "ชื่อแผนก";

            //กำหนดความกว้างคอลัมน์
            dgvDepartment.Columns[0].Width = 100;
            dgvDepartment.Columns[1].Width = 220;

            //กำหนดสีพื้นหลังแบบสลับ
            dgvDepartment.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgvDepartment.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            //กำหนดฟอนต์
            dgvDepartment.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvDepartment.DefaultCellStyle.Font = new Font("Tahoma", 11);
        }

        // เคลียร์ค่าตัวแปรและ TextBox ทั้งหมด
        private void ClearInputs()
        {
            dept_id = "";
            action = "";
            txtID.Clear();
            txtName.Clear();
            txtDesc.Clear();
            txtPhone.Clear();
            txtFax.Clear();
        }

        // ข้อ 8. เรียกใช้ ShowAllDepartment() ในเหตุการณ์ Form_Load
        private void Workshop10_Load(object sender, EventArgs e)
        {
            // จำกัดความยาวให้ตรงกับชนิดข้อมูลในตาราง
            txtID.MaxLength = 3;
            txtName.MaxLength = 30;
            txtDesc.MaxLength = 200;
            txtPhone.MaxLength = 10;
            txtFax.MaxLength = 10;

            txtDesc.Multiline = true;
            txtDesc.ReadOnly = false;
            txtDesc.Enabled = true;

            try
            {
                ShowAllDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดข้อมูลได้: " + ex.Message, "แจ้งข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ข้อ 9. เหตุการณ์คลิกปุ่ม "เพิ่มใหม่"
        private void btnNew_Click(object sender, EventArgs e)
        {
            //กำหนดค่าให้ตัวแปร
            dept_id = "";
            action = "insert";

            //เคลียร์ TextBox ให้ว่าง
            txtID.Clear();
            txtName.Clear();
            txtDesc.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtID.Focus();
        }

        // ข้อ 10. เหตุการณ์ CellMouseUp ของ dgvDepartment
        private void dgvDepartment_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;

            // คลิกที่หัวตาราง (row = -1) หรือแถวว่างท้ายตาราง ให้ข้าม
            if (row < 0 || dgvDepartment.Rows[row].IsNewRow)
            {
                return;
            }

            DataGridViewRow r = dgvDepartment.Rows[row];

            dept_id = Convert.ToString(r.Cells[0].Value).Trim();
            action = "update";
            //แสดงข้อมูลในTextBox
            txtID.Text = Convert.ToString(r.Cells[0].Value).Trim();
            txtName.Text = Convert.ToString(r.Cells[1].Value);
            txtDesc.Text = Convert.ToString(r.Cells[2].Value);
            txtPhone.Text = Convert.ToString(r.Cells[3].Value);
            txtFax.Text = Convert.ToString(r.Cells[4].Value);
        }

        // ข้อ 11. ฟังก์ชันสำหรับลบข้อมูลแผนก (Transaction)
        private void DeleteRecord()
        {
            SqlTransaction tr;   // ตัวแปร Transaction
            SqlConnection conn = DBConnect.Company_DB_Connect();
            bool success = false;

            tr = conn.BeginTransaction(); //เริ่มการทำงานแบบ Transaction
            try // เริ่มดักการทำงานของโค้ด
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.Transaction = tr;
                com.CommandText = "Delete From Department Where dept_id = @id";
                com.Parameters.AddWithValue("@id", dept_id);
                com.ExecuteNonQuery();

                tr.Commit(); //กำหนดให้การทำงานของ Transaction เสร็จสมบูรณ์
                success = true;
            }
            catch //กรณีเกิดข้อผิดพลาดในส่วนที่ดักการทำงานของโค้ด
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล", "แจ้งข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                try { tr.Rollback(); } catch { } //ยกเลิกการทำงานของ Transaction
            }
            finally
            {
                conn.Close();
            }

            if (success)
            {
                ShowAllDepartment(); //แสดงข้อมูลทั้งหมด

                //เคลียร์ค่าต่างๆ
                ClearInputs();
                txtID.Focus();
            }
        }

        // ข้อ 12. เหตุการณ์คลิกปุ่ม "ลบ"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dept_id == "") //ถ้าไม่ได้เลือกรายการใน DataGridView
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลบข้อมูล");
                return;
            }

            if (MessageBox.Show("คุณต้องการลบข้อมูลแผนก รหัส : " + dept_id + " ใช่หรือไม่", "ยืนยันการทำงาน",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        // ข้อ 14. ฟังก์ชันสำหรับเพิ่มข้อมูล (เรียก Store Procedure Insert_Department)
        private void InsertRecord()
        {
            int result;

            using (SqlConnection conn = DBConnect.Company_DB_Connect())
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Insert_Department";
                com.Parameters.Add("@id", SqlDbType.Char, 3).Value = txtID.Text.Trim();
                com.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = txtName.Text.Trim();
                com.Parameters.Add("@desc", SqlDbType.NVarChar, 200).Value = txtDesc.Text;
                com.Parameters.Add("@phone", SqlDbType.VarChar, 10).Value = txtPhone.Text.Trim();
                com.Parameters.Add("@fax", SqlDbType.VarChar, 10).Value = txtFax.Text.Trim();

                //กำหนดพารามิเตอร์ที่รับข้อมูลกลับ
                SqlParameter ret = com.Parameters.Add("@returnVal", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;

                com.ExecuteNonQuery(); // รันคำสั่ง sql

                //รับค่า Return Value
                result = (int)ret.Value;
            }

            if (result == -1)
            {
                MessageBox.Show("รหัสแผนกซ้ำ");
                txtID.Focus();
                txtID.SelectAll();
                return;
            }
            else if (result == 0)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มข้อมูล");
                return;
            }
            else
            {
                ShowAllDepartment();
                ClearInputs();
            }
        }

        // ข้อ 17. ฟังก์ชัน Update_Record() เพื่อแก้ไขข้อมูล (เรียก Store Procedure Update_Department)
        private void Update_Record()
        {
            int result;

            using (SqlConnection conn = DBConnect.Company_DB_Connect())
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Update_Department";
                com.Parameters.Add("@curr_id", SqlDbType.Char, 3).Value = dept_id;
                com.Parameters.Add("@id", SqlDbType.Char, 3).Value = txtID.Text.Trim();
                com.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = txtName.Text.Trim();
                com.Parameters.Add("@desc", SqlDbType.NVarChar, 200).Value = txtDesc.Text;
                com.Parameters.Add("@phone", SqlDbType.VarChar, 10).Value = txtPhone.Text.Trim();
                com.Parameters.Add("@fax", SqlDbType.VarChar, 10).Value = txtFax.Text.Trim();

                //กำหนดพารามิเตอร์ที่รับข้อมูลกลับ
                SqlParameter ret = com.Parameters.Add("@returnVal", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;

                com.ExecuteNonQuery();

                result = (int)ret.Value;
            }

            if (result == -1)
            {
                MessageBox.Show("รหัสแผนกซ้ำ");
                txtID.Focus();
                txtID.SelectAll();
                return;
            }
            else if (result == 0)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการปรับปรุงข้อมูล");
                return;
            }
            else
            {
                ShowAllDepartment();
                ClearInputs();
            }
        }

        // ข้อ 15 + 18. เหตุการณ์คลิกปุ่ม "บันทึก"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ยังไม่ได้กด "เพิ่มใหม่" และไม่ได้เลือกรายการในตาราง
            if (action == "")
            {
                MessageBox.Show("กรุณากดปุ่มเพิ่มใหม่ หรือเลือกรายการที่ต้องการแก้ไขก่อน");
                return;
            }

            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกรหัสแผนก");
                txtID.Focus();
                return;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกชื่อแผนก");
                txtName.Focus();
                return;
            }

            try
            {
                if (action == "insert")
                {
                    InsertRecord();
                }
                else if (action == "update")
                {
                    Update_Record();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "แจ้งข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // เมธอดว่างที่ Visual Studio สร้างไว้ตอนดับเบิลคลิก TextBox
        // เก็บไว้เพื่อไม่ให้ build พัง เพราะ Designer อาจอ้างถึงอยู่
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}