namespace MediIT115
{
    partial class frmBCDuocMau20
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCDuocMau20));
            this.btInBaoCao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this.txtGiamDoc = new System.Windows.Forms.TextBox();
            this.btXuatExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckGoiKTC = new System.Windows.Forms.CheckBox();
            this.btXuatExcel20 = new System.Windows.Forms.Button();
            this.cbLoaiBC = new System.Windows.Forms.ComboBox();
            this.treeView_HAISON1 = new Report2009.TreeView_HAISON();
            this.lbloai = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.haison1 = new MediIT115.haison();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInBaoCao
            // 
            this.btInBaoCao.Image = global::MediIT115.PrintRibbonControllerResources.RibbonPrintPreview_PrintDirectLarge;
            this.btInBaoCao.Location = new System.Drawing.Point(288, 52);
            this.btInBaoCao.Name = "btInBaoCao";
            this.btInBaoCao.Size = new System.Drawing.Size(52, 44);
            this.btInBaoCao.TabIndex = 6;
            this.btInBaoCao.UseVisualStyleBackColor = true;
            this.btInBaoCao.Click += new System.EventHandler(this.btInBaoCao_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtGiamDoc);
            this.panel1.Controls.Add(this.btXuatExcel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbLoai);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Location = new System.Drawing.Point(-2, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 196);
            this.panel1.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(417, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton1.Text = "Thông tin kèm theo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 28);
            this.button2.TabIndex = 50;
            this.button2.Text = "Xuất Excel M20";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtGiamDoc
            // 
            this.txtGiamDoc.Location = new System.Drawing.Point(100, 62);
            this.txtGiamDoc.Name = "txtGiamDoc";
            this.txtGiamDoc.Size = new System.Drawing.Size(219, 20);
            this.txtGiamDoc.TabIndex = 14;
            // 
            // btXuatExcel
            // 
            this.btXuatExcel.Location = new System.Drawing.Point(325, 100);
            this.btXuatExcel.Name = "btXuatExcel";
            this.btXuatExcel.Size = new System.Drawing.Size(82, 28);
            this.btXuatExcel.TabIndex = 49;
            this.btXuatExcel.Text = "Xuất Excel";
            this.btXuatExcel.UseVisualStyleBackColor = true;
            this.btXuatExcel.Visible = false;
            this.btXuatExcel.Click += new System.EventHandler(this.btXuatExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Giám đốc";
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú"});
            this.cbLoai.Location = new System.Drawing.Point(100, 88);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(131, 21);
            this.cbLoai.TabIndex = 43;
            this.cbLoai.TabStop = false;
            this.cbLoai.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 48;
            this.button1.Text = "Thuốc TL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Người lập";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(100, 38);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(219, 20);
            this.txtHoTen.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ckGoiKTC);
            this.panel2.Controls.Add(this.btXuatExcel20);
            this.panel2.Controls.Add(this.cbLoaiBC);
            this.panel2.Controls.Add(this.treeView_HAISON1);
            this.panel2.Controls.Add(this.lbloai);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.haison1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btInBaoCao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 365);
            this.panel2.TabIndex = 9;
            // 
            // ckGoiKTC
            // 
            this.ckGoiKTC.AutoSize = true;
            this.ckGoiKTC.Location = new System.Drawing.Point(349, 29);
            this.ckGoiKTC.Name = "ckGoiKTC";
            this.ckGoiKTC.Size = new System.Drawing.Size(59, 17);
            this.ckGoiKTC.TabIndex = 52;
            this.ckGoiKTC.Text = "Gói VT";
            this.ckGoiKTC.UseVisualStyleBackColor = true;
            // 
            // btXuatExcel20
            // 
            this.btXuatExcel20.Image = global::MediIT115.PrintRibbonControllerResources.RibbonPrintPreview_ExportXlsLarge;
            this.btXuatExcel20.Location = new System.Drawing.Point(346, 52);
            this.btXuatExcel20.Name = "btXuatExcel20";
            this.btXuatExcel20.Size = new System.Drawing.Size(52, 44);
            this.btXuatExcel20.TabIndex = 51;
            this.btXuatExcel20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btXuatExcel20.UseVisualStyleBackColor = true;
            this.btXuatExcel20.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbLoaiBC
            // 
            this.cbLoaiBC.FormattingEnabled = true;
            this.cbLoaiBC.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbLoaiBC.Location = new System.Drawing.Point(58, 29);
            this.cbLoaiBC.Name = "cbLoaiBC";
            this.cbLoaiBC.Size = new System.Drawing.Size(219, 21);
            this.cbLoaiBC.TabIndex = 44;
            this.cbLoaiBC.TabStop = false;
            this.cbLoaiBC.SelectedIndexChanged += new System.EventHandler(this.cbLoaiBC_SelectedIndexChanged_1);
            // 
            // treeView_HAISON1
            // 
            this.treeView_HAISON1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.treeView_HAISON1.BackColor = System.Drawing.Color.Transparent;
            this.treeView_HAISON1.Location = new System.Drawing.Point(425, 28);
            this.treeView_HAISON1.Name = "treeView_HAISON1";
            this.treeView_HAISON1.Size = new System.Drawing.Size(396, 335);
            this.treeView_HAISON1.TabIndex = 47;
            // 
            // lbloai
            // 
            this.lbloai.AutoSize = true;
            this.lbloai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbloai.Location = new System.Drawing.Point(7, 32);
            this.lbloai.Name = "lbloai";
            this.lbloai.Size = new System.Drawing.Size(45, 13);
            this.lbloai.TabIndex = 44;
            this.lbloai.Text = "Loại BN";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(826, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(399, 22);
            this.toolStripButton2.Text = "Thống kê tổng hợp thuốc sử dụng (mẫu 20/BHYT) - Đơn thuốc ngoại trú theo kho";
            // 
            // haison1
            // 
            this.haison1.Location = new System.Drawing.Point(8, 51);
            this.haison1.Name = "haison1";
            this.haison1.Size = new System.Drawing.Size(274, 68);
            this.haison1.TabIndex = 7;
            // 
            // frmBCDuocMau20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(830, 365);
            this.Controls.Add(this.panel2);
            this.Name = "frmBCDuocMau20";
            this.Text = "frmBCDuocMau20";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBCDuocMau20_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private haison haison1;
        private System.Windows.Forms.Button btInBaoCao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtGiamDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label lbloai;
        private System.Windows.Forms.ComboBox cbLoai;
        private Report2009.TreeView_HAISON treeView_HAISON1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbLoaiBC;
        private System.Windows.Forms.Button btXuatExcel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btXuatExcel20;
        private System.Windows.Forms.CheckBox ckGoiKTC;
    }
}