namespace MediIT115
{
    partial class frmKhoaSoLieuBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoaSoLieuBHYT));
            this.panel10 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.date_lock = new System.Windows.Forms.DateTimePicker();
            this.btLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dExport = new System.Windows.Forms.DateTimePicker();
            this.txtSoThang = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbhytcn = new System.Windows.Forms.Button();
            this.txtExv_chidinh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Green;
            this.panel10.Controls.Add(this.dateTimePicker1);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.lbtitle);
            this.panel10.Location = new System.Drawing.Point(1, 1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(621, 40);
            this.panel10.TabIndex = 50;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy ";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(805, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 37;
            this.dateTimePicker1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(747, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Ngày BC";
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.BackColor = System.Drawing.Color.Transparent;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.ForeColor = System.Drawing.Color.Red;
            this.lbtitle.Location = new System.Drawing.Point(3, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(213, 24);
            this.lbtitle.TabIndex = 12;
            this.lbtitle.Text = "KHÓA SỐ LIỆU BHYT";
            // 
            // date_lock
            // 
            this.date_lock.CustomFormat = "dd/MM/yyyy";
            this.date_lock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_lock.Location = new System.Drawing.Point(150, 20);
            this.date_lock.Name = "date_lock";
            this.date_lock.Size = new System.Drawing.Size(103, 22);
            this.date_lock.TabIndex = 51;
            // 
            // btLuu
            // 
            this.btLuu.Image = ((System.Drawing.Image)(resources.GetObject("btLuu.Image")));
            this.btLuu.Location = new System.Drawing.Point(259, 15);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(76, 33);
            this.btLuu.TabIndex = 52;
            this.btLuu.Text = "Lưu";
            this.btLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Khóa số liệu trước ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Tháng hiện hành:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Số tháng về trước:";
            // 
            // dExport
            // 
            this.dExport.CustomFormat = "MM/yyyy";
            this.dExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dExport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dExport.Location = new System.Drawing.Point(144, 16);
            this.dExport.Name = "dExport";
            this.dExport.Size = new System.Drawing.Size(83, 22);
            this.dExport.TabIndex = 56;
            // 
            // txtSoThang
            // 
            this.txtSoThang.Location = new System.Drawing.Point(192, 44);
            this.txtSoThang.Name = "txtSoThang";
            this.txtSoThang.Size = new System.Drawing.Size(35, 20);
            this.txtSoThang.TabIndex = 57;
            this.txtSoThang.Text = "3";
            this.txtSoThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtbhytcn);
            this.panel1.Controls.Add(this.txtExv_chidinh);
            this.panel1.Controls.Add(this.dExport);
            this.panel1.Controls.Add(this.txtSoThang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(23, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 199);
            this.panel1.TabIndex = 58;
            // 
            // txtbhytcn
            // 
            this.txtbhytcn.Image = ((System.Drawing.Image)(resources.GetObject("txtbhytcn.Image")));
            this.txtbhytcn.Location = new System.Drawing.Point(357, 49);
            this.txtbhytcn.Name = "txtbhytcn";
            this.txtbhytcn.Size = new System.Drawing.Size(213, 28);
            this.txtbhytcn.TabIndex = 59;
            this.txtbhytcn.Text = "Tạo số liệu bhyt_cn";
            this.txtbhytcn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtbhytcn.UseVisualStyleBackColor = true;
            this.txtbhytcn.Click += new System.EventHandler(this.txtbhytcn_Click);
            // 
            // txtExv_chidinh
            // 
            this.txtExv_chidinh.Image = ((System.Drawing.Image)(resources.GetObject("txtExv_chidinh.Image")));
            this.txtExv_chidinh.Location = new System.Drawing.Point(357, 16);
            this.txtExv_chidinh.Name = "txtExv_chidinh";
            this.txtExv_chidinh.Size = new System.Drawing.Size(213, 28);
            this.txtExv_chidinh.TabIndex = 58;
            this.txtExv_chidinh.Text = "Tạo số liệu temp_v_chidinh";
            this.txtExv_chidinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtExv_chidinh.UseVisualStyleBackColor = true;
            this.txtExv_chidinh.Click += new System.EventHandler(this.txtExv_chidinh_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.date_lock);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(23, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 81);
            this.panel2.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(357, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 28);
            this.button1.TabIndex = 60;
            this.button1.Text = "Tạo số liệu d_dmbdbh";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmKhoaSoLieuBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 373);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel10);
            this.Name = "frmKhoaSoLieuBHYT";
            this.Text = "frmKhoaSoLieuCDHA";
            this.Load += new System.EventHandler(this.frmKhoaSoLieuBHYT_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.DateTimePicker date_lock;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dExport;
        private System.Windows.Forms.TextBox txtSoThang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button txtExv_chidinh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button txtbhytcn;
        private System.Windows.Forms.Button button1;
    }
}