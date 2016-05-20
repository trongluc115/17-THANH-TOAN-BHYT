namespace MediIT115
{
    partial class frmKhoaSoLieuCDHA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoaSoLieuCDHA));
            this.panel10 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.date_lock = new System.Windows.Forms.DateTimePicker();
            this.btLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel10.SuspendLayout();
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
            this.panel10.Size = new System.Drawing.Size(403, 40);
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
            this.lbtitle.Size = new System.Drawing.Size(216, 24);
            this.lbtitle.TabIndex = 12;
            this.lbtitle.Text = "KHÓA SỐ LIỆU CĐHA";
            // 
            // date_lock
            // 
            this.date_lock.CustomFormat = "dd/MM/yyyy";
            this.date_lock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_lock.Location = new System.Drawing.Point(171, 59);
            this.date_lock.Name = "date_lock";
            this.date_lock.Size = new System.Drawing.Size(103, 22);
            this.date_lock.TabIndex = 51;
            // 
            // btLuu
            // 
            this.btLuu.Image = ((System.Drawing.Image)(resources.GetObject("btLuu.Image")));
            this.btLuu.Location = new System.Drawing.Point(280, 59);
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
            this.label1.Location = new System.Drawing.Point(38, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Cài đặt ngày khóa số liệu";
            // 
            // frmKhoaSoLieuCDHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 147);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.date_lock);
            this.Controls.Add(this.panel10);
            this.Name = "frmKhoaSoLieuCDHA";
            this.Text = "frmKhoaSoLieuCDHA";
            this.Load += new System.EventHandler(this.frmKhoaSoLieuCDHA_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.DateTimePicker date_lock;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Label label1;
    }
}