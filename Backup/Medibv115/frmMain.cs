using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entity;
using DataMySQL;
using LibBaocao;
using System.Globalization;
namespace MediIT115
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

      

        private void d01BáoCáoThuốcBHYTNgoạiTrúM20BVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCDuocMau20 frm = new frmBCDuocMau20();
            frm.MdiParent = this;
            frm.Show();
        }

       

        private void duyệtBHYTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDuyetBHYTNgoaiTru frm = new frmDuyetBHYTNgoaiTru();
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoBHYTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBaoCaoNoiTruBHYT frm = new frmBaoCaoNoiTruBHYT("1");
            frm.MdiParent = this;
            frm.Show();
        }

        private void duyệtBHYTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDuyetBHYTNoiTru frm = new frmDuyetBHYTNoiTru();
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoBHYTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBaoCaoNoiTruBHYT frm = new frmBaoCaoNoiTruBHYT("0");
            frm.MdiParent = this;
            frm.Show();
        }

        private void thôngSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trangThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLThietBi frm = new frmQLThietBi();
            frm.MdiParent = this;
            frm.Show();
        }

       

        private void yêuCầuChỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLYeuCau frm = new frmQLYeuCau();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nhậnTrảThẻBHYTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLKTCAO frm = new frmQLKTCAO();
            frm.MdiParent = this;
            frm.Show();
        }
        private void initformatRegion()
        {
            try
            {

                CultureInfo culture = new CultureInfo("en-US");
                DateTime date = DateTime.Now;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            }
            catch { }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
              //  việnPhíToolStripMenuItem.Visible = true;
               // dượcToolStripMenuItem.Visible = true;
                f_loadMenu();
            }
            catch { }
        }
        private void f_loadMenu()
        {
            string right = "";

            string[] list_right = new string[100];
            try
            {
                string sql = "";
                sql = " select right_";
                sql += " from bv115.bv_dlogin log ";
                sql += " where id=@userid";
                sql = sql.Replace("@userid", AccessData.m_userid);
                AccessData OraData = new AccessData();
                DataSet ds = OraData.get_data(sql);
                right = ds.Tables[0].Rows[0][0].ToString();
                list_right = right.Split('+');
                f_setVisibleAllMenu(false);
                foreach (string item in list_right)
                {
                    f_setVisibleMenu(item, true);
                }


            }
            catch { }
        }
        private void f_setVisibleMenu(string name, bool visible_value)
        {
            try
            {
                foreach (ToolStripMenuItem mnItem in msmenu.Items)
                {
                    for (int i = 0; i < mnItem.DropDown.Items.Count; i++)
                    {
                        if (mnItem.DropDown.Items[i].Name.CompareTo(name) == 0)
                        {
                            mnItem.DropDown.Items[i].Visible = visible_value;
                        }

                    }
                }
            }
            catch { }
        }
        private void f_setVisibleAllMenu(bool visible_value)
        {
            try
            {
                foreach (ToolStripMenuItem mnItem in msmenu.Items)
                {
                    for (int i = 0; i < mnItem.DropDown.Items.Count; i++)
                    {
                        mnItem.DropDown.Items[i].Visible = visible_value;


                    }
                }
            }
            catch { }
        }
        private void trảThẻBHYTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLBHYT_trathe frm = new frmQLBHYT_trathe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiếpNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiepNhanKB frm = new frmTiepNhanKB();
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoBảoTrìToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportQLMay frm = new frmReportQLMay();
              

            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoKiểmKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportKiemKe frm = new frmReportKiemKe();


            frm.MdiParent = this;
            frm.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdoimatkhau frm = new frmdoimatkhau();
            frm.Show();
        }

        private void d02BáoBáoXNCLSMẫu21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCCLSMau21 frm = new frmBCCLSMau21();
            frm.MdiParent = this;
            frm.Show();
        }

        private void danhMụcNhómBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucORA frm = new frmDanhMucORA("BV115.dm_nhombc", "NHÓM BÁO CÁO");
            frm.MdiParent = this;
            frm.Show();
        }

        private void danhMụcBiệtDượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucThuocBH frm = new frmDanhMucThuocBH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void danhMụcViệnPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucVienPhiBH frm = new frmDanhMucVienPhiBH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void M0303_Click(object sender, EventArgs e)
        {
            frmDuyetBHYTEdit frm = new frmDuyetBHYTEdit();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void M0304_Click(object sender, EventArgs e)
        {

            frmBaoCaoNoiTruBHYTEdit frm = new frmBaoCaoNoiTruBHYTEdit("0");
            frm.MdiParent = this;
            frm.Show();
        }
    }
}