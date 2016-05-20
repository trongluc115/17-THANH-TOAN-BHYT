using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entity;
using Data;
using DataOracle;
using LibBaocao;

namespace MediIT115
{
    public partial class frmDuyetBoPhan : Form
    {
        CBenhNhan BN;
        CThanhToanBHYT BHYT;
        double _khambenh=0;
        private List<string> Listthuock;
        private DateTime date_lock;
        public frmDuyetBoPhan()
        {
            InitializeComponent();
            
            
        }
        private void add_SoPhieu()
        { 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
            f_duyetthuchien();
            f_load();
            btMoi.Select();
            
            
        }
       
       
   
  
        private bool KiemTraMaThe(string Ma)
        {
            CXml cxml = new CXml();
            string sformat = cxml.ReadXML("P1", "config.xml");
            if (sformat.IndexOf(Ma) >= 0)
                return true;
            else
                return false;
        }
        private void f_setcbPhai(int value)
        {
            try
            {
                cbPhai.SelectedIndex = value;
            }
            catch { cbPhai.SelectedIndex = 0; }
        }
        
        private void init_form()
        {
            try
            {
                txtMaBN.Text = "";
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
              
                txtMaQL.Text = "";
                f_setcbPhai(0);

             
              
                
               
                txtSoBienLai.Text = "";

                txtSoPhieu.Text = "";
            
                txtIDThanhToan.Text = "";
              

              
               
                txtNamSinh.Text = "";


           
              
            }
            catch { }
        }
        private void txtMaBN_Leave(object sender, EventArgs e)
        {
            loadBHYT();
            f_load();

            
        }
        
        private void loadBHYT()
        {
            try
            {

                CBenhNhanOracle BNOracle = new CBenhNhanOracle();
                BN = BNOracle.getBenhNhan(txtMaBN.Text);
                BN.HoTen = s_prepair(BN.HoTen);
                BN.DiaChi = s_prepair(BN.DiaChi);
                txtNamSinh.Text = BN.NamSinh.ToString();
                txtHoTen.Text =BN.HoTen;
                txtDiaChi.Text = BN.DiaChi;
                f_setcbPhai(BN.GioiTinh);

                //CThanhToanBHYTOracleNoiTru DataOracle = new CThanhToanBHYTOracleNoiTru();
                //DataSet dsdotdt = DataOracle.f_loadNgayNhapVien_MaQL(txtMaBN.Text, haison1.tungay, haison1.denngay, ckLocNgay.Checked);
                //cbdotdieutri.DataSource = null;
                //cbdotdieutri.DataSource = dsdotdt.Tables[0];
                //cbdotdieutri.DisplayMember = "dotdieutri";
                //cbdotdieutri.ValueMember = "mavaovien";
   

                        


              
               // btLuu.Select();
               // txtMaBN.Enabled = false;
            }
            catch { }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private long f_getvalue_Long(string value)
        {
            long result = 0;
            try
            {
                result = (long)(float.Parse(value));
            }
            catch
            {       
            }
            return result;
        }
        
    

        private void frmDuyetBHYT_Load(object sender, EventArgs e)
        {
            BN = new CBenhNhan();
            BHYT = new CThanhToanBHYT();
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            _khambenh = OraDanhmuc.f_getgiaVP("30228");
          
            //f_init_addmodul();
            Listthuock = new List<string>();
            d_dmbdbh_Orace ora_dmbd = new d_dmbdbh_Orace();
            //Listthuock = ora_dmbd.getDanhSachThuocK();
            this.Text = this.Text + " ("+AccessData._NHOM_CDHA+")";
            init();



        }
        private void init()
        {
            try
            {
                lbkhu.Text = AccessData.s_tenkhuvuc;
                DataSet ds = new DataSet();
                cdha_hen_Oracle Data_cdha_hen = new cdha_hen_Oracle();
                ds = Data_cdha_hen.f_getCDHA_Loai("");
                cbCDHA_loai.DataSource = ds.Tables[0];
                cbCDHA_loai.DisplayMember = "Name";
                cbCDHA_loai.ValueMember = "ID";
                cbCDHA_loai.SelectedIndex = 0;

                ds = Data_cdha_hen.f_getCDHA_NOITHUCHIEN(AccessData.s_makhuvuc);
                cbarea.DataSource = ds.Tables[0];
                cbarea.DisplayMember = "Name";
                cbarea.ValueMember = "ID";
                cbarea.SelectedIndex = 0;
                panel1.Visible = false;
                panel3.Visible = false;

                xml_read();
                m_option option = new m_option();
                date_lock = option.f_get_CDHA_LockDate(AccessData.s_makhuvuc);

            }
            catch { }
        }
        private long getLong(string s)
        {
            try
            {
                return long.Parse(s);
            }
            catch { }
            return 0;
        }
        private string s_prepair(string s)
        {
            string kq = "";
            kq = s.Replace("'", " ");
            return kq;
        }
   
    
   
    

        private void btMoi_Click(object sender, EventArgs e)
        {
            txtMaBN.Enabled = true;
            lbThongBao.Text = "...";
            init_form();
            txtMaBN.Select();
        }

        private void txtMaBN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                     SendKeys.Send("{Tab}");
//                    btLuu.Select();
                    
                }
            }
            catch { }
            
        }
        private string f_clearDot(string s)
        {
            return s.Replace(".", "");
        }
        private string f_insertDot(string s)
        {
            string result = "";
            string temp = s;
            string num="";
            for (int i = 1; i <= temp.Length; i++)
            {
                num = temp.Substring(temp.Length - i, 1);
                if (i % 3 == 0)
                {
                    result = "." + num + result;
                }
                else
                {
                    result = num + result;
                }
            }
            return result.TrimStart('.');
        }

      
        private void TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)sender;
                textbox.Text = f_insertDot(textbox.Text);
               // f_loadTongCongSua();
            }
            catch { }
        }
        private void TextBox_Setfocus(object sender, EventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)sender;
                textbox.Text = f_clearDot(textbox.Text);
            }
            catch { }
        }
   
  
        private void ckDuyetBHYT_CheckedChanged(object sender, EventArgs e)
        {
            loadBHYT();
        }

        private void ckKhacNgay_CheckedChanged(object sender, EventArgs e)
        {
            loadBHYT();
        }

        private void ckLoaiDuyet_CheckedChanged(object sender, EventArgs e)
        {
            loadBHYT();
        }

       
       
     
     
      

       
    
        private double Double_Round(Double value)
        {
            return  Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }
   

     

     
        

     
     
     
     

        private void txtSoPhieu_Leave(object sender, EventArgs e)
        {
            try
            {
                long n = long.Parse(txtSoPhieu.Text);
            }
            catch {
                MessageBox.Show("Số phiếu không hợp lệ!");
                txtSoPhieu.Select();
            }
        }

        private void dngayra_ValueChanged(object sender, EventArgs e)
        {
            if (ckloaddate.Checked == true)
            {
                dngaybc.Value = dngayra.Value;
            }
        }

       
       

        private void dview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

      

      
        private bool IsThuocK(string mabd)
        {
            for (int i = 0; i < Listthuock.Count; i++)
            {
                if (Listthuock[i].CompareTo(mabd) == 0)
                    return true;
            }
            return false;
        }
    

        private void bnLuuTN_Click(object sender, EventArgs e)
        {
           
        }

        private   void f_load()
        {
            f_load_before();
            f_load_after();
        }
        private void f_load_after()
        {
            cdha_dvll_Oracle dvll_Ora = new cdha_dvll_Oracle();
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);

            DataTable dtcp = dvll_Ora.f_getCLS_daduyet_bophan(tungay, denngay, txtMaBN.Text, "1",cbCDHA_loai.SelectedValue.ToString());
            ddsdaduyet.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                ddsdaduyet.Rows.Add(item.ItemArray);
            }
            lbSoLuong.Text = ddsdaduyet.Rows.Count.ToString();
           
        }
        private void f_load_before()
        {
            cdha_dvll_Oracle dvll_Ora = new cdha_dvll_Oracle();
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);

            DataTable dtcp = dvll_Ora.f_getCLS_chuaduyet_bophan(tungay, denngay, txtMaBN.Text, "0",cbCDHA_loai.SelectedValue.ToString());
            dschuaduyet.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                dschuaduyet.Rows.Add(item.ItemArray);
            }
            if (txtMaBN.Text.Length == 8)
            {
                foreach (DataGridViewRow item in dschuaduyet.Rows)
                {
                    item.Cells[0].Value = true;
                }
            }
        }
        private void f_TimKiem(string timkiem)
        {

            try
            {
               
                foreach (DataGridViewRow item in dschuaduyet.Rows)
                    
                {
                    if (item.Cells["SoHDDV"].Value.ToString().IndexOf(timkiem,0)!=-1 || timkiem.Length==0)
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }

            }
            catch { }

        }

        private void txtSoBienLai_TextChanged(object sender, EventArgs e)
        {
            f_TimKiem(txtSoBienLai.Text);
        }

    
        private void f_xoaduyet()
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check==true)
                {
                    cdha_dvll dvll = new cdha_dvll();
                    string s_id=item.Cells["id_"].Value.ToString();
                    dvll.ID = long.Parse(s_id);
                    dvll.DONE = "0";
                    dvll.NGAYTHUCHIEN = DateTime.Now;
                    dvll_Oracle.f_update(dvll);
                    
                    cdha_hen_Oracle henOracle = new cdha_hen_Oracle();
                    henOracle.f_update_dathuchien("0", s_id);
                }
            }
           
        }

        private void f_duyetthuchien()
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            foreach (DataGridViewRow item in dschuaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true)
                {
                    cdha_dvll dvll = new cdha_dvll();
                    dvll.ID = long.Parse(item.Cells["id"].Value.ToString());
                    dvll.DONE = "1";
                    dvll.NGAYTHUCHIEN = dngaybc.Value;
                    dvll.Noithuchien = cbarea.SelectedValue.ToString();
                    dvll_Oracle.f_update(dvll);
                    string s_mavp = item.Cells["mavp"].Value.ToString();
                    string s_tenvp = item.Cells["tenvp"].Value.ToString();
                    frmnhapvattu frm = new frmnhapvattu("",s_mavp,dvll.ID.ToString(),s_mavp,"1");
                    frm.Show();
                    string s_id = dvll.ID.ToString();
                    cdha_hen_Oracle henOracle = new cdha_hen_Oracle();
                    henOracle.f_update_dathuchien("1", s_id);

                    
                }
            }

        }

        private void chkAll1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dschuaduyet.Rows)
            {
                item.Cells[0].Value = chkAll1.Checked;
            }
        }

        private void chkAll2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                item.Cells[0].Value = chkAll2.Checked;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dschuaduyet_Leave(object sender, EventArgs e)
        {
            dschuaduyet.EndEdit();
        }

 
        private void d_loadvattu(string s_id)
        {
            try
            {
                Ccdha_thuocphimOracle thuocphimOra=new Ccdha_thuocphimOracle();
                DataSet ds=new DataSet();
                ds=thuocphimOra.f_get(s_id);
                dsvattu.Rows.Clear();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    dsvattu.Rows.Add(dr.ItemArray);
                }
            }
            catch { }
        }

        private void btInBC_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            string reportname = "rpt_baocaoCDHA_DV_M02.rpt";
            cdha_dvll_Oracle dvll = new cdha_dvll_Oracle();
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);
            string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
            DataTable dt = dvll.f_getBAOCAO_M02(tungay, denngay,txtNhom.Text);
            frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }

        private void txtCurSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddsdaduyet_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void ddsdaduyet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow item = ddsdaduyet.CurrentRow;
             DateTime ngayth =m_format.DateTime_parse(item.Cells["ngayth2"].Value.ToString());
             if (f_kiemtra_locked(ngayth))
             {
                 string s_mavp = item.Cells["mavp_"].Value.ToString();
                 string s_id = item.Cells["id_"].Value.ToString();
                 string s_tenvp = item.Cells["tenvp_"].Value.ToString();
                 frmnhapvattu frm = new frmnhapvattu("", s_tenvp, s_id, s_mavp, "0");
                 frm.Show();
             }
        }

        private void ddsdaduyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string s_id = ddsdaduyet.CurrentRow.Cells["id_"].Value.ToString();
            d_loadvattu(s_id);
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (f_kiemtra_locked(dngaybc.Value.Date))
            {
                panel10.Enabled = false;
                panel1.Visible = true;
                panel3.Visible = true;
                xml_write();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            f_xoaduyet();
            f_load();
        }
        private void xml_write()
        {
            try
            {
                CXml xml_file = new CXml();
                xml_file.WriteXML("ROOM", cbarea.SelectedValue.ToString(), "ConfigCDHA.xml");
                xml_file.WriteXML("TECH",  cbCDHA_loai.SelectedValue.ToString(), "ConfigCDHA.xml");

            }
            catch { }
        }
        private void xml_read()
        {
            try
            {
                CXml xml_file = new CXml();
                string s_room = xml_file.ReadXML("ROOM", "ConfigCDHA.xml");
                string s_tech = xml_file.ReadXML("TECH", "ConfigCDHA.xml");
                f_set_ComboBox(cbarea, s_room);
                f_set_ComboBox(cbCDHA_loai, s_tech);
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

        private void btnSavefilm_Click(object sender, EventArgs e)
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true)
                {
                    cdha_dvll dvll = new cdha_dvll();
                    dvll.ID = long.Parse(item.Cells["id_"].Value.ToString());
                    
                    string s_mavp = item.Cells["mavp_"].Value.ToString();
                    string s_tenvp = item.Cells["tenvp_"].Value.ToString();
                    frmnhapvattu frm = new frmnhapvattu("", s_tenvp, dvll.ID.ToString(), s_mavp, "1");
                    frm.Show();


                }
            }
        }
        private bool f_kiemtra_locked(DateTime ngay)
        {
            bool result = true;
            if (ngay <= date_lock)
            {
                result = false;
                MessageBox.Show("Đã khóa số liệu đến ngày: " + string.Format("{0:dd/MM/yyyy}", date_lock));
            }
            return result;
        }
        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                switch (e.KeyCode)
                {
                    case Keys.F5:
                        CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                        f_duyetthuchien();
                        f_load();
                        btMoi.Select();
                        break;
                    case Keys.F3:
                        txtMaBN.Enabled = true;
                        lbThongBao.Text = "...";
                        init_form();
                        txtMaBN.Select();
                        break;
                }





            }
            catch { }
        }
    }
}