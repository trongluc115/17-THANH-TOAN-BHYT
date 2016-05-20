using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;
using Entity;
using LibBaocao;
namespace MediIT115
{
    public partial class frmQLDAOTAO : Form
    {
        private string S_idnhom;
        public frmQLDAOTAO()
        {
            InitializeComponent();
        }
        public frmQLDAOTAO(string s_idnhom)
        {
            InitializeComponent();
            S_idnhom = s_idnhom;
        }

        private void frmQLDAOTAO_Load(object sender, EventArgs e)
        {
            f_init_addmodul();
        }
        private void f_init_addmodul()
        {
            CDanhMucOracle dataOracle = new CDanhMucOracle();
            DMNV_Oracle nv_Oracle = new DMNV_Oracle();
            DataTable dtdm_dichvu = nv_Oracle.f_get("");


            listicd10.DataSource = dtdm_dichvu;
            listicd10.DisplayMember = "HOTEN";
            listicd10.ValueMember = "MA";


            /*DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhong();
            cbDanhMucKP.DataSource = dtdm_khoaphong;
            cbDanhMucKP.DisplayMember = "TEN";
            cbDanhMucKP.ValueMember = "ID";
            cbDanhMucKP.SelectedIndex = 0;*/

            DataTable dtdm_dt_loai = dataOracle.d_getDMDT_LOAI(S_idnhom);
            cbLoai.DataSource = dtdm_dt_loai;
            cbLoai.DisplayMember = "TEN";
            cbLoai.ValueMember = "ID";
            cbLoai.SelectedIndex = 0;


          



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
                    DMNV_Oracle OraDanhmuc = new DMNV_Oracle();
               
                    txtNameVP.Text = OraDanhmuc.f_get(txtIDVP.Text).Rows[0]["HOTEN"].ToString();

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
                list.RowFilter = "HOTEN like '%" + ten.Trim() + "%'";
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
                    cbLoai,
                    txtIDVP.Location.X,
                   txtIDVP.Location.Y + txtIDVP.Height,
                    (txtIDVP.Width + txtNameVP.Width),
                    txtIDVP.Height);

            }
        }


        #endregion 

        private void cbDanhMucKP_Enter(object sender, EventArgs e)
        {
           
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            frmDMnhanvien frm = new frmDMnhanvien();
            frm.Show();
        }

        private void cbLoai_Enter(object sender, EventArgs e)
        {
            try
            {
                DMNV_Oracle OraDanhmuc = new DMNV_Oracle();
                DataTable nhanvien=OraDanhmuc.f_get(txtIDVP.Text);
                txtNameVP.Text = nhanvien.Rows[0]["HOTEN"].ToString();
                lbngaysinh.Text = nhanvien.Rows[0]["NGAYSINH"].ToString();
                lbdiachi.Text = nhanvien.Rows[0]["DIACHI"].ToString();
                lbdienthoai.Text = nhanvien.Rows[0]["DIENTHOAI"].ToString();
                lbbangcap.Text = nhanvien.Rows[0]["BANGCAP"].ToString();
                lbngoaingu.Text = nhanvien.Rows[0]["NGONNGU"].ToString();
                lbdtnn.Text = nhanvien.Rows[0]["DTNUOCNGOAI"].ToString();
                lbkhoaphong.Text = nhanvien.Rows[0]["TENKP"].ToString();
                lbnhom.Text = nhanvien.Rows[0]["TENNHOM"].ToString();
                lbtrinhdo.Text = nhanvien.Rows[0]["TRINHDO"].ToString();
                lbkinhnghiem.Text = nhanvien.Rows[0]["KINHNGHIEM"].ToString();
                f_loadchitiet();
            }
            catch { }

        }
        public void f_loadchitiet()
        {
            try {
                DT_history_Oracle OraDTHis = new DT_history_Oracle();
                DataTable dt_history = new DataTable();
                dt_history = OraDTHis.f_get(txtIDVP.Text,S_idnhom);
                dgridChiTiet.Rows.Clear();
                foreach (DataRow dr in dt_history.Rows)
                {
                    dgridChiTiet.Rows.Add(dr.ItemArray);
                }
                
            }
            catch { }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            f_save();
        }
        private void f_save()
        {
            try
            {
                DT_history_Oracle dt_hisOra = new DT_history_Oracle();
                CDT_history his = new CDT_history();
                
                his.Id_loai = cbLoai.SelectedValue.ToString();
                his.Mabs = txtIDVP.Text;
                his.Noidung = txtNoiDung.Text;
                his.Ngay = dNgayLamViec.Value;
                his.Tungay = dtungay.Value;
                his.Denngay = ddenngay.Value;
                try
                {
                    his.Value = double.Parse(txtValue.Text);
                }
                catch { }

                dt_hisOra.f_insert(his);
                f_loadchitiet();
            }
            catch { }
        }

        private void dgridChiTiet_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow row = dgridChiTiet.SelectedRows[0];
                string s_id = row.Cells["ID"].Value.ToString();
                if (MessageBox.Show("Bạn muốn xóa dòng này không?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DT_history_Oracle dt_hisOra = new DT_history_Oracle();
                    dt_hisOra.f_delete(s_id);
                    f_loadchitiet();
                }
            }
            catch { }
        }

        private void btprint_Click(object sender, EventArgs e)
        {
            print_SYLL();
        }
        private void print_SYLL()
        {
           AccessData d = new AccessData();
            DT_history_Oracle dt_hisOra = new DT_history_Oracle();         

            DataTable dt = dt_hisOra.f_gettoreport(txtIDVP.Text) ;
            frmReport a = new frmReport(d, dt, "rpt_llnhanvien.rpt", "", "", "", "", "", "", "", "", "", "");
            a.Show();
        }
    }
}
