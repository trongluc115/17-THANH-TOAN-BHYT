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
using Data;
namespace MediIT115
{
    public partial class frmBCCDHA_DV : Form
    {
        public frmBCCDHA_DV()
        {
            InitializeComponent();
        }

        private void btInBaoCao_Click(object sender, EventArgs e)
        {
         
            AccessData d = new AccessData();
            string reportname = "rpt_baocaoCDHA_DV_M01DT.rpt";
            cdha_dvll_Oracle dvll = new cdha_dvll_Oracle();
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);
            int loai = cbLoai.SelectedIndex;
            switch(loai)
            {
                case 1:reportname = "rpt_baocaoCDHA_DV_M01DT_MONTH.rpt"; 
                    break;
                case 2:reportname = "rpt_baocaoCDHA_DV_M01DT_NHOM.rpt"; 
                    break;
            }
            
            string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
            DataTable dt = dvll.f_getBAOCAO_M01(tungay,denngay,AccessData.s_makhuvuc);
            frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, txtGiamDoc.Text, "", "", "", "", "", "", "");
            a.Show();
        }

        private void frmBCDuocMau20_Load(object sender, EventArgs e)
        {
            cbLoai.SelectedIndex = 0;
            CDanhMucOracle dm = new CDanhMucOracle();
            treeView_HAISON1.setDataSource(dm.d_getDMNhomCDHA(AccessData._NHOM_CDHA), "ten", "id", "Danh mục Nhóm BHYT", false, "Chọn Nhóm CDHA để báo cáo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
          
                

                AccessData d = new AccessData();
                string reportname = "BCPHIM.rpt";
                cdha_dvll_Oracle dvll = new cdha_dvll_Oracle();
                DateTime tungay = m_format.DateTime_parse(haison1.tungay);
                DateTime denngay = m_format.DateTime_parse(haison1.denngay);
                if (cbLoai.SelectedIndex == 1) reportname = "BCPHIM_MONTH.rpt";
                string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
                DataTable dt = dvll.f_getBAOCAO_PHIMDV(tungay, denngay, treeView_HAISON1.get_Ma.Trim(','));
                frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, txtGiamDoc.Text, "", "", "", "", "", "", "");
                a.Show();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            string reportname = "rpt_baocaoCDHA_DV_M02.rpt";
            int loai = cbLoai.SelectedIndex;
            switch (loai)
            {
                case 1: reportname = "rpt_baocaoCDHA_DV_M02_MONTH.rpt";
                    break;
                case 2: reportname = "rpt_baocaoCDHA_DV_M02_NHOM.rpt";
                    break;
            }
            cdha_dvll_Oracle dvll = new cdha_dvll_Oracle();
            DateTime tungay = m_format.DateTime_parse(haison1.tungay);
            DateTime denngay = m_format.DateTime_parse(haison1.denngay);
            string title = haison1.s_title.Replace("Báo cáo ", "").ToUpper();
            DataTable dt = dvll.f_getBAOCAO_M02_dathuchien(tungay, denngay, treeView_HAISON1.get_Ma.Trim(','));
            frmReport a = new frmReport(d, dt, reportname, title, txtHoTen.Text, "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }
    }
}