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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void workshop7ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WorkShop7 frmWorkshop7 = new WorkShop7();
            this.IsMdiContainer = true;
            frmWorkshop7.MdiParent = this;
            frmWorkshop7.Show();
        }

        private void workshop8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workshop8 frmWorkshop8 = new Workshop8();
            this.IsMdiContainer = true;
            frmWorkshop8.MdiParent = this;
            frmWorkshop8.Show();
        }

        private void workshop9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddUser frmAddUser = new FrmAddUser();
            
            this.IsMdiContainer = true;
            frmAddUser.Show();
            frmAddUser.MdiParent = this;
        }

        private void workshop10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workshop10 frmWorkshop10 = new Workshop10();
            this.IsMdiContainer = true;
            frmWorkshop10.MdiParent = this;
            frmWorkshop10.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void workshopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
