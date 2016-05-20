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
    public partial class frmBCCLSMau21 : Form
    {
        string stypereport = "";
        string s_tenreport = "123";
        string s_tieuDeExcel = "123";
        string s_tenBaoCao = "123";
        AccessData d = new AccessData();  
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        Excel.Range orange;
        System.Data.DataTable dtChungC79_80_a_HD;
        decimal t_deNghiThanhToan = 0;
        string _loaibn = "1";// 0 noitru,1 ngoaitru

        public frmBCCLSMau21()
        {
            InitializeComponent();
        }

        private void btInBaoCao_Click(object sender, EventArgs e)
        {
         

            AccessData d = new AccessData();
            string reportname = "rpt_BCCanLamSang.rpt";
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
            DataSet ds = data.f_loadBCMau21(tungay, denngay, stypereport, ckVTYT.Checked, treeView_HAISON1.get_Ma.Trim(','), "");
            frmReport a = new frmReport(d, ds.Tables[0], reportname, title, txtHoTen.Text, txtGiamDoc.Text, "", "", "", "", "", "", "");
            a.Show();
        }

        private void frmBCDuocMau20_Load(object sender, EventArgs e)
        {
            cbLoai.SelectedIndex = 0;
            DSMauC79_80a_HD();
            CDanhMucOracle dm=new CDanhMucOracle();
            treeView_HAISON1.setDataSource(dm.d_getDMNhomBHYT(),"ten","id","Danh mục Nhóm BHYT",false,"Chọn Nhóm BHYT để báo cáo");
            init_cbloaibc();
        }
        private void init_cbloaibc()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                System.Data.DataTable dtdm_loaibc = dataOracle.d_getDM_BCDieuKien("");
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

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            
            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            DataSet ds = data.f_loadBCMau21_XuatExcel(tungay, denngay, stypereport, ckVTYT.Checked, treeView_HAISON1.get_Ma.Trim(','), "");
            SapXepData(ds);
            exp_excel(dtChungC79_80_a_HD);
        }
        private void xuat_excel1()
        {
            AccessData d = new AccessData();

            string tungay = haison1.tungay;
            string denngay = haison1.denngay;
            CThanhToanBHYTOracleNoiTru data = new CThanhToanBHYTOracleNoiTru();
            DataSet ds = data.f_loadBCMau21_XuatExcel(tungay, denngay, stypereport, ckVTYT.Checked, treeView_HAISON1.get_Ma.Trim(','), "");
            string reportname = "xuat_excel.rpt";
            frmReportExcel a = new frmReportExcel(d, ds.Tables[0], reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }
        #region Excel M21
      
        public void DSMauC79_80a_HD()//cấu trúc chung mẫu c80a-HD; c79a-HD
        {
            
          
         
            dtChungC79_80_a_HD = new System.Data.DataTable();
            dtChungC79_80_a_HD.Columns.Add("stt", typeof(string));
           // dtChungC79_80_a_HD.Columns.Add("tennhom", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("mahoa1", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("mahoa2", typeof(string));
            dtChungC79_80_a_HD.Columns.Add("tenvp", typeof(string));
            
            dtChungC79_80_a_HD.Columns.Add("slngoaitru", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("slnoitru", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("dongia", typeof(decimal)).DefaultValue = 0;
            dtChungC79_80_a_HD.Columns.Add("thanhtien", typeof(decimal)).DefaultValue = 0;
                       
            dtChungC79_80_a_HD.Columns.Add("ghichu", typeof(string));
            
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
                string s_tennhom = "";
                int i_sttA = 0;
                foreach (DataRow r in dts_.Tables[0].Select("","tennhom,tenvp"))
                {
                    r1 = d.getrowbyid(dtChungC79_80_a_HD, "TENNHOM");
                    if (r1 == null)
                    {
                        if (r["tennhom"].ToString().Equals(s_tennhom.ToString()) == false)
                        {
                            r2 = dtChungC79_80_a_HD.NewRow();
                            r2["mahoa1"] = r["tennhom"];
                            r2["stt"] = d.getIndex(i_sttA) ;
                            dtChungC79_80_a_HD.Rows.Add(r2);
                            s_tennhom = r["tennhom"].ToString();
                            i_sttA++;
                            manhomthe++;
                        }
                        r2 = dtChungC79_80_a_HD.NewRow();
                        r2["stt"] = i_stt;
                        i_stt++;
                  //      r2["tennhom"] = r["tennhom"];                      
                        r2["mahoa1"] = r["mahoa1"];
                        r2["mahoa2"] = r["mahoa2"];
                        
                        r2["tenvp"] = r["tenvp"];
                        r2["dongia"] = r["dongia"];
                        r2["slngoaitru"] = r["slngoaitru"];
                        r2["slnoitru"] = r["slnoitru"];
                        r2["thanhtien"] = double.Parse(r["thanhtien_ngoaitru"].ToString()) + double.Parse(r["thanhtien_noitru"].ToString());
                        
                        r2["ghichu"] = r["mavp"];

             
                        dtChungC79_80_a_HD.Rows.Add(r2);
                    }
                    else
                    {
                        if (r["tennhom"].ToString().Equals(s_tennhom.ToString()) == false)
                        {
                            r2 = dtChungC79_80_a_HD.NewRow();
                            r2["mahoa1"] = r["tennhom"];
                            r2["stt"] =  d.getIndex(i_sttA) ;
                            dtChungC79_80_a_HD.Rows.Add(r2);
                            r["tennhom"].ToString();
                            i_sttA++;
                            manhomthe++;
                        }
                      r2 = dtChungC79_80_a_HD.NewRow();
                        r2["stt"] = i_stt;
                        i_stt++;
                     //   r2["tennhom"] = r["tennhom"];                      
                        r2["mahoa1"] = r["mahoa1"];
                        r2["mahoa2"] = r["mahoa2"];
                        r2["tenvp"] = r["tenvp"];
                        r2["dongia"] = r["dongia"];
                        r2["slngoaitru"] = r["slngoaitru"];
                        r2["slnoitru"] = r["slnoitru"];
                        r2["thanhtien"] = double.Parse(r["thanhtien_ngoaitru"].ToString()) + double.Parse(r["thanhtien_noitru"].ToString());
                        
                        r2["ghichu"] = r["mavp"];
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
                int be = 9, i_cot = 9, dong = 10, sodong = dtxml.Rows.Count + 10, socot = dtxml.Columns.Count - 1, dongke = sodong + 2;
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
                for (int k = 8; k < 9; k++)
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
                //s_tenBaoCao = "THỐNG KÊ DỊCH VỤ KỸ THUẬT THANH TOÁN BHYT ";
                osheet.Cells[2, socot - 6] = s_tenBaoCao;
                s_tieuDeExcel = "THỐNG KÊ DỊCH VỤ KỸ THUẬT THANH TOÁN BHYT ";
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

                osheet.Cells[7,5] = "Số lượng";
                orange = osheet.get_Range(d.getIndex(4) + "7", d.getIndex(5) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;
                /*
                osheet.Cells[7, 10] = "TỔNG CHI PHÍ KHÁM, CHỮA BỆNH BHYT";
                orange = osheet.get_Range(d.getIndex(9) + "7", d.getIndex(20) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[7, 23] = "Đề nghị BHXH thanh toán ";
                orange = osheet.get_Range(d.getIndex(22) + "7", d.getIndex(23) + "7");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[8, 11] = "Không áp dụng tỷ lệ thanh toán";
                orange = osheet.get_Range(d.getIndex(10) + "8", d.getIndex(15) + "8");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;

                osheet.Cells[8, 17] = "Thanh toán theo tỷ lệ";
                orange = osheet.get_Range(d.getIndex(16) + "8", d.getIndex(18) + "8");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.MergeCells = true;
                orange.Font.Bold = true;*/
                //megre cot 
                for (int i = 0; i < i_cot; i++)
                {
                    if (i==0 | i== 1|| i == 2 || i == 3 || i == 6 || i == 7 || i == 8 || i == 9 )
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "7", d.getIndex(i) + "9");
                        orange.MergeCells = true;
                    }
                    
                    else
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "8", d.getIndex(i) + "9");
                        orange.MergeCells = true;
                    }
                }/*
                //end 
                //end format cột 

                //footer
                osheet.Cells[sodong + 2, 1] = "Số tiền đề nghị thanh toán (viết bằng chữ) ";// +data.doiTienThanhSo(t_deNghiThanhToan);
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

             /*   osheet.Cells[sodong + 5, 15] = "Kế toán trưởng";
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
                orange.Font.Bold = true;*/
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
            string[] map ={ "STT", "STT theo quyết định phê duyệt giá", "Mã hóa DVKT ", "Tên dịch vụ y tế", "Ngoại trú", "Nội trú", "Đơn giá (đồng)", "Thành tiền (đồng)","Mã ICD9" };
            return map[i];
        }
        private string getSTT(int i)
        {
            string[] map ={"'(1)", "'(2)", "'(3)", "'(4)", "'(5)", "'(6)", "'(7)", "'(8)","'(9)'"};
            return map[i];
        }

        #endregion




    }

}