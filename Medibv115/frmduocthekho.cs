using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;
using LibBaocao;
using Entity;
namespace MediIT115
{
    public partial class frmduocthekho: Form
    {
        private d_dmbdbh_Orace dmbd_oracle = new d_dmbdbh_Orace();
        public frmduocthekho()
        {
            InitializeComponent();
        }

        private void frmDMnhanvien_Load(object sender, EventArgs e)
        {
            f_loadcbb();
            f_load();

        }
        private void f_load()
        {
            CDanhMucOracle dataOracle = new CDanhMucOracle();
            DMNV_Oracle nv_Oracle = new DMNV_Oracle();
        

            DataTable dtdm_dichvu = dmbd_oracle.getBYT_d_dmbd("");
            dgridChiTiet.DataSource = dtdm_dichvu;

         
        }
        private void f_loadcbb()
        {
            try
            {
              

             
            }
            catch { }
        
        }
        private void Filt_Search(string ten)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[dgridChiTiet.DataSource];
                DataView list = (DataView)manager.List;
                list.RowFilter = "TEN like '%" + ten.Trim() + "%'";
            }
            catch
            {
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Filt_Search(txtTimKiem.Text);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {

        }

        private void cbLoai_Enter(object sender, EventArgs e)
        {

        }

        private void dgridChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                string s_id = dgridChiTiet.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtID.Text = s_id;
            }
            catch { }
        }

        private void dgridChiTiet_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = dgridChiTiet.SelectedRows[0];
                string s_id = row.Cells["ID"].Value.ToString();
                txtID.Text = s_id;
            }
            catch { }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            f_loadct();
        }
        private void f_loadct()
        {
            try {
             
                DataTable dtdm_chitiet = dmbd_oracle.getBYT_d_dmbd(txtID.Text);
                ten.Text = dtdm_chitiet.Rows[0]["TEN"].ToString();
                txthamluong.Text = dtdm_chitiet.Rows[0]["HAMLUONG"].ToString();
                txtdonvi.Text = dtdm_chitiet.Rows[0]["DONVI"].ToString();               
                txtidbyt.Text = dtdm_chitiet.Rows[0]["ID_BYT"].ToString();
                txtbvapthau.Text = dtdm_chitiet.Rows[0]["BV_APTHAU"].ToString();
                txtngayhl.Text = dtdm_chitiet.Rows[0]["NGAYHIEULUC"].ToString();
                txthlden.Text = dtdm_chitiet.Rows[0]["HIEULUCDEN"].ToString();
                txtsqdmua.Text = dtdm_chitiet.Rows[0]["SOQD_MUASAM"].ToString();
                txtnhombyt.Text = dtdm_chitiet.Rows[0]["NHOM_BYT"].ToString();
                txttenbyt.Text = dtdm_chitiet.Rows[0]["TEN_BYT"].ToString();
                txtqdstt.Text = dtdm_chitiet.Rows[0]["QD_STT"].ToString();

              
            }
            catch { }
        }
        private void setList(ComboBox cb, string s_value)
        { 
            try{
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.SelectedValue.ToString() == s_value)
                    {
                        return;
                    }
                }
            }catch{}
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
            {
                f_update();
            }
           
        
        }
        private void f_update()
        {
            
        }
       

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        # region list

      

       
      

       
        #endregion 

        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

               
                if (e.KeyCode == Keys.F5)
                {
                    if (txtID.Text.Length > 0)
                    {
                        f_update();
                    }

                   

                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();

                }
                if (e.KeyCode == Keys.F3)
                {
                    f_load();

                }


            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reportname = "xuat_excel.rpt";
            Thekho_Oracle Ora_thekho = new Thekho_Oracle();
            DataTable dt = new DataTable();
            AccessData d = new AccessData();
            dt = Ora_thekho.f_getTheKho(dsolieuthang.Value,m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay),txtID.Text);
            frmReport a = new frmReport(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
     
     
    }
}
