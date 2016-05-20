using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataMySQL;
using Entity;
using LibBaocao;
using DataOracle;
using AutoUpdate;
using DataUpdate;
namespace MediIT115
{
    public partial class frmLogin2 : Form
    {
        public string mRight = "";
        public string mUserid = "";
        public bool mExit = false;
        public int iUserid = 0;
        public string mTenDangNhap = "";
        public string mPassword = "";
        public string mUserAdmin = "";
        public string mPasswordAdmin = "";
        private CConnection_Oracle ora_con = new CConnection_Oracle();
        private CLoginOracle clogin;
        public frmLogin2()
        {      
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.mUserid = "";
            this.mExit = true;
            Application.Exit();
        }
        private void setDefault()
        {
            try
            {
                AccessData data = new AccessData();
                DataSet ds = new DataSet();
               
                string  sql = "Select to_char(date_lock,'dd/mm/yyyy') from Bv115.m_config where id=1";
                ds = data.get_data(sql);
                string str_date = ds.Tables[0].Rows[0][0].ToString();
                AccessData.m_date_lock = m_format.DateTime_parse(str_date);
                AccessData.m_date_default = ddefault.Value;
                   
                
            }
            catch { }
        }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            
            mUserAdmin = clogin.userAdmin;
            mPasswordAdmin = clogin.passwordAdmin;
            
            setDefault();
            xml_write();
            if ((txtUsername.Text == clogin.userAdmin) && (txtPassword.Text == clogin.passwordAdmin))
            {
                //ora_con.tao_schema();
                mTenDangNhap = txtUsername.Text;
                mPassword = txtPassword.Text;
                

                
                this.Close();
            }
            else
            {
                AccessData data = new AccessData();
                           
                try
                {
                    DataSet ds = clogin.LoadDSUser(txtUsername.Text, txtPassword.Text);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            iUserid = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                            mRight = ds.Tables[0].Rows[0]["menuitem"].ToString();
                            mUserid = ds.Tables[0].Rows[0]["hoten"].ToString();
                            mTenDangNhap = ds.Tables[0].Rows[0]["username"].ToString();
                            mPassword = ds.Tables[0].Rows[0]["password"].ToString();
                            AccessData._NHOM_CDHA = ds.Tables[0].Rows[0]["NHOMCDHA"].ToString();
                            AccessData.m_userid = iUserid.ToString();
                            AccessData.s_makhuvuc = cbkhu.SelectedValue.ToString();
                            AccessData.s_tenkhuvuc = cbkhu.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập không thành công!");
                         
                        }
                    }

                   
                }
                catch
                {
                    MessageBox.Show("Đăng nhập không thành công!");
                  
                }
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
            clogin = new CLoginOracle();
            setDefault();
            initcbkhu();
            xml_read();
            Version();
        }
        private void Version()
        {


            lbverson.Text += this.ProductVersion;
                
            
        }
        private void initcbkhu()
        {
            try
            {
                CDanhMucOracle DMOracle = new CDanhMucOracle();
           
                cbkhu.DataSource = DMOracle.d_getDMKHU("");
                cbkhu.DisplayMember = "Name";
                cbkhu.ValueMember = "ID";
                cbkhu.SelectedIndex = 0;
            }
            catch { }
        }
        private void xml_write()
        {
            try {
                CXml xml_file = new CXml();
                xml_file.WriteXML("AREA", cbkhu.SelectedValue.ToString(), "ConfigCDHA.xml");

            }
            catch { }
        }
        private void xml_read()
        {
            try
            {
                CXml xml_file = new CXml();
                string s_area=xml_file.ReadXML("AREA", "ConfigCDHA.xml");

                f_set_ComboBox(cbkhu, s_area);
            }
            catch { }
        }
        private void f_set_ComboBox(ComboBox cb, string s_value)
        {
            try
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.SelectedValue.ToString().CompareTo(s_value) == 0)
                    {
                        break;
                    }
                }
            }
            catch { }

        }

        private void lbverson_Click(object sender, EventArgs e)
        {
          
        }
    }
}