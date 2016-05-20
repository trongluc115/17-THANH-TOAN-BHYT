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
    public partial class frmDuyetCDHANT: Form
    {
        CBenhNhan BN;
        CThanhToanBHYT BHYT;
        double _khambenh=0;
        private List<string> Listthuock;
        private DateTime date_lock;
        public frmDuyetCDHANT()
        {
            InitializeComponent();
            
            
        }
        private void add_SoPhieu()
        { 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                    
            save();
             f_load_before();
             f_load_after();
              btMoi.Select();
            
            
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
    
                f_setcbPhai(0);
                dview.Rows.Clear();
              
            }
            catch { }
        }
        private void txtMaBN_Leave(object sender, EventArgs e)
        {
            loadBHYT();            
            f_load_after();
            f_load_before();
            
            
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
            lbkhu.Text = AccessData.s_tenkhuvuc;
            panel1.Visible = false;
            panel2.Visible = false;
            
            d_dmbdbh_Orace ora_dmbd = new d_dmbdbh_Orace();
            
            init();

        }
        private void init()
        {
            try
            {
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

        

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void f_load_before()
        {
            try
            {

                cdha_dvll_Oracle dataOracle = new cdha_dvll_Oracle();
                //IFormatProvider culture = new  CultureInfoConverter("en-US", true);
                f_load_after();
                string mavaovien = "";
                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;
                string s_loaicdha = cbCDHA_loai.SelectedValue.ToString();
                DataTable dtcp = dataOracle.f_get_cdha_bv(txtMaBN.Text, "", ngayvao, ngayra, "1",s_loaicdha).Tables[0];
                dview.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dview.Rows.Add(item.ItemArray);
                }



            }
            catch { }
        }
        
        
        
        private void save()
        {
            cdha_dvll_Oracle cdhadvl_O = new cdha_dvll_Oracle();
            

            int stt=0;
            foreach (DataGridViewRow item in dview.Rows)
            {
                DataGridViewCell oCell = item.Cells["check"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check==true && item.Visible==true)
                {
                    cdha_dvll vct = new cdha_dvll();
                    vct.ID = long.Parse(item.Cells["ID"].Value.ToString());
                    
                    
                    vct.MAKP = item.Cells["MAKP"].Value.ToString();
                    vct.SOHD = item.Cells["SoHDDV"].Value.ToString();
                    vct.SOBL = item.Cells["SoBL"].Value.ToString();
                    vct.MADOITUONG = item.Cells["MADOITUONG"].Value.ToString();
                    vct.MAVP = item.Cells["MAVP"].Value.ToString();
                    vct.SOLUONG = float.Parse(item.Cells["SL"].Value.ToString());
                    vct.DONGIA = float.Parse(item.Cells["DONGIA"].Value.ToString());
                    vct.NGAYCD = DateTime.ParseExact(item.Cells["NGAY"].Value.ToString(), "dd/MM/yyyy", null);
                    vct.MABSCD = item.Cells["MaBS"].Value.ToString();
                    DateTime temp = dngaybc.Value;
                    DateTime value = m_format.DateTime_parse_HHmm(String.Format("{0:dd/MM/yyyy} {1:HH:mm}", temp, DateTime.Now));
                    vct.NGAYCHUP = value;
                    vct.MABN = item.Cells["Mabn"].Value.ToString();
                    vct.STT = stt;
                    vct.Noithuchien = cbarea.SelectedValue.ToString();
                    vct.Cdhakhu = AccessData.s_makhuvuc;                


                    cdhadvl_O.f_insert_bv(vct);
                    stt++;
                    string s_mavp = item.Cells["mavp"].Value.ToString();
                    string s_tenvp = item.Cells["tenvp"].Value.ToString();
                    string s_id = vct.ID.ToString();
                    frmnhapvattu frm = new frmnhapvattu("", s_tenvp, s_id, s_mavp, "1");
                    frm.Show();

                    cdha_hen_Oracle henOracle = new cdha_hen_Oracle();
                    henOracle.f_update_dathuchien("1", s_id);
                    
                }
               
            }
            
        }

        private void bnLuuTN_Click(object sender, EventArgs e)
        {
            save();
        }

        
        private void f_load_after()
        {
            cdha_dvll_Oracle dvll_Ora = new cdha_dvll_Oracle();
            DateTime tungay = dngayvao.Value;
            DateTime denngay = dngayra.Value;

            DataTable dtcp = dvll_Ora.f_get_after_CDHAnoitru(tungay, denngay, txtMaBN.Text,"-1",cbarea.SelectedValue.ToString());
            ddsdaduyet.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                ddsdaduyet.Rows.Add(item.ItemArray);
            }
            format_grid();
        }
        private void f_TimKiem(string timkiem)
        {

            try
            {
               
                foreach (DataGridViewRow item in dview.Rows)
                    
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
        private void f_TimKiemTen(string timkiem)
        {

            try
            {

                foreach (DataGridViewRow item in dview.Rows)
                {
                    if (item.Cells["HOTEN"].Value.ToString().ToLower().IndexOf(timkiem.ToLower(), 0) != -1 || timkiem.Length == 0)
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

    

        private void btDelete_Click(object sender, EventArgs e)
        {
            f_suadaduyet();
        }
        private void f_suadaduyet()
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            
            
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check==true)
                {
                    DateTime ngayth =m_format.DateTime_parse(item.Cells["ngayth2"].Value.ToString());
                    if (f_kiemtra_locked(ngayth))
                    {
                        string s_id = item.Cells["id_"].Value.ToString();
                        dvll_Oracle.f_delete(long.Parse(s_id));
                        cdha_hen_Oracle henOracle = new cdha_hen_Oracle();
                        henOracle.f_update_dathuchien("0", s_id);
                    }
                }
            }
           

        }

        private void chkAll1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dview.Rows)
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

        private void dview_Click(object sender, EventArgs e)
        {
          //  dview.EndEdit();
        }
        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dview.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                }
                else
                {
                    chk.Value = chk.FalseValue;
                }

            }
            
        }

        private void dview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dview_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            f_TimKiemTen(txtSearch.Text);
        }

        private void ddsdaduyet_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btTraKQ_Click(object sender, EventArgs e)
        {
            save_trakq();
        }
        private void format_grid()
        {
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["TRAKQ"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    item.DefaultCellStyle.ForeColor = Color.Red;

                }
                else
                {
                    item.DefaultCellStyle.ForeColor = Color.Black;

                }

            }
        }
        private void save_trakq()
        {

            cdha_dvll_Oracle cdhadvl_O = new cdha_dvll_Oracle();

            // DataGridViewRow row = dview.SelectedRows[0];
            int stt = 0;
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["TRAKQ"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    cdha_dvll vct = new cdha_dvll();
                    vct.ID = long.Parse(item.Cells["id_"].Value.ToString());
                    vct.TRAKQ = "1";
                    cdhadvl_O.f_update_trakq(vct);
                    
                }
                else
                {
                    cdha_dvll vct = new cdha_dvll();
                    vct.ID = long.Parse(item.Cells["id_"].Value.ToString());
                    vct.TRAKQ = "0";
                    cdhadvl_O.f_update_trakq(vct);
                
                }

            }
            f_load_before();
        }

        private void btInTraKQ_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            string reportname = "rpt_baocaoCDHA_DV_M03.rpt";
            cdha_dvll_Oracle dvll = new cdha_dvll_Oracle();
            DateTime tungay = dngayvao.Value;

            DateTime denngay = dngayra.Value;
            string title = "BÁO CÁO ";
            DataTable dt = dvll.f_getBAOCAO_M02_TRAKQ_khu(tungay, denngay, AccessData.s_makhuvuc);
            frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {


        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (f_kiemtra_locked(dngaybc.Value.Date))
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel10.Enabled = false;
                xml_write();
            }
        }
        

        private void btnNhapVT_Click(object sender, EventArgs e)
        {
            cdha_dvll_Oracle cdhadvl_O = new cdha_dvll_Oracle();

            
            int stt = 0;
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["CHON_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    cdha_dvll vct = new cdha_dvll();
                    string s_id = item.Cells["id_"].Value.ToString();
                   
                    string s_mavp = item.Cells["mavp_"].Value.ToString();
                    string s_tenvp = item.Cells["tenvp_"].Value.ToString();
                    frmnhapvattu frm = new frmnhapvattu("", s_tenvp, s_id, s_mavp, "0");
                    frm.Show();
                    return;
                }
                

            }
            f_load_before();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            f_suadaduyet();

            f_load_before();
            f_load_after();
        }
        private void xml_write()
        {
            try
            {
                CXml xml_file = new CXml();
                xml_file.WriteXML("ROOM", cbarea.SelectedValue.ToString(), "ConfigCDHA.xml");
                xml_file.WriteXML("TECH", cbCDHA_loai.SelectedValue.ToString(), "ConfigCDHA.xml");

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

        private void ddsdaduyet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow item = new DataGridViewRow();
            item = ddsdaduyet.CurrentRow; 
            DateTime ngayth =m_format.DateTime_parse(item.Cells["ngayth2"].Value.ToString());
             if (f_kiemtra_locked(ngayth))
             {
              
                 string s_id = item.Cells["id_"].Value.ToString();
                 string s_mavp = item.Cells["mavp_"].Value.ToString();
                 string s_tenvp = item.Cells["tenvp_"].Value.ToString();
                 frmnhapvattu frm = new frmnhapvattu("", s_tenvp, s_id, s_mavp, "0");
                 frm.Show();
             }
            
        }
        private void f_TimKiemTen_ddsdaduyet(string timkiem)
        {

            try
            {

                foreach (DataGridViewRow item in ddsdaduyet.Rows)
                {
                    if (item.Cells["HOTEN_"].Value.ToString().ToLower().IndexOf(timkiem.ToLower(), 0) != -1 || timkiem.Length == 0)
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

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            f_TimKiemTen_ddsdaduyet(txtSearch2.Text);
        }
        private bool f_kiemtra_locked(DateTime ngay)
        {
            bool result = true;
            if (ngay <= date_lock)
            {
                result = false;
                MessageBox.Show("Đã khóa số liệu đến ngày: "+string.Format("{0:dd/MM/yyyy}",date_lock));
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

                        save();
                        f_load_before();
                        f_load_after();
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
        private void f_ingiayhen()
        {
           
                  
                    DataTable mydt = new DataTable();
                    DataRow mydr;
                    mydt.Columns.Add(new DataColumn("MABN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("HOTEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NAMSINH", typeof(string)));
                    mydt.Columns.Add(new DataColumn("TENVP", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NGAY_HEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("GIO_HEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NOITHUCHIEN", typeof(string)));
                    mydr = mydt.NewRow();
                    mydr[0] = txtMaBN.Text;
                    mydr[1] = txtHoTen.Text;
                    mydr[2] = txtNamSinh.Text;
                    mydr[3] = "-";
                    mydr[4] = "-";
                    mydr[5] = "-";
                    mydr[6] = cbarea.Text;
                    mydt.Rows.Add(mydr);
                    AccessData d = new AccessData();
                    string s_reportname = "nhanphim.rpt";
                    string s_title = "";
                    frmReport a = new frmReport(d, mydt, s_reportname, s_title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
                    a.Show();
              

            
        }

        private void btPrintPH_Click(object sender, EventArgs e)
        {
            f_ingiayhen();
        }


    }
}