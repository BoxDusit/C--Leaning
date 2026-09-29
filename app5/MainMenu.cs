using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app5
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void workshop5_Click(object sender, EventArgs e)
        {
            ProductByCategory frmWorkshop5 = new ProductByCategory();
            frmWorkshop5.Show();
        }

        private void workshop6_Click(object sender, EventArgs e)
        {
            OrdersAndDetail frmWorkshop6 = new OrdersAndDetail();
            frmWorkshop6.Show();
        }

        // เพิ่มการเรียกใช้งาน WorkShop7
        private void workshop7_Click(object sender, EventArgs e)
        {
            WorkShop7 frmWorkshop7 = new WorkShop7();
            frmWorkshop7.Show(); // เปิดแบบซ้อนกันได้หลายหน้าจอ
        }
    }
}
