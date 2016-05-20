namespace MediIT115
{
    partial class frmQLKTCAO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLKTCAO));
            this.cbKhoaPhong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dTKTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dview = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btRefesh = new System.Windows.Forms.Button();
            this.txtmaql = new System.Windows.Forms.TextBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtmavaovien = new System.Windows.Forms.TextBox();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtTollStrip = new System.Windows.Forms.ToolStripTextBox();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolNhapKTCAO = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.txtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnttdot = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckttdot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dview)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnttdot.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbKhoaPhong
            // 
            this.cbKhoaPhong.FormattingEnabled = true;
            this.cbKhoaPhong.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.cbKhoaPhong.Location = new System.Drawing.Point(240, 4);
            this.cbKhoaPhong.Name = "cbKhoaPhong";
            this.cbKhoaPhong.Size = new System.Drawing.Size(415, 21);
            this.cbKhoaPhong.TabIndex = 3;
            this.cbKhoaPhong.SelectedIndexChanged += new System.EventHandler(this.cbKhoaPhong_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Kh/Phòng";
            // 
            // dTKTuNgay
            // 
            this.dTKTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dTKTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTKTuNgay.Location = new System.Drawing.Point(54, 4);
            this.dTKTuNgay.Name = "dTKTuNgay";
            this.dTKTuNgay.Size = new System.Drawing.Size(107, 20);
            this.dTKTuNgay.TabIndex = 50;
            // 
            // dview
            // 
            this.dview.AllowUserToAddRows = false;
            this.dview.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dview.Location = new System.Drawing.Point(5, 31);
            this.dview.Name = "dview";
            this.dview.Size = new System.Drawing.Size(983, 566);
            this.dview.TabIndex = 2;
            this.dview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dview_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txttimkiem);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dTKTuNgay);
            this.panel3.Controls.Add(this.btRefesh);
            this.panel3.Controls.Add(this.dview);
            this.panel3.Controls.Add(this.cbKhoaPhong);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(9, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(995, 604);
            this.panel3.TabIndex = 9;
            // 
            // txttimkiem
            // 
            this.txttimkiem.BackColor = System.Drawing.Color.Yellow;
            this.txttimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimkiem.ForeColor = System.Drawing.Color.Red;
            this.txttimkiem.Location = new System.Drawing.Point(698, 3);
            this.txttimkiem.MaxLength = 8;
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(224, 20);
            this.txttimkiem.TabIndex = 6;
            this.txttimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Ngày";
            // 
            // btRefesh
            // 
            this.btRefesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefesh.ForeColor = System.Drawing.Color.Red;
            this.btRefesh.Location = new System.Drawing.Point(661, 3);
            this.btRefesh.Name = "btRefesh";
            this.btRefesh.Size = new System.Drawing.Size(31, 23);
            this.btRefesh.TabIndex = 46;
            this.btRefesh.Text = "...";
            this.btRefesh.UseVisualStyleBackColor = true;
            this.btRefesh.Click += new System.EventHandler(this.btRefesh_Click);
            // 
            // txtmaql
            // 
            this.txtmaql.Location = new System.Drawing.Point(937, 27);
            this.txtmaql.Name = "txtmaql";
            this.txtmaql.Size = new System.Drawing.Size(56, 20);
            this.txtmaql.TabIndex = 61;
            this.txtmaql.Visible = false;
            // 
            // txthoten
            // 
            this.txthoten.Enabled = false;
            this.txthoten.Location = new System.Drawing.Point(561, 4);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(217, 20);
            this.txthoten.TabIndex = 60;
            // 
            // txtmavaovien
            // 
            this.txtmavaovien.Location = new System.Drawing.Point(926, 26);
            this.txtmavaovien.Name = "txtmavaovien";
            this.txtmavaovien.Size = new System.Drawing.Size(46, 20);
            this.txtmavaovien.TabIndex = 59;
            this.txtmavaovien.Visible = false;
            // 
            // txtmabn
            // 
            this.txtmabn.Enabled = false;
            this.txtmabn.Location = new System.Drawing.Point(411, 3);
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(81, 20);
            this.txtmabn.TabIndex = 58;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTollStrip,
            this.toolNew,
            this.toolEdit,
            this.toolSave,
            this.toolStripSeparator,
            this.toolCancel,
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.toolNhapKTCAO,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 10;
            // 
            // txtTollStrip
            // 
            this.txtTollStrip.Name = "txtTollStrip";
            this.txtTollStrip.Size = new System.Drawing.Size(10, 25);
            this.txtTollStrip.Text = "QUẢN LÝ THẺ BHYT";
            this.txtTollStrip.Visible = false;
            // 
            // toolNew
            // 
            this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNew.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(23, 22);
            this.toolNew.Text = "&F3";
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(23, 22);
            this.toolEdit.Text = "&F4";
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Text = "&F5";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCancel
            // 
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(23, 22);
            this.toolCancel.Text = "&ESC";
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 22);
            this.toolDelete.Text = "C&ut";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MediIT115.Properties.Resources.print;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolNhapKTCAO
            // 
            this.toolNhapKTCAO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolNhapKTCAO.Image = ((System.Drawing.Image)(resources.GetObject("toolNhapKTCAO.Image")));
            this.toolNhapKTCAO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNhapKTCAO.Name = "toolNhapKTCAO";
            this.toolNhapKTCAO.Size = new System.Drawing.Size(112, 22);
            this.toolNhapKTCAO.Text = "[F7] Nhập KT cao";
            this.toolNhapKTCAO.Click += new System.EventHandler(this.toolNhapKTCAO_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTuNgay.Location = new System.Drawing.Point(105, 2);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(92, 20);
            this.txtTuNgay.TabIndex = 51;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenNgay.Location = new System.Drawing.Point(260, 3);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(87, 20);
            this.txtDenNgay.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(53, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(202, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Đến ngày";
            // 
            // pnttdot
            // 
            this.pnttdot.Controls.Add(this.label5);
            this.pnttdot.Controls.Add(this.label4);
            this.pnttdot.Controls.Add(this.txtDenNgay);
            this.pnttdot.Controls.Add(this.txthoten);
            this.pnttdot.Controls.Add(this.txtTuNgay);
            this.pnttdot.Controls.Add(this.txtmabn);
            this.pnttdot.Controls.Add(this.label1);
            this.pnttdot.Controls.Add(this.label2);
            this.pnttdot.Location = new System.Drawing.Point(127, 26);
            this.pnttdot.Name = "pnttdot";
            this.pnttdot.Size = new System.Drawing.Size(780, 33);
            this.pnttdot.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(503, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(367, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Mã BN";
            // 
            // ckttdot
            // 
            this.ckttdot.AutoSize = true;
            this.ckttdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckttdot.ForeColor = System.Drawing.Color.Blue;
            this.ckttdot.Location = new System.Drawing.Point(15, 31);
            this.ckttdot.Name = "ckttdot";
            this.ckttdot.Size = new System.Drawing.Size(143, 17);
            this.ckttdot.TabIndex = 63;
            this.ckttdot.Text = "Thanh toán theo đợt";
            this.ckttdot.UseVisualStyleBackColor = true;
            this.ckttdot.CheckedChanged += new System.EventHandler(this.ckttdot_CheckedChanged);
            // 
            // frmQLKTCAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1016, 681);
            this.Controls.Add(this.ckttdot);
            this.Controls.Add(this.pnttdot);
            this.Controls.Add(this.txtmavaovien);
            this.Controls.Add(this.txtmaql);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmQLKTCAO";
            this.Text = "QL KTCAO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQLThietBi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dview)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnttdot.ResumeLayout(false);
            this.pnttdot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbKhoaPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtTollStrip;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btRefesh;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolNhapKTCAO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dTKTuNgay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox txtmabn;
        private System.Windows.Forms.TextBox txtmavaovien;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtmaql;
        private System.Windows.Forms.DateTimePicker txtTuNgay;
        private System.Windows.Forms.DateTimePicker txtDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnttdot;
        private System.Windows.Forms.CheckBox ckttdot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

