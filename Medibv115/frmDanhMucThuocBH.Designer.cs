namespace MediIT115
{
    partial class frmDanhMucThuocBH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucThuocBH));
            this.panel5 = new System.Windows.Forms.Panel();
            this.dDanhMuc = new System.Windows.Forms.DataGridView();
            this.MaTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLoai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Lọc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bhyt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtToolStrip = new System.Windows.Forms.ToolStripTextBox();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cmbPhong = new System.Windows.Forms.ToolStripComboBox();
            this.tbThuocDY = new System.Windows.Forms.ToolStripButton();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.cbLoaiBN = new System.Windows.Forms.ComboBox();
            this.txtMaVPChoice = new System.Windows.Forms.RichTextBox();
            this.haison1 = new MediIT115.haison();
            this.toolStripButtonFromList = new System.Windows.Forms.ToolStripButton();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dDanhMuc)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dDanhMuc);
            this.panel5.Location = new System.Drawing.Point(6, 99);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(936, 446);
            this.panel5.TabIndex = 11;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // dDanhMuc
            // 
            this.dDanhMuc.AllowUserToAddRows = false;
            this.dDanhMuc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dDanhMuc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTB,
            this.ten,
            this.cbLoai,
            this.Lọc,
            this.bhyt});
            this.dDanhMuc.Location = new System.Drawing.Point(2, 3);
            this.dDanhMuc.Name = "dDanhMuc";
            this.dDanhMuc.Size = new System.Drawing.Size(930, 435);
            this.dDanhMuc.TabIndex = 4;
            this.dDanhMuc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dDanhMuc_CellDoubleClick);
            // 
            // MaTB
            // 
            this.MaTB.HeaderText = "Mã";
            this.MaTB.Name = "MaTB";
            // 
            // ten
            // 
            this.ten.HeaderText = "Tên";
            this.ten.Name = "ten";
            this.ten.Width = 350;
            // 
            // cbLoai
            // 
            this.cbLoai.HeaderText = "Loại YC";
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Width = 250;
            // 
            // Lọc
            // 
            this.Lọc.HeaderText = "Enable";
            this.Lọc.Name = "Lọc";
            this.Lọc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Lọc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bhyt
            // 
            this.bhyt.HeaderText = "TL BHYT";
            this.bhyt.Name = "bhyt";
            this.bhyt.Width = 80;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtToolStrip,
            this.toolNew,
            this.toolEdit,
            this.toolSave,
            this.toolStripSeparator,
            this.toolStripButton2,
            this.toolDelete,
            this.toolCancel,
            this.toolStripSeparator1,
            this.helpToolStripButton,
            this.toolStripButton1,
            this.cmbPhong,
            this.tbThuocDY,
            this.toolStripButtonFromList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(948, 25);
            this.toolStrip1.TabIndex = 12;
            // 
            // txtToolStrip
            // 
            this.txtToolStrip.Name = "txtToolStrip";
            this.txtToolStrip.Size = new System.Drawing.Size(200, 25);
            this.txtToolStrip.Text = "DANH MUC THUOC";
            // 
            // toolNew
            // 
            this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNew.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(23, 22);
            this.toolNew.Text = "&New";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(23, 22);
            this.toolEdit.Text = "&Open";
            this.toolEdit.Click += new System.EventHandler(this.toolEdit_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Text = "&Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MediIT115.Properties.Resources.print;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 22);
            this.toolDelete.Text = "C&ut";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCancel.Enabled = false;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(23, 22);
            this.toolCancel.Text = "&DeleteChoice";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cmbPhong
            // 
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(121, 25);
            // 
            // tbThuocDY
            // 
            this.tbThuocDY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbThuocDY.Image = ((System.Drawing.Image)(resources.GetObject("tbThuocDY.Image")));
            this.tbThuocDY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbThuocDY.Name = "tbThuocDY";
            this.tbThuocDY.Size = new System.Drawing.Size(23, 22);
            this.tbThuocDY.Text = "Thuốc Đông y";
            this.tbThuocDY.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tbThuocDY.Click += new System.EventHandler(this.tbThuocDY_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.Yellow;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.Red;
            this.txtsearch.Location = new System.Drawing.Point(286, 76);
            this.txtsearch.MaxLength = 0;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(245, 20);
            this.txtsearch.TabIndex = 16;
            this.txtsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // cbLoaiBN
            // 
            this.cbLoaiBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBN.FormattingEnabled = true;
            this.cbLoaiBN.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú"});
            this.cbLoaiBN.Location = new System.Drawing.Point(286, 51);
            this.cbLoaiBN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLoaiBN.Name = "cbLoaiBN";
            this.cbLoaiBN.Size = new System.Drawing.Size(155, 21);
            this.cbLoaiBN.TabIndex = 43;
            this.cbLoaiBN.TabStop = false;
            // 
            // txtMaVPChoice
            // 
            this.txtMaVPChoice.Location = new System.Drawing.Point(537, 31);
            this.txtMaVPChoice.Name = "txtMaVPChoice";
            this.txtMaVPChoice.Size = new System.Drawing.Size(403, 64);
            this.txtMaVPChoice.TabIndex = 44;
            this.txtMaVPChoice.Text = "";
            // 
            // haison1
            // 
            this.haison1.Location = new System.Drawing.Point(6, 28);
            this.haison1.Name = "haison1";
            this.haison1.Size = new System.Drawing.Size(279, 68);
            this.haison1.TabIndex = 17;
            // 
            // toolStripButtonFromList
            // 
            this.toolStripButtonFromList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFromList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFromList.Image")));
            this.toolStripButtonFromList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFromList.Name = "toolStripButtonFromList";
            this.toolStripButtonFromList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFromList.Text = "Lấy danh mục từ danh sách";
            this.toolStripButtonFromList.Click += new System.EventHandler(this.toolStripButtonFromList_Click);
            // 
            // frmDanhMucThuocBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(948, 558);
            this.Controls.Add(this.txtMaVPChoice);
            this.Controls.Add(this.cbLoaiBN);
            this.Controls.Add(this.haison1);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel5);
            this.Name = "frmDanhMucThuocBH";
            this.Text = "frmDanhMucThuoc";
            this.Load += new System.EventHandler(this.frmDanhMuc_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dDanhMuc)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dDanhMuc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtToolStrip;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox cmbPhong;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox txtsearch;
        private haison haison1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbLoai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Lọc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bhyt;
        private System.Windows.Forms.ToolStripButton tbThuocDY;
        private System.Windows.Forms.ComboBox cbLoaiBN;
        private System.Windows.Forms.RichTextBox txtMaVPChoice;
        private System.Windows.Forms.ToolStripButton toolStripButtonFromList;
    }
}