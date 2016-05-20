namespace MediIT115
{
    partial class XtraForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.dngaybc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ddsdaduyet = new System.Windows.Forms.DataGridView();
            this.Chon_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TRAKQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SOTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaycd_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYGIO_HEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabn_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMSINH_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mavp_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenvp_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvt_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSCD_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkp_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddsdaduyet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(150, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(413, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khoa/Phòng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 54);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(98, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(629, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "LỊCH THỰC HIỆN XÉT NGHIỆM - CẬN LÂM SÀNG THEO HẸN";
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(581, 66);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 26);
            this.btnFind.TabIndex = 42;
            this.btnFind.Text = "Tìm";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // dngaybc
            // 
            this.dngaybc.CalendarForeColor = System.Drawing.Color.Black;
            this.dngaybc.CustomFormat = "dd/MM/yyyy ";
            this.dngaybc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dngaybc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dngaybc.Location = new System.Drawing.Point(150, 93);
            this.dngaybc.Name = "dngaybc";
            this.dngaybc.Size = new System.Drawing.Size(121, 20);
            this.dngaybc.TabIndex = 43;
            this.dngaybc.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Ngày";
            // 
            // ddsdaduyet
            // 
            this.ddsdaduyet.AllowUserToAddRows = false;
            this.ddsdaduyet.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddsdaduyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ddsdaduyet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddsdaduyet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ddsdaduyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ddsdaduyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon_,
            this.TRAKQ,
            this.SOTT,
            this.ngaycd_,
            this.NGAYGIO_HEN,
            this.mabn_,
            this.HOTEN_,
            this.NAMSINH_,
            this.mavp_,
            this.tenvp_,
            this.dataGridViewTextBoxColumn9,
            this.dvt_,
            this.sl_,
            this.dongia_,
            this.BSCD_,
            this.tenkp_,
            this.id_});
            this.ddsdaduyet.Location = new System.Drawing.Point(12, 131);
            this.ddsdaduyet.Name = "ddsdaduyet";
            this.ddsdaduyet.Size = new System.Drawing.Size(970, 374);
            this.ddsdaduyet.TabIndex = 45;
            // 
            // Chon_
            // 
            this.Chon_.HeaderText = "Chọn";
            this.Chon_.Name = "Chon_";
            this.Chon_.Width = 50;
            // 
            // TRAKQ
            // 
            this.TRAKQ.HeaderText = "Trả KQ";
            this.TRAKQ.Name = "TRAKQ";
            this.TRAKQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TRAKQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TRAKQ.Width = 70;
            // 
            // SOTT
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.SOTT.DefaultCellStyle = dataGridViewCellStyle2;
            this.SOTT.HeaderText = "SOTT";
            this.SOTT.Name = "SOTT";
            this.SOTT.Width = 40;
            // 
            // ngaycd_
            // 
            this.ngaycd_.HeaderText = "NGAY C.ĐỊNH";
            this.ngaycd_.Name = "ngaycd_";
            // 
            // NGAYGIO_HEN
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.NGAYGIO_HEN.DefaultCellStyle = dataGridViewCellStyle3;
            this.NGAYGIO_HEN.HeaderText = "T.GIAN HẸN";
            this.NGAYGIO_HEN.Name = "NGAYGIO_HEN";
            this.NGAYGIO_HEN.Width = 70;
            // 
            // mabn_
            // 
            this.mabn_.HeaderText = "mabn";
            this.mabn_.Name = "mabn_";
            this.mabn_.Width = 50;
            // 
            // HOTEN_
            // 
            this.HOTEN_.HeaderText = "HO VA TEN";
            this.HOTEN_.Name = "HOTEN_";
            // 
            // NAMSINH_
            // 
            this.NAMSINH_.HeaderText = "NAMSINH";
            this.NAMSINH_.Name = "NAMSINH_";
            this.NAMSINH_.Width = 50;
            // 
            // mavp_
            // 
            this.mavp_.HeaderText = "MAVP";
            this.mavp_.Name = "mavp_";
            this.mavp_.Visible = false;
            this.mavp_.Width = 70;
            // 
            // tenvp_
            // 
            this.tenvp_.HeaderText = "TENVP";
            this.tenvp_.Name = "tenvp_";
            this.tenvp_.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "ĐT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 30;
            // 
            // dvt_
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dvt_.DefaultCellStyle = dataGridViewCellStyle4;
            this.dvt_.HeaderText = "DVT";
            this.dvt_.Name = "dvt_";
            this.dvt_.Width = 40;
            // 
            // sl_
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.sl_.DefaultCellStyle = dataGridViewCellStyle5;
            this.sl_.HeaderText = "SL";
            this.sl_.Name = "sl_";
            this.sl_.Width = 50;
            // 
            // dongia_
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.dongia_.DefaultCellStyle = dataGridViewCellStyle6;
            this.dongia_.HeaderText = "DONGIA";
            this.dongia_.Name = "dongia_";
            this.dongia_.Width = 90;
            // 
            // BSCD_
            // 
            this.BSCD_.HeaderText = "Bác sĩ CĐ";
            this.BSCD_.Name = "BSCD_";
            // 
            // tenkp_
            // 
            this.tenkp_.HeaderText = "TENKP";
            this.tenkp_.Name = "tenkp_";
            // 
            // id_
            // 
            this.id_.HeaderText = "ID";
            this.id_.Name = "id_";
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 517);
            this.Controls.Add(this.ddsdaduyet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dngaybc);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "XtraForm2";
            this.Text = "Lich thuc hien CDHA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddsdaduyet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DateTimePicker dngaybc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ddsdaduyet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon_;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TRAKQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaycd_;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYGIO_HEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn mabn_;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN_;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMSINH_;
        private System.Windows.Forms.DataGridViewTextBoxColumn mavp_;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenvp_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvt_;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia_;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSCD_;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkp_;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_;
    }
}