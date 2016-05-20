namespace MediIT115
{
    partial class frmQLDAOTAO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLDAOTAO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIDVP = new System.Windows.Forms.TextBox();
            this.listicd10 = new LibList.List();
            this.txtNameVP = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.dgridChiTiet = new System.Windows.Forms.DataGridView();
            this.txtNoiDung = new System.Windows.Forms.RichTextBox();
            this.dtungay = new System.Windows.Forms.DateTimePicker();
            this.ddenngay = new System.Windows.Forms.DateTimePicker();
            this.dNgayLamViec = new System.Windows.Forms.DateTimePicker();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btprint = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbkinhnghiem = new System.Windows.Forms.Label();
            this.lbnhom = new System.Windows.Forms.Label();
            this.lbtrinhdo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbngoaingu = new System.Windows.Forms.Label();
            this.lbkhoaphong = new System.Windows.Forms.Label();
            this.lbdtnn = new System.Windows.Forms.Label();
            this.lbbangcap = new System.Windows.Forms.Label();
            this.lbchuyenmon = new System.Windows.Forms.Label();
            this.lbdienthoai = new System.Windows.Forms.Label();
            this.lbdiachi = new System.Windows.Forms.Label();
            this.lbngaysinh = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOIDUNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TUNGAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DENNGAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sogio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGÀY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgridChiTiet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDVP
            // 
            this.txtIDVP.BackColor = System.Drawing.Color.Yellow;
            this.txtIDVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDVP.ForeColor = System.Drawing.Color.Red;
            this.txtIDVP.Location = new System.Drawing.Point(12, 59);
            this.txtIDVP.MaxLength = 0;
            this.txtIDVP.Name = "txtIDVP";
            this.txtIDVP.Size = new System.Drawing.Size(70, 20);
            this.txtIDVP.TabIndex = 62;
            this.txtIDVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIDVP.TextChanged += new System.EventHandler(this.txtIDVP_TextChanged);
            this.txtIDVP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDVP_KeyDown);
            // 
            // listicd10
            // 
            this.listicd10.ColumnCount = 0;
            this.listicd10.FormattingEnabled = true;
            this.listicd10.Location = new System.Drawing.Point(12, 80);
            this.listicd10.MatchBufferTimeOut = 1000D;
            this.listicd10.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listicd10.Name = "listicd10";
            this.listicd10.Size = new System.Drawing.Size(840, 4);
            this.listicd10.TabIndex = 60;
            this.listicd10.TextIndex = -1;
            this.listicd10.TextMember = null;
            this.listicd10.ValueIndex = -1;
            this.listicd10.Visible = false;
            // 
            // txtNameVP
            // 
            this.txtNameVP.BackColor = System.Drawing.Color.Yellow;
            this.txtNameVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameVP.ForeColor = System.Drawing.Color.Red;
            this.txtNameVP.Location = new System.Drawing.Point(83, 59);
            this.txtNameVP.MaxLength = 0;
            this.txtNameVP.Name = "txtNameVP";
            this.txtNameVP.Size = new System.Drawing.Size(769, 20);
            this.txtNameVP.TabIndex = 61;
            this.txtNameVP.TextChanged += new System.EventHandler(this.txtNameVP_TextChanged);
            this.txtNameVP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameVP_KeyDown);
            // 
            // btThem
            // 
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.Location = new System.Drawing.Point(858, 56);
            this.btThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 28);
            this.btThem.TabIndex = 59;
            this.btThem.TabStop = false;
            this.btThem.Text = "Thêm";
            this.btThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Visible = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(868, 56);
            this.btLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(59, 25);
            this.btLuu.TabIndex = 15;
            this.btLuu.Text = "F4-Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
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
            this.dgridChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LOAI,
            this.NOIDUNG,
            this.TUNGAY,
            this.DENNGAY,
            this.sogio,
            this.NGÀY});
            this.dgridChiTiet.Location = new System.Drawing.Point(12, 315);
            this.dgridChiTiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgridChiTiet.Name = "dgridChiTiet";
            this.dgridChiTiet.RowHeadersWidth = 60;
            this.dgridChiTiet.RowTemplate.Height = 30;
            this.dgridChiTiet.Size = new System.Drawing.Size(992, 413);
            this.dgridChiTiet.TabIndex = 66;
            this.dgridChiTiet.DoubleClick += new System.EventHandler(this.dgridChiTiet_DoubleClick);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(59, 28);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(633, 53);
            this.txtNoiDung.TabIndex = 11;
            this.txtNoiDung.Text = "";
            // 
            // dtungay
            // 
            this.dtungay.CalendarForeColor = System.Drawing.Color.Black;
            this.dtungay.CustomFormat = "dd/MM/yyyy ";
            this.dtungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtungay.Location = new System.Drawing.Point(757, 34);
            this.dtungay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtungay.Name = "dtungay";
            this.dtungay.Size = new System.Drawing.Size(98, 21);
            this.dtungay.TabIndex = 13;
            // 
            // ddenngay
            // 
            this.ddenngay.CalendarForeColor = System.Drawing.Color.Black;
            this.ddenngay.CustomFormat = "dd/MM/yyyy ";
            this.ddenngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ddenngay.Location = new System.Drawing.Point(757, 61);
            this.ddenngay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddenngay.Name = "ddenngay";
            this.ddenngay.Size = new System.Drawing.Size(98, 21);
            this.ddenngay.TabIndex = 14;
            // 
            // dNgayLamViec
            // 
            this.dNgayLamViec.CalendarForeColor = System.Drawing.Color.Black;
            this.dNgayLamViec.CustomFormat = "dd/MM/yyyy ";
            this.dNgayLamViec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dNgayLamViec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dNgayLamViec.Location = new System.Drawing.Point(594, 6);
            this.dNgayLamViec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dNgayLamViec.Name = "dNgayLamViec";
            this.dNgayLamViec.Size = new System.Drawing.Size(98, 21);
            this.dNgayLamViec.TabIndex = 72;
            this.dNgayLamViec.TabStop = false;
            // 
            // cbLoai
            // 
            this.cbLoai.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.cbLoai.Location = new System.Drawing.Point(60, 4);
            this.cbLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(475, 22);
            this.cbLoai.TabIndex = 10;
            this.cbLoai.Enter += new System.EventHandler(this.cbLoai_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Nội dung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(704, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(704, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Đến ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btprint);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ddenngay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNoiDung);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtungay);
            this.panel1.Controls.Add(this.cbLoai);
            this.panel1.Controls.Add(this.dNgayLamViec);
            this.panel1.Location = new System.Drawing.Point(12, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 86);
            this.panel1.TabIndex = 78;
            // 
            // btprint
            // 
            this.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btprint.Image = ((System.Drawing.Image)(resources.GetObject("btprint.Image")));
            this.btprint.Location = new System.Drawing.Point(933, 56);
            this.btprint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btprint.Name = "btprint";
            this.btprint.Size = new System.Drawing.Size(59, 25);
            this.btprint.TabIndex = 98;
            this.btprint.TabStop = false;
            this.btprint.UseVisualStyleBackColor = true;
            this.btprint.Click += new System.EventHandler(this.btprint_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(705, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 97;
            this.label18.Text = "Giờ thực học:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(757, 7);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(98, 20);
            this.txtValue.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(541, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 78;
            this.label14.Text = "Ngày LV:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbkinhnghiem);
            this.panel2.Controls.Add(this.lbnhom);
            this.panel2.Controls.Add(this.lbtrinhdo);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.lbngoaingu);
            this.panel2.Controls.Add(this.lbkhoaphong);
            this.panel2.Controls.Add(this.lbdtnn);
            this.panel2.Controls.Add(this.lbbangcap);
            this.panel2.Controls.Add(this.lbchuyenmon);
            this.panel2.Controls.Add(this.lbdienthoai);
            this.panel2.Controls.Add(this.lbdiachi);
            this.panel2.Controls.Add(this.lbngaysinh);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 90);
            this.panel2.TabIndex = 79;
            // 
            // lbkinhnghiem
            // 
            this.lbkinhnghiem.AutoSize = true;
            this.lbkinhnghiem.ForeColor = System.Drawing.Color.Navy;
            this.lbkinhnghiem.Location = new System.Drawing.Point(807, 73);
            this.lbkinhnghiem.Name = "lbkinhnghiem";
            this.lbkinhnghiem.Size = new System.Drawing.Size(33, 13);
            this.lbkinhnghiem.TabIndex = 99;
            this.lbkinhnghiem.Text = "value";
            // 
            // lbnhom
            // 
            this.lbnhom.AutoSize = true;
            this.lbnhom.ForeColor = System.Drawing.Color.Navy;
            this.lbnhom.Location = new System.Drawing.Point(119, 73);
            this.lbnhom.Name = "lbnhom";
            this.lbnhom.Size = new System.Drawing.Size(33, 13);
            this.lbnhom.TabIndex = 98;
            this.lbnhom.Text = "value";
            // 
            // lbtrinhdo
            // 
            this.lbtrinhdo.AutoSize = true;
            this.lbtrinhdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtrinhdo.ForeColor = System.Drawing.Color.Navy;
            this.lbtrinhdo.Location = new System.Drawing.Point(552, 2);
            this.lbtrinhdo.Name = "lbtrinhdo";
            this.lbtrinhdo.Size = new System.Drawing.Size(36, 15);
            this.lbtrinhdo.TabIndex = 97;
            this.lbtrinhdo.Text = "value";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Navy;
            this.label23.Location = new System.Drawing.Point(693, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 15);
            this.label23.TabIndex = 96;
            this.label23.Text = "Kinh nghiệm:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Navy;
            this.label24.Location = new System.Drawing.Point(9, 72);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 15);
            this.label24.TabIndex = 95;
            this.label24.Text = "Chức danh:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Navy;
            this.label25.Location = new System.Drawing.Point(443, 2);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 15);
            this.label25.TabIndex = 94;
            this.label25.Text = "Trinh độ:";
            // 
            // lbngoaingu
            // 
            this.lbngoaingu.AutoSize = true;
            this.lbngoaingu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngoaingu.ForeColor = System.Drawing.Color.Navy;
            this.lbngoaingu.Location = new System.Drawing.Point(552, 70);
            this.lbngoaingu.Name = "lbngoaingu";
            this.lbngoaingu.Size = new System.Drawing.Size(36, 15);
            this.lbngoaingu.TabIndex = 92;
            this.lbngoaingu.Text = "value";
            // 
            // lbkhoaphong
            // 
            this.lbkhoaphong.AutoSize = true;
            this.lbkhoaphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbkhoaphong.ForeColor = System.Drawing.Color.Navy;
            this.lbkhoaphong.Location = new System.Drawing.Point(119, 56);
            this.lbkhoaphong.Name = "lbkhoaphong";
            this.lbkhoaphong.Size = new System.Drawing.Size(36, 15);
            this.lbkhoaphong.TabIndex = 91;
            this.lbkhoaphong.Text = "value";
            // 
            // lbdtnn
            // 
            this.lbdtnn.AutoSize = true;
            this.lbdtnn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdtnn.ForeColor = System.Drawing.Color.Navy;
            this.lbdtnn.Location = new System.Drawing.Point(552, 53);
            this.lbdtnn.Name = "lbdtnn";
            this.lbdtnn.Size = new System.Drawing.Size(36, 15);
            this.lbdtnn.TabIndex = 90;
            this.lbdtnn.Text = "value";
            // 
            // lbbangcap
            // 
            this.lbbangcap.AutoSize = true;
            this.lbbangcap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbangcap.ForeColor = System.Drawing.Color.Navy;
            this.lbbangcap.Location = new System.Drawing.Point(552, 19);
            this.lbbangcap.Name = "lbbangcap";
            this.lbbangcap.Size = new System.Drawing.Size(36, 15);
            this.lbbangcap.TabIndex = 89;
            this.lbbangcap.Text = "value";
            // 
            // lbchuyenmon
            // 
            this.lbchuyenmon.AutoSize = true;
            this.lbchuyenmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbchuyenmon.ForeColor = System.Drawing.Color.Navy;
            this.lbchuyenmon.Location = new System.Drawing.Point(552, 36);
            this.lbchuyenmon.Name = "lbchuyenmon";
            this.lbchuyenmon.Size = new System.Drawing.Size(36, 15);
            this.lbchuyenmon.TabIndex = 88;
            this.lbchuyenmon.Text = "value";
            // 
            // lbdienthoai
            // 
            this.lbdienthoai.AutoSize = true;
            this.lbdienthoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdienthoai.ForeColor = System.Drawing.Color.Navy;
            this.lbdienthoai.Location = new System.Drawing.Point(119, 38);
            this.lbdienthoai.Name = "lbdienthoai";
            this.lbdienthoai.Size = new System.Drawing.Size(36, 15);
            this.lbdienthoai.TabIndex = 87;
            this.lbdienthoai.Text = "value";
            // 
            // lbdiachi
            // 
            this.lbdiachi.AutoSize = true;
            this.lbdiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdiachi.ForeColor = System.Drawing.Color.Navy;
            this.lbdiachi.Location = new System.Drawing.Point(119, 20);
            this.lbdiachi.Name = "lbdiachi";
            this.lbdiachi.Size = new System.Drawing.Size(36, 15);
            this.lbdiachi.TabIndex = 86;
            this.lbdiachi.Text = "value";
            // 
            // lbngaysinh
            // 
            this.lbngaysinh.AutoSize = true;
            this.lbngaysinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngaysinh.ForeColor = System.Drawing.Color.Navy;
            this.lbngaysinh.Location = new System.Drawing.Point(119, 2);
            this.lbngaysinh.Name = "lbngaysinh";
            this.lbngaysinh.Size = new System.Drawing.Size(36, 15);
            this.lbngaysinh.TabIndex = 85;
            this.lbngaysinh.Text = "value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(443, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 83;
            this.label12.Text = "Ngoại ngữ:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(10, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 15);
            this.label13.TabIndex = 82;
            this.label13.Text = "Khoa phòng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(443, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 15);
            this.label10.TabIndex = 81;
            this.label10.Text = "Đào tạo NN:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(443, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 80;
            this.label9.Text = "Bằng cấp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(443, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 79;
            this.label7.Text = "Chuyên môn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(10, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 78;
            this.label6.Text = "Điện thoại: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 77;
            this.label5.Text = "Địa chỉ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(10, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 76;
            this.label4.Text = "Ngày sinh:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Green;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(4, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1010, 34);
            this.panel3.TabIndex = 80;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(28, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(487, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "PHẦN MỀM QUẢN LÝ NHÂN VIÊN ( ĐÀO TẠO - NGHIÊN CỨU KHOA HỌC - CÔNG TÁC TUYẾN)";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(4, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1010, 21);
            this.panel4.TabIndex = 80;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(8, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(240, 13);
            this.label15.TabIndex = 77;
            this.label15.Text = "I. Thông tin hành chánh - lý lịch nhân viên";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Teal;
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(4, 181);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1010, 21);
            this.panel5.TabIndex = 80;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(175, 13);
            this.label16.TabIndex = 77;
            this.label16.Text = "II. Bổ sung quá trình công tác:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Teal;
            this.panel6.Controls.Add(this.label19);
            this.panel6.Location = new System.Drawing.Point(4, 292);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1010, 21);
            this.panel6.TabIndex = 81;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(8, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(172, 13);
            this.label19.TabIndex = 77;
            this.label19.Text = "III. Lịch sử quá trình công tác";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 70;
            // 
            // LOAI
            // 
            this.LOAI.HeaderText = "TEN";
            this.LOAI.Name = "LOAI";
            this.LOAI.Width = 200;
            // 
            // NOIDUNG
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.NullValue = null;
            this.NOIDUNG.DefaultCellStyle = dataGridViewCellStyle3;
            this.NOIDUNG.HeaderText = "NỘI DUNG";
            this.NOIDUNG.Name = "NOIDUNG";
            this.NOIDUNG.Width = 300;
            // 
            // TUNGAY
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            this.TUNGAY.DefaultCellStyle = dataGridViewCellStyle4;
            this.TUNGAY.HeaderText = "TỪ NGÀY";
            this.TUNGAY.Name = "TUNGAY";
            // 
            // DENNGAY
            // 
            this.DENNGAY.HeaderText = "ĐẾN NGÀY";
            this.DENNGAY.Name = "DENNGAY";
            // 
            // sogio
            // 
            this.sogio.HeaderText = "GIỜ THỰC HỌC";
            this.sogio.Name = "sogio";
            // 
            // NGÀY
            // 
            this.NGÀY.HeaderText = "NGAY";
            this.NGÀY.Name = "NGÀY";
            // 
            // frmQLDAOTAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgridChiTiet);
            this.Controls.Add(this.txtIDVP);
            this.Controls.Add(this.listicd10);
            this.Controls.Add(this.txtNameVP);
            this.Controls.Add(this.btThem);
            this.Name = "frmQLDAOTAO";
            this.Text = "frmQLDAOTAO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQLDAOTAO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridChiTiet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDVP;
        private LibList.List listicd10;
        private System.Windows.Forms.TextBox txtNameVP;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.DataGridView dgridChiTiet;
        private System.Windows.Forms.RichTextBox txtNoiDung;
        private System.Windows.Forms.DateTimePicker dtungay;
        private System.Windows.Forms.DateTimePicker ddenngay;
        private System.Windows.Forms.DateTimePicker dNgayLamViec;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbngoaingu;
        private System.Windows.Forms.Label lbkhoaphong;
        private System.Windows.Forms.Label lbdtnn;
        private System.Windows.Forms.Label lbbangcap;
        private System.Windows.Forms.Label lbchuyenmon;
        private System.Windows.Forms.Label lbdienthoai;
        private System.Windows.Forms.Label lbdiachi;
        private System.Windows.Forms.Label lbngaysinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbkinhnghiem;
        private System.Windows.Forms.Label lbnhom;
        private System.Windows.Forms.Label lbtrinhdo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOIDUNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TUNGAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DENNGAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn sogio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGÀY;
    }
}