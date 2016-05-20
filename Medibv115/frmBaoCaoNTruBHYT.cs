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
namespace MediIT115
{
    public partial class frmBaoCaoNTruBHYT : Form
    {
        DataSet _ds;
        DataSet _dsChuaDuyet;
        string stypereport = "";
        public frmBaoCaoNTruBHYT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            
           
            DataSet ds = data.f_loadBCMau79_80_DK(tungay,denngay,"0",ckCanNgheo.Checked,"","",stypereport);
            string reportname = "rptDuyetbhytmau79";
            if (ckCanNgheo.Checked)
                reportname += "_CN";
            if (ckTongHop.Checked)
                reportname += "_TH";
            reportname += ".rpt";
            
            frmReport a = new frmReport(d, ds.Tables[0], reportname,cbLoaiBC.Text +  " TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void btLload_Click(object sender, EventArgs e)
        {

            f_LoadDSDaDuyet();
        }
        private void f_LoadDSDaDuyet()
        {
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            string dieukien = " and b.loaibn=0 ";
            _ds = data.f_loadDanhSachDaDuyet(tungay, denngay,dieukien);
            f_locdanhsachdaduyet(txtTimkiem.Text);
        }
        private void f_locdanhsachdaduyet(string value)
        {
            try
            {
                DataView dv = new DataView(_ds.Tables[0]);
                dv.RowFilter = "MaBN like '%" + value + "%'";
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
                string NamSinh=row.Cells["NamSinh"].Value.ToString();
                string DiaChi=row.Cells["DiaChi"].Value.ToString();
                int phai=int.Parse(row.Cells["GIOITINH"].Value.ToString());
                string MaBHYT=row.Cells["SOTHEBHYT"].Value.ToString();
                string MaBV=row.Cells["MaBV"].Value.ToString();
                string TenBV=row.Cells["TenBV"].Value.ToString();
                int TraiTuyen=int.Parse(row.Cells["TraiTuyen"].Value.ToString());
                string IDDuyet=row.Cells["ID"].Value.ToString();
                setThongTin(MaBN, Hoten, NamSinh, DiaChi, phai, MaBHYT, MaBV, TenBV, TraiTuyen, IDDuyet,"","");
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
                string NamSinh = row.Cells["NamSinh"].Value.ToString();
                string DiaChi = "";
                int phai = int.Parse(row.Cells["GIOITINH"].Value.ToString());
                string MaBHYT = row.Cells["SOTHEBHYT"].Value.ToString();
                string MaBV = row.Cells["MaBV"].Value.ToString();
                string MaICD = row.Cells["ICD10"].Value.ToString();
                string ChanDoan = row.Cells["ChanDoan"].Value.ToString();
                
                int TraiTuyen = int.Parse(row.Cells["TraiTuyen"].Value.ToString());
                string IDDuyet = row.Cells["ID"].Value.ToString();
                setThongTin(MaBN, Hoten, NamSinh, DiaChi, phai, MaBHYT, MaBV, "-", TraiTuyen, IDDuyet,MaICD,ChanDoan);
            }
            catch { }

        }
        private void setThongTin(string MaBN,string Hoten,string NamSinh,string DiaChi,int phai,string MaBHYT,string MaBV,string TenBV,int TraiTuyen,string IDDuyet,string MaICD,string ChanDoan)
        {
            txtMaBN.Text = MaBN;
            txtHoTen.Text = Hoten;
           
            txtNamSinh.Text = NamSinh;         
            f_setcbPhai(phai);

            txtMaBHYT.Text =MaBHYT;
          
            txtTenBV.Text = TenBV;
            txtIDDuyet.Text = IDDuyet;
            txtMaICD.Text = MaICD;
            txtChanDoan.Text = ChanDoan;
          
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
            }
            else
            {
                MessageBox.Show(string.Format("Số liệu đã khóa đến ngày {0:dd/MM/yyyy}! ", AccessData.m_date_lock));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            f_locdanhsachdaduyet(txtTimkiem.Text);
        }

        private void frmBaoCaoNgoaiTruBHYT_Load(object sender, EventArgs e)
        {
            _ds = new DataSet();
            _dsChuaDuyet = new DataSet();
            init_cbloaibc();
        }

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
               // CThanhToanBHYTDAO data = new CThanhToanBHYTDAO();
                CThanhToanBHYTOracleNoiTru dataOra = new CThanhToanBHYTOracleNoiTru();

                string tungay = haison1.tungay;
                string denngay = haison1.denngay;
                DataTable dt = dataOra.kiemtratrung_trongngay("",m_format.DateTime_parse(tungay));
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
                DataTable dtdm_loaibc = dataOracle.d_getDM_BCDieuKien("");
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
                Ora_v_bhytds.f_update_ICD(v_ds);
            }
            catch { }

        }

        private void btExcel_Click(object sender, EventArgs e)
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
            string reportname = "rptDuyetbhytmau79";
            if (ckCanNgheo.Checked)
                reportname += "_CN";
            if (ckTongHop.Checked)
                reportname += "_TH";
            reportname += ".rpt";

            frmReport a = new frmReport(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //m_option M_OPT=new m_option();
            //int nrow=M_OPT.f_update_dinhsuat(m_format.DateTime_parse(haison1.tungay),m_format.DateTime_parse(haison1.denngay,));
            //MessageBox.Show(nrow.ToString() + " rows effect");
        }
       
      
    }
}