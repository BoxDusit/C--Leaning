using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2
{
    public partial class Form1 : Form
    {
        double unitPrice = 0.0;
        int itemIndex = 1; // ตัวนับลำดับที่สำหรับ dgvList

        public Form1()
        {
            InitializeComponent();

            // 1. 🔥 บังคับให้สร้างคอลัมน์ตั้งแต่ตอนเปิดหน้าจอ (แก้ Error คอลัมน์ไม่มี)
            this.Load += Form1_Load;

            // 2. 🔥 บังคับให้ปุ่มกดทำงาน (เผื่อหน้าดีไซน์ไม่ได้ผูกไว้)
            btnAdd.Click += btnAdd_Click;
            btnNew.Click += btnNew_Click;

            // 3. 🔥 บังคับให้อัปเดตราคารวมทันทีที่กดลูกศรเปลี่ยนจำนวน
            numQty.ValueChanged += numQty_ValueChanged;

            // 4. ผูกเหตุการณ์ CheckedChanged เข้ากับตัวเลือกทั้งหมด
            rdbAmericano.CheckedChanged += RadioButtons_CheckedChanged;
            rdbEspresso.CheckedChanged += RadioButtons_CheckedChanged;
            rdbCappuccino.CheckedChanged += RadioButtons_CheckedChanged;
            rdbLatte.CheckedChanged += RadioButtons_CheckedChanged;
            rdbMocha.CheckedChanged += RadioButtons_CheckedChanged;

            RdbHot.CheckedChanged += RadioButtons_CheckedChanged;
            rdbIced.CheckedChanged += RadioButtons_CheckedChanged;
            rdbSmoothie.CheckedChanged += RadioButtons_CheckedChanged;

            rdbSmall.CheckedChanged += RadioButtons_CheckedChanged;
            rdbMedium.CheckedChanged += RadioButtons_CheckedChanged;
            rdbLarge.CheckedChanged += RadioButtons_CheckedChanged;

            ckbShot.CheckedChanged += RadioButtons_CheckedChanged;
            ckbWhip.CheckedChanged += RadioButtons_CheckedChanged;
        }

        // --- 1. ฟังก์ชันคำนวณราคาต่อหน่วย ---
        public void calculatePrice()
        {
            unitPrice = 0.0;

            // ก. กำหนดราคาตั้งต้นจากชนิดเครื่องดื่ม (อิงจากราคาร้อน ไซส์ S)
            if (rdbAmericano.Checked) unitPrice = 35.0;
            else if (rdbEspresso.Checked) unitPrice = 40.0;
            else if (rdbCappuccino.Checked) unitPrice = 45.0;
            else if (rdbLatte.Checked) unitPrice = 50.0;
            else if (rdbMocha.Checked) unitPrice = 55.0;

            // ข. บวกราคาเพิ่มตามประเภท (เย็น / ปั่น)
            if (rdbIced.Checked) unitPrice += 5.0;
            else if (rdbSmoothie.Checked) unitPrice += 10.0;

            // ค. บวกราคาเพิ่มตามขนาด (ไซส์ M / L)
            if (rdbMedium.Checked) unitPrice += 5.0;
            else if (rdbLarge.Checked) unitPrice += 10.0;

            // *** ง. ดักจับเงื่อนไขพิเศษตามตาราง: Cappuccino เย็น L ให้เป็น 50 บาท ***
            if (rdbCappuccino.Checked && rdbIced.Checked && rdbLarge.Checked)
            {
                unitPrice = 50.0;
            }

            // จ. บวกราคา Option พิเศษ 
            if (ckbShot.Checked) unitPrice += 15.0;
            if (ckbWhip.Checked) unitPrice += 10.0;

            // แสดงผลราคาต่อหน่วย
            txtPrice.Text = unitPrice.ToString("0.00");

            // อัปเดตราคารวมด้วยเสมอเมื่อมีการเปลี่ยนเงื่อนไข
            calculateRowSum();
        }

        // --- 2. ฟังก์ชันคำนวณราคารวม (หน่วย x จำนวน) ---
        private void calculateRowSum()
        {
            // 🚨 แก้ไข: ดึงค่าด้วย .Value แทน .Text
            int qty = (int)numQty.Value;

            if (qty > 0)
            {
                double rowSum = unitPrice * qty;
                txtSum.Text = rowSum.ToString("0.00");
            }
            else
            {
                txtSum.Text = "0.00";
            }
        }

        // --- 3. ฟังก์ชันรีเซ็ตหน้าจอตามข้อกำหนด ---
        private void ResetForm()
        {
            rdbAmericano.Checked = true;
            RdbHot.Checked = true;
            rdbSmall.Checked = true;

            ckbShot.Checked = false;
            ckbWhip.Checked = false;

            numQty.Text = "0";
            txtSum.Text = "0.00";

            calculatePrice();
        }

        // --- 4. ฟังก์ชันคำนวณยอดเงินรวมทั้งหมด ---
        private void CalculateGrandTotal()
        {
            double grandTotal = 0.0;

            // วนลูปบวกค่าในคอลัมน์ Index ที่ 5 (ราคารวม)
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    grandTotal += Convert.ToDouble(row.Cells[5].Value);
                }
            }

            lbTotal.Text = grandTotal.ToString("0.00");
        }

        // ============================================
        // เหตุการณ์ต่างๆ (EVENTS)
        // ============================================

        // เมื่อรันโปรแกรมขึ้นมาครั้งแรก
        private void Form1_Load(object sender, EventArgs e)
        {
            // ล้างคอลัมน์เก่าที่อาจมีค้างอยู่ แล้วสร้าง 6 คอลัมน์ตามโจทย์เป๊ะ
            dgvList.Columns.Clear();
            dgvList.ColumnCount = 6;
            dgvList.Columns[0].Name = "ที่";
            dgvList.Columns[1].Name = "รายการ";
            dgvList.Columns[2].Name = "พิเศษ";
            dgvList.Columns[3].Name = "ราคา/หน่วย";
            dgvList.Columns[4].Name = "จำนวน";
            dgvList.Columns[5].Name = "ราคารวม";

            ResetForm();
        }

        // เมื่อมีการติ๊กเลือกชนิด/ขนาด/ประเภท
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        // เมื่อเปลี่ยนตัวเลขจำนวน
        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            calculateRowSum();
        }

        // ปุ่ม 'เพิ่มรายการ' ลงตาราง
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 🚨 แก้ไข: ดึงค่าด้วย .Value แทน .Text
            int qty = (int)numQty.Value;

            // ป้องกันการเพิ่มรายการถ้าไม่ได้ระบุจำนวน
            if (qty <= 0)
            {
                MessageBox.Show("กรุณาระบุจำนวนเครื่องดื่มอย่างน้อย 1 แก้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string drinkName = "";
            if (rdbAmericano.Checked) drinkName = "Americano";
            else if (rdbEspresso.Checked) drinkName = "Espresso";
            else if (rdbCappuccino.Checked) drinkName = "Cappuccino";
            else if (rdbLatte.Checked) drinkName = "Latte";
            else if (rdbMocha.Checked) drinkName = "Mocha";

            string type = RdbHot.Checked ? "ร้อน" : rdbIced.Checked ? "เย็น" : "ปั่น";
            string size = rdbSmall.Checked ? "S" : rdbMedium.Checked ? "M" : "L";
            string fullMenuName = $"{drinkName} ({type}) [{size}]";

            string extra = "";
            if (ckbShot.Checked) extra += "เพิ่มช็อต ";
            if (ckbWhip.Checked) extra += "เพิ่มวิปครีม ";
            if (string.IsNullOrEmpty(extra) || extra.Trim() == "") extra = "-";

            // แอดข้อมูล 6 ช่องลงไปใน 6 คอลัมน์ที่สร้างไว้
            dgvList.Rows.Add(itemIndex, fullMenuName, extra, txtPrice.Text, qty.ToString(), txtSum.Text);

            itemIndex++;
            CalculateGrandTotal();
        }

        // ปุ่ม 'ทำรายการใหม่'
        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
            dgvList.Rows.Clear();
            lbTotal.Text = "0.00";
            itemIndex = 1;
        }
    
























private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rdbMedium_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
