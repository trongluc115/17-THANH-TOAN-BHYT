namespace MediIT115
{
    partial class frmdoimatkhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtmatkhaucu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmakhau1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmatkhau2 = new System.Windows.Forms.TextBox();
            this.btLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // txtmatkhaucu
            // 
            this.txtmatkhaucu.Location = new System.Drawing.Point(144, 8);
            this.txtmatkhaucu.Name = "txtmatkhaucu";
            this.txtmatkhaucu.PasswordChar = '*';
            this.txtmatkhaucu.Size = new System.Drawing.Size(124, 20);
            this.txtmatkhaucu.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txtmakhau1
            // 
            this.txtmakhau1.Location = new System.Drawing.Point(144, 34);
            this.txtmakhau1.Name = "txtmakhau1";
            this.txtmakhau1.PasswordChar = '*';
            this.txtmakhau1.Size = new System.Drawing.Size(124, 20);
            this.txtmakhau1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // txtmatkhau2
            // 
            this.txtmatkhau2.Location = new System.Drawing.Point(144, 60);
            this.txtmatkhau2.Name = "txtmatkhau2";
            this.txtmatkhau2.PasswordChar = '*';
            this.txtmatkhau2.Size = new System.Drawing.Size(124, 20);
            this.txtmatkhau2.TabIndex = 22;
            // 
            // btLuu
            // 
            this.btLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.ForeColor = System.Drawing.Color.Red;
            this.btLuu.Location = new System.Drawing.Point(192, 86);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(76, 27);
            this.btLuu.TabIndex = 47;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // frmdoimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 122);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmatkhau2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmakhau1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmatkhaucu);
            this.Name = "frmdoimatkhau";
            this.Text = "Doi mat khau";
            this.Load += new System.EventHandler(this.frmdoimatkhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmatkhaucu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmakhau1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmatkhau2;
        private System.Windows.Forms.Button btLuu;
    }
}