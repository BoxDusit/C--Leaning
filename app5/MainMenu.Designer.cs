namespace app5
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.workshopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workshop5 = new System.Windows.Forms.ToolStripMenuItem();
            this.workshop6 = new System.Windows.Forms.ToolStripMenuItem();
            this.workShop7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workshopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // workshopToolStripMenuItem
            // 
            this.workshopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workshop5,
            this.workshop6,
            this.workShop7ToolStripMenuItem});
            this.workshopToolStripMenuItem.Name = "workshopToolStripMenuItem";
            this.workshopToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.workshopToolStripMenuItem.Text = "Workshop";
            // 
            // workshop5
            // 
            this.workshop5.Name = "workshop5";
            this.workshop5.Size = new System.Drawing.Size(224, 26);
            this.workshop5.Text = "Workshop5";
            this.workshop5.Click += new System.EventHandler(this.workshop5_Click);
            // 
            // workshop6
            // 
            this.workshop6.Name = "workshop6";
            this.workshop6.Size = new System.Drawing.Size(224, 26);
            this.workshop6.Text = "Workshop6";
            this.workshop6.Click += new System.EventHandler(this.workshop6_Click);
            // 
            // workShop7ToolStripMenuItem
            // 
            this.workShop7ToolStripMenuItem.Name = "workShop7ToolStripMenuItem";
            this.workShop7ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.workShop7ToolStripMenuItem.Text = "WorkShop7";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem workshopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workshop5;
        private System.Windows.Forms.ToolStripMenuItem workshop6;
        private System.Windows.Forms.ToolStripMenuItem workShop7ToolStripMenuItem;
    }
}