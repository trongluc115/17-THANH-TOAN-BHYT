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
    public partial class frmDanhMucThuocBH : Form
    {
        private string _tableName = "";
        private string _title = "";
        private List<string> Listthuock;
        AccessData OraData;
        string sql = "";
     
        private string _mabn = "";
        private string _mavaovien = "";
        private string _hoten = "";
        private string _makp = "";
        private string _maql = "";
        private DataSet dsdanhmuc;
        private int _tileBHYTtra = 0;
        DataTable dt_dmbd;
        
        bool flagIsNew = false;
        public frmDanhMucThuocBH()
        {
            InitializeComponent();
        }
        public frmDanhMucThuocBH(string tablename, string title)
        {
            _tableName = tablename;
            _title = title;
            InitializeComponent();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            txtToolStrip.Text = _title;
            init_cbloaiyc();
          f_loadDanhSach();
          //Listthuock = new List<string>();
          //  d_dmbdbh_Orace ora_dmbd=new d_dmbdbh_Orace();
          //  Listthuock = ora_dmbd.getDanhSachThuocK();
            
        }
        #region init
        private void init_cbloaiyc()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                DataTable dtdm_loaibc = dataOracle.get_NHOMXHH();
                cbLoai.DataSource = dtdm_loaibc;
                cbLoai.DisplayMember = "NAME";
                cbLoai.ValueMember = "ID";
               

            }
            catch { }
        }
        #endregion 
        private void f_loadDanhSach()
        {
            try
            {
                dDanhMuc.Rows.Clear();
                CDanhMucOracle ora_danhmuc = new CDanhMucOracle();
                 dt_dmbd= ora_danhmuc.get_danhmucbd_bhyt("");
                 foreach (DataRow dr in dt_dmbd.Rows)
                 {
                     dDanhMuc.Rows.Add(dr.ItemArray);
                 }
           //  dDanhMuc.DataSource = dt_dmbd;

            }
            catch { }

            
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            f_save();
        }
        private void f_save()
        {
            try
            {
                d_dmbdbh item = new d_dmbdbh();
                d_dmbdbh_Orace Ora_d_dmbdbh = new d_dmbdbh_Orace();
                int i = 0;
                foreach (DataGridViewRow row in dDanhMuc.Rows)
                {
                    try
                    {
                        item.ID=long.Parse(row.Cells["MaTB"].Value.ToString());
                        item.ID_TYPE = row.Cells[2].Value.ToString();
                        item.ENABLE = (row.Cells[3].Value.ToString().CompareTo("True") == 0 || row.Cells[3].Value.ToString().CompareTo("1") == 0 ? 1 : 0);
                        item.BHYT = int.Parse(row.Cells["BHYT"].Value.ToString());
                        Ora_d_dmbdbh.f_update(item);
                        if (i > 30)
                            break;
                        else
                            i++;
                    }
                    catch { }
                }

            }
            catch { }
        }
        private void controlToolStrip(string code)
        {
            switch (code)
            {
                case "new":
                    toolDelete.Enabled = false;
                    toolEdit.Enabled = false;

                    toolCancel.Enabled = true;
                    toolSave.Enabled = true;
                    
                    toolNew.Enabled = false;
                    flagIsNew = true;
                   
                    break;
                case "edit":
                    toolDelete.Enabled = false;
                    toolNew.Enabled = false;
                    toolSave.Enabled = true;

                    toolCancel.Enabled = true;
                    toolEdit.Enabled = false;
                    
                    flagIsNew = false;
                    break;
                case "cancel":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                    toolEdit.Enabled = true;
                    toolSave.Enabled = false;
                    
                    break;
                case "save":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                    toolEdit.Enabled = true;
                    toolSave.Enabled = false;
                    
                    break;

            }

        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            controlToolStrip("new");
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            controlToolStrip("edit");
        }

        private void dDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int row=dDanhMuc.CurrentCell.RowIndex;
                
            }
            catch { }
        }
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {



            try
            {
                dDanhMuc.Rows.Clear();
                CDanhMucOracle ora_danhmuc = new CDanhMucOracle();
                dt_dmbd = ora_danhmuc.get_danhmucbd_bhyt(txtsearch.Text);
                foreach (DataRow dr in dt_dmbd.Rows)
                {
                    dDanhMuc.Rows.Add(dr.ItemArray);
                }
                //  dDanhMuc.DataSource = dt_dmbd;

            }
            catch { }
               
                //try
                //{
                //    foreach (DataGridViewRow dr in dDanhMuc.Rows)
                //    {
                //        if (dr.Cells["ten"].Value.ToString().ToLower().IndexOf(txtsearch.Text.ToLower()) > 0)
                //            dr.Visible = true;
                //        else
                //            dr.Visible = false;
                //    }
                //}
                //catch { }
            
            

            

            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string reportname = "xuat_excel.rpt";
            d_dmbdbh_Orace Ora_dmbd = new d_dmbdbh_Orace();
            DataTable dt=new DataTable();
            AccessData d = new AccessData();
            dt=Ora_dmbd.getListBaoCaoFromChoice(m_format.DateTime_parse(haison1.tungay),m_format.DateTime_parse(haison1.denngay),cbLoaiBN.SelectedIndex.ToString());
            frmReport a = new frmReport(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void toolDelete_Click(object sender, EventArgs e)
        {
            d_dmbdbh_Orace Ora_dmbd = new d_dmbdbh_Orace();
            Ora_dmbd.f_updateall("d_dmbdbh", "0");
        }

        private void tbThuocDY_Click(object sender, EventArgs e)
        {
            string reportname = "xuat_excel.rpt";
            d_dmbdbh_Orace Ora_dmbd = new d_dmbdbh_Orace();
            DataTable dt = new DataTable();
            AccessData d = new AccessData();
            dt = Ora_dmbd.getListBaoCaoFromThuocDongY(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay));
            frmReport a = new frmReport(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }
        private void dDanhMuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string s_mavp = dDanhMuc.CurrentRow.Cells["MaTb"].Value.ToString();
                txtMaVPChoice.Text += "," + s_mavp;
                txtMaVPChoice.Text = txtMaVPChoice.Text.Trim(',');
            }
            catch { }
        }

        private void toolStripButtonFromList_Click(object sender, EventArgs e)
        {
            string reportname = "xuat_excel.rpt";
            d_dmbdbh_Orace Ora_dmbd = new d_dmbdbh_Orace();
            DataTable dt = new DataTable();
            AccessData d = new AccessData();
            dt = Ora_dmbd.getListBaoCaoFromList(m_format.DateTime_parse(haison1.tungay), m_format.DateTime_parse(haison1.denngay), cbLoaiBN.SelectedIndex.ToString(),txtMaVPChoice.Text);
            frmReport a = new frmReport(d, dt, reportname, "TỪ NGÀY " + haison1.tungay + " ĐẾN NGÀY " + haison1.denngay, "", "", "", "", "", "", "", "", "");
            a.Show();
        }
    }
}