namespace MediIT115
{
    partial class frmbytgiavp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbytgiavp));
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgridChiTiet = new System.Windows.Forms.DataGridView();
            this.btLuu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtqdstt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txttenbyt = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtidbyt = new System.Windows.Forms.TextBox();
            this.lbkp = new System.Windows.Forms.Label();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.txtBHYTtra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtgiacu = new System.Windows.Forms.TextBox();
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
            this.btLuu.Location = new System.Drawing.Point(543, 96);
            this.btLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(59, 24);
            this.btLuu.TabIndex = 23;
            this.btLuu.Text = "Lưu";
            this.btLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtgiacu);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtqdstt);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txttenbyt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtidbyt);
            this.panel1.Controls.Add(this.lbkp);
            this.panel1.Controls.Add(this.txtdonvi);
            this.panel1.Controls.Add(this.txtBHYTtra);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ten);
            this.panel1.Location = new System.Drawing.Point(1, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 124);
            this.panel1.TabIndex = 79;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(608, 96);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 24);
            this.button1.TabIndex = 118;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "QĐ.STT";
            // 
            // txtqdstt
            // 
            this.txtqdstt.Location = new System.Drawing.Point(335, 50);
            this.txtqdstt.Name = "txtqdstt";
            this.txtqdstt.Size = new System.Drawing.Size(193, 20);
            this.txtqdstt.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(673, 96);
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
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(543, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(59, 20);
            this.txtID.TabIndex = 104;
            this.txtID.TabStop = false;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Tên BYT";
            // 
            // txttenbyt
            // 
            this.txttenbyt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenbyt.Location = new System.Drawing.Point(76, 71);
            this.txttenbyt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttenbyt.Name = "txttenbyt";
            this.txttenbyt.Size = new System.Drawing.Size(452, 23);
            this.txttenbyt.TabIndex = 20;
            this.txttenbyt.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "ID BYT";
            // 
            // txtidbyt
            // 
            this.txtidbyt.Location = new System.Drawing.Point(76, 49);
            this.txtidbyt.Name = "txtidbyt";
            this.txtidbyt.Size = new System.Drawing.Size(181, 20);
            this.txtidbyt.TabIndex = 18;
            // 
            // lbkp
            // 
            this.lbkp.AutoSize = true;
            this.lbkp.Location = new System.Drawing.Point(343, 31);
            this.lbkp.Name = "lbkp";
            this.lbkp.Size = new System.Drawing.Size(41, 13);
            this.lbkp.TabIndex = 89;
            this.lbkp.Text = "Đơn vị:";
            // 
            // txtdonvi
            // 
            this.txtdonvi.Location = new System.Drawing.Point(404, 27);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(124, 20);
            this.txtdonvi.TabIndex = 14;
            // 
            // txtBHYTtra
            // 
            this.txtBHYTtra.Location = new System.Drawing.Point(76, 27);
            this.txtBHYTtra.Name = "txtBHYTtra";
            this.txtBHYTtra.Size = new System.Drawing.Size(261, 20);
            this.txtBHYTtra.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "BHYT trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Tên ";
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(76, 5);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(452, 20);
            this.ten.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Giá cũ";
            // 
            // txtgiacu
            // 
            this.txtgiacu.Location = new System.Drawing.Point(76, 96);
            this.txtgiacu.Name = "txtgiacu";
            this.txtgiacu.Size = new System.Drawing.Size(193, 20);
            this.txtgiacu.TabIndex = 119;
            // 
            // frmbytgiavp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(999, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgridChiTiet);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "frmbytgiavp";
            this.Text = "BYT VIEN PHI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMnhanvien_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey_KeyDown);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBHYTtra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtidbyt;
        private System.Windows.Forms.Label lbkp;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txttenbyt;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtqdstt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgiacu;
    }
}