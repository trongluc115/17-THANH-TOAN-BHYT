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


namespace MediIT115
{
    public partial class frmDanhSachHen : Form
    {
     
        string _loaibn = "1";// 0 noitru,1 ngoaitru
        public frmDanhSachHen()
        {
            InitializeComponent();
        }
        private void init_cbKhoaPhong()
        {

            CDanhMucOracle dataOracle = new CDanhMucOracle();
            
            bv_dlogin log = new bv_dlogin();
            CLoginOracle logOra = new CLoginOracle();
            log = logOra.f_getUser(AccessData.m_userid);
            System.Data.DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong(log.Khoaphong);
            //System.Data.DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong();
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

        private void frmDanhSachHen_Load(object sender, EventArgs e)
        {
            init_cbKhoaPhong();
            init();
        }
        private void init()
        {
            try
            {
                DataSet ds=new DataSet();
                cdha_hen_Oracle Data_cdha_hen = new cdha_hen_Oracle();
                //ds = Data_cdha_hen.f_getCDHA_Loai("");
                //cbCDHA_loai.DataSource = ds.Tables[0];
                //cbCDHA_loai.DisplayMember = "Name";
                //cbCDHA_loai.ValueMember = "ID";
                //cbCDHA_loai.SelectedIndex = 0;

                ds = Data_cdha_hen.f_getCDHA_NOITHUCHIEN("-1");
                cbarea.DataSource = ds.Tables[0];
                cbarea.DisplayMember = "Name";
                cbarea.ValueMember = "ID";
                cbarea.SelectedIndex = 0;

               
                
            }
            catch { }
        }
        private void f_loaddsdaduyet()
        {
            cdha_hen_Oracle dvll_Ora = new cdha_hen_Oracle();
            DateTime tungay = d_tungay.Value;
            DateTime denngay = d_denngay.Value;

            string s_makp;
            try
            {
                s_makp = cbDanhMucKP.SelectedValue.ToString();
            }
            catch
            {
                s_makp = "-1";
            }
            
            DataTable dtcp = dvll_Ora.f_getCLS_DADUYET_KHOA(tungay, denngay, s_makp);
            ddsdaduyet.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                ddsdaduyet.Rows.Add(item.ItemArray);
            }
            format_grid();
        }
        private void format_grid()
        {
            try
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
            catch { }
        }

        private void cbDanhMucKP_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_loaddsdaduyet();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            f_loaddsdaduyet();
        }

        private void btListHen_Click(object sender, EventArgs e)
        {
            cdha_hen_Oracle dvll_Ora = new cdha_hen_Oracle();
            DateTime tungay = d_tungay.Value;
            DateTime denngay = d_denngay.Value;
            string s_makp;
            try{
                s_makp= cbDanhMucKP.SelectedValue.ToString();
            }catch{
                s_makp = "-1";
            }

            DataTable mydt = dvll_Ora.f_getCLS_DADUYET_KHOA(tungay, denngay, s_makp);
            AccessData d = new AccessData();
            string s_reportname = "danhsachhen_bc.rpt";
            string s_title = "";
            frmReport a = new frmReport(d, mydt, s_reportname, s_title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_loaddsxeplich();
        }
        private void f_loaddsxeplich()
        {
            try
            {
                cdha_hen_Oracle dvll_Ora = new cdha_hen_Oracle();
                DateTime tungay = d_tungay.Value;
                DateTime denngay = d_denngay.Value;
//                string s_dieukien "";= cbCDHA_loai.SelectedValue.ToString();
                string s_noithuchien = cbarea.SelectedValue.ToString();
                DataTable dtcp = dvll_Ora.f_getCLS_DADUYET(tungay, denngay,"", s_noithuchien);
                dsxeplich.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dsxeplich.Rows.Add(item.ItemArray);
                }
                format_grid();
            }
            catch { }
        }
    }
}