using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;
using Entity;
namespace MediIT115
{
    public partial class frmDMnhanvien : Form
    {
        public frmDMnhanvien()
        {
            InitializeComponent();
        }

        private void frmDMnhanvien_Load(object sender, EventArgs e)
        {
            f_loadcbb();
            f_load();

        }
        private void f_load()
        {
            CDanhMucOracle dataOracle = new CDanhMucOracle();
            DMNV_Oracle nv_Oracle = new DMNV_Oracle();
            DataTable dtdm_dichvu = nv_Oracle.f_get("");
            dgridChiTiet.DataSource = dtdm_dichvu;

         
        }
        private void f_loadcbb()
        {
            try
            {
                CDanhMucOracle dataOracle = new CDanhMucOracle();

                DataTable dtdm_khoaphong = dataOracle.d_getDMKhoaPhongFromLoai("0");
                cbDanhMucKP.DataSource = dtdm_khoaphong;
                cbDanhMucKP.DisplayMember = "TEN";
                cbDanhMucKP.ValueMember = "ID";
                cbDanhMucKP.SelectedIndex = 0;

                DataTable dtdm_nhomnhanvien = dataOracle.d_getnhomnhanvien();                    
                cbNhom.DataSource = dtdm_nhomnhanvien;
                cbNhom.DisplayMember = "TEN";
                cbNhom.ValueMember = "ID";
                cbNhom.SelectedIndex = 0;

                DataTable dtdm_trinhdo = dataOracle.d_gettrinhdo();
                cbtrinhdo.DataSource = dtdm_trinhdo;
                cbtrinhdo.DisplayMember = "TEN";
                cbtrinhdo.ValueMember = "ID";
                cbtrinhdo.SelectedIndex = 0;

                DataTable dtdm_chuyenkhoa = dataOracle.d_getchuyenkhoa();
                cbchuyenkhoa.DataSource = dtdm_chuyenkhoa;
                cbchuyenkhoa.DisplayMember = "TEN";
                cbchuyenkhoa.ValueMember = "ID";
                cbchuyenkhoa.SelectedIndex = 0;
            }
            catch { }
        
        }
        private void Filt_Search(string ten)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[dgridChiTiet.DataSource];
                DataView list = (DataView)manager.List;
                list.RowFilter = "HOTEN like '%" + ten.Trim() + "%'";
            }
            catch
            {
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Filt_Search(txtTimKiem.Text);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {

        }

        private void cbLoai_Enter(object sender, EventArgs e)
        {

        }

        private void dgridChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                string s_id = dgridChiTiet.Rows[e.RowIndex].Cells["MA"].Value.ToString();
                txtID.Text = s_id;
            }
            catch { }
        }

        private void dgridChiTiet_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = dgridChiTiet.SelectedRows[0];
                string s_id = row.Cells["MA"].Value.ToString();
                txtID.Text = s_id;
            }
            catch { }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            f_loadct();
        }
        private void f_loadct()
        {
            try {
                CDanhMucOracle dataOracle = new CDanhMucOracle();
                DMNV_Oracle nv_Oracle = new DMNV_Oracle();
                DataTable dtdm_chitiet = nv_Oracle.f_getbyid(txtID.Text);
                txtHoTen.Text = dtdm_chitiet.Rows[0]["HOTEN"].ToString();
                txtDiaChi.Text = dtdm_chitiet.Rows[0]["DIACHI"].ToString();
                txtDienThoai.Text = dtdm_chitiet.Rows[0]["DIENTHOAI"].ToString();
                dngaysinh.Value = m_format.DateTime_parse(dtdm_chitiet.Rows[0]["NGAYSINH"].ToString());
                txtNgoaiNgu.Text = dtdm_chitiet.Rows[0]["NGONNGU"].ToString();
                setList(cbchuyenkhoa,dtdm_chitiet.Rows[0]["CHUYENKHOA"].ToString());
                
                txtbangcap.Text = dtdm_chitiet.Rows[0]["BANGCAP"].ToString();
                txtdtnuocngoai.Text = dtdm_chitiet.Rows[0]["DTNUOCNGOAI"].ToString();
                txtkinhnghiem.Text = dtdm_chitiet.Rows[0]["KINHNGHIEM"].ToString();
                setList( cbtrinhdo ,dtdm_chitiet.Rows[0]["TRINHDO"].ToString());
                setList(cbDanhMucKP, dtdm_chitiet.Rows[0]["MAKP"].ToString());
                setList(cbNhom, dtdm_chitiet.Rows[0]["MANHOM"].ToString());
                string s_phai= dtdm_chitiet.Rows[0]["PHAI"].ToString();
                cbPhai.SelectedIndex = int.Parse(s_phai);
              
            }
            catch { }
        }
        private void setList(ComboBox cb, string s_value)
        { 
            try{
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.SelectedValue.ToString() == s_value)
                    {
                        return;
                    }
                }
            }catch{}
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
            {
                f_update();
            }
            else
            {
                f_insert();
            }

            f_load();
        }
        private void f_update()
        {
            try{
            DMNV_Oracle NV_Oracle = new DMNV_Oracle();
            CDMNV nv=new CDMNV();
            nv.Ma = txtID.Text;
            nv.Hoten = txtHoTen.Text;
            nv.Ngaysinh = dngaysinh.Value;
            nv.Phai = cbPhai.SelectedIndex.ToString();
            nv.Dienthoai = txtDienThoai.Text;
            nv.Diachi = txtDiaChi.Text;
            nv.Makp = cbDanhMucKP.SelectedValue.ToString();
            nv.Nhom = cbNhom.SelectedValue.ToString();
            nv.Chuyenkhoa = cbchuyenkhoa.SelectedValue.ToString();
            nv.Ngonngu = txtNgoaiNgu.Text;            
            nv.Bangcap = txtbangcap.Text;
            nv.Dtnuocngoai = txtdtnuocngoai.Text;
            nv.Kinhnghiem = txtkinhnghiem.Text;
            nv.Trinhdo = cbtrinhdo.SelectedValue.ToString();

            NV_Oracle.f_update(nv);
            }catch{}
        }
        private void f_insert()
        {
            try
            {
                DMNV_Oracle NV_Oracle = new DMNV_Oracle();
                CDMNV nv = new CDMNV();
                Capid_Oracle Id_oracle = new Capid_Oracle();
                string s_id=Id_oracle.f_get("DMNV");
                Id_oracle.f_update_one("DMNV");
                
                nv.Ma = int.Parse(s_id).ToString("D4");
                txtID.Text = nv.Ma;
             
                nv.Hoten = txtHoTen.Text;
                nv.Ngaysinh = dngaysinh.Value;
                nv.Phai = cbPhai.SelectedIndex.ToString();
                nv.Dienthoai = txtDienThoai.Text;
                nv.Diachi = txtDiaChi.Text;
                nv.Makp = cbDanhMucKP.SelectedValue.ToString();
                nv.Nhom = cbNhom.SelectedValue.ToString();
                nv.Chuyenkhoa = cbchuyenkhoa.SelectedValue.ToString();
                nv.Ngonngu = txtNgoaiNgu.Text;                
                nv.Bangcap = txtbangcap.Text;
                nv.Dtnuocngoai = txtdtnuocngoai.Text;
                nv.Kinhnghiem = txtkinhnghiem.Text;
                nv.Trinhdo = cbtrinhdo.SelectedValue.ToString();

               NV_Oracle.f_insert(nv);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                txtID.Text = "";
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                txtbangcap.Text = "";
                
                txtDienThoai.Text = "";
                txtdtnuocngoai.Text = "";
                txtkinhnghiem.Text = "";
                txtNgoaiNgu.Text = "";
                

            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        # region list

      

       
      

       
        #endregion 

      
     
     
    }
}
