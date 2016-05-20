using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Data;
using DataMySQL;
using Entity;
using LibBaocao;

namespace MediIT115
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            
            
            Application.Exit();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            AccessData data = new AccessData();
            string sql = "Select id from Bv115.bv_dlogin where Upper(userid)=Upper('{0}') and password_='{1}'";
            sql = sql.Replace("{0}", txtUsername.Text);
            sql = sql.Replace("{1}", txtPassword.Text);
            string ID="";
            
            try
            {
                DataSet ds = data.get_data(sql);
                ID = ds.Tables[0].Rows[0][0].ToString();
                sql = "Select to_char(date_lock,'dd/mm/yyyy') from Bv115.m_config where id=1";
                ds=data.get_data(sql);
                string str_date = ds.Tables[0].Rows[0][0].ToString();
                if (ID.Length > 0)
                {
                    AccessData.m_userid = ID;
                    AccessData.m_date_lock = m_format.DateTime_parse(str_date);
                    AccessData.m_date_default = ddefault.Value;
                    this.Close();
                }
            }
            catch {
                MessageBox.Show("Đăng nhập không thành công!");
                Application.Exit();
            }
            
            
            
        }
        public void f_Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
              
               
                if (e.KeyCode == Keys.Enter)
                {
                  
                    if (e.Handled == false)
                    {
                        SendKeys.Send("{Tab}");
                        e.Handled = true;
                    }
                }
                else
                    if ((sender.GetType().ToString() == "System.Windows.Forms.ComboBox"))
                    {
                       
                        System.Windows.Forms.ComboBox tmp = (System.Windows.Forms.ComboBox)(sender);
                        if (tmp.SelectedIndex < 0)
                        {
                            tmp.SelectedIndex = 0;
                        }
                    
                    }
            }
            catch
            {
               
            }

        }
        

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }
    }
}