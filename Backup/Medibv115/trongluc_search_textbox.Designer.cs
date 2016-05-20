namespace MediIT115
{
    partial class trongluc_search_textbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trongluc_search_textbox));
            this.dgridtimkiem = new System.Windows.Forms.DataGridView();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tengoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttenvp = new System.Windows.Forms.TextBox();
            this.txtmavp = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgridtimkiem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridtimkiem
            // 
            this.dgridtimkiem.AllowUserToAddRows = false;
            this.dgridtimkiem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgridtimkiem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridtimkiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgridtimkiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgridtimkiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgridtimkiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgridtimkiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridtimkiem.ColumnHeadersVisible = false;
            this.dgridtimkiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mid,
            this.tengoi,
            this.donvi,
            this.DonGia});
            this.dgridtimkiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgridtimkiem.Location = new System.Drawing.Point(7, 22);
            this.dgridtimkiem.Name = "dgridtimkiem";
            this.dgridtimkiem.ReadOnly = true;
            this.dgridtimkiem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgridtimkiem.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgridtimkiem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgridtimkiem.Size = new System.Drawing.Size(648, 96);
            this.dgridtimkiem.TabIndex = 40;
            this.dgridtimkiem.Visible = false;
            this.dgridtimkiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridtimkiem_CellClick);
            this.dgridtimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown_grid);
            // 
            // mid
            // 
            this.mid.HeaderText = "ID";
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            this.mid.Width = 80;
            // 
            // tengoi
            // 
            this.tengoi.HeaderText = "Tên gói kỹ thuật cao";
            this.tengoi.Name = "tengoi";
            this.tengoi.ReadOnly = true;
            this.tengoi.Width = 400;
            // 
            // donvi
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.donvi.DefaultCellStyle = dataGridViewCellStyle2;
            this.donvi.HeaderText = "Đơn vị";
            this.donvi.Name = "donvi";
            this.donvi.ReadOnly = true;
            this.donvi.Width = 80;
            // 
            // DonGia
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.DonGia.HeaderText = "DonGia";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 70;
            // 
            // txttenvp
            // 
            this.txttenvp.BackColor = System.Drawing.Color.White;
            this.txttenvp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenvp.ForeColor = System.Drawing.Color.Red;
            this.txttenvp.Location = new System.Drawing.Point(87, 0);
            this.txttenvp.Name = "txttenvp";
            this.txttenvp.Size = new System.Drawing.Size(542, 20);
            this.txttenvp.TabIndex = 1;
            this.txttenvp.TextChanged += new System.EventHandler(this.txttenvp_TextChanged);
            this.txttenvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // txtmavp
            // 
            this.txtmavp.Enabled = false;
            this.txtmavp.Location = new System.Drawing.Point(7, 0);
            this.txtmavp.Name = "txtmavp";
            this.txtmavp.Size = new System.Drawing.Size(76, 20);
            this.txtmavp.TabIndex = 42;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.Red;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.Location = new System.Drawing.Point(628, -2);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(27, 23);
            this.btClose.TabIndex = 43;
            this.btClose.TabStop = false;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // trongluc_search_textbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txtmavp);
            this.Controls.Add(this.dgridtimkiem);
            this.Controls.Add(this.txttenvp);
            this.Name = "trongluc_search_textbox";
            this.Size = new System.Drawing.Size(661, 121);
            this.Load += new System.EventHandler(this.trongluc_search_textbox_Load);
            this.Enter += new System.EventHandler(this.trongluc_search_textbox_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgridtimkiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridtimkiem;
        private System.Windows.Forms.TextBox txttenvp;
        private System.Windows.Forms.TextBox txtmavp;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tengoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn donvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
    }
}
