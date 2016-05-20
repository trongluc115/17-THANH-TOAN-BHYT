namespace MediIT115
{
    partial class frmUpdate_giavp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate_giavp));
            this.dGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dGrid
            // 
            this.dGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGrid.BackgroundColor = System.Drawing.Color.White;
            this.dGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TEN37,
            this.GIA37,
            this.STT37});
            this.dGrid.Location = new System.Drawing.Point(12, 13);
            this.dGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dGrid.Name = "dGrid";
            this.dGrid.Size = new System.Drawing.Size(672, 514);
            this.dGrid.TabIndex = 44;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 70;
            // 
            // TEN37
            // 
            this.TEN37.HeaderText = "TEN37";
            this.TEN37.Name = "TEN37";
            this.TEN37.Width = 300;
            // 
            // GIA37
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.GIA37.DefaultCellStyle = dataGridViewCellStyle2;
            this.GIA37.HeaderText = "GIA37";
            this.GIA37.Name = "GIA37";
            this.GIA37.Width = 150;
            // 
            // STT37
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            this.STT37.DefaultCellStyle = dataGridViewCellStyle3;
            this.STT37.HeaderText = "STT37";
            this.STT37.Name = "STT37";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(565, 553);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 32);
            this.button1.TabIndex = 45;
            this.button1.Text = "Update ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmUpdate_giavp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 592);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dGrid);
            this.Name = "frmUpdate_giavp";
            this.Text = "frmUpdate_giavp";
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN37;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA37;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT37;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dGrid;
    }
}