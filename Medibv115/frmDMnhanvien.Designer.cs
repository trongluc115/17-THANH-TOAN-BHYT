namespace MediIT115
{
    partial class frmDMnhanvien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMnhanvien));
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgridChiTiet = new System.Windows.Forms.DataGridView();
            this.btLuu = new System.Windows.Forms.Button();
            this.dngaysinh = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbchuyenkhoa = new System.Windows.Forms.ComboBox();
            this.cbtrinhdo = new System.Windows.Forms.ComboBox();
            this.cbDanhMucKP = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtkinhnghiem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtdtnuocngoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbangcap = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNgoaiNgu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNhom = new System.Windows.Forms.ComboBox();
            this.lbkp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.cbPhai = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridChiTiet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.Yellow;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Red;
            this.txtTimKiem.Location = new System.Drawing.Point(1, 0);
            this.txtTimKiem.MaxLength = 0;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(992, 20);
            this.txtTimKiem.TabIndex = 61;
            this.txtTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgridChiTiet
            // 
            this.dgridChiTiet.AllowUserToAddRows = false;
            this.dgridChiTiet.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgridChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgridChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridChiTiet.Location = new System.Drawing.Point(1, 23);
            this.dgridChiTiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgridChiTiet.Name = "dgridChiTiet";
            this.dgridChiTiet.RowHeadersWidth = 60;
            this.dgridChiTiet.RowTemplate.Height = 20;
            this.dgridChiTiet.Size = new System.Drawing.Size(992, 533);
            this.dgridChiTiet.TabIndex = 66;
            this.dgridChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridChiTiet_CellClick);
            this.dgridChiTiet.Click += new System.EventHandler(this.dgridChiTiet_Click);
            // 
            // btLuu
            // 
            this.btLuu.Image = ((System.Drawing.Image)(resources.GetObject("btLuu.Image")));
            this.btLuu.Location = new System.Drawing.Point(799, 97);
            this.btLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(59, 24);
            this.btLuu.TabIndex = 23;
            this.btLuu.Text = "Lưu";
            this.btLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click_1);
            // 
            // dngaysinh
            // 
            this.dngaysinh.CalendarForeColor = System.Drawing.Color.Black;
            this.dngaysinh.CustomFormat = "dd/MM/yyyy ";
            this.dngaysinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dngaysinh.Location = new System.Drawing.Point(346, 4);
            this.dngaysinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dngaysinh.Name = "dngaysinh";
            this.dngaysinh.Size = new System.Drawing.Size(98, 21);
            this.dngaysinh.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbchuyenkhoa);
            this.panel1.Controls.Add(this.cbtrinhdo);
            this.panel1.Controls.Add(this.cbDanhMucKP);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtkinhnghiem);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtdtnuocngoai);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtbangcap);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNgoaiNgu);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbNhom);
            this.panel1.Controls.Add(this.lbkp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDienThoai);
            this.panel1.Controls.Add(this.cbPhai);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.dngaysinh);
            this.panel1.Location = new System.Drawing.Point(1, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 124);
            this.panel1.TabIndex = 79;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(927, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 24);
            this.button2.TabIndex = 105;
            this.button2.TabStop = false;
            this.button2.Text = "Thoát";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(863, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 24);
            this.button1.TabIndex = 80;
            this.button1.Text = "Mới";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbchuyenkhoa
            // 
            this.cbchuyenkhoa.FormattingEnabled = true;
            this.cbchuyenkhoa.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbchuyenkhoa.Location = new System.Drawing.Point(334, 91);
            this.cbchuyenkhoa.Name = "cbchuyenkhoa";
            this.cbchuyenkhoa.Size = new System.Drawing.Size(193, 21);
            this.cbchuyenkhoa.TabIndex = 19;
            // 
            // cbtrinhdo
            // 
            this.cbtrinhdo.FormattingEnabled = true;
            this.cbtrinhdo.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbtrinhdo.Location = new System.Drawing.Point(334, 69);
            this.cbtrinhdo.Name = "cbtrinhdo";
            this.cbtrinhdo.Size = new System.Drawing.Size(193, 21);
            this.cbtrinhdo.TabIndex = 17;
            // 
            // cbDanhMucKP
            // 
            this.cbDanhMucKP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDanhMucKP.FormattingEnabled = true;
            this.cbDanhMucKP.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.cbDanhMucKP.Location = new System.Drawing.Point(276, 47);
            this.cbDanhMucKP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDanhMucKP.Name = "cbDanhMucKP";
            this.cbDanhMucKP.Size = new System.Drawing.Size(252, 22);
            this.cbDanhMucKP.TabIndex = 15;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(539, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(59, 20);
            this.txtID.TabIndex = 104;
            this.txtID.TabStop = false;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(536, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "K.nghiệm:";
            // 
            // txtkinhnghiem
            // 
            this.txtkinhnghiem.Location = new System.Drawing.Point(612, 72);
            this.txtkinhnghiem.Name = "txtkinhnghiem";
            this.txtkinhnghiem.Size = new System.Drawing.Size(377, 20);
            this.txtkinhnghiem.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(536, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "ĐTN.Ngoài:";
            // 
            // txtdtnuocngoai
            // 
            this.txtdtnuocngoai.Location = new System.Drawing.Point(612, 49);
            this.txtdtnuocngoai.Name = "txtdtnuocngoai";
            this.txtdtnuocngoai.Size = new System.Drawing.Size(375, 20);
            this.txtdtnuocngoai.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Bằng cấp";
            // 
            // txtbangcap
            // 
            this.txtbangcap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbangcap.Location = new System.Drawing.Point(612, 3);
            this.txtbangcap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbangcap.Name = "txtbangcap";
            this.txtbangcap.Size = new System.Drawing.Size(375, 44);
            this.txtbangcap.TabIndex = 20;
            this.txtbangcap.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Chuyên khoa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Ng.Ngữ:";
            // 
            // txtNgoaiNgu
            // 
            this.txtNgoaiNgu.Location = new System.Drawing.Point(76, 91);
            this.txtNgoaiNgu.Name = "txtNgoaiNgu";
            this.txtNgoaiNgu.Size = new System.Drawing.Size(181, 20);
            this.txtNgoaiNgu.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Trình độ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Nhóm";
            // 
            // cbNhom
            // 
            this.cbNhom.FormattingEnabled = true;
            this.cbNhom.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbNhom.Location = new System.Drawing.Point(76, 69);
            this.cbNhom.Name = "cbNhom";
            this.cbNhom.Size = new System.Drawing.Size(193, 21);
            this.cbNhom.TabIndex = 16;
            // 
            // lbkp
            // 
            this.lbkp.AutoSize = true;
            this.lbkp.Location = new System.Drawing.Point(206, 52);
            this.lbkp.Name = "lbkp";
            this.lbkp.Size = new System.Drawing.Size(71, 13);
            this.lbkp.TabIndex = 89;
            this.lbkp.Text = "Khoa, phòng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(76, 49);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(124, 20);
            this.txtDienThoai.TabIndex = 14;
            // 
            // cbPhai
            // 
            this.cbPhai.FormattingEnabled = true;
            this.cbPhai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbPhai.Location = new System.Drawing.Point(446, 4);
            this.cbPhai.Name = "cbPhai";
            this.cbPhai.Size = new System.Drawing.Size(82, 21);
            this.cbPhai.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(76, 27);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(452, 20);
            this.txtDiaChi.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Địa chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(76, 5);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(207, 20);
            this.txtHoTen.TabIndex = 10;
            // 
            // frmDMnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1016, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgridChiTiet);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "frmDMnhanvien";
            this.Text = "frmQLDAOTAO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMnhanvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridChiTiet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgridChiTiet;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.DateTimePicker dngaysinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPhai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNgoaiNgu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNhom;
        private System.Windows.Forms.Label lbkp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtkinhnghiem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtdtnuocngoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtbangcap;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDanhMucKP;
        private System.Windows.Forms.ComboBox cbchuyenkhoa;
        private System.Windows.Forms.ComboBox cbtrinhdo;
        private System.Windows.Forms.Button button2;
    }
}