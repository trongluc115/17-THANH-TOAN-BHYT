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
    public partial class frmDuyetCDHA : Form
    {
        CBenhNhan BN;
        CThanhToanBHYT BHYT;
        double _khambenh=0;
        private List<string> Listthuock;
        public frmDuyetCDHA()
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
            f_init_addmodul();
            

           
            DateTime ngayvao = DateTime.ParseExact(haison1.tungay, "dd/MM/yyyy", null);
            DateTime ngayra = DateTime.ParseExact(haison1.denngay, "dd/MM/yyyy", null);
           
            dngayvao.Value = ngayvao;
            dngayra.Value = ngayra;
           
            f_load_after();
            f_load_before();
            f_loadTongCong();
            
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

                CThanhToanBHYTOracleNoiTru DataOracle = new CThanhToanBHYTOracleNoiTru();
                DataSet dsdotdt = DataOracle.f_loadNgayNhapVien_MaQL(txtMaBN.Text, haison1.tungay, haison1.denngay, ckLocNgay.Checked);
                cbdotdieutri.DataSource = null;
                cbdotdieutri.DataSource = dsdotdt.Tables[0];
                cbdotdieutri.DisplayMember = "dotdieutri";
                cbdotdieutri.ValueMember = "mavaovien";
                cbdotdieutri.SelectedIndex = 0;

          
                        


              
                //btLuu.Select();
                txtMaBN.Enabled = false;
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
        
        private void f_loadTongCong()
        {
            try
            {
                double TongCP=0;
              
                foreach (DataGridViewRow item in dview.Rows)
                {
                       DataGridViewCell oCell = item.Cells["check"];
                        bool check = Convert.ToBoolean(oCell.Value);
                        if (check == true && item.Visible == true)
                        {
                            TongCP += long.Parse(item.Cells["TONGTIEN"].Value.ToString());
                        }
                    
                }
              
              
               
           
            }
            catch { }
          //  CanhBao();

        }

        private void frmDuyetBHYT_Load(object sender, EventArgs e)
        {
            BN = new CBenhNhan();
            BHYT = new CThanhToanBHYT();
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            _khambenh = OraDanhmuc.f_getgiaVP("30228");
            lbkhu.Text = AccessData.s_tenkhuvuc;      
            //f_init_addmodul();
            Listthuock = new List<string>();
            d_dmbdbh_Orace ora_dmbd = new d_dmbdbh_Orace();
            Listthuock = ora_dmbd.getDanhSachThuocK();

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
        
        private void f_luuChiTiet(string id)
        {

            int stt = 0;
            string mavp = "";
            float dongia = 0;
            float soluong = 0;
            float thanhtien = 0;
            string GPNK = "";
            string BVAPTHAU = "";
            CThanhToanBHYTDAO data = new CThanhToanBHYTDAO();
            int roweffect = 0;
            try
            {
                foreach (DataGridViewRow row in dview.Rows)
                {
                    mavp = row.Cells["MaVP"].Value.ToString();
                    dongia = float.Parse(row.Cells["dongia"].Value.ToString());
                    soluong = float.Parse(row.Cells["SL"].Value.ToString());
                    int idnhombhyt = int.Parse(row.Cells["IDNHOMBHYT"].Value.ToString());
                    if (idnhombhyt == 7 || idnhombhyt == 1)
                    {
                        roweffect = data.InsertThuoc20(id, txtMaBN.Text, stt.ToString(), mavp, dongia.ToString(), soluong.ToString(), thanhtien.ToString(), GPNK, BVAPTHAU, "2",dngayra.Value);
                    }
                    else
                    {
                        roweffect = data.InsertCLS20(id, txtMaBN.Text, stt.ToString(), mavp, dongia.ToString(), soluong.ToString(), dngayra.Value);
                    }

                    
                    stt++;
                }
                //stt = 0;

                //foreach (DataGridViewRow row in dViewThuoc.Rows)
                //{
                //    mavp = row.Cells["MaVP"].Value.ToString();
                //    dongia = float.Parse(row.Cells["dongia"].Value.ToString());
                //    soluong = float.Parse(row.Cells["soluong"].Value.ToString());
                //    thanhtien = float.Parse(row.Cells["sotien"].Value.ToString());
                    
                //    if (roweffect == 0)
                //        MessageBox.Show("Thêm chi tiết không thành công!");
                //    stt++;
                //}
            }
            catch
            {
                MessageBox.Show("Thêm chi tiết không thành công!");
            }
        }
        private int f_MaNhomThe(string MaBV, int traituyen)
        {
            int nhomthe = 0;
            try
            {
                if (MaBV.CompareTo("79024") == 0)
                {
                    nhomthe = 1;    
                }
                else
                {
                    if (traituyen == 0)
                    {
                        nhomthe = 2;
                    }
                    else
                    {
                        nhomthe = 3;
                    }
                }
            }
            catch { }
            return nhomthe;
        }
        private string f_NhomThe(string MaNhomThe)
        {
            string s = "";
            switch (MaNhomThe)
            { 
                case "1":
                    s = "A. Bệnh Nhân Đăng Ký KCB Ban Đầu Tại Cơ Sở KCB.";
                    break;
                case "2":
                    s = "B. Bệnh Nhân Không Đăng Ký KCB Ban Đầu Tại Cơ Sở KCB. B1. Bệnh Nhân Nội Tỉnh (Thẻ Do BHXH TP.HCM Phát Hành )";
                    break;
                case "3":
                    s = "C. Bệnh Nhân Trái Tuyến Có Trình Thẻ. C1.Bệnh Nhân Ngoại Tỉnh.";
                    break;
            }
            return s;
        }

        private void btMoi_Click(object sender, EventArgs e)
        {
            txtMaBN.Enabled = true;
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
        
        

     
    

        
      
        private void f_load_before()
        {
            try
            {

                cdha_dvll_Oracle dataOracle = new cdha_dvll_Oracle();
                //IFormatProvider culture = new  CultureInfoConverter("en-US", true);
                //f_load_after();
               
                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;
                DataTable dtcp = dataOracle.f_getv_ttrvkp_ct_ALL3(txtMaBN.Text, "", ngayvao, ngayra, "").Tables[0];
                dview.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dview.Rows.Add(item.ItemArray);
                }





            }
            catch { }
        }
      
        
     
        private double f_tongcp()
        {
            double tongcpbh = 0;
            double bhyttra=0;
            double bntra=0;
            double thanhtien=0;
            double soluong = 0;
            double dongia = 0;
            foreach (DataGridViewRow item in dview.Rows)
            {

                soluong = double.Parse(item.Cells["SL"].Value.ToString());
                dongia = double.Parse(item.Cells["DONGIA"].Value.ToString());
                thanhtien = soluong * dongia;
                
                int doituong = int.Parse(item.Cells["MADOITUONG"].Value.ToString());
                switch (doituong)
                {
                    case 1:
                        {
                            tongcpbh += thanhtien;
                            
                            break;
                        }
                    
                    default:
                        {
                         break;
                        }
                }
                
            }
            return tongcpbh;
        }
        
        private void f_set_CBKhoaPhong(string makp)
        {
            try
            {
                for (int i = 0; i < cbDanhMucKP.Items.Count;i++ )
                {
                    cbDanhMucKP.SelectedIndex = i;
                    if (cbDanhMucKP.SelectedValue.ToString().CompareTo(makp) == 0)
                    {
                        break;
                    }
                }
            }
            catch { }
        
        }
        private double Double_Round(Double value)
        {
            return  Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }
        private void f_loadChiTiet()
        {
            try
            {
                double[] Value = new double[15];
                double tongchiphi = 0;
                for (int i = 0; i < 15; i++)
                {
                    Value[i] = 0;
                }
                foreach (DataGridViewRow row in dview.Rows)
                {
                    int madoituong=int.Parse(row.Cells["MADOITUONG"].Value.ToString());
                    if ( madoituong == 1)
                    {
                        int pos = int.Parse(row.Cells["IDNhomBHYT"].Value.ToString());
                        Value[pos] += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                    }
                    if(madoituong!=5)
                    {
                        tongchiphi += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                    }
                    
                }

                txtTongCP.Text = f_insertDot(Double_Round(tongchiphi).ToString());
              
                txtThuoc.Text = f_insertDot(Double_Round(Value[1]).ToString());
                txtMau.Text = f_insertDot(Double_Round(Value[2]).ToString());
                txtXetNghiem.Text = f_insertDot(Double_Round(Value[3]).ToString());
                txtCDHA.Text = f_insertDot(Double_Round(Value[4]).ToString());
               
                txtDVKTThuong.Text = f_insertDot(Double_Round(Value[5]).ToString());
                txtDVKTCao.Text = f_insertDot(Double_Round(Value[6]).ToString());
                
                txtVTYT.Text = f_insertDot(Double_Round(Value[7]).ToString());
                txtKhamBenh.Text = f_insertDot(Double_Round(Value[8]).ToString());
                txtGiuong.Text = f_insertDot(Double_Round(Value[9]).ToString());
                txtCPVC.Text = f_insertDot(Double_Round(Value[10]).ToString());
                txtKhac.Text = f_insertDot(Double_Round(Value[11]).ToString());
                txtThamDoCN.Text = f_insertDot(Double_Round(Value[12]).ToString());

            }
            catch { }

        }

        private void f_init_addmodul()
        {
            cdha_dvll_Oracle cdha_Ora=new cdha_dvll_Oracle();
            
            DateTime tungay=m_format.DateTime_parse(haison1.tungay);
            DateTime denngay=m_format.DateTime_parse(haison1.denngay);
            DataTable dtdm_dichvu = cdha_Ora.d_getCLS(tungay, denngay, txtMaBN.Text);
            tl_danhmuc.datasource = dtdm_dichvu;
            tl_danhmuc.set_labelname("Dịch vụ");
            

            //DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong();
            //cbDanhMucKP.DataSource = dtdm_khoaphong;
            //cbDanhMucKP.DisplayMember = "TEN";
            //cbDanhMucKP.ValueMember = "ID";
            //cbDanhMucKP.SelectedIndex = 0;
            //cbLoai.SelectedIndex = 0;
            //cbdoituong.DataSource = dataOracle.d_getDMDoiTuong();
            //cbdoituong.DisplayMember = "ten";
            //cbdoituong.ValueMember = "ma";
            //cbdoituong.SelectedIndex = 0;



        }

        
  
        
 

   
  

 



  
        private void ckLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            loadBHYT();
        }

        

    

        private void txtSL_Leave(object sender, EventArgs e)
        {
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            txtDonGia.Text = OraDanhmuc.f_getgiaVP(tl_danhmuc.get_id()).ToString();
        }
        private void CanhBao()
        {

            if (ckKhamBenh.Checked == true)
            {
                CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
                 
                double khambenh = double.Parse(f_clearDot(txtKhamBenh.Text));
                if(khambenh!=_khambenh)
                    MessageBox.Show("Vui lòng kiểm tra tiền khám!");
            }
        }

      

  

  
   
   
        private void save()
        {
            cdha_dvll_Oracle cdhadvl_O = new cdha_dvll_Oracle();
            
           // DataGridViewRow row = dview.SelectedRows[0];
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
                    vct.NGAYCHUP = dngaybc.Value;
                    vct.MABN = txtMaBN.Text;
                    vct.STT = stt;
                    vct.Cdhakhu = AccessData.s_makhuvuc;                


                    cdhadvl_O.f_insert(vct);
                    stt++;
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
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);

            DataTable dtcp = dvll_Ora.f_getCLS_DADUYET(tungay, denngay, txtMaBN.Text,"-1");
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
                    if (item.Cells["TENVP"].Value.ToString().ToLower().IndexOf(timkiem.ToLower(), 0) != -1 || timkiem.Length == 0)
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

        private void btDelete_Click(object sender, EventArgs e)
        {
            f_delete_after();
            f_load_before();
            f_load_after();
        }
        private void f_delete_after()
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check==true)
                { 
                    dvll_Oracle.f_delete(long.Parse(item.Cells["id_"].Value.ToString()));
                }
            }
         


        }

        private void chkAll1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dview.Rows)
            {
                item.Cells[0].Value = chkAll1.Checked;
                
            }
            f_loadTongCong();
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
           
            SendKeys.Send("{RIGHT}");
            SendKeys.Send("{LEFT}");
            
        }

        private void dview_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            f_loadTongCong();
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
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);
            string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
            DataTable dt = dvll.f_getBAOCAO_M02_TRAKQ_khu(tungay, denngay, AccessData.s_makhuvuc);
            frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            f_delete_after();
            f_load_after();
            f_load_before();
        }
    }
}