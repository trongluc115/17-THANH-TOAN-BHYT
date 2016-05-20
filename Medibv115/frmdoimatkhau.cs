using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibBaocao;
namespace MediIT115
{
    public partial class frmdoimatkhau : Form
    {
        public frmdoimatkhau()
        {
            InitializeComponent();
        }
        string sql = "";
        private void btLuu_Click(object sender, EventArgs e)
        {
            AccessData data = new AccessData();
            string sql = "Select id from Bv115.bv_login where id='{0}' and password='{1}'";
            sql = sql.Replace("{0}", AccessData.m_userid);
            sql = sql.Replace("{1}", txtmatkhaucu.Text);
            string ID = "";
            try
            {
                DataSet ds = data.get_data(sql);
                ID = ds.Tables[0].Rows[0][0].ToString();
                if (ID.Length > 0)
                {
                    if (txtmakhau1.Text.CompareTo(txtmatkhau2.Text) == 0)
                    {
                        f_update_matkhau(ID, txtmatkhau2.Text);
                        MessageBox.Show("Thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra xác thực mật khẩu!");
                    }

                }
                else {
                    MessageBox.Show("Không thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Không thành công!");
                
            }
        }
        private void f_update_matkhau(string id,string matkhau)
        {
            try
            {

                AccessData data = new AccessData();
                    sql = "update Bv115.bv_login set password='{0}' where id={1} ";
                    
                    sql = sql.Replace("{0}", matkhau);
                    sql = sql.Replace("{1}", id);
                    
                    data.execute_data(sql);
               
            }
            catch { }
        }

        private void frmdoimatkhau_Load(object sender, EventArgs e)
        {
           
        }
    }
}