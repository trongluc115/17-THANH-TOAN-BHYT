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

namespace MediIT115
{
    public partial class frmKTCvattu : Form
    {

        private string s_idduyet = "";
        private string s_hoten = "";
        private string s_sotien = "";
        public frmKTCvattu()
        {
            InitializeComponent();
        }
        public frmKTCvattu(string S_idduyet,string Hoten,string Sotien)
        {
            InitializeComponent();
            s_idduyet = S_idduyet;
            txtHoten.Text = Hoten;
            s_sotien =f_clearDot(Sotien);
            txtvtyttl.Text =f_insertDot(s_sotien);
        }
        private void f_load()
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
            CThanhToanBHYTOracleVienPhi dataOracleVP = new CThanhToanBHYTOracleVienPhi();
                     
            DataTable dtcp = dataOracleVP.f_getv_ttrvkp_ct_ALL_FROMVPKTC(s_idduyet);

            dview.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                dview.Rows.Add(item.ItemArray);
            }
            f_Sum();

        }
        private void frmKTCvattu_Load(object sender, EventArgs e)
        {
            f_init_addmodul();
            f_load();
           
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
           
            cbdoituong.DataSource = dataOracle.d_getDMDoiTuong();
            cbdoituong.DisplayMember = "ten";
            cbdoituong.ValueMember = "ma";
            cbdoituong.SelectedIndex = 0;



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

        private void btThem_Click(object sender, EventArgs e)
        {
            f_add_dichvu();
            f_Sum();
            txtSL.Text = "1";
            txtDonGia.Text = "";
            txtNameVP.Select();
        }

        private void txtSL_Enter(object sender, EventArgs e)
        {
            CDanhMucOracle OraDanhmuc = new CDanhMucOracle();
            txtDonGia.Text = OraDanhmuc.f_getgiaVP(txtIDVP.Text).ToString();
            txtNameVP.Text = OraDanhmuc.f_getNameVP(txtIDVP.Text).ToString();
        }

        private void listicd10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void f_add_dichvu()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                int row = dview.RowCount;
                dview.Rows.Add();
                dview.Rows[row].Cells["MaVP"].Value = txtIDVP.Text;
                dview.Rows[row].Cells["TenVP"].Value = txtNameVP.Text;
                dview.Rows[row].Cells["SL"].Value = txtSL.Text;
                dview.Rows[row].Cells["DonGia"].Value = txtDonGia.Text;
                dview.Rows[row].Cells["MaDoiTuong"].Value = cbdoituong.SelectedValue.ToString();
                dview.Rows[row].Cells["idnhombhyt"].Value = dataOracle.f_get_idnhombhyt(txtIDVP.Text);
                dview.Rows[row].Cells["Makp"].Value = cbDanhMucKP.SelectedValue.ToString();
                dview.Rows[row].Cells["tenkp"].Value = cbDanhMucKP.Text;             
              
                dview.Rows[row].Cells["IDKHOA"].Value = "0";
                dview.Rows[row].Cells["BHYTTRA"].Value =0;     
               // dview.Rows[row].DefaultCellStyle.BackColor = Color.Yellow;



            }
            catch { }
        }
        private void f_Sum()
        {
            double d_sum = 0;
            double bhyttra = 0;
            double bntra = 0;
            double thanhtien = 0;
            double soluong = 0;
            double dongia = 0;
        
            d_dmbdbh_Orace ORA_dmbd = new d_dmbdbh_Orace();
            foreach (DataGridViewRow item in dview.Rows)
            {

                soluong = double.Parse(item.Cells["SL"].Value.ToString());
                dongia = double.Parse(item.Cells["DONGIA"].Value.ToString());
                thanhtien = soluong * dongia;                        
                 
               
                item.Cells["TONGTIEN"].Value = thanhtien;
                item.Cells["BNTRA"].Value = 0;
                d_sum += thanhtien;
                bhyttra +=  double.Parse(item.Cells["BHYTTRA"].Value.ToString());
               
              
               

            }
            d_sum = Math.Round(d_sum, 0);
            txtSum.Text = f_insertDot( d_sum.ToString());
            txtSumBHYT.Text = f_insertDot(Math.Round(bhyttra, 0).ToString());

        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            f_luu_ct(s_idduyet);
        }
        private bool f_luu_ct(string id)
        {
            try
            {
             
                float float_pro = 0;
                v_bhytktc_Oracle vktcOracle = new v_bhytktc_Oracle();
                vktcOracle.f_delete(long.Parse(id));
                int stt = 1;
                foreach (DataGridViewRow item in dview.Rows)
                {
                    v_bhytct vct = new v_bhytct();
                    vct.ID = long.Parse(id);
                    vct.STT = stt;
                    vct.NGAY = DateTime.Today;
                    vct.MAKP = item.Cells["MAKP"].Value.ToString();
                    vct.MADOITUONG = item.Cells["MADOITUONG"].Value.ToString();
                    vct.MAVP = item.Cells["MAVP"].Value.ToString();
                    vct.SOLUONG = float.Parse(item.Cells["SL"].Value.ToString());
                    vct.DONGIA = double.Parse(item.Cells["DONGIA"].Value.ToString());
                    vct.SOTIEN = vct.DONGIA * vct.SOLUONG;
                    vct.BHYTTRA = double.Parse(item.Cells["BHYTTRA"].Value.ToString());

                  //  vct.IDTONGHOP = double.Parse(item.Cells["ID"].Value.ToString());
                    vct.IDNHOMBHYT = int.Parse(item.Cells["IDNHOMBHYT"].Value.ToString());
                    try
                    {
                        vct.ID_KTCAO = long.Parse(item.Cells["idktcao"].Value.ToString());
                    }
                    catch { }
                    vktcOracle.f_insert(vct);
                  

                    stt++;

                }
            }
            catch { return false; }
           
            return true;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            v_bhytktc_Oracle vktcOracle = new v_bhytktc_Oracle();
            vktcOracle.f_delete(long.Parse(s_idduyet));
            f_load();
        }
        private string f_insertDot(string s)
        {
            string result = "";
            string temp = s;
            string num = "";
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
        private string f_clearDot(string s)
        {
            return s.Replace(".", "");
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            f_Sum();
        }

        private void dview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            f_Sum();
        }

        private void btgetdata_Click(object sender, EventArgs e)
        {
            f_loadfromVP();
        }
        void f_loadfromVP()
        {
            CThanhToanBHYTOracleNoiTru dataOracle = new CThanhToanBHYTOracleNoiTru();
            CThanhToanBHYTOracleVienPhi dataOracleVP = new CThanhToanBHYTOracleVienPhi();

            DataTable dtcp = dataOracleVP.f_getv_ttrvkp_ct_ALL_FROM_BHYTCT(s_idduyet);

            dview.Rows.Clear();

            foreach (DataRow item in dtcp.Rows)
            {
                dview.Rows.Add(item.ItemArray);
            }
            f_Sum();
        }

        private void dview_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            f_Sum();
        }

        private void btloadbh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dview.Rows)
            {





                item.Cells["BHYTTRA"].Value = item.Cells["TONGTIEN"].Value;
            




            }
        }
        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F3)
                {

                    f_loadfromVP();
                }

                // Ctrl + O
                if (e.KeyCode == Keys.F5)
                {
                    f_luu_ct(s_idduyet);

                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();

                }


            }
            catch { }
        }

    }
}
