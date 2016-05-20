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
using System.Xml;

namespace MediIT115
{
    public partial class frmDuyetBHYTNoiTru: Form
    {
        CBenhNhan BN;
        CThanhToanBHYT BHYT;
        double _khambenh=0;
        private int _loaibn = 0;//0 là noi tru 1 la ngoai trú
        private List<string> Listthuock;
        private List<string> ListKTC;
        private List<string> ListVTYT_TL;
        public frmDuyetBHYTNoiTru()
        {
            InitializeComponent();
            
            
        }
        public frmDuyetBHYTNoiTru(int LoaiBN)
        {
            InitializeComponent();
            _loaibn = LoaiBN;


        }
        private void add_SoPhieu()
        { 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                f_save();
           
        }
        public bool f_Luu_oracle()
        {
            bool result = true;
            lbIDDuyet.Text = "-";
            try
            {
                string id= m_option.f_get_capid(AccessData.m_userid);
                result=f_luu_ds(id);
                if (result==false)
                {
                    MessageBox.Show("Không kết nối được Oracle Server!");
                    lbThongBao.Text = "Thao tác duyệt thất bại";
                    f_delete(id);
                }
                else
                {
                    lbThongBao.Text = "Thao tác duyệt thành công";
                    result= f_luu_ll(id);
                    if (result == false)
                    {
                        lbThongBao.Text="Lưu lý lịch thất bại!";
                        //lbThongBao.Text = "Lưu lý lịch thất bại";
                        f_delete(id);
                        return false;
                    }
                    result =f_luu_ct(id);
                    if (result == false)
                    {
                        lbThongBao.Text="Lưu chi tiết thất bại!";
                       // lbThongBao.Text = "Lưu lý lịch thất bại";
                        f_delete(id);
                        return false;
                    }
                    lbIDDuyet.Text = id;


                }

            }
            catch { return false; }
            return true;


        }
        private bool f_luu_ds(string id)
        {
            try
            {
                v_bhytds vds = new v_bhytds();
                v_bhytds_Oracle vdsOracle = new v_bhytds_Oracle();
                long value=1;
                vds.ID = long.Parse(id);
                vds.MABN = txtMaBN.Text;
                vds.MAVAOVIEN = (long.TryParse(txtMaVaoVien.Text,out value)==true?long.Parse(txtMaVaoVien.Text):1);
                vds.MAQL = (long.TryParse(txtMaQL.Text,out value)==true?long.Parse(txtMaQL.Text):1);
                vds.GIUONG = "";
                vds.NGAYVAO = dngayvao.Value;
                vds.NGAYRA = dngayra.Value;
                vds.CHANDOAN = txtChanDoan.Text;
                vds.MAICD = txtICD.Text;
                vds.SOTHE = txtMaBHYT.Text;
                vds.MAPHU = 0;
                vds.TUNGAY = dtungayBHYT.Value;
                vds.DENNGAY = dHSD.Value;
                vds.MABV = txtMaBV.Text;
                vds.NOIGIOITHIEU = "";
                vds.TRAITUYEN = cbTuyen.SelectedIndex.ToString();
                vds.COMPUTER = Computer.getMachineName();
                vds.USERID = int.Parse(AccessData.m_userid);
                vds.NGAYUD = DateTime.Today;
                vds.MAICDKT = "";
                vds.CHANDOANKT = "";
                vds.BCKTC =(ckbckt.Checked?"1":"0");
                vds.Macanngheo = txtMaCN.Text;
                vds.BCThuocUB = (ckThuocUB.Checked ? "1" : "0");
                vds.HuongKTC = "1";
                vds.MaKP = cbDanhMucKP.SelectedValue.ToString();
                int roweffect = vdsOracle.f_insert(vds);
                if (roweffect < 1)
                    return false;
            }
            catch { return false; }
            return true;
        }
        private bool f_luu_ll(string id)
        {
            try {
                
                v_bhytll_Oracle vllOracle = new v_bhytll_Oracle();
                v_bhytll vll = new v_bhytll();
                long value = 1;
                vll.ID = long.Parse(id);
                vll.LOAIBN = cbLoai.SelectedIndex;
                vll.QUYENSO = "0";
                vll.SOBIENLAI = (long.TryParse(txtSoBienLai.Text,out value)==true?long.Parse(txtSoBienLai.Text):1);
                vll.NGAY = dngaybc.Value;
                vll.SOTIEN = double.Parse(f_clearDot(txtTongCong.Text));
                vll.BHYT = double.Parse(f_clearDot(txtBHYTTra.Text));
                vll.UBNDTRA = double.Parse(f_clearDot(txtUBNDTra.Text ));
                vll.SOPHIEU = txtSoPhieu.Text;
                vll.KHAMBENH= double.Parse(f_clearDot(txtKhamBenh.Text));
                vll.THUOC= double.Parse(f_clearDot(txtThuoc.Text));
                vll.MAU= double.Parse(f_clearDot(txtMau.Text));
                vll.XETNGHIEM= double.Parse(f_clearDot(txtXetNghiem.Text));
                vll.CDHA= double.Parse(f_clearDot(txtCDHA.Text));
                vll.DVKTTHUONG= double.Parse(f_clearDot(txtDVKTThuong.Text));
                vll.DVKTCAO= double.Parse(f_clearDot(txtDVKTCao.Text));
                vll.VTTH= double.Parse(f_clearDot(txtVTYT.Text));
                vll.CPVC= double.Parse(f_clearDot(txtCPVC.Text));
                vll.TDCN= double.Parse(f_clearDot(txtThamDoCN.Text));
                vll.GIUONG= double.Parse(f_clearDot(txtGiuong.Text));
                vll.KHAC = double.Parse(f_clearDot(txtKhac.Text));
                vll.TILETHE = txtTileThe.Text;
                vll.TILEHUONG = txtTileBH.Text;
                vll.THUOCK = double.Parse(f_clearDot(txtThuocK.Text));
                vll.VTYTTL = double.Parse(f_clearDot(txtvtyttt.Text));
                vll.THUOCTL = double.Parse(f_clearDot(txtThuocK.Text));
                vllOracle.f_insert(vll);

            }
            catch { return false; }
            return true;
        }
        private bool f_luu_ct(string id)
        {
            try
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                float float_pro = 0;
                v_bhytct_Oracle vctOracle = new v_bhytct_Oracle();
                int stt = 1;
                foreach (DataGridViewRow item in dview.Rows)
                {
                    v_bhytct vct = new v_bhytct();
                    vct.ID = long.Parse(id);
                    vct.STT = stt;
                    vct.NGAY = DateTime.ParseExact(item.Cells["NGAY"].Value.ToString(),"dd/MM/yyyy",null);
                    vct.MAKP = item.Cells["MAKP"].Value.ToString();
                    vct.MADOITUONG =item.Cells["MADOITUONG"].Value.ToString();
                    vct.MAVP = item.Cells["MAVP"].Value.ToString();
                    vct.SOLUONG=float.Parse(item.Cells["SL"].Value.ToString());
                    vct.DONGIA=double.Parse(item.Cells["DONGIA"].Value.ToString());
                    vct.SOTIEN = vct.DONGIA * vct.SOLUONG;
                    vct.BHYTTRA=double.Parse(item.Cells["BHYTTRA"].Value.ToString());
                                        
                    vct.IDTONGHOP = double.Parse(item.Cells["ID"].Value.ToString());
                    vct.IDNHOMBHYT = int.Parse(item.Cells["IDNHOMBHYT"].Value.ToString());
                    try
                    {
                        vct.ID_KTCAO = long.Parse(item.Cells["idktcao"].Value.ToString());
                    }
                    catch { }
                    vctOracle.f_insert(vct);
                    float_pro = stt*100 / dview.RowCount;
                    progressBar1.Value = (int)float_pro;

                    stt++;
                    
                }
            }
            catch { return false; }
            progressBar1.Visible = false;
            return true;
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
        private void f_setTraiTuyen(int value)
        {
            try
            {
                cbTuyen.SelectedIndex = value;
            }
            catch { cbTuyen.SelectedIndex = 0; }
        }
        private void init_form()
        {
            try
            {
                txtMaBN.Text = "";
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                txtICD.Text = "";
                txtChanDoan.Text = "";
                txtMaQL.Text = "";
                f_setcbPhai(0);

                txtMaBHYT.Text = "";
                txtMaBV.Text = "";
                //txtTenBV.Text = "";
                dHSD.Value = DateTime.Today;
                
                f_setTraiTuyen(0);
                txtSoBienLai.Text = "";

                txtSoPhieu.Text = "";
                txtMaVaoVien.Text = "";
                txtIDThanhToan.Text = "";
                txtThuoc.Text = "0";
                txtMau.Text = "0";
                txtXetNghiem.Text = "0";
                txtCDHA.Text = "0";

                txtDVKTThuong.Text = "0";
                txtDVKTCao.Text = "0";
                txtVTYT.Text = "0";
                txtKhamBenh.Text = "0";
                txtGiuong.Text = "0";
                txtCPVC.Text = "0";
                txtKhac.Text = "0";
                txtThamDoCN.Text = "0";
                txtTongCong.Text = "0";
                txtBHYTTra.Text = "0";
                txtBNTra.Text = "0";
                txtUBNDTra.Text = "0";
                txtNamSinh.Text = "";


                dview.Rows.Clear();
              
            }
            catch { }
        }
        private void txtMaBN_Leave(object sender, EventArgs e)
        {
            loadBHYT();
            
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

                CThanhToanBHYTOracleVienPhi DataOracleVP = new CThanhToanBHYTOracleVienPhi();
                DataTable dsdotdt = DataOracleVP.f_getHoaDon(m_format.DateTime_parse(haison1.tungay), txtMaBN.Text);
                cbdotdieutri.DataSource = null;
                cbdotdieutri.DataSource = dsdotdt;
                cbdotdieutri.DisplayMember = "dotdieutri";
                cbdotdieutri.ValueMember = "idttrv";
                
               
                //txtMaBN.Enabled = false;
            }
            catch { }
            btLuu.Select();

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
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
                double BHYTTra = 0;
                double BNTra = 0;
                foreach (DataGridViewRow row in dview.Rows)
                {
                    TongCP += long.Parse(row.Cells["SoTien"].Value.ToString());
                    BHYTTra += long.Parse(row.Cells["BHYTTra"].Value.ToString());
                }
                float fTongThuoc = 0;
                float fBHYTtra = 0;
             
                TongCP += (long)Math.Round(fTongThuoc,0,MidpointRounding.AwayFromZero);
                BHYTTra += (long)Math.Round(fBHYTtra, 0, MidpointRounding.AwayFromZero);
                BNTra = TongCP - BHYTTra;
                txtTongCong.Text = f_insertDot(TongCP.ToString());
                txtBHYTTra.Text = f_insertDot(BHYTTra.ToString());
                txtBNTra.Text = f_insertDot(BNTra.ToString());

            }
            catch { }
            //CanhBao();

        }

        private void frmDuyetBHYT_Load(object sender, EventArgs e)
        {
            BN = new CBenhNhan();
            BHYT = new CThanhToanBHYT();
            dngaybc.Value = AccessData.m_date_default;
            init();

        }
        #region init
        private void init()
        {
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            panel_T.Visible = false;
            panelKTC.Visible = false;
            _khambenh = OraDanhmuc.f_getgiaVP("30228");
            cbLoaiVP.SelectedIndex = 0;
            cbNhomBHYT.DataSource = OraDanhmuc.d_getDMNhomBHYT();
            cbNhomBHYT.DisplayMember = "ten";
            cbNhomBHYT.ValueMember = "id";
            f_init_addmodul();
            Listthuock = new List<string>();
            ListKTC = new List<string>();
            ListVTYT_TL = new List<string>();
            d_dmbdbh_Orace ora_dmbd = new d_dmbdbh_Orace();
            Listthuock = ora_dmbd.getDanhSachThuocK();
            ListKTC = ora_dmbd.getListKTC();
            ListVTYT_TL = ora_dmbd.getListVTYT_TL();
            cbLoai.SelectedIndex = _loaibn;
            init_dgridT();

        }
        private void init_dgridT()
        { 
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            DataTable dt = OraDanhmuc.d_getDMNhomBHYT();
            foreach (DataRow dr in dt.Rows)
            {
                dGridT.Rows.Add(dr.ItemArray);
            }
        }
#endregion 
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
        private void f_Luu()
        {
            try
            {
                
                BHYT.MaBN = txtMaBN.Text;
                BHYT.MaBV = txtMaBV.Text;
                
                BHYT.ICD = txtICD.Text;
                BHYT.ChanDoan = txtChanDoan.Text;
                //BHYT.NoiDangKyBHYT =  txtTenBV.Text;
                
                BHYT.SoTheBHYT = txtMaBHYT.Text;
                BHYT.SoPhieu = txtSoPhieu.Text;
                BHYT.MaVaoVien = getLong(txtMaVaoVien.Text);
                BHYT.IDTTRV = getLong(txtIDThanhToan.Text);
                BHYT.TraiTuyen = cbTuyen.SelectedIndex;
                BHYT.TongTien = getLong(f_clearDot(txtTongCong.Text));
                BHYT.BHYTTra = getLong(f_clearDot(txtBHYTTra.Text));
                BHYT.BNTra = getLong(f_clearDot(txtBNTra.Text));
                BHYT.TienKham = getLong(f_clearDot(txtKhamBenh.Text));
                BHYT.Thuoc = getLong(f_clearDot(txtThuoc.Text));
                BHYT.Mau = getLong(f_clearDot(txtMau.Text));
                BHYT.XetNghiem = getLong(f_clearDot(txtXetNghiem.Text));
                BHYT.CDHA = getLong(f_clearDot(txtCDHA.Text));
                BHYT.DVKTthongthuong = getLong(f_clearDot(txtDVKTThuong.Text));
                BHYT.DVKTcao = getLong(f_clearDot(txtDVKTCao.Text));
                BHYT.VTYT = getLong(f_clearDot(txtVTYT.Text));
                BHYT.ChiPhiVC = getLong(f_clearDot(txtCPVC.Text));
                BHYT.ThamDoChucNang = getLong(f_clearDot(txtThamDoCN.Text));
                BHYT.Khac = getLong(f_clearDot(txtKhac.Text));
                BHYT.Giuong = getLong(f_clearDot(txtGiuong.Text));
                BHYT.LoaiThe = BHYT.SoTheBHYT.Substring(0, 2);
                BHYT.MaNhomThe = f_MaNhomThe(BHYT.MaBV, BHYT.TraiTuyen).ToString(); 
                BHYT.NhomThe = f_NhomThe(BHYT.MaNhomThe);
                BHYT.NgayLamViec = dngayra.Value;
                BHYT.TuNgay = dtungayBHYT.Value;
                BHYT.HSD = dHSD.Value;
                
                BHYT.SoBienLai = txtSoBienLai.Text;
                CBenhNhanDAO BenhNhanDAO = new CBenhNhanDAO();
                BenhNhanDAO.Insert(BN);
                CThanhToanBHYTDAO ttBHYTDAO = new CThanhToanBHYTDAO();
                int roweffect=ttBHYTDAO.Insert(BHYT);
                if (roweffect == 0)
                {
                    MessageBox.Show("Không kết nối được SQL Server!");

                    lbThongBao.Text = "Thao tác duyệt thất bại";
                }
                else
                {
                    lbThongBao.Text = "Thao tác duyệt thành công";
                    string IDDuyet = ttBHYTDAO.KiemTraDaDuyet(txtMaBN.Text, txtIDThanhToan.Text,dngayra.Value);
                    f_luuChiTiet(IDDuyet);
                }

            }
            catch { }
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
            f_new();
        }
        #region control
        private void f_new()
        {
            txtMaBN.Enabled = true;
            lbThongBao.Text = "...";
            init_form();
            txtMaBN.Select();
        }
        private void f_save()
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();

            if (txtSoPhieu.Text.Length < 1)
            {
                MessageBox.Show("Nhập số phiếu ");
                txtSoPhieu.Select();

            }
            else if (AccessData.m_date_lock > dngaybc.Value)
            {
                MessageBox.Show(string.Format("Số liệu đã khóa đến ngày {0:dd/MM/yyyy}! ", AccessData.m_date_lock));
                dngaybc.Select();

            }

            else
            {
                //CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                DataTable dt = dataOracle.kiemtratrung_MaVaoVien(txtMaVaoVien.Text);
                if (dt.Rows.Count > 0)
                {
                    frmMessage_List fm = new frmMessage_List(dt);
                    fm.Show();
                    if (MessageBox.Show("Bạn có lưu hay không?", "Canh bao trung", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                f_Luu_oracle();
                btMoi.Select();
            }


            
            
            
        }
        private void f_sophieu()
        {
            txtSoPhieu.Text = f_CapSoPhieu();
        }
        #endregion

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
        private void f_loadTongCongSua(int tile)
        {
            long TONG = 0;
            try
            {
                TONG+= getLong(f_clearDot(txtKhamBenh.Text));
                TONG += getLong(f_clearDot(txtThuoc.Text));
                TONG += getLong(f_clearDot(txtMau.Text));
                TONG += getLong(f_clearDot(txtXetNghiem.Text));
                TONG += getLong(f_clearDot(txtCDHA.Text));
                TONG += getLong(f_clearDot(txtDVKTThuong.Text));
                TONG += getLong(f_clearDot(txtDVKTCao.Text));
                TONG += getLong(f_clearDot(txtVTYT.Text));
                TONG += getLong(f_clearDot(txtCPVC.Text));
                TONG += getLong(f_clearDot(txtThamDoCN.Text));
                TONG += getLong(f_clearDot(txtKhac.Text));
                TONG += getLong(f_clearDot(txtGiuong.Text));
                TONG += getLong(f_clearDot(txtThuocK.Text));
                TONG += getLong(f_clearDot(txtvtyttt.Text));
                txtTongCong.Text = f_insertDot(TONG.ToString());
               
                long bhyttra=0;
                //if (ckbckt.Checked == false)
                //{
                //    bhyttra = TONG * tile / 100;
                //}
                //else
                //{
                //    bhyttra = f_loadTongCongBHYTtra_KTC();
                //}
                bhyttra = f_loadTongCongBHYTtra_KTC();
                long bntra = TONG - bhyttra;
                txtBHYTTra.Text = f_insertDot(bhyttra.ToString());
                txtBNTra.Text=f_insertDot(bntra.ToString());
                CanhBao();
            }
            catch { }
            
        }
        private long f_loadTongCongBHYTtra_KTC()
        {

            double TongCP = 0;
            double BHYTTra = 0;
            double BNTra = 0;
            try
            {
            
                foreach (DataGridViewRow row in dview.Rows)
                {
                    
                  //  TongCP += double.Parse(row.Cells["tongtien"].Value.ToString());
                    BHYTTra += double.Parse(row.Cells["BHYTTra"].Value.ToString());
                }
                

             //   TongCP += (long)Math.Round(fTongThuoc, 0, MidpointRounding.AwayFromZero);
             //   BHYTTra += (long)Math.Round(fBHYTtra, 0, MidpointRounding.AwayFromZero);
                //BNTra = TongCP - BHYTTra;
            

            }
            catch { }
            return (long)Math.Round(BHYTTra, 0, MidpointRounding.AwayFromZero);

        
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

        private void btCong_Click(object sender, EventArgs e)
        {
            DichChuyenSo(1);
        }
        private void DichChuyenSo(int num)
        {
            try
            {
                int BHYTtra = int.Parse(f_clearDot(txtBHYTTra.Text)) + num;
                int BNtra = int.Parse(f_clearDot(txtTongCong.Text)) - BHYTtra;
                txtBHYTTra.Text = f_insertDot(BHYTtra.ToString());
                txtBNTra.Text = f_insertDot(BNtra.ToString());
            }
            catch { }
        }

        private void btTru_Click(object sender, EventArgs e)
        {
            DichChuyenSo(-1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Load_Chitiet_CP()
        {
            try
            {

                CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                CThanhToanBHYTOracleVienPhi dataOracleVP = new CThanhToanBHYTOracleVienPhi();
                //IFormatProvider culture = new  CultureInfoConverter("en-US", true);
                DateTime tungay = m_format.DateTime_parse(haison1.tungay);

                string mavaovien = txtMaVaoVien.Text;
                long idttrv = long.Parse(cbdotdieutri.SelectedValue.ToString());
                
                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;

                DateTime ngayvaohd =m_format.DateTime_parse(haison1.tungay);
                DateTime ngayrahd = m_format.DateTime_parse(haison1.denngay);
                DataTable dtcp;
                if (ckbckt.Checked == true)
                {
                    dtcp = dataOracleVP.f_getv_ttrvkp_ct_ALL_FROMVPKTC(txtMaBN.Text, idttrv.ToString(), tungay, _loaibn.ToString());
                }
                else {
                    dtcp = dataOracleVP.f_getv_ttrvkp_ct_ALL_FROMVP(txtMaBN.Text, idttrv.ToString(), tungay, _loaibn.ToString());
                }
                dview.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dview.Rows.Add(item.ItemArray);
                }
                if (ckbckt.Checked == true)
                {
                    initKTCAO();
                }
                
                CThanhToanBHYT bhyt = new CThanhToanBHYT();
                bhyt = dataOracleVP.f_loadTT_BHYT(idttrv.ToString(), tungay);
                txtMaBHYT.Text = bhyt.SoTheBHYT;
                txtMaBV.Text = bhyt.MaBV;
                txtMaCN.Text = bhyt.Macn;
                //txtTenBV.Text = bhyt.NoiDangKyBHYT;
                dtungayBHYT.Value = bhyt.TuNgay;
                dHSD.Value = bhyt.HSD;
                txtChanDoan.Text = dataOracleVP.f_loadChanDoanFull(idttrv.ToString(), tungay).TrimStart(';');
                txtChanDoan.Text = txtChanDoan.Text.Replace("_ ;", "");
                txtChanDoan.Text = txtChanDoan.Text.TrimStart(' ');
                txtChanDoan.Text = txtChanDoan.Text.TrimStart(';');

                txtICD.Text = dataOracleVP.f_loadICDFull(idttrv.ToString(), tungay).TrimStart(';');
                txtICD.Text = txtICD.Text.TrimStart(' ');
                txtICD.Text = txtICD.Text.TrimStart(';');

                f_setTraiTuyen(bhyt.TraiTuyen);
                txtSoBienLai.Text = bhyt.SoBienLai;
                txtSoPhieu.Text = dataOracle.f_loadSoPhieu(mavaovien.ToString(), ngayra);
                txtMaQL.Text = bhyt.MaQuanLy;
                txtIDThanhToan.Text = bhyt.IDTTRV.ToString();
                txtMaVaoVien.Text = bhyt.MaVaoVien.ToString();
                bhyt = dataOracleVP.f_loadKhoaPhong_UBNDTra(idttrv.ToString(), tungay);
                txtUBNDTra.Text =f_insertDot(bhyt.Ubndtra.ToString());
                f_set_CBKhoaPhong(bhyt.Makp);

               
               
                f_tinhbhyt();
            }
            catch { }
        }
        private void Load_Chitiet_CP_Edit()
        {
            try
            {

                CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                CThanhToanBHYTOracleVienPhi dataOracleVP = new CThanhToanBHYTOracleVienPhi();
                //IFormatProvider culture = new  CultureInfoConverter("en-US", true);
                DateTime tungay = m_format.DateTime_parse(haison1.tungay);

                string mavaovien = txtMaVaoVien.Text;
             //   long idttrv = long.Parse(cbdotdieutri.SelectedValue.ToString());

                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;

                DateTime ngayvaohd = m_format.DateTime_parse(haison1.tungay);
                DateTime ngayrahd = m_format.DateTime_parse(haison1.denngay);
                DataTable dtcp = dataOracleVP.f_getv_ttrvkp_ct_ALL_FROMVPedit(txtMaBN.Text, "", tungay, _loaibn.ToString(),txtSoPhieu.Text);

                dview.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dview.Rows.Add(item.ItemArray);
                }


                CThanhToanBHYT bhyt = new CThanhToanBHYT();
                bhyt = dataOracleVP.f_loadTT_BHYT_Edit(txtMaBN.Text,txtSoPhieu.Text);
                txtMaBHYT.Text = bhyt.SoTheBHYT;
                txtMaBV.Text = bhyt.MaBV;
                txtMaCN.Text = bhyt.Macn;
                //txtTenBV.Text = bhyt.NoiDangKyBHYT;
                dtungayBHYT.Value = bhyt.TuNgay;
                dHSD.Value = bhyt.HSD;         
                txtChanDoan.Text = bhyt.ChanDoan;              

                
                txtICD.Text = bhyt.ICD;
                
                f_setTraiTuyen(bhyt.TraiTuyen);
                txtSoBienLai.Text = bhyt.SoBienLai;
                
                txtMaQL.Text = bhyt.MaQuanLy;
                txtIDThanhToan.Text = "-1";
                txtMaVaoVien.Text = bhyt.MaVaoVien.ToString();
                
                txtUBNDTra.Text = f_insertDot(bhyt.Ubndtra.ToString());
                f_set_CBKhoaPhong(bhyt.Makp);

                

                f_tinhbhyt();
            }
            catch { }
        }
        private void f_loadBHYT()
        {
            try
            {
                CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
                CThanhToanBHYT bhyt = new CThanhToanBHYT();
                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;
                string mavaovien = txtMaVaoVien.Text;
                bhyt = dataOracle.f_loadTT_BHYT_CLS(mavaovien.ToString(), ngayvao);
                txtMaBHYT.Text = bhyt.SoTheBHYT;
                txtMaBV.Text = bhyt.MaBV;
                txtMaCN.Text = bhyt.Macn;
                //txtTenBV.Text = bhyt.NoiDangKyBHYT;
                dtungayBHYT.Value = bhyt.TuNgay;
                dHSD.Value = bhyt.HSD;
                txtChanDoan.Text = dataOracle.f_loadChanDoanFull(mavaovien.ToString(), ngayvao).TrimStart(';');
                txtChanDoan.Text = txtChanDoan.Text.Replace("_ ;", "");
                txtChanDoan.Text = txtChanDoan.Text.TrimStart(' ');
                txtChanDoan.Text = txtChanDoan.Text.TrimStart(';');

                txtICD.Text = dataOracle.f_loadICDFull(mavaovien.ToString(), ngayvao).TrimStart(';');
                txtICD.Text = txtICD.Text.TrimStart(' ');
                txtICD.Text = txtICD.Text.TrimStart(';');

                f_setTraiTuyen(bhyt.TraiTuyen);
                txtSoBienLai.Text = bhyt.SoBienLai;
                txtSoPhieu.Text = dataOracle.f_loadSoPhieu(mavaovien.ToString(), ngayvao);
                txtMaQL.Text = bhyt.MaQuanLy;
                txtIDThanhToan.Text = bhyt.IDTTRV.ToString();
            }
            catch { }
        }
        private void cbdotdieutri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] ngay = cbdotdieutri.Text.Split('-');
                DateTime ngayvao = DateTime.ParseExact(ngay[0].TrimEnd(' '), "dd/MM/yyyy HH:mm", null);
                DateTime ngayra = DateTime.ParseExact(ngay[1].TrimStart(' '), "dd/MM/yyyy HH:mm", null);
                long mavaovien = long.Parse(cbdotdieutri.SelectedValue.ToString());
                dngayvao.Value = ngayvao;
                dngayra.Value = ngayra;
                txtMaVaoVien.Text = mavaovien.ToString();
                Load_Chitiet_CP();
                btLuu.Select();
            }
            catch { }
        }

        private void btLoadBHYT_Click(object sender, EventArgs e)
        {
            print_BV();
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
        private void f_tinhbhyt()
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
            //int tile = dataOracle.f_gettileBHYTtra(txtMaBHYT.Text, cbTuyen.SelectedIndex.ToString());

            int tile = 0;
            int tilethe = dataOracle.f_gettileBHYTtra_3KT(txtMaBHYT.Text, "0");
            double tongcp=f_tongcp();
            int traituyen=cbTuyen.SelectedIndex;
            if (tongcp < 172500 && ck100.Checked == false&&traituyen==0)
            {
                tile = 100;
            }
            else if(  ck100.Checked == true)
            {
                tile = int.Parse(txtTileBH.Text);
            }
            else 
            { 
                tile = dataOracle.f_gettileBHYTtra_3KT(txtMaBHYT.Text, cbTuyen.SelectedIndex.ToString());
            }
           
            
            txtTileBH.Text = tile.ToString();
            txtTileThe.Text = tilethe.ToString();
            double bhyttra=0;
            double bntra=0;
            double thanhtien=0;
            double soluong = 0;
            double dongia = 0;
            string mavp = "";
            string makp = "";
            double thuock = 0;
            d_dmbdbh_Orace ORA_dmbd = new d_dmbdbh_Orace();
            foreach (DataGridViewRow item in dview.Rows)
            {

                soluong = double.Parse(item.Cells["SL"].Value.ToString());
                dongia = double.Parse(item.Cells["DONGIA"].Value.ToString());
                mavp = item.Cells["MAVP"].Value.ToString();
                double tilethuock = ORA_dmbd.getTiLeThuocK(mavp);
                
                thanhtien = soluong * dongia;
                int doituong=int.Parse(item.Cells["MADOITUONG"].Value.ToString());
                int idnhombhyt = int.Parse(item.Cells["IDNHOMBHYT"].Value.ToString());
                switch (doituong)
                {
                    case 1:
                        {
                            if (IsThuocK(mavp)==true)
                                thuock += thanhtien;
                            if (idnhombhyt == 6 || idnhombhyt == 14)
                            {
                                bhyttra =double.Parse(item.Cells["BHYTTRA"].Value.ToString());
                                bntra = thanhtien - bhyttra;
 
                            }
                            else
                            {
                                bhyttra = (double)(thanhtien * tile / 100) * tilethuock;
                                bntra = thanhtien - bhyttra;
                            }
                            break;
                        }
                    case 2:
                    case 7:
                        {
                            bhyttra = 0;
                            bntra = thanhtien - bhyttra;
                            break;
                        }
                    case 4:
                        {
                            bhyttra = double.Parse(item.Cells["BHYTTRA"].Value.ToString());
                            bntra = thanhtien - bhyttra;
                            break;
                        }
                    default:
                        {   bhyttra = 0;
                        bntra = 0; break;
                    }
                }
                item.Cells["TONGTIEN"].Value = thanhtien;
                item.Cells["BHYTTRA"].Value = bhyttra;
                item.Cells["BNTRA"].Value = bntra;
                //item.Cells["THUOCK"].Value = IsThuocK(mavp);
                string makp_temp=item.Cells["MAKP"].Value.ToString();
                if (makp_temp.Length > 0)
                {
                    makp = makp_temp;
                }
                
            }
            long temp = (long)thuock;

            txtThuocK.Text = temp.ToString();
            //f_set_CBKhoaPhong(makp);
            f_loadChiTiet();// 
            f_loadTongCongSua(tile);
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
        private void setGroupKTC()
        {
            //foreach (DataGridViewRow row in dview.Rows)
            //{
            //    string mavp = row.Cells["MAVP"].Value.ToString();
            //    if (ListKTC.FindIndex(delegate(string s) { return s.Contains(mavp); }) >= 0)
            //    {
            //        row.Cells["IDNhomBHYT"].Value = "6";
            //        row.Cells["NHOM"].Value = "KTC";
            //    }

            //}
            /*Chỉnh sửa ngày 13/5/2015 Có tỉ lệ: quy tắc: BHYT/Tổng tiền < tỉ lệ hưởng => có tỉ lệ.*/

            foreach (DataGridViewRow row in dview.Rows)
            {
                //string mavp = row.Cells["MAVP"].Value.ToString();
                float Tongtien=float.Parse(row.Cells["TONGTIEN"].Value.ToString());
                float bhyttra=float.Parse(row.Cells["BHYTTRA"].Value.ToString());
                int tile=(int)Math.Ceiling(bhyttra/Tongtien*100);
               // row.ContextMenuStrip.Text=tile.ToString();
                string s_madoituong = row.Cells["madoituong"].Value.ToString();
                if (tile < int.Parse(txtTileBH.Text)&& tile>0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    int idnhombhytold = int.Parse(row.Cells["IDNhomBHYT"].Value.ToString());
                    
                    switch (idnhombhytold)
                    {
                        case 1: // Nhóm thuốc chuyển thành thuốc tt theo ti le
                            row.Cells["IDNhomBHYT"].Value = "13";
                            row.Cells["NHOM"].Value = "THUỐC TỈ LỆ";
                            break;
                        case 7: // Nhóm vtth chuyển thành vtth theo ti le
                            row.Cells["IDNhomBHYT"].Value = "14";
                            row.Cells["NHOM"].Value = "VTTH TỈ LỆ";
                            break;
                        case 4: // Nhóm CDHA chuyển thành DVKT theo ti le
                            row.Cells["IDNhomBHYT"].Value = "6";
                            row.Cells["NHOM"].Value = "DVKT TỈ LỆ";
                            break;
                        case 5: // Nhóm CDHA chuyển thành DVKT theo ti le
                            row.Cells["IDNhomBHYT"].Value = "6";
                            row.Cells["NHOM"].Value = "DVKT TỈ LỆ";
                            break;
                        case 3: // Nhóm CDHA chuyển thành DVKT theo ti le
                            row.Cells["IDNhomBHYT"].Value = "6";
                            row.Cells["NHOM"].Value = "DVKT TỈ LỆ";
                            break;

                    }

                }
                else if (tile==0 && s_madoituong=="1")
                {
                    row.Cells["madoituong"].Value = "2";
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                

            }
        }
       
        private void setGroupThuocK()
        {
            foreach (DataGridViewRow row in dview.Rows)
            {
                string mavp = row.Cells["MAVP"].Value.ToString();
                if (Listthuock.FindIndex(delegate(string s) { return s.Contains(mavp); }) >= 0)
                {
                    row.Cells["IDNhomBHYT"].Value = "13";
                    row.Cells["NHOM"].Value = "THUOCTL";
                }

            }

        }

        private void setGroupVTYT_TL()
        {
            foreach (DataGridViewRow row in dview.Rows)
            {
                string mavp = row.Cells["MAVP"].Value.ToString();
                if (ListVTYT_TL.FindIndex(delegate(string s) { return s.Contains(mavp); }) >= 0)
                {
                    row.Cells["IDNhomBHYT"].Value = "14";
                    row.Cells["NHOM"].Value = "VTYT TI LE";
                }

            }

        }

        private void f_loadChiTiet()
        {
            try
            {
                setGroupKTC(); // NHÓM 6 V_NHOMBHYT
                //setGroupThuocK(); // NHÓM 13 V_NHOMBHYT ..Lock ngày 14/5/2015 sử dụng chung nhóm setGroupKTC
                //setGroupVTYT_TL(); // NHÓM 14 ..Lock ngày 14/5/2015 sử dụng chung nhóm setGroupKTC
                double[] Value = new double[16];
                double tongchiphi = 0;
                for (int i = 0; i < 16; i++)
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
                txtThuocK.Text = f_insertDot(Double_Round(Value[13]).ToString());
                txtvtyttt.Text = f_insertDot(Double_Round(Value[14]).ToString());

            }
            catch { }

        }

        private void f_init_addmodul()
        {
            CDanhMucOracle dataOracle = new CDanhMucOracle();
            DataTable dtdm_dichvu = dataOracle.f_getDMDuoc_VienPhi();

            
            listicd10.DataSource = dtdm_dichvu;
            listicd10.DisplayMember = "TEN";
            listicd10.ValueMember = "ID";

           
            
            
            


            DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong();
            cbDanhMucKP.DataSource = dtdm_khoaphong;
            cbDanhMucKP.DisplayMember = "TEN";
            cbDanhMucKP.ValueMember = "ID";
            cbDanhMucKP.SelectedIndex = 0;
            cbLoai.SelectedIndex = 0;
            cbdoituong.DataSource = dataOracle.d_getDMDoiTuong();
            cbdoituong.DisplayMember = "ten";
            cbdoituong.ValueMember = "ma";
            cbdoituong.SelectedIndex = 0;



        }

        private void btThem_Click(object sender, EventArgs e)
        {
            f_add_dichvu();
            f_tinhbhyt();
            txtSL.Text = "1";
            txtDonGia.Text = "";
            txtNameVP.Select();
            

        }
        private void f_add_dichvu()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                int row = dview.RowCount;
                dview.Rows.Add();
                dview.Rows[row].Cells["MaVP"].Value=txtIDVP.Text;
                dview.Rows[row].Cells["TenVP"].Value = txtNameVP.Text;
                dview.Rows[row].Cells["SL"].Value =txtSL.Text;
                dview.Rows[row].Cells["DonGia"].Value = txtDonGia.Text;
                dview.Rows[row].Cells["MaDoiTuong"].Value = cbdoituong.SelectedValue.ToString();
                dview.Rows[row].Cells["idnhombhyt"].Value =dataOracle.f_get_idnhombhyt(txtIDVP.Text);
                dview.Rows[row].Cells["Makp"].Value = cbDanhMucKP.SelectedValue.ToString();
                dview.Rows[row].Cells["tenkp"].Value = cbDanhMucKP.Text;
                dview.Rows[row].Cells["ngay"].Value = string.Format("{0:dd/MM/yyyy}",dngayra.Value);
                dview.Rows[row].Cells["ID"].Value = string.Format("{0:yyyyMMdd}", dngayra.Value);
                dview.Rows[row].Cells["IDKHOA"].Value = "0";
                dview.Rows[row].DefaultCellStyle.BackColor = Color.Yellow;



            }
            catch { }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            f_tinhbhyt();
        }
        private void print_BV()
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();

            //DataSet ds = data.f_loadBaoCaoMau20(tungay, denngay, "");

            DataSet ds = data.f_getv_ttrvkp_ct_BV115(txtMaBN.Text, lbIDDuyet.Text);
            frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_test.rpt", "", "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Chitiet_CP();
        }

        private void lbloai_Click(object sender, EventArgs e)
        {
            Load_Chitiet_CP();
        }

        private void ckbckt_CheckedChanged(object sender, EventArgs e)
        {
            f_loadTongCongSua(0);
        }

        private void ckThuocUB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMaBHYT_TextChanged(object sender, EventArgs e)
        {
            try {
                int lenBHYT=txtMaBHYT.Text.Length;
                lbSLKT.Text = lenBHYT.ToString();
                if (lenBHYT == 20)
                {
                    txtMaBV.Text = txtMaBHYT.Text.Substring(15, 5);
                }
            }
            catch { }
        }
        private void f_delete(string idduyet)
        {
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
            MessageBox.Show("Đã xóa phiếu: ID= " + idduyet);
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            string idduyet = lbIDDuyet.Text;
            f_delete(idduyet);
        }

        private void ckLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            loadBHYT();
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

            if (ckloaddate.Checked == true && _loaibn == 1)
            {
                dngaybc.Value = dngayra.Value;
            }
            else
            {
                dngaybc.Value = AccessData.m_date_default;
            }
             
                TimeSpan ts;
                DateTime Fromday = dngayvao.Value;   //YYYY-MM-DD
                DateTime ToDay = dngayra.Value;
                ts = ToDay.Date - Fromday.Date;
                
                //int songay =  ToDay.DayOfYear - Fromday.DayOfYear+1;
                int songay = (int)ts.TotalDays;
                               
                lbSoNgay.Text = songay.ToString();
           
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            txtDonGia.Text = OraDanhmuc.f_getgiaVP(txtIDVP.Text).ToString();
        }
        private void CanhBao()
        {

            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            double khambenh = double.Parse(f_clearDot(txtKhamBenh.Text));
            if (ckKhamBenh.Checked == true&&khambenh!=_khambenh&& _loaibn==1)
            {   
                   MessageBox.Show("Vui lòng kiểm tra tiền khám="+khambenh+" -(Đơn giá = "+_khambenh.ToString()+")");
            }

            double giuong = double.Parse(f_clearDot(txtGiuong.Text));

            if (chkGiuong.Checked == true && giuong == 0 && _loaibn == 1)
            {

                MessageBox.Show("Vui lòng kiểm tra tiền giường=0!");
            }
            if (chkGiuong.Checked == false && giuong > 0 && _loaibn == 1)
            {
                MessageBox.Show("Vui lòng kiểm tra tiền giường="+giuong);
            }
        }

        private void dview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try {
                dview.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Load_Chitiet_CP_Edit();
        }

        private void lbSoPhieu_Click(object sender, EventArgs e)
        {
            f_sophieu();
        }
        private string f_CapSoPhieu()
        {
            string result = "";
            try {
                
                result += txtCurSP.Text;
                int numtemp = int.Parse(txtCurSP.Text);
                numtemp++;
                txtCurSP.Text = numtemp.ToString();
            }
            catch { }
            return result;
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

        private void txtUBNDTra_Leave(object sender, EventArgs e)
        {
            try
            {
                int BHYTtra = int.Parse(f_clearDot(txtBHYTTra.Text));
                int UBNDTra= int.Parse(f_clearDot(txtUBNDTra.Text));
                int BNtra = int.Parse(f_clearDot(txtTongCong.Text)) - BHYTtra-UBNDTra;
                
                //txtBHYTTra.Text = f_insertDot(BHYTtra.ToString());
                txtBNTra.Text = f_insertDot(BNtra.ToString());
                TextBox_Leave(sender, e);
            }
            catch { }
        }

        private void lbUBNDtra_Click(object sender, EventArgs e)
        {
            f_UBNDTra();
        }
        private void f_UBNDTra()
        { 
         try
            {
                int tileUB = 15;
                if (txtTileBH.Text.CompareTo("95") == 0)
                {
                    tileUB = 5;
                }
                int TongTien = int.Parse(f_clearDot(txtTongCong.Text));
                double UBtra=Math.Round((double)TongTien * tileUB / 100, 0, MidpointRounding.AwayFromZero);
                int UBNDtra = (int)UBtra;
                txtUBNDTra.Text = f_insertDot(UBNDtra.ToString());
                txtUBNDTra_T.Text = txtUBNDTra.Text;
            }
            catch { }
        }
        private void dview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbGiuong_Click(object sender, EventArgs e)
        {
            filter("1");
        }
        private void filter(string nhom)
        {
            foreach (DataGridViewRow dr in dview.Rows)
            {
                string nhombh = dr.Cells["IDNHOMBHYT"].Value.ToString();
                if (nhombh.CompareTo(nhom) == 0||nhom.Length==0)
                {
                    dr.Visible = true;
                }
                else
                {
                    dr.Visible = false;
                }
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            filter("");
        }

        private void cbNhomBHYT_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter(cbNhomBHYT.SelectedValue.ToString());
        }

        private void ckVisibleT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                f_tinhbhyt();
                panel_T.Visible = ckVisibleT.Checked;
                double sumbhyt = 0;
                double sumsotien = 0;
                double[] bhyt = new double[16];
                double[] sotien = new double[16];
                double tongchiphi = 0;
                for (int i = 0; i < 16; i++)
                {
                    bhyt[i] = 0;
                    sotien[i] = 0;
                }
                foreach (DataGridViewRow row in dview.Rows)
                {
                    int madoituong = int.Parse(row.Cells["MADOITUONG"].Value.ToString());
                    if (madoituong == 1)
                    {
                     
                        int pos = int.Parse(row.Cells["IDNhomBHYT"].Value.ToString());
                        switch (pos)
                        {
                            case 13 :
                                bhyt[1] += double.Parse(row.Cells["BHYTTRA"].Value.ToString());
                                sotien[1] += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                                break;
                            case 14:
                                bhyt[6] += double.Parse(row.Cells["BHYTTRA"].Value.ToString());
                                sotien[6] += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                                break;
                            default :
                                bhyt[pos] += double.Parse(row.Cells["BHYTTRA"].Value.ToString());
                                sumbhyt += double.Parse(row.Cells["BHYTTRA"].Value.ToString());
                                sotien[pos] += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                                sumsotien += double.Parse(row.Cells["TONGTIEN"].Value.ToString());
                                break;
                        }
                    }

                   

                }
                bhyt[4]+=bhyt[12]; //TDCN
                sotien[4]+=sotien[12];
                bhyt[12] = 0;
                sotien[12] = 0;
                foreach (DataGridViewRow dr in dGridT.Rows)
                {
                    int idnhom = int.Parse(dr.Cells["T_ID"].Value.ToString());
                   
                    dr.Cells["T_BHYT"].Value = f_insertDot(Double_Round(bhyt[idnhom]).ToString());
                    dr.Cells["T_SOTIEN"].Value = f_insertDot(Double_Round(sotien[idnhom]).ToString());

                }
                
                //bhyt_T.Text = f_insertDot(Double_Round(sumbhyt).ToString());
                //sotien_T.Text = f_insertDot(Double_Round(sumsotien).ToString());
                txtTileHuong_T.Text = txtTileBH.Text;
                txtBHYT_T.Text = txtBHYTTra.Text;
                txtBNTra_T.Text = txtBNTra.Text;
                txtTongCong_T.Text = txtTongCong.Text;
                txtUBNDTra_T.Text = txtUBNDTra.Text;
            }
            catch { }
        }

        private void ckKTC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panelKTC.Visible = ckKTC.Checked;
            }
            catch { }
        }
        private void addKTC()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                int row = dview.RowCount;
                // add ten PTTT KTC
                dview.Rows.Add();
                dview.Rows[row].Cells["MaVP"].Value = txtIDVP.Text;
                dview.Rows[row].Cells["TenVP"].Value = txtNameVP.Text;
                dview.Rows[row].Cells["SL"].Value = "1";
                txtDonGia.Text = dataOracle.f_getgiaVP(txtIDVP.Text).ToString();
                dview.Rows[row].Cells["DonGia"].Value = f_clearDot(txtDonGia.Text);
                dview.Rows[row].Cells["BHYTTRA"].Value = f_clearDot(txtDonGia.Text);

                dview.Rows[row].Cells["MaDoiTuong"].Value = cbdoituong.SelectedValue.ToString();
                dview.Rows[row].Cells["idnhombhyt"].Value = "6";
                dview.Rows[row].Cells["Makp"].Value = cbDanhMucKP.SelectedValue.ToString();
                dview.Rows[row].Cells["tenkp"].Value = cbDanhMucKP.Text;
                dview.Rows[row].Cells["ngay"].Value = string.Format("{0:dd/MM/yyyy}", dngayra.Value);
                dview.Rows[row].Cells["ID"].Value = string.Format("{0:yyyyMMdd}", dngayra.Value);
                dview.Rows[row].Cells["IDKHOA"].Value = "0";
                //add Gói VT KTC
                row++;
                dview.Rows.Add();
                dview.Rows[row].Cells["MaVP"].Value = "44147";
                dview.Rows[row].Cells["TenVP"].Value = "Gói vật tư kỹ thuật cao KTC";
                dview.Rows[row].Cells["SL"].Value = "1";
                long dongiaVT=long.Parse(f_clearDot(txtSoTienKTC.Text))-long.Parse(f_clearDot(txtDonGia.Text));
                long bhyttraVT = long.Parse(f_clearDot(txtBHYTKTC.Text)) - long.Parse(f_clearDot(txtDonGia.Text));
                dview.Rows[row].Cells["DonGia"].Value = dongiaVT;
                dview.Rows[row].Cells["BHYTTRA"].Value = bhyttraVT;

                dview.Rows[row].Cells["MaDoiTuong"].Value = cbdoituong.SelectedValue.ToString();
                dview.Rows[row].Cells["idnhombhyt"].Value = "14";
                dview.Rows[row].Cells["Makp"].Value = cbDanhMucKP.SelectedValue.ToString();
                dview.Rows[row].Cells["tenkp"].Value = cbDanhMucKP.Text;
                dview.Rows[row].Cells["ngay"].Value = string.Format("{0:dd/MM/yyyy}", dngayra.Value);
                dview.Rows[row].Cells["ID"].Value = string.Format("{0:yyyyMMdd}", dngayra.Value);
                dview.Rows[row].Cells["IDKHOA"].Value = "0";


            }
            catch { }
        }

        private void btAddKTC_Click(object sender, EventArgs e)
        {
            addKTC();
        }

        private void txtCurSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Hotkeys
        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                /*
                if ((e.Modifiers ==Keys.Control ) && (e.KeyCode==Keys.N))
                {
                    //MessageBox.Show("New");
                    if(toolNew.Enabled==true)
                    f_new();
                }

                // Ctrl + O
                if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    //MessageBox.Show("Open");
                    if(toolEdit.Enabled==true&&txtMaMay.Text.Length>0)
                    f_edit();
                }

                // Ctrl + S
                if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.S))
                {
                    //MessageBox.Show("Save");
                    if(toolSave.Enabled==true)
                    f_save();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MessageBox.Show("Save");
                    if (toolCancel.Enabled == true)
                    f_cancel();
                }*/
                if (e.KeyCode == Keys.F3)
                {

                    f_sophieu();    
                }

                // Ctrl + O
                if (e.KeyCode == Keys.F5)
                {
                    f_new();
                    
                    
                }

                // Ctrl + S
                if (e.KeyCode == Keys.F4)
                {
                    //MessageBox.Show("Save");
                   
                        f_save();
                   
                }
                if (e.KeyCode == Keys.Escape)
                {
                    ckVisibleT.Checked = !ckVisibleT.Checked;
                }
                if (e.KeyCode == Keys.F6)
                {
                    //Them noi dung;
                    f_tinhbhyt();
                   
                }
                if (e.KeyCode == Keys.F7)
                {
                    //Them noi dung;
                    cbDanhMucKP.Select();

                }
                if (e.KeyCode == Keys.F8)
                {
                    //Them noi dung;
                    f_loadChiTiet();

                }
                if (e.KeyCode == Keys.F9)
                {
                    //Them noi dung;
                    

                }
                if (e.KeyCode == Keys.F10)
                {
                    //Them noi dung;
                    f_UBNDTra();

                }
                if (e.KeyCode == Keys.F11)
                {
                    //Them noi dung;
                    ckKTC.Checked = !ckKTC.Checked;

                }


            }
            catch { }
        }

        #endregion

        private void lbNgayVao_Click(object sender, EventArgs e)
        {
            f_loadBHYT();
        }
        private void f_getChanDoanFromICD()
        {
            CDanhMucOracle DM_Ora = new CDanhMucOracle();
            txtChanDoan.Text = DM_Ora.getChanDoanFromICD(txtICD.Text.Trim());
        }

        private void label9_Click(object sender, EventArgs e)
        {
            f_getChanDoanFromICD();
        }

        private void lbNgayRa_Click(object sender, EventArgs e)
        {
            f_loadBHYT();
        }

        private void lbUBNDTra_T_Click(object sender, EventArgs e)
        {
            f_UBNDTra();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void initKTCAO()
        {
            try
            {
                v_giavpbh_Oracle vpbh=new v_giavpbh_Oracle();
                int nrow = dview.Rows.Count;
                for (int i=0;i<nrow;i++)
                {
                    DataGridViewRow item =dview.Rows[i];
                    string s_idktcao = item.Cells["idktcao"].Value.ToString();
                    string s_mavp = item.Cells["MAVP"].Value.ToString();

                    int isgoi = vpbh.is_ktcgoi(s_mavp);
                    if (item.Cells["idnhombhyt"].Value.ToString() == "6" && s_idktcao.Length > 2 && isgoi==1)
                    {
                        double tonggoi = double.Parse(item.Cells["dongia"].Value.ToString());
                        double bhyttragoi = double.Parse(item.Cells["bhyttra"].Value.ToString());
                        if (ckTachgoi.Checked == true)
                        {
                            tonggoi = f_sumgoithanhtien(s_idktcao);
                            bhyttragoi = f_sumgoibhyttra(s_idktcao);
                        }

                        CDanhMucOracle OraDanhmuc = new CDanhMucOracle();                                 
                        double giapt =  OraDanhmuc.f_getgiaVP(s_mavp);
                        double giavt = tonggoi - giapt;
                        
                        if(giavt>0)
                        {
                            int row = dview.RowCount;
                            dview.Rows.Add();

                            for (int j = 0; j < item.Cells.Count; j++)
                            {
                                dview.Rows[row].Cells[j].Value = item.Cells[j].Value;
                            }
                            double trangoi=46000000;
                            double bhyttravt = bhyttragoi - giapt;
                            dview.Rows[row].Cells["mavp"].Value = "44147";
                            dview.Rows[row].Cells["Tenvp"].Value = "Gói vật tư kỹ thuật cao KTC";
                            dview.Rows[row].Cells["idnhombhyt"].Value = "14";
                            dview.Rows[row].Cells["dongia"].Value = (bhyttragoi==trangoi?trangoi-giapt:giavt);
                            dview.Rows[row].Cells["sl"].Value = 1;
                            dview.Rows[row].Cells["tongtien"].Value = (bhyttragoi == trangoi ? trangoi - giapt : giavt);
                            dview.Rows[row].Cells["bhyttra"].Value = (bhyttragoi == trangoi ? trangoi - giapt : bhyttravt);
                            dview.Rows[row].Cells["bntra"].Value = (bhyttragoi == trangoi ? 0 : giavt - bhyttravt);
                           
                            item.Cells["dongia"].Value = giapt;
                            item.Cells["sl"].Value = 1;
                            item.Cells["tongtien"].Value = giapt;
                            item.Cells["bhyttra"].Value = giapt;
                            item.Cells["bntra"].Value = 0;
                        }
                        else if(s_mavp=="44732")
                        {
                            item.Cells["idnhombhyt"].Value = "4";
                        }


                    }
                }
            }
            catch { }
                
        }
        private double f_sumgiavtktcao(string s_idktcao)
        {
            double result = 0;
            try {
                foreach (DataGridViewRow item in dview.Rows)
                {
                    if (item.Cells["idnhombhyt"].Value.ToString() == "14" && item.Cells["idktcao"].Value.ToString() == s_idktcao )
                    {
                        result+=double.Parse(item.Cells["tongtien"].Value.ToString());
                    }
                }
            }
                
            catch { }
            return result;
        }

        private double f_sumgoithanhtien(string s_idktcao)
        {
            double result = 0;
            try
            {
                foreach (DataGridViewRow item in dview.Rows)
                {
                    if (item.Cells["madoituong"].Value.ToString() == "1" && item.Cells["idktcao"].Value.ToString() == s_idktcao )
                    {
                        result += double.Parse(item.Cells["tongtien"].Value.ToString());
                        
                    }
                }
            }

            catch { }
            return result;
        }
        private double f_sumgoibhyttra(string s_idktcao)
        {
            double result = 0;
            try
            {
                foreach (DataGridViewRow item in dview.Rows)
                {
                    if (item.Cells["madoituong"].Value.ToString() == "1" && item.Cells["idktcao"].Value.ToString() == s_idktcao )
                    {
                        result += double.Parse(item.Cells["bhyttra"].Value.ToString());
                        if (item.Cells["STTNHOM"].Value.ToString() != "-1")
                        {
                            item.Cells["madoituong"].Value = "5";
                        }
                    }
                }
            }

            catch { }
            return result;
        }


        private void bttinhktc_Click(object sender, EventArgs e)
        {
            initKTCAO();
        }

        private void listicd10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSL_Enter(object sender, EventArgs e)
        {
            try
            {
                CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
                txtDonGia.Text = OraDanhmuc.f_getgiaVP(txtIDVP.Text).ToString();
                txtNameVP.Text = OraDanhmuc.f_getNameVP(txtIDVP.Text).ToString();
            }
            catch { }
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}{Home}");
            }
        }

        # region list

        private void txtNameVP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Up))
            {
                listicd10.Focus();
            }
            else if (e.KeyCode == Keys.Return)
            {
                if (listicd10.Visible)
                {
                    listicd10.Focus();
                }
                else
                {
                    SendKeys.Send("{Tab}{Home}");
                    
                }
            }
        }

        private void txtIDVP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIDVP.Text == "")
                {
                    txtNameVP.Text = "";
                    txtNameVP.Focus();
                }
                else
                {
                    CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
                    txtDonGia.Text = OraDanhmuc.f_getgiaVP(txtIDVP.Text).ToString();
                    txtNameVP.Text = OraDanhmuc.f_getNameVP(txtIDVP.Text).ToString();

                }

            }
        }

        private void txtIDVP_TextChanged(object sender, EventArgs e)
        {
            listicd10.Hide();
        }

        private void Filt_ICD(string ten)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[listicd10.DataSource];
                DataView list = (DataView)manager.List;
                list.RowFilter = "TEN like '%" + ten.Trim() + "%'";
            }
            catch
            {
            }
        }

        private void txtNameVP_TextChanged(object sender, EventArgs e)
        {
            if ((base.ActiveControl == txtNameVP))// && ((txtMaIcd10.Text == "") || (txtMaIcd10.Text.Trim() == u00)))
            {
                Filt_ICD(txtNameVP.Text);
            
                listicd10.Browse_mavp(txtNameVP,
                    txtIDVP,
                    txtSL,
                    txtIDVP.Location.X,
                   txtIDVP.Location.Y + txtIDVP.Height,
                    (txtIDVP.Width + txtNameVP.Width),
                    txtIDVP.Height);
                
            }
        }


        #endregion 

        
    }
}