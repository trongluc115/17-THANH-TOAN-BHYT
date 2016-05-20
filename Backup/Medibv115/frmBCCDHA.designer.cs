namespace MediIT115
{
    partial class frmBCCDHA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCCDHA));
            this.btInBaoCao = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeview_room = new Report2009.TreeView_HAISON();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbloai = new System.Windows.Forms.Label();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.haison1 = new MediIT115.haison();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInBaoCao
            // 
            this.btInBaoCao.Location = new System.Drawing.Point(303, 28);
            this.btInBaoCao.Name = "btInBaoCao";
            this.btInBaoCao.Size = new System.Drawing.Size(82, 28);
            this.btInBaoCao.TabIndex = 6;
            this.btInBaoCao.Text = "In Báo Cáo";
            this.btInBaoCao.UseVisualStyleBackColor = true;
            this.btInBaoCao.Click += new System.EventHandler(this.btInBaoCao_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.treeview_room);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lbloai);
            this.panel2.Controls.Add(this.cbLoai);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.haison1);
            this.panel2.Controls.Add(this.btInBaoCao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 360);
            this.panel2.TabIndex = 9;
            // 
            // treeview_room
            // 
            this.treeview_room.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.treeview_room.BackColor = System.Drawing.Color.Transparent;
            this.treeview_room.Location = new System.Drawing.Point(402, 28);
            this.treeview_room.Name = "treeview_room";
            this.treeview_room.Size = new System.Drawing.Size(396, 318);
            this.treeview_room.TabIndex = 50;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 28);
            this.button2.TabIndex = 49;
            this.button2.Text = "BC Bộ phận";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 48;
            this.button1.Text = "Báo cáo Phim";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbloai
            // 
            this.lbloai.AutoSize = true;
            this.lbloai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbloai.Location = new System.Drawing.Point(7, 32);
            this.lbloai.Name = "lbloai";
            this.lbloai.Size = new System.Drawing.Size(44, 13);
            this.lbloai.TabIndex = 44;
            this.lbloai.Text = "Loại BC";
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Báo cáo ngày",
            "Báo cáo tháng",
            "Báo cáo nhóm"});
            this.cbLoai.Location = new System.Drawing.Point(58, 28);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(131, 21);
            this.cbLoai.TabIndex = 43;
            this.cbLoai.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(826, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton2.Text = "Báo cáo CĐHA";
            this.toolStripButton2.ToolTipText = "Báo cáo CĐHA ";
            // 
            // haison1
            // 
            this.haison1.Location = new System.Drawing.Point(8, 51);
            this.haison1.Name = "haison1";
            this.haison1.Size = new System.Drawing.Size(274, 68);
            this.haison1.TabIndex = 7;
            // 
            // frmBCCDHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(830, 360);
            this.Controls.Add(this.panel2);
            this.Name = "frmBCCDHA";
            this.Text = "CDHA DICH VU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBCDuocMau20_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private haison haison1;
        private System.Windows.Forms.Button btInBaoCao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label lbloai;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Report2009.TreeView_HAISON treeview_room;
    }
}