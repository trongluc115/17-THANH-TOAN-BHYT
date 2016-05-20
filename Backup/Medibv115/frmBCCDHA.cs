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
    public partial class frmBCCDHA: Form
    {
        public frmBCCDHA()
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
            frmReport a = new frmReport(d, dt, reportname, title, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void frmBCDuocMau20_Load(object sender, EventArgs e)
        {
            cbLoai.SelectedIndex = 0;
                        
            cdha_hen_Oracle Data_cdha_hen = new cdha_hen_Oracle();
            treeview_room.setDataSource(Data_cdha_hen.f_getCDHA_NOITHUCHIEN(AccessData.s_makhuvuc).Tables[0], "Name", "Id", "NƠI THỰC HIỆN", false, "NƠI THỰC HIỆN"); 
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
                DataTable dt = dvll.f_getBAOCAO_CDHA_PHIM(tungay, denngay, treeview_room.get_Ma);
                frmReport a = new frmReport(d, dt, reportname, title, "ht","gd", "", "", "", "", "", "", "");
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
            DataTable dt = dvll.f_getBAOCAO_CDHA_M02_dathuchien(tungay, denngay, treeview_room.get_Ma);
            frmReport a = new frmReport(d, dt, reportname, title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }
    }
}