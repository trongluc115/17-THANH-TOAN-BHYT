namespace MediIT115
{
    partial class frmDanhMucVienPhiBH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucVienPhiBH));
            this.panel5 = new System.Windows.Forms.Panel();
            this.dDanhMuc = new System.Windows.Forms.DataGridView();
            this.MaTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLoai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.filter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ktcgoi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bhyt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_byt = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStripButtonPrintFromList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.cbLoaiBN = new System.Windows.Forms.ComboBox();
            this.haison1 = new MediIT115.haison();
            this.txtMaVPChoice = new System.Windows.Forms.RichTextBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
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
            this.panel5.Size = new System.Drawing.Size(977, 446);
            this.panel5.TabIndex = 11;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // dDanhMuc
            // 
            this.dDanhMuc.AllowUserToAddRows = false;
            this.dDanhMuc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dDanhMuc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTB,
            this.ten,
            this.dongia,
            this.cbLoai,
            this.filter,
            this.ktcgoi,
            this.bhyt,
            this.id_byt});
            this.dDanhMuc.Location = new System.Drawing.Point(2, 1);
            this.dDanhMuc.Name = "dDanhMuc";
            this.dDanhMuc.Size = new System.Drawing.Size(968, 435);
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
            this.ten.Width = 250;
            // 
            // dongia
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dongia.DefaultCellStyle = dataGridViewCellStyle4;
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.Name = "dongia";
            this.dongia.Width = 80;
            // 
            // cbLoai
            // 
            this.cbLoai.HeaderText = "Loại YC";
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Width = 250;
            // 
            // filter
            // 
            this.filter.HeaderText = "Enable";
            this.filter.Name = "filter";
            this.filter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.filter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.filter.Width = 80;
            // 
            // ktcgoi
            // 
            this.ktcgoi.HeaderText = "KTC Gói";
            this.ktcgoi.Name = "ktcgoi";
            this.ktcgoi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ktcgoi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bhyt
            // 
            this.bhyt.HeaderText = "BHYT";
            this.bhyt.Name = "bhyt";
            this.bhyt.Width = 60;
            // 
            // id_byt
            // 
            this.id_byt.HeaderText = "id_byt";
            this.id_byt.Name = "id_byt";
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
            this.toolStripButtonPrintFromList,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(992, 26);
            this.toolStrip1.TabIndex = 12;
            // 
            // txtToolStrip
            // 
            this.txtToolStrip.Name = "txtToolStrip";
            this.txtToolStrip.Size = new System.Drawing.Size(200, 26);
            this.txtToolStrip.Text = "DANH MUC VIEN PHI";
            // 
            // toolNew
            // 
            this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNew.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(23, 23);
            this.toolNew.Text = "&New";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(23, 23);
            this.toolEdit.Text = "&Open";
            this.toolEdit.Click += new System.EventHandler(this.toolEdit_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 23);
            this.toolSave.Text = "&Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MediIT115.Properties.Resources.print;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 23);
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
            this.toolCancel.Size = new System.Drawing.Size(23, 23);
            this.toolCancel.Text = "&Copy";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cmbPhong
            // 
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStripButtonPrintFromList
            // 
            this.toolStripButtonPrintFromList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrintFromList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrintFromList.Image")));
            this.toolStripButtonPrintFromList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrintFromList.Name = "toolStripButtonPrintFromList";
            this.toolStripButtonPrintFromList.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonPrintFromList.Text = "toolStripButton3";
            this.toolStripButtonPrintFromList.Click += new System.EventHandler(this.toolStripButtonPrintFromList_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(86, 23);
            this.toolStripButton3.Text = "Smart Card";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            this.cbLoaiBN.Location = new System.Drawing.Point(286, 48);
            this.cbLoaiBN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLoaiBN.Name = "cbLoaiBN";
            this.cbLoaiBN.Size = new System.Drawing.Size(155, 21);
            this.cbLoaiBN.TabIndex = 42;
            this.cbLoaiBN.TabStop = false;
            // 
            // haison1
            // 
            this.haison1.Location = new System.Drawing.Point(6, 28);
            this.haison1.Name = "haison1";
            this.haison1.Size = new System.Drawing.Size(279, 68);
            this.haison1.TabIndex = 17;
            // 
            // txtMaVPChoice
            // 
            this.txtMaVPChoice.Location = new System.Drawing.Point(537, 32);
            this.txtMaVPChoice.Name = "txtMaVPChoice";
            this.txtMaVPChoice.Size = new System.Drawing.Size(446, 64);
            this.txtMaVPChoice.TabIndex = 45;
            this.txtMaVPChoice.Text = "553,622,565,564,566,567,40039,40058,40059,40060,40057,40219";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(40, 23);
            this.toolStripButton4.Text = "ICU";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // frmDanhMucVienPhiBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(992, 558);
            this.Controls.Add(this.txtMaVPChoice);
            this.Controls.Add(this.cbLoaiBN);
            this.Controls.Add(this.haison1);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel5);
            this.Name = "frmDanhMucVienPhiBH";
            this.Text = "frmDanhMucVienPhi";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbLoai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn filter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ktcgoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bhyt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_byt;
        private System.Windows.Forms.ComboBox cbLoaiBN;
        private System.Windows.Forms.RichTextBox txtMaVPChoice;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrintFromList;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}