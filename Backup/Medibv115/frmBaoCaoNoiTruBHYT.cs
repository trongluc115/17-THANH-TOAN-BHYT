using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;
using LibBaocao;
using Data;
using Entity;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using Excel;

namespace MediIT115
{
    public partial class frmBaoCaoNoiTruBHYT: Form
    {
        DataSet _ds;
        DataSet _dsChuaDuyet;
        
        SortedList _listrow = null;

        CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
        AccessData d = new AccessData();
       string stypereport = "";
        string s_tenreport = "123";
        string s_tieuDeExcel = "123";
        string s_tenBaoCao = "123";
       
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        Excel.Range orange;
        System.Data.DataTable dtChungC79_80_a_HD;
        decimal t_deNghiThanhToan = 0;
        string _loaibn = "1";// 0 noitru,1 ngoaitru
      
        public frmBaoCaoNoiTruBHYT()
        {
            DSMauC79_80a_HD();
            InitializeComponent();
        }
        public frmBaoCaoNoiTruBHYT(string loaibn)
        {
            DSMauC79_80a_HD();
            _loaibn = loaibn;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            
           
            DataSet ds = data.f_loadBCMau79_80_DK(tungay,denngay,"0",ckCanNgheo.Checked,"","",stypereport);
            string reportname = "rptDuyetbhytmau79_2015"+"_"+_loaibn;
            if (ckCanNgheo.Checked)
                reportname += "_CN";
            if (ckTongHop.Checked)
                reportname += "_TH";
            reportname += ".rpt";
            
            frmReport a = new frmReport(d, ds.Tables[0], reportname,cbLoaiBC.Text +  " " + haison1.s_title, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void btLload_Click(object sender, EventArgs e)
        {

           f_LoadDSDaDuyet();
            addGrid();
        }
        private void f_LoadDSDaDuyet()
        {
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();


            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            string dieukien = " and b.loaibn= "+_loaibn + " and (a.mabn like '%"+txtTimkiem.Text+"%'  ";
            dieukien += " or b.sophieu ='" + txtTimkiem.Text + "' or a.sothe like '%" + txtTimkiem.Text + "%')   ";
            if (ckLocUser.Checked == true)
                dieukien += " and  a.USERID=" + AccessData.m_userid  ;
            
            _ds = data.f_loadDanhSachDaDuyet(tungay, denngay,dieukien);
            
          
            lbSoLuong.Text = DSDaDuyet.Rows.Count.ToString();
          
        }
        private void f_locdanhsachdaduyet(string value)
        {
            try
            {
                DataView dv = new DataView(_ds.Tables[0]);
                string sfilter = (txtSoNgay.Text.Length > 0 ? " songay=" + txtSoNgay.Text : "");
                
                dv.RowFilter = sfilter;
                //dv.RowFilter = " SOPHIEU like '%" + value + "%'";
                DSDaDuyet.DataSource = dv;
                lbSoLuong.Text = DSDaDuyet.Rows.Count.ToString();
            }
            catch { }
        }
        private void f_locdanhsachchuaduyet(string value)
        {
            try
            {
                DataView dv = new DataView(_dsChuaDuyet.Tables[0]);
                dv.RowFilter = "MaBN like '%" + value + "%'";
                dsChuaDuyet.DataSource = dv;
                lbSoLuongChuaDuyet.Text = dsChuaDuyet.Rows.Count.ToString();
            }
            catch { }
        }

        private void dsChuaDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = DSDaDuyet.SelectedRows[0];
                string MaBN=row.Cells["MaBN"].Value.ToString();
                string Hoten=row.Cells["HoTen"].Value.ToString();
              
                //int phai=int.Parse(row.Cells["GIOITINH"].Value.ToString());
                string MaBHYT=row.Cells["SOTHEBHYT"].Value.ToString();
                string MaBV=row.Cells["MaBV"].Value.ToString();
                string TenBV=row.Cells["TenBV"].Value.ToString();
                int TraiTuyen=int.Parse(row.Cells["TraiTuyen"].Value.ToString());
                string IDDuyet=row.Cells["ID"].Value.ToString();
                string SoPhieu = row.Cells["SOTOA"].Value.ToString();
                DateTime tungay=m_format.DateTime_parse(row.Cells["TUNGAY"].Value.ToString());
                DateTime denngay = m_format.DateTime_parse(row.Cells["DENNGAY"].Value.ToString());


                setThongTin(MaBN, Hoten,  MaBHYT, MaBV, TenBV, TraiTuyen, IDDuyet,"","",SoPhieu,tungay,denngay);
            }
            catch { }
        }

        private void DSDaDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = DSDaDuyet.SelectedRows[0];
                string MaBN = row.Cells["MaBN"].Value.ToString();
                string Hoten = row.Cells["HoTen"].Value.ToString();
                string MaKP = row.Cells["MaKP"].Value.ToString();

                f_set_CBKhoaPhong(MaKP);
                string MaBHYT = row.Cells["SOTHEBHYT"].Value.ToString();
                string MaBV = "";
                string MaICD = row.Cells["ICD10"].Value.ToString();
                string ChanDoan = row.Cells["ChanDoan"].Value.ToString();
                
                int TraiTuyen = int.Parse(row.Cells["TraiTuyen"].Value.ToString());
                string IDDuyet = row.Cells["ID"].Value.ToString();
                string SoPhieu = row.Cells["SOPHIEU"].Value.ToString();
                string UBNDTra = row.Cells["UBNDTRA"].Value.ToString();
                DateTime tungay = m_format.DateTime_parse(row.Cells["TUNGAY"].Value.ToString());
                DateTime denngay = m_format.DateTime_parse(row.Cells["DENNGAY"].Value.ToString());
                DateTime ngayvao = m_format.DateTime_parse(row.Cells["NGAYVAO"].Value.ToString());
                DateTime ngayra = m_format.DateTime_parse(row.Cells["NGAYRA"].Value.ToString());

                dngayvao2.Value = ngayvao;
                dngayra2.Value = ngayra;
                txtUBNDTra.Text = UBNDTra;

                
                setThongTin(MaBN, Hoten,  MaBHYT, MaBV, "-", TraiTuyen, IDDuyet, MaICD, ChanDoan, SoPhieu, tungay, denngay);
            }
            catch { }

        }
        private void setThongTin(string MaBN,string Hoten,string MaBHYT,string MaBV,string TenBV,int TraiTuyen,string IDDuyet,string MaICD,string ChanDoan,string sophieu,DateTime tungay,DateTime denngay)
        {
            txtMaBN.Text = MaBN;
            txtHoTen.Text = Hoten;
           
            

            txtMaBHYT.Text =MaBHYT;
          
            txtTenBV.Text = TenBV;
            txtIDDuyet.Text = IDDuyet;
            txtMaICD.Text = MaICD;
            txtChanDoan.Text = ChanDoan;
            txtSoPhieu.Text = sophieu;
            dtungay.Value = tungay;
            ddenngay.Value = denngay;
            f_setTraiTuyen(TraiTuyen);
        }
        private void f_setcbPhai(int value)
        {
            try
            {
                cbPhai.SelectedIndex = value;
            }
            catch { cbPhai.SelectedIndex = 0; }
        }
        private void f_setTraiTuyen(int value)
        {
            try
            {
                cbTuyen.SelectedIndex = value;
            }
            catch { cbTuyen.SelectedIndex = 0; }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (AccessData.m_date_lock < m_format.DateTime_parse(haison1.tungay))
            {

                string idduyet = txtIDDuyet.Text;
                v_bhytct_Oracle v_bhytctOra = new v_bhytct_Oracle();
                v_bhytll_Oracle v_bhytllOra = new v_bhytll_Oracle();
                v_bhytds_Oracle v_bhytdsOra = new v_bhytds_Oracle();
                v_bhytctOra.f_delete(long.Parse(idduyet));
                v_bhytllOra.f_delete(long.Parse(idduyet));
                CThanhToanBHYT thanhtoan = new CThanhToanBHYT();
                thanhtoan.MaBN = txtMaBN.Text;
                thanhtoan.SoTheBHYT = txtMaBHYT.Text;
                thanhtoan.ID = long.Parse(idduyet);
                v_bhytdsOra.f_delete(thanhtoan);
                f_LoadDSDaDuyet();
                addGrid();
            }
            else
            {
                MessageBox.Show(string.Format("Số liệu đã khóa đến ngày {0:dd/MM/yyyy}! ", AccessData.m_date_lock));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //f_locdanhsachdaduyet(txtTimkiem.Text);
            f_LoadDSDaDuyet();
            addGrid();
        }

        private void frmBaoCaoNgoaiTruBHYT_Load(object sender, EventArgs e)
        {
            
            _ds = new DataSet();
            _dsChuaDuyet = new DataSet();
            init_cbloaibc();
            init_cbKhoaPhong();

            if(AccessData.m_userid!="1794")
            {
                Pcauhinh.Visible=false;
            }
        }
        #region cbkhoaphong
        private void init_cbKhoaPhong()
        {
            CDanhMucOracle dataOracle = new CDanhMucOracle();
            System.Data.DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong();
            cbDanhMucKP.DataSource = dtdm_khoaphong;
            cbDanhMucKP.DisplayMember = "TEN";
            cbDanhMucKP.ValueMember = "ID";
            cbDanhMucKP.SelectedIndex = 0;
            
        }
        private void f_set_CBKhoaPhong(string makp)
        {
            try
            {
                for (int i = 0; i < cbDanhMucKP.Items.Count; i++)
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
        #endregion
        private void btLoadDSChuaDuyet_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            CThanhToanBHYTOracle d = new CThanhToanBHYTOracle();
            CThanhToanBHYTDAO data = new CThanhToanBHYTDAO();
                       

           
            string smabndaduyet = "";
            _dsChuaDuyet = d.f_loadDanhSachCLSChuaDuyet(tungay, denngay, smabndaduyet);
            
            f_locdanhsachchuaduyet(txtTimKiemChuaDuyet.Text);
        }

        private void txtTimKiemChuaDuyet_TextChanged(object sender, EventArgs e)
        {
            f_locdanhsachchuaduyet(txtTimKiemChuaDuyet.Text);
        }

        private void haison1_Load(object sender, EventArgs e)
        {

        }

        private void cmdKiemTraTrung_Click(object sender, EventArgs e)
        {
            try
            {
              
                CThanhToanBHYTOracleNoiTru dataOra = new CThanhToanBHYTOracleNoiTru();

                string tungay = haison1.tungay;
                string denngay = haison1.denngay;
                System.Data.DataTable dt = dataOra.kiemtratrung_trongngay(_loaibn, m_format.DateTime_parse(tungay));
                dsChuaDuyet.DataSource = dt;
            }
            catch { }
        }
        private void print_BV()
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();

            //DataSet ds = data.f_loadBaoCaoMau20(tungay, denngay, "");

            //DataSet ds = data.f_getv_ttrvkp_ct_BV115(txtMaBN.Text, txtIDDuyet.Text);
            //frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_ct.rpt", "", "", "", "", "", "", "", "", "", "");
            //a.Show();

            DataSet ds = data.f_getv_ttrvkp_ct_BV115(txtMaBN.Text, txtIDDuyet.Text);
            frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_ct.rpt", "", "", "", "", "", "", "", "", "", "");
            a.Show();
        }
        private void print_BV01()
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();

            //DataSet ds = data.f_loadBaoCaoMau20(tungay, denngay, "");

            //DataSet ds = data.f_getv_ttrvkp_ct_BV115(txtMaBN.Text, txtIDDuyet.Text);
            //frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_ct.rpt", "", "", "", "", "", "", "", "", "", "");
            //a.Show();

            DataSet ds = data.f_getv_ttrvkp_ct_BV115(txtMaBN.Text, txtIDDuyet.Text);
            frmReport a = new frmReport(d, ds.Tables[0], "v_thanhtoanravienngtru_chitiet.rpt", "", "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            print_BV();
        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {

        }
        private void init_cbloaibc()
        {
            try {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                System.Data.DataTable dtdm_loaibc = dataOracle.d_getDM_BCDieuKien(_loaibn );
                cbLoaiBC.DataSource = dtdm_loaibc;
                cbLoaiBC.DisplayMember = "TEN";
                cbLoaiBC.ValueMember = "MA";
         
                cbLoaiBC.SelectedIndex = 0;
                
            }
            catch { }
        }

        private void cbLoaiBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                CDanhMucOracle oracle_danhmuc = new CDanhMucOracle();
                stypereport = oracle_danhmuc.d_getDM_BCDieuKien_FromID(cbLoaiBC.SelectedValue.ToString());
                s_tenreport = oracle_danhmuc.d_getDM_BCDieuKien_TenReport_FromID(cbLoaiBC.SelectedValue.ToString());
                s_tieuDeExcel = oracle_danhmuc.d_getDM_BCDieuKien_TieuDeExcel_FromID(cbLoaiBC.SelectedValue.ToString());
                s_tenBaoCao = oracle_danhmuc.d_getDM_BCDieuKien_TenBaoCao_FromID(cbLoaiBC.SelectedValue.ToString());
            }
            catch { }
            //MessageBox.Show(stypereport);

        }

        private void btprint01BV_Click(object sender, EventArgs e)
        {
            print_BV01();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                v_bhytds v_ds = new v_bhytds();
                v_bhytds_Oracle Ora_v_bhytds = new v_bhytds_Oracle();
                v_ds.ID = long.Parse(txtIDDuyet.Text);
                v_ds.MAICD = txtMaICD.Text;
                v_ds.CHANDOAN = txtChanDoan.Text;
                v_ds.TUNGAY = dtungay.Value;
                v_ds.DENNGAY = ddenngay.Value;
                v_ds.SOTHE = txtMaBHYT.Text;
                v_ds.MaKP = cbDanhMucKP.SelectedValue.ToString();
                v_ds.NGAYVAO = dngayvao2.Value;
                v_ds.NGAYRA = dngayra2.Value;
                double value = 0;
                Ora_v_bhytds.f_update(v_ds);
                v_bhytll v_ll = new v_bhytll();
                v_bhytll_Oracle Ora_v_bhytll = new v_bhytll_Oracle();
                v_ll.SOPHIEU = txtSoPhieu.Text;
                v_ll.ID = v_ds.ID;
                v_ll.UBNDTRA =(double.TryParse(txtUBNDTra.Text,out value)==true? double.Parse(txtUBNDTra.Text):0);
                Ora_v_bhytll.f_update(v_ll);
                f_LoadDSDaDuyet();
                addGrid();
            }
            catch { }

        }

     /*   private void btExcel_Click(object sender, EventArgs e)
        {
            //CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();


            //string tungay = haison1.tungay;
            //string denngay = haison1.denngay;
            //_ds = data.f_Export_Excel(tungay, denngay, stypereport);
            //f_locdanhsachdaduyet(txtTimkiem.Text);


            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;


            DataSet ds = data.f_Export_Excel(tungay, denngay, stypereport);
            Export ex = new Export();
            //ex.ExportToExcel(ds);
            txtsqlExport.Text = AccessData.Export_SQL;
            string reportname = "xuat_excel.rpt";

          
          
           // frmReport a = new frmReport(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
           // a.Show();
        }*/
      
        private void button1_Click_2(object sender, EventArgs e)
        {
            
            m_option M_OPT=new m_option();
            int nrow=M_OPT.f_update_dinhsuat(m_format.DateTime_parse(haison1.tungay),m_format.DateTime_parse(haison1.denngay),_loaibn);
            MessageBox.Show(nrow.ToString() + " rows effect");
        }

        private void btThuocK_Click(object sender, EventArgs e)
        {
            m_option M_OPT = new m_option();
            string[] s_macp ={ "31", "32", "20" };
            string[] s_name ={ "THAMPHAN", "THUOCK", "CHAYTHAN" };
            string result = "";
            int row = 0;

            row=M_OPT.f_update_Keythuock0(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            result += "RESET: " + row+"\n";
            for (int i = 0; i < 3;i++ )
            {
                row = M_OPT.f_update_Keythuock1(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay), s_macp[i]);//THAM PHAN
                result += s_name[i]+" = " + row + "\n";
                M_OPT.f_update_CHIPHI_NGOAI(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay),s_macp[i]);
            }
            MessageBox.Show(result.ToString() + " rows effect");
        }

        private void btUBNDtra_Click(object sender, EventArgs e)
        {
            m_option M_OPT = new m_option();
            System.Data.DataTable dt = M_OPT.f_get_UBNDtra(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            //int nrow = M_OPT.f_update_UBNDtra(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            //MessageBox.Show(nrow.ToString() + " rows effect");
            dCauHinh.DataSource = dt;
        }

        private void btCheckSum_Click(object sender, EventArgs e)
        {
            m_option M_OPT = new m_option();
            dCauHinh.DataSource= M_OPT.f_get_KiemtraTong(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            //MessageBox.Show(nrow.ToString() + " rows effect");
        }

        private void btUpdateTong_Click(object sender, EventArgs e)
        {
            m_option M_OPT = new m_option();
           int nrow = M_OPT.f_update_UBNDtra(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            MessageBox.Show(nrow.ToString() + " rows effect");
        }

        private void btgetExcel_Click(object sender, EventArgs e)
        {
            m_option M_OPT = new m_option();
            dCauHinh.DataSource = M_OPT.f_get_XuatExcel(txtsqlExport.Text);
        }

        #region Xuat Excel
        private void btExcel_Click(object sender, EventArgs e)
        {
            
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_Excel2(tungay, denngay, stypereport);
            dCauHinh.DataSource = ds.Tables[0];
            
            SapXepData(ds);
            exp_excel(dtChungC79_80_a_HD);
            //end Thanh Thúy thêm xuất excel 15.04.2015
        }
        private void btExcel_UBNDTRA_Click(object sender, EventArgs e)
        {

            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_Excel2(tungay, denngay, stypereport);
            dCauHinh.DataSource = ds.Tables[0];
            //Thanh Thúy locked 15.04.2015
            //string reportname = "rptDuyetbhytmau79";
            //if (ckCanNgheo.Checked)
            //    reportname += "_CN";
            //if (ckTongHop.Checked)
            //    reportname += "_TH";
            //reportname += ".rpt";

            //frmReport a = new frmReport(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            //a.Show();
            //end Thanh Thúy locked 15.04.2015
            //Thanh Thúy thêm xuất excel 15.04.2015              
            SapXepData(ds);
            exp_excel(dtChungC79_80_a_HD);
            //end Thanh Thúy thêm xuất excel 15.04.2015
        }
        public void DSMauC79_80a_HD()//cấu trúc chung mẫu c80a-HD; c79a-HD
        {
            dtChungC79_80_a_HD = new System.Data.DataTable();
            dtChungC79_80_a_HD.Columns.Add("stt", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("hoten", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("namsinhnam", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("namsinhnu", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("mathebhyt", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("madkbd", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("mabenh", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("ngayvao", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("ngayra", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("songay", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("tongcong", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("xetnghiem", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("cdha", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("thuoc", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("mau", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("ttpt", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("vtyt", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("dvkt", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("thuock", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("vtyttt", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("tienkham", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("vanchuyen", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("bntra", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("bhyttra", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("ngoaidinhsuat", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("lydo", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("benhkhac", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("noikcb", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("khoa", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("namquyettoan", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("thangquyettoan", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("giatritu", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("giatriden", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("diachi", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("mabn", typeof(string));
            dtChungC79_80_a_HD.AcceptChanges();
        }

            private void SapXepData(DataSet ds )
        {
            try
            {
                t_deNghiThanhToan = 0;
                System.Data.DataSet dts_ = ds;
                //  dsChungC79_80_a_HD.Tables.Clear();
                // System.Data.DataSet dssx = ds;
                string s_stt = "";
                string m_mabv = "", s = "", s_sothe = "";
                // m_mabv = d.MABV_BHYT.ToString();
                string[] arr;
                DataRow r1, r2;
                int i_stt = 1;
                dtChungC79_80_a_HD.Clear();
                int manhomthe = 0;
                foreach (DataRow r in dts_.Tables[0].Select("", "manhomthe,mathe"))
                {
                    r1 = d.getrowbyid(dtChungC79_80_a_HD, "MANHOMTHE");
                    if (r1 == null)
                    {
                        r2 = dtChungC79_80_a_HD.NewRow();
                        if (r["manhomthe"].ToString() == "1") r2["stt"] = "A";
                        if (r["manhomthe"].ToString() == "2") r2["stt"] = "B";
                        if (r["manhomthe"].ToString() == "3") r2["stt"] = "C";
                        r2["hoten"] = r["nhomthe"];
                        if (r["manhomthe"].ToString().Equals(manhomthe.ToString())==false)
                        {
                            dtChungC79_80_a_HD.Rows.Add(r2);
                            
                            manhomthe++;
                        }
                        r2 = dtChungC79_80_a_HD.NewRow();
                        r2["stt"] = i_stt;
                        i_stt++;
                        r2["hoten"] = r["hoten"];
                        if (r["gioitinh"].ToString() == "1")
                        {
                            r2["namsinhnam"] = r["namsinh"];
                        }
                        else
                        {
                            r2["namsinhnu"] = r["namsinh"];
                        }
                        r2["mathebhyt"] = r["mathe"];
                        r2["madkbd"] = r["ma_dkbd"];
                        r2["mabenh"] = r["mabenh"];
                        r2["ngayvao"] = r["ngayvao"];
                        r2["ngayra"] = r["ngayra"];
                        r2["songay"] = r["songay"];
                        r2["tongcong"] = r["t_tongchi"];
                        r2["xetnghiem"] = r["t_xn"];
                        r2["cdha"] = r["t_cdha"];
                        r2["thuoc"] = r["t_thuoc"];

                        r2["mau"] = r["t_mau"];
                        r2["ttpt"] = r["t_pttt"];
                        r2["vtyt"] = r["t_vtyttth"];

                        r2["dvkt"] = r["t_dvktc"];
                        r2["thuock"] = r["t_ktg"];
                        r2["vtyttt"] = r["t_vtyttt"];
                        r2["tienkham"] = r["t_kham"];
                        r2["vanchuyen"] = r["t_vchuyen"];
                        r2["bntra"] = r["t_bntra"];
                        r2["bhyttra"] = r["t_bhtra"];
                        t_deNghiThanhToan += decimal.Parse(r["t_bhtra"].ToString());
                        r2["ngoaidinhsuat"] = r["t_ngoaids"];
                        if (r["lydo_vv"].ToString() == "0")
                            r2["lydo"] = "Đúng tuyến";
                        if (r["lydo_vv"].ToString() == "1")
                            r2["lydo"] = "Trái tuyến";
                        if (r["lydo_vv"].ToString() == "2")
                            r2["lydo"] = "Cấp cứu";
                        r2["benhkhac"] = r["benhkhac"];
                        r2["noikcb"] = r["noikcb"];
                        r2["khoa"] = r["khoa"];
                        r2["namquyettoan"] = r["nam_qt"];
                        r2["thangquyettoan"] = r["thang_qt"];
                        r2["giatritu"] = r["gt_tu"];
                        r2["giatriden"] = r["gt_den"];
                        r2["diachi"] = r["diachi"];
                        r2["mabn"] = r["mabn"];
                        dtChungC79_80_a_HD.Rows.Add(r2);
                    }
                    else
                    {
                        r2 = dtChungC79_80_a_HD.NewRow();
                        r2["stt"] = i_stt++;
                        r2["hoten"] = r["hoten"];
                        if (r["gioitinh"].ToString() == "1")
                        {
                            r2["namsinhnam"] = r["namsinh"];
                        }
                        else
                        {
                            r2["namsinhnu"] = r["namsinh"];
                        }
                        r2["mathebhyt"] = r["mathe"];
                        r2["madkbd"] = r["ma_dkbd"];
                        r2["mabenh"] = r["mabenh"];
                        r2["ngayvao"] = r["ngayvao"];
                        r2["ngayra"] = r["ngayra"];
                        r2["songay"] = r["songay"];
                        r2["tongcong"] = r["t_tongchi"];
                        r2["xetnghiem"] = r["t_xn"];
                        r2["cdha"] = r["t_cdha"];
                        r2["thuoc"] = r["t_thuoc"];

                        r2["mau"] = r["t_mau"];
                        r2["ttpt"] = r["t_pttt"];
                        r2["vtyt"] = r["t_vtyttth"];

                        r2["dvkt"] = r["t_dvktc"];
                        r2["thuock"] = r["t_ktg"];
                        r2["vtyttt"] = r["t_vtyttt"];
                        r2["tienkham"] = r["t_kham"];
                        r2["vanchuyen"] = r["t_vchuyen"];
                        r2["bntra"] = r["t_bntra"];
                        r2["bhyttra"] = r["t_bhtra"];
                        t_deNghiThanhToan += decimal.Parse(r["t_bhtra"].ToString());
                        r2["ngoaidinhsuat"] = r["t_ngoaids"];
                        if (r["lydo_vv"].ToString() == "0")
                            r2["lydo"] = "Đúng tuyến";
                        if (r["lydo_vv"].ToString() == "1")
                            r2["lydo"] = "Trái tuyến";
                        if (r["lydo_vv"].ToString() == "2")
                            r2["lydo"] = "Cấp cứu";
                        r2["benhkhac"] = r["benhkhac"];
                        r2["noikcb"] = r["noikcb"];
                        r2["khoa"] = r["khoa"];
                        r2["namquyettoan"] = r["nam_qt"];
                        r2["thangquyettoan"] = r["thang_qt"];
                        r2["giatritu"] = r["gt_tu"];
                        r2["giatriden"] = r["gt_den"];
                        r2["diachi"] = r["diachi"];
                        r2["mabn"] = r["mabn"];
                        dtChungC79_80_a_HD.Rows.Add(r2);
                    }
                }
                 dtChungC79_80_a_HD.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        
        private void exp_excel(System.Data.DataTable dts)
        {
            if (d.check_open_Excel() == true)
            {
                DialogResult dlg = MessageBox.Show("Bạn phải tắt các chương trình Excel đang chạy trước khi tổng hợp.\nBạn có muốn tự động tắt luôn không?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.Yes)
                    d.check_process_Excel();
                else return;
            }
            d.check_process_Excel();

            try
            {
                System.Data.DataTable dtxml = dts;
                int be = 9, i_cot = 35, dong = 10, sodong = dtxml.Rows.Count + 10, socot = dtxml.Columns.Count - 1, dongke = sodong + 2;
                string tenfile = d.Export_Excel(dtxml, s_tenreport);
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));//,Missing.Value,Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;

                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);//,Missing.Value);
                osheet.get_Range(d.getIndex(9) + dong.ToString(), d.getIndex(socot - 5) + dongke.ToString()).NumberFormat = "#,##0";
                osheet.get_Range(d.getIndex(0) + "7", d.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                //dong ten cot
                for (int i = 0; i < i_cot; i++) osheet.Cells[dong - 1, i + 1] = getTencot(i).ToString();
                orange = osheet.get_Range(d.getIndex(0) + "9", d.getIndex(i_cot - 1) + "9");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Bold = true;
                //end dong ten cot
                //dong stt
                for (int i = 0; i < i_cot; i++) osheet.Cells[dong, i + 1] = getSTT(i).ToString();
                orange = osheet.get_Range(d.getIndex(0) + "10", d.getIndex(i_cot - 1) + "10");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Bold = true;
                //end dong stt
                int so = sodong, j = 0;
                //Tinh tong               
                osheet.Cells[sodong + 1, 2] = "Tổng cộng A + B + C";
                for (int k = 11; k < socot - 5; k++)
                {
                    osheet.Cells[sodong + 1, k] = "=SUM(" + d.getIndex(k - 1) + "9:" + d.getIndex(k - 1) + (sodong).ToString() + ")";
                }
                orange = osheet.get_Range(d.getIndex(0) + (sodong + 1).ToString(), d.getIndex(socot) + (sodong + 1).ToString());
                orange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                orange.Font.Bold = true;

                //end dong tong 
                //tieu de
                osheet.Cells[1, 1] = "Tên cơ sở khám, chữa bệnh: BỆNH VIỆN NHÂN DÂN 115";
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(3) + "1");
                orange.MergeCells = true;

                osheet.Cells[2, 1] = "Mã số: 79024";
                orange = osheet.get_Range(d.getIndex(0) + "2", d.getIndex(3) + "2");
                orange.MergeCells = true;

                osheet.Cells[2, socot - 6] = s_tenBaoCao;

                osheet.Cells[3, 4] = s_tieuDeExcel;
                orange = osheet.get_Range(d.getIndex(3) + "3", d.getIndex(socot - 5) + "3");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 16;
                orange.Font.Bold = true;

                string s_title = haison1.s_title;
                osheet.Cells[4, 4] = s_title;
                orange = osheet.get_Range(d.getIndex(3) + "4", d.getIndex(socot - 5) + "4");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 10;
                orange.Font.Bold = true;

                osheet.Cells[5, 4] = "(Gửi cùng với file dữ liệu hàng tháng)";
                orange = osheet.get_Range(d.getIndex(3) + "5", d.getIndex(socot - 5) + "5");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                osheet.Cells[6, socot - 6] = "Đơn vị : đồng";
                //end tieu de
                //format cột              

                osheet.Cells[7, 3] = "Năm sinh";
                orange = osheet.get_Range(d.getIndex(2) + "7", d.getIndex(3) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[7, 12] = "TỔNG CHI PHÍ KHÁM, CHỮA BỆNH BHYT";
                orange = osheet.get_Range(d.getIndex(11) + "7", d.getIndex(21) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[7, 24] = "Đề nghị BHXH thanh toán ";
                orange = osheet.get_Range(d.getIndex(23) + "7", d.getIndex(24) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[8, 12] = "Không áp dụng tỷ lệ thanh toán";
                orange = osheet.get_Range(d.getIndex(11) + "8", d.getIndex(16) + "8");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[8, 18] = "Thanh toán theo tỷ lệ";
                orange = osheet.get_Range(d.getIndex(17) + "8", d.getIndex(19) + "8");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;
                //megre cot 
                for (int i = 0; i < i_cot; i++)
                {
                    if (i == 2 || i == 3 ||  i == 23  || i == 20 || i == 21 || i == 23 || i == 24)
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "8", d.getIndex(i) + "9");
                        orange.MergeCells = true;
                    }
                    else if (i > 10 && i < 20)
                    {

                    }
                    else
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "7", d.getIndex(i) + "9");
                        orange.MergeCells = true;
                    }
                }
                //end 
                //end format cột 

                //footer
                osheet.Cells[sodong + 2, 1] = "Số tiền đề nghị thanh toán (viết bằng chữ) " + m_format.So_chu(t_deNghiThanhToan);
                orange = osheet.get_Range(d.getIndex(0) + (sodong + 2), d.getIndex(socot - 1) + (sodong + 2));
                orange.MergeCells = true;

                osheet.Cells[sodong + 5, 2] = "Người lập biểu";
                orange = osheet.get_Range(d.getIndex(1) + (sodong + 5), d.getIndex(2) + (sodong + 5));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;

                osheet.Cells[sodong + 6, 2] = "(Ký, họ tên)";
                orange = osheet.get_Range(d.getIndex(1) + (sodong + 6), d.getIndex(2) + (sodong + 6));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Italic = true;

                osheet.Cells[sodong + 5, 7] = "Trưởng phòng KHTH";
                orange = osheet.get_Range(d.getIndex(6) + (sodong + 5), d.getIndex(8) + (sodong + 5));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;

                osheet.Cells[sodong + 6, 7] = "(Ký, họ tên)";
                orange = osheet.get_Range(d.getIndex(6) + (sodong + 6), d.getIndex(8) + (sodong + 6));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Italic = true;

                osheet.Cells[sodong + 5, 15] = "Kế toán trưởng";
                orange = osheet.get_Range(d.getIndex(14) + (sodong + 5), d.getIndex(15) + (sodong + 5));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;

                osheet.Cells[sodong + 6, 15] = "(Ký, họ tên)";
                orange = osheet.get_Range(d.getIndex(14) + (sodong + 6), d.getIndex(15) + (sodong + 6));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Italic = true;

                osheet.Cells[sodong + 4, 20] = "....., ngày.....tháng....năm....";
                orange = osheet.get_Range(d.getIndex(18) + (sodong + 4), d.getIndex(21) + (sodong + 4));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Italic = true;

                osheet.Cells[sodong + 5, 20] = "Thủ trưởng đơn vị";
                orange = osheet.get_Range(d.getIndex(19) + (sodong + 5), d.getIndex(20) + (sodong + 5));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;

                osheet.Cells[sodong + 6, 20] = "(Ký, họ tên, đóng dấu)";
                orange = osheet.get_Range(d.getIndex(19) + (sodong + 6), d.getIndex(20) + (sodong + 6));
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Italic = true;

                orange = osheet.get_Range(d.getIndex(0) + (sodong + 3), d.getIndex(socot - 1) + (sodong + 5));
                orange.Font.Bold = true;
                //format chung
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(socot) + sodong.ToString());
                orange.Font.Name = "Times New Roman";
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;

                orange = osheet.get_Range(d.getIndex(0) + "7", d.getIndex(socot) + sodong.ToString());
                orange.Font.Size = 8;

                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                //end 


                // orange = osheet.get_Range(d.getIndex(socot - 7) + "6", d.getIndex(socot - 7) + "6");

                // if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                // else 
                oxl.Visible = true;
                //end format chung
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getTencot(int i)
        {
            string[] map ={ "STT", "Họ và tên", "Nam", "Nữ", "Mã thẻ BHYT", "Mã ĐKBĐ", "Mã bệnh", "Ngày vào", "Ngày ra","Số ngày", "Tổng cộng", "Xét nghiệm", "CĐHA, TDCN", "Thuốc", "Máu", "TTPT", "VTYT", "DVKT", "Thuốc.", "VTYT.", "Tiền khám", "Vận chuyển", "Người bệnh chi trả", "Tổng cộng.", "Trong đó chi phí ngoài quỹ định suất", "Lý do", "Bệnh khác", "Nơi KCB", "Khoa", "Năm QT", "Tháng QT", "GT_Từ", "GT_Đến", "Địa chỉ","MaBN" };
            return map[i];
        }
        private string getSTT(int i)
        {
            string[] map ={ "A", "B", "C", "D", "E", "F", "G", "H", "I","K", "'(1)", "'(2)", "'(3)", "'(4)", "'(5)", "'(6)", "'(7)", "'(8)", "'(9)", "'(10)", "'(11)", "'(12)", "'(13)", "'(14)", "'(15)", "'(16)", "'(17)", "'(18)", "'(19)", "'(20)", "'(21)", "'(22)", "'(23)", "'(24)" ,"(25)"};
            return map[i];
        }
        #endregion

        private void BT_toexcel_ubnd_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_Excel_UBNDTRA(tungay, denngay, stypereport);
            dCauHinh.DataSource = ds.Tables[0];

            SapXepData(ds);
            exp_excel(dtChungC79_80_a_HD);

            //string reportname = "xuat_excel.rpt";
            //frmReportExcel a = new frmReportExcel(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            //a.Show();   
        
        }

        private void btExcelXHH_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_ExcelXHH(tungay, denngay,stypereport);
            dCauHinh.DataSource = ds.Tables[0];

            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();           
                
            //SapXepData(ds);
            //exp_excel(dtChungC79_80_a_HD);
            ////end Thanh Thúy thêm xuất excel 15.04.2015
        }

        private void btM7980_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_Excel_M79_80(tungay, denngay, stypereport);
            //dCauHinh.DataSource = ds.Tables[0];

            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();       
        }

        private void btkiemtra_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_ExcelKiemTra(tungay, denngay, stypereport);
            dCauHinh.DataSource = ds.Tables[0];

        }
        
        private void bt79SYT_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = data.f_Export_Excel_M79_80_SYT(tungay, denngay, stypereport);
            //dCauHinh.DataSource = ds.Tables[0];
            CXml m_xml = new CXml();
            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                col.ColumnName = col.ColumnName.ToLower();
            }
            m_xml.WriteXML(ds, "Table1_SYT.xml");
            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();    
        }

        private void btM21_SYT_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = new DataSet("SYT");
            System.Data.DataTable dt = new System.Data.DataTable("table3");
            v_giavpbh_Oracle vpdata = new v_giavpbh_Oracle();

             dt = vpdata.getListM21_SYT(m_format.DateTime_parse(tungay), m_format.DateTime_parse(denngay), stypereport);
            //dCauHinh.DataSource = ds.Tables[0];
             CXml m_xml = new CXml();
             System.Data.DataTable temp = new System.Data.DataTable();
             temp = dt.Copy();
             ds.Tables.Add(temp);
             foreach (DataColumn col in dt.Columns)
             {
                 col.ColumnName = col.ColumnName.ToLower();
             }
            m_xml.WriteXML(ds, "Table3_SYT.xml");
            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();    
        }

        private void btM20SYT_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;

            DataSet ds = new DataSet("SYT");
            System.Data.DataTable dt= new System.Data.DataTable("table2");
            d_dmbdbh_Orace vpdata = new d_dmbdbh_Orace();

            dt = vpdata.getListM20_SYT(m_format.DateTime_parse(tungay), m_format.DateTime_parse(denngay), stypereport);
            //dCauHinh.DataSource = ds.Tables[0];
            CXml m_xml = new CXml();
            System.Data.DataTable temp = new System.Data.DataTable();
            temp = dt.Copy();
            ds.Tables.Add(temp);
            foreach (DataColumn col in dt.Columns)
            {
                col.ColumnName = col.ColumnName.ToLower();
            }
            m_xml.WriteXML(ds, "Table2_SYT.xml");
            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();    

        }

        private void btkiemtra2_Click(object sender, EventArgs e)
        {
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            m_option M_OPT = new m_option();
            M_OPT.f_update_ICD();
            DataSet ds = data.f_Export_ExcelKiemTra2(tungay, denngay, stypereport);
            dCauHinh.DataSource = ds.Tables[0];
        }

        private void ckfilterDate_CheckedChanged(object sender, EventArgs e)
        {
            
            f_locdanhsachdaduyet("");
        }

        private void txtSoNgay_TextChanged(object sender, EventArgs e)
        {
            f_locdanhsachdaduyet("");
        }
        private void addGrid()
        {
            try
            {
                DataView dv = new DataView(_ds.Tables[0]);
                string sfilter = (txtSoNgay.Text.Length > 0 ? " songay=" + txtSoNgay.Text : "");
                
                dv.RowFilter = sfilter;
                //dv.RowFilter = " SOPHIEU like '%" + value + "%'";
                DSDaDuyet.DataSource = dv;
                lbSoLuong.Text = DSDaDuyet.Rows.Count.ToString();
                dGridView.Rows.Clear();
                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    string songay=dr["SONGAY"].ToString();
                    if (txtSoNgay.Text.Length == 0 || txtSoNgay.Text==songay )
                    {
                        //dieukien += (txtSoNgay.Text.Length > 0 ? " and songay=" + txtSoNgay.Text : "");
                        //_ds.Tables[0].DefaultView.RowFilter = " songay=" + txtSoNgay.Text;
                        dGridView.Rows.Add(dr.ItemArray);
                    }
                    
                }
            }
            catch { }
        }

        private void dGridView_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dGridView.SelectedRows[0];
                    
                string MaBN = row.Cells["MaBN"].Value.ToString();
                string Hoten = row.Cells["HoTen"].Value.ToString();
                string MaKP = row.Cells["MaKP"].Value.ToString();

                f_set_CBKhoaPhong(MaKP);
                string MaBHYT = row.Cells["SOTHE"].Value.ToString();
                string MaBV = "";
                string MaICD = row.Cells["ICD10"].Value.ToString();
                string ChanDoan = row.Cells["CHANDOAN"].Value.ToString();

                int TraiTuyen = int.Parse(row.Cells["TRAITUYEN"].Value.ToString());
                string IDDuyet = row.Cells["ID"].Value.ToString();
                string SoPhieu = row.Cells["SOPHIEU"].Value.ToString();
                string UBNDTra = row.Cells["UBNDTRA"].Value.ToString();
                DateTime tungay = m_format.DateTime_parse(row.Cells["TUNGAY"].Value.ToString());
                DateTime denngay = m_format.DateTime_parse(row.Cells["DENNGAY"].Value.ToString());
                DateTime ngayvao = m_format.DateTime_parse(row.Cells["NGAYVAO"].Value.ToString());
                DateTime ngayra = m_format.DateTime_parse(row.Cells["NGAYRA"].Value.ToString());

                dngayvao2.Value = ngayvao;
                dngayra2.Value = ngayra;
                txtUBNDTra.Text = UBNDTra;


                setThongTin(MaBN, Hoten, MaBHYT, MaBV, "-", TraiTuyen, IDDuyet, MaICD, ChanDoan, SoPhieu, tungay, denngay);
            }
            catch { }
        }

        private void btnM04_Click(object sender, EventArgs e)
        {
            try {



                string path = @"test.txt";

                //Create the RichTextBox. (Requires a reference to System.Windows.Forms.dll.)
                System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

                // Get the contents of the RTF file. Note that when it is
                // stored in the string, it is encoded as UTF-16.
                string s = System.IO.File.ReadAllText(path,Encoding.UTF8);

                // Display the RTF text.

                System.Windows.Forms.MessageBox.Show(s);

                // Convert the RTF to plain text.
                rtBox.Rtf = s;
                string plainText = rtBox.Text;

                // Display plain text output in MessageBox because console
                // cannot display Greek letters.
                System.Windows.Forms.MessageBox.Show(plainText);

                // Output plain text to file, encoded as UTF-8.
                System.IO.File.WriteAllText(@"output.txt", plainText);
                
            }
            catch { }
        }
     
        
    }
}