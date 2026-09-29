namespace app2
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbMocha = new System.Windows.Forms.RadioButton();
            this.rdbLatte = new System.Windows.Forms.RadioButton();
            this.rdbCappuccino = new System.Windows.Forms.RadioButton();
            this.rdbAmericano = new System.Windows.Forms.RadioButton();
            this.rdbEspresso = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSmoothie = new System.Windows.Forms.RadioButton();
            this.rdbIced = new System.Windows.Forms.RadioButton();
            this.RdbHot = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbWhip = new System.Windows.Forms.CheckBox();
            this.ckbShot = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbLarge = new System.Windows.Forms.RadioButton();
            this.rdbMedium = new System.Windows.Forms.RadioButton();
            this.rdbSmall = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.rdbMocha);
            this.groupBox1.Controls.Add(this.rdbLatte);
            this.groupBox1.Controls.Add(this.rdbCappuccino);
            this.groupBox1.Controls.Add(this.rdbAmericano);
            this.groupBox1.Controls.Add(this.rdbEspresso);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 283);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายการเครื่องดื่ม";
            // 
            // rdbMocha
            // 
            this.rdbMocha.AutoSize = true;
            this.rdbMocha.Location = new System.Drawing.Point(32, 230);
            this.rdbMocha.Name = "rdbMocha";
            this.rdbMocha.Size = new System.Drawing.Size(85, 24);
            this.rdbMocha.TabIndex = 4;
            this.rdbMocha.Text = "Mocha";
            this.rdbMocha.UseVisualStyleBackColor = true;
            // 
            // rdbLatte
            // 
            this.rdbLatte.AutoSize = true;
            this.rdbLatte.Location = new System.Drawing.Point(32, 182);
            this.rdbLatte.Name = "rdbLatte";
            this.rdbLatte.Size = new System.Drawing.Size(73, 24);
            this.rdbLatte.TabIndex = 3;
            this.rdbLatte.Text = "Latte";
            this.rdbLatte.UseVisualStyleBackColor = true;
            // 
            // rdbCappuccino
            // 
            this.rdbCappuccino.AutoSize = true;
            this.rdbCappuccino.Location = new System.Drawing.Point(32, 138);
            this.rdbCappuccino.Name = "rdbCappuccino";
            this.rdbCappuccino.Size = new System.Drawing.Size(128, 24);
            this.rdbCappuccino.TabIndex = 2;
            this.rdbCappuccino.Text = "Cappuccino";
            this.rdbCappuccino.UseVisualStyleBackColor = true;
            // 
            // rdbAmericano
            // 
            this.rdbAmericano.AutoSize = true;
            this.rdbAmericano.Location = new System.Drawing.Point(32, 91);
            this.rdbAmericano.Name = "rdbAmericano";
            this.rdbAmericano.Size = new System.Drawing.Size(119, 24);
            this.rdbAmericano.TabIndex = 1;
            this.rdbAmericano.Text = "Americano";
            this.rdbAmericano.UseVisualStyleBackColor = true;
            // 
            // rdbEspresso
            // 
            this.rdbEspresso.AutoSize = true;
            this.rdbEspresso.Location = new System.Drawing.Point(32, 45);
            this.rdbEspresso.Name = "rdbEspresso";
            this.rdbEspresso.Size = new System.Drawing.Size(109, 24);
            this.rdbEspresso.TabIndex = 0;
            this.rdbEspresso.Text = "Espresso";
            this.rdbEspresso.UseVisualStyleBackColor = true;
            this.rdbEspresso.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox2.Controls.Add(this.rdbSmoothie);
            this.groupBox2.Controls.Add(this.rdbIced);
            this.groupBox2.Controls.Add(this.RdbHot);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(394, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ประเภท";
            // 
            // rdbSmoothie
            // 
            this.rdbSmoothie.AutoSize = true;
            this.rdbSmoothie.Location = new System.Drawing.Point(23, 91);
            this.rdbSmoothie.Name = "rdbSmoothie";
            this.rdbSmoothie.Size = new System.Drawing.Size(52, 24);
            this.rdbSmoothie.TabIndex = 3;
            this.rdbSmoothie.TabStop = true;
            this.rdbSmoothie.Text = "ปั่น";
            this.rdbSmoothie.UseVisualStyleBackColor = true;
            this.rdbSmoothie.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdbIced
            // 
            this.rdbIced.AutoSize = true;
            this.rdbIced.Location = new System.Drawing.Point(23, 58);
            this.rdbIced.Name = "rdbIced";
            this.rdbIced.Size = new System.Drawing.Size(58, 24);
            this.rdbIced.TabIndex = 2;
            this.rdbIced.TabStop = true;
            this.rdbIced.Text = "เย็น";
            this.rdbIced.UseVisualStyleBackColor = true;
            // 
            // RdbHot
            // 
            this.RdbHot.AutoSize = true;
            this.RdbHot.Location = new System.Drawing.Point(23, 21);
            this.RdbHot.Name = "RdbHot";
            this.RdbHot.Size = new System.Drawing.Size(60, 24);
            this.RdbHot.TabIndex = 1;
            this.RdbHot.TabStop = true;
            this.RdbHot.Text = "ร้อน";
            this.RdbHot.UseVisualStyleBackColor = true;
            this.RdbHot.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox3.Controls.Add(this.ckbWhip);
            this.groupBox3.Controls.Add(this.ckbShot);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(394, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 129);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "เพิ่มพิเศษ";
            // 
            // ckbWhip
            // 
            this.ckbWhip.AutoSize = true;
            this.ckbWhip.Location = new System.Drawing.Point(23, 87);
            this.ckbWhip.Name = "ckbWhip";
            this.ckbWhip.Size = new System.Drawing.Size(188, 24);
            this.ckbWhip.TabIndex = 1;
            this.ckbWhip.Text = "เพิ่มวิปครีม +10 บาท";
            this.ckbWhip.UseVisualStyleBackColor = true;
            this.ckbWhip.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ckbShot
            // 
            this.ckbShot.AutoSize = true;
            this.ckbShot.Location = new System.Drawing.Point(23, 39);
            this.ckbShot.Name = "ckbShot";
            this.ckbShot.Size = new System.Drawing.Size(168, 24);
            this.ckbShot.TabIndex = 0;
            this.ckbShot.Text = "เพิ่มช็อต +15 บาท";
            this.ckbShot.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.MediumPurple;
            this.groupBox4.Controls.Add(this.rdbLarge);
            this.groupBox4.Controls.Add(this.rdbMedium);
            this.groupBox4.Controls.Add(this.rdbSmall);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(743, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 94);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ขนาด";
            // 
            // rdbLarge
            // 
            this.rdbLarge.AutoSize = true;
            this.rdbLarge.Location = new System.Drawing.Point(201, 21);
            this.rdbLarge.Name = "rdbLarge";
            this.rdbLarge.Size = new System.Drawing.Size(41, 24);
            this.rdbLarge.TabIndex = 4;
            this.rdbLarge.TabStop = true;
            this.rdbLarge.Text = "L";
            this.rdbLarge.UseVisualStyleBackColor = true;
            // 
            // rdbMedium
            // 
            this.rdbMedium.AutoSize = true;
            this.rdbMedium.Location = new System.Drawing.Point(109, 21);
            this.rdbMedium.Name = "rdbMedium";
            this.rdbMedium.Size = new System.Drawing.Size(45, 24);
            this.rdbMedium.TabIndex = 3;
            this.rdbMedium.TabStop = true;
            this.rdbMedium.Text = "M";
            this.rdbMedium.UseVisualStyleBackColor = true;
            this.rdbMedium.CheckedChanged += new System.EventHandler(this.rdbMedium_CheckedChanged);
            // 
            // rdbSmall
            // 
            this.rdbSmall.AutoSize = true;
            this.rdbSmall.Location = new System.Drawing.Point(17, 21);
            this.rdbSmall.Name = "rdbSmall";
            this.rdbSmall.Size = new System.Drawing.Size(42, 24);
            this.rdbSmall.TabIndex = 2;
            this.rdbSmall.TabStop = true;
            this.rdbSmall.Text = "S";
            this.rdbSmall.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Pink;
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.numQty);
            this.groupBox5.Controls.Add(this.txtSum);
            this.groupBox5.Controls.Add(this.txtPrice);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(743, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(319, 172);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายการสินค้า";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ราคารวม";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "จำนวน";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ราคาต่อหน่วย";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(153, 82);
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(148, 27);
            this.numQty.TabIndex = 2;
            this.numQty.ValueChanged += new System.EventHandler(this.numQty_ValueChanged);
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(153, 128);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(148, 27);
            this.txtSum.TabIndex = 1;
            this.txtSum.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(153, 43);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(148, 27);
            this.txtPrice.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(743, 336);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(319, 45);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "เพิ่มรายการ";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(42, 388);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.Size = new System.Drawing.Size(1020, 150);
            this.dgvList.TabIndex = 6;
            // 
            // lbTotal
            // 
            this.lbTotal.BackColor = System.Drawing.SystemColors.Info;
            this.lbTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbTotal.Location = new System.Drawing.Point(698, 549);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(364, 58);
            this.lbTotal.TabIndex = 7;
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(42, 560);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(214, 44);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "ทำารายการใหม่";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(530, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "ราคารวม(บาท)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 616);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "โปรเเกรมคำนวนขายเครื่องดื่ม";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbMocha;
        private System.Windows.Forms.RadioButton rdbLatte;
        private System.Windows.Forms.RadioButton rdbCappuccino;
        private System.Windows.Forms.RadioButton rdbAmericano;
        private System.Windows.Forms.RadioButton rdbEspresso;
        private System.Windows.Forms.RadioButton rdbSmoothie;
        private System.Windows.Forms.RadioButton rdbIced;
        private System.Windows.Forms.RadioButton RdbHot;
        private System.Windows.Forms.CheckBox ckbWhip;
        private System.Windows.Forms.CheckBox ckbShot;
        private System.Windows.Forms.RadioButton rdbLarge;
        private System.Windows.Forms.RadioButton rdbMedium;
        private System.Windows.Forms.RadioButton rdbSmall;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

