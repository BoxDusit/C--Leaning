using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace app5
{
    public partial class FrmAddUser : Form
    {
        // ค่าที่ Stored Procedure AddUser_Transaction ส่งกลับ
        private const int RESULT_DUPLICATE = 0;   // อีเมลซ้ำ
        private const int RESULT_SUCCESS = 1;     // เพิ่มสำเร็จ
        // ค่าอื่น (เช่น -1) = เกิดข้อผิดพลาด

        public FrmAddUser()
        {
            InitializeComponent();

            // ใช้ -= ก่อน += เพื่อกัน event ผูกซ้ำ (ไม่ว่า Designer จะผูกไว้แล้วหรือไม่)
            this.Load -= FrmAddUser_Load;
            this.Load += FrmAddUser_Load;

            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            // พิมพ์อีเมลใหม่แล้วล้างข้อความแจ้งเตือนเดิม
            txtEmail.TextChanged -= txtEmail_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        // เมธอดว่างที่ Visual Studio สร้างไว้ (Designer อาจอ้างถึง จึงเก็บไว้)
        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lbEmailErr.Text = "*";
        }

        // Step 6: Form_Load
        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            setPosition();
            lbMsg.Visible = false;

            // ให้ข้อความแจ้งเตือนแสดงได้ยาวและเห็นชัด
            foreach (Label lb in new Label[] { lbEmailErr, lbPwdErr, lbCfPwdErr })
            {
                lb.AutoSize = true;
                lb.ForeColor = Color.Red;
            }

            // จำกัดความยาวให้ตรงกับคอลัมน์ในตาราง users
            txtEmail.MaxLength = 50;
            txtFirstname.MaxLength = 40;
            txtLastname.MaxLength = 60;
            txtPassword.MaxLength = 50;
            txtCfPassword.MaxLength = 50;

            // ซ่อนรหัสผ่านเป็นดอกจัน
            txtPassword.PasswordChar = '*';
            txtCfPassword.PasswordChar = '*';

            txtEmail.Focus();
        }

        // Step 3: กำหนดตัวเลือกใน combobox
        public void setPosition()
        {
            cboPosition.Items.Clear(); // กันรายการซ้ำถ้าเรียกซ้ำ
            cboPosition.Items.Add("Manager");
            cboPosition.Items.Add("IT Developer");
            cboPosition.Items.Add("Project Manager");
            cboPosition.Items.Add("UX/UI Designer");
            cboPosition.Items.Add("Database Admin");
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList; // เลือกได้เฉพาะรายการ
            cboPosition.SelectedIndex = 0;
        }

        // Step 4: ล้างค่าในฟอร์มกรอกข้อมูล
        public void clearForm()
        {
            txtEmail.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtPassword.Clear();
            txtCfPassword.Clear();
            if (cboPosition.Items.Count > 0)
            {
                cboPosition.SelectedIndex = 0;
            }

            lbEmailErr.Text = "*";
            lbPwdErr.Text = "*";
            lbCfPwdErr.Text = "*";

            txtEmail.Focus();
        }

        // ตรวจรูปแบบอีเมล
        private bool isValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // ตรวจเฉพาะอีเมล (ว่าง / รูปแบบ) คืนค่า true ถ้าผ่าน
        private bool validateEmail()
        {
            string email = txtEmail.Text.Trim();

            if (email == "")
            {
                lbEmailErr.Text = "ป้อนอีเมล์...";
                return false;
            }

            if (!isValidEmail(email))
            {
                lbEmailErr.Text = "รูปแบบอีเมล์ไม่ถูกต้อง";
                return false;
            }

            lbEmailErr.Text = "*";
            return true;
        }

        // ตรวจว่าอีเมลนี้มีในตาราง users แล้วหรือไม่ (ไม่ต้องรอกรอกรหัสผ่าน)
        private bool emailExists(string email)
        {
            using (SqlConnection conn = DBConnect.NorthwindConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM users WHERE userID = @userID", conn))
            {
                cmd.Parameters.Add("@userID", SqlDbType.NVarChar, 50).Value = email;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // แจ้งเตือนอีเมลซ้ำ
        private void showDuplicateEmail()
        {
            lbEmailErr.Text = "Email ซ้ำ!! มีผู้ใช้นี้ในระบบแล้ว";
            lbMsg.Visible = false;
            MessageBox.Show("อีเมลนี้มีอยู่ในระบบแล้ว ไม่สามารถเพิ่มข้อมูลได้",
                "อีเมลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            txtEmail.SelectAll();
        }

        // Step 5: ตรวจสอบข้อมูล  คืนค่า -1 ถ้ามีข้อผิดพลาด, 0 ถ้าผ่าน
        public int checkInputForm()
        {
            int status = 0;
            Control firstInvalid = null; // ช่องแรกที่ผิด ไว้ย้ายเคอร์เซอร์ไปหา

            // อีเมล
            if (!validateEmail())
            {
                status = -1;
                if (firstInvalid == null) firstInvalid = txtEmail;
            }

            // รหัสผ่าน
            if (txtPassword.Text == "")
            {
                lbPwdErr.Text = "ป้อนรหัสผ่าน...";
                status = -1;
                if (firstInvalid == null) firstInvalid = txtPassword;
            }
            else
            {
                lbPwdErr.Text = "*";
            }

            // ยืนยันรหัสผ่าน
            if (!txtCfPassword.Text.Equals(txtPassword.Text))
            {
                lbCfPwdErr.Text = "ป้อนรหัสผ่านให้ตรงกัน";
                status = -1;
                if (firstInvalid == null) firstInvalid = txtCfPassword;
            }
            else
            {
                lbCfPwdErr.Text = "*";
            }

            if (firstInvalid != null)
            {
                firstInvalid.Focus();
            }

            return status;
        }

        // Step 2: เรียกใช้โพรซีเดอร์ AddUser_Transaction
        // คืนค่า: 1 = เพิ่มสำเร็จ, 0 = อีเมลซ้ำ, ค่าอื่น = เกิดข้อผิดพลาด
        public int addNewUser()
        {
            using (SqlConnection conn = DBConnect.NorthwindConnection())
            using (SqlCommand cmd = new SqlCommand("AddUser_Transaction", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.NVarChar, 50).Value = txtEmail.Text.Trim();
                cmd.Parameters.Add("@firstname", SqlDbType.NVarChar, 100).Value = txtFirstname.Text.Trim();
                cmd.Parameters.Add("@lastname", SqlDbType.NVarChar, 100).Value = txtLastname.Text.Trim();
                cmd.Parameters.Add("@position", SqlDbType.NVarChar, 100).Value = cboPosition.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 255).Value = txtPassword.Text;

                SqlParameter result = new SqlParameter("@Result", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(result);

                cmd.ExecuteNonQuery();

                // ถ้า Procedure ไม่ได้ตั้งค่า @Result จะเป็น DBNull ให้ถือว่าผิดพลาด
                if (result.Value == null || result.Value == DBNull.Value) return -1;

                return Convert.ToInt32(result.Value);
            }
        }

        // Step 7: ปุ่มบันทึก
        private void btnSave_Click(object sender, EventArgs e)
        {
            lbMsg.Visible = false;

            try
            {
                // 1) ตรวจอีเมลก่อน ถ้าอีเมลถูกรูปแบบและซ้ำ ให้แจ้งทันที
                //    ไม่ต้องรอให้กรอกรหัสผ่านหรือช่องอื่นให้ครบ
                if (validateEmail() && emailExists(txtEmail.Text.Trim()))
                {
                    showDuplicateEmail();
                    return;
                }

                // 2) ตรวจช่องอื่นๆ (รหัสผ่าน ยืนยันรหัสผ่าน ฯลฯ)
                if (checkInputForm() == -1) return;

                // 3) บันทึกข้อมูล
                int result = addNewUser();

                if (result == RESULT_DUPLICATE)          // ซ้ำตอนบันทึก (กันกรณีมีคนเพิ่มพร้อมกัน)
                {
                    showDuplicateEmail();
                }
                else if (result == RESULT_SUCCESS)       // เพิ่มสำเร็จ
                {
                    clearForm();
                    lbMsg.Text = "เพิ่มข้อมูลผู้ใช้ในระบบเรียบร้อยแล้ว...";
                    lbMsg.Visible = true;
                }
                else                                     // ข้อผิดพลาดอื่น
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มข้อมูล กรุณาลองใหม่อีกครั้ง",
                        "แจ้งข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มข้อมูล: " + ex.Message, "แจ้งข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Step 8: ปุ่มเคลียร์
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
            lbMsg.Visible = false;
        }
    }
}