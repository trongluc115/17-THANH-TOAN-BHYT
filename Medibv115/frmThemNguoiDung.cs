using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;

namespace MediIT115
{
    public partial class frmThemNguoiDung : Form
    {
        CThemNguoiDung cuser = new CThemNguoiDung();
        DataSet dsr = new DataSet();
        private int i_id = 0;
        private string s_psw = "", s_tenDangNhap = "", s_right = "", s_hoTen="";
        private bool bSua = false;
        public frmThemNguoiDung(DataSet dset)
        {
            InitializeComponent();
            dsr = dset;
        }
        public frmThemNguoiDung(DataSet dset, int userid,string hoTen, string tenDangNhap, string psw, string right, bool change)
		{
			InitializeComponent();
            dsr = dset; i_id = userid;
            s_tenDangNhap = tenDangNhap; s_psw = psw; s_right = right;
            s_hoTen = hoTen;
            bSua = change;
		}
        public DataSet dsright
        {
            get
            {
                return dsr;
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (bKiemTra()==true)
            {
                cuser.upd_ins_bv_login(i_id, txtHoTen.Text, txtTenDangNhap.Text, txtMatKhau.Text);
                cuser.updrec(dsr.Tables[0], i_id, txtTenDangNhap.Text, txtMatKhau.Text, txtHoTen.Text);
                MessageBox.Show("Lưu thành công !","BV115");
            }
        }
        private bool bKiemTra()
        {
            if (txtHoTen.Text.Trim(' ') == "")
            {
                MessageBox.Show("Họ tên không được trống !","BV115");
                txtHoTen.Focus();
                return false;
            }
            if (txtTenDangNhap.Text.Trim(' ') == "")
            {
                MessageBox.Show("Tên đăng nhập không được trống !", "BV115");
                txtTenDangNhap.Focus();
                return false;
            }

            if (txtMatKhau.Text.Trim(' ') == "")
            {
                MessageBox.Show("Mật khẩu không được trống !", "BV115");
                txtMatKhau.Focus();
                return false;
            }
            if (txtMatKhauNhapLai.Text.Trim(' ') == "")
            {
                MessageBox.Show("Mật khẩu nhập lại không được trống !", "BV115");
                txtMatKhauNhapLai.Focus();
                return false;
            }
            if (txtMatKhau.Text != txtMatKhauNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp, vui lòng kiểm tra lại!", "BV115");
                txtMatKhauNhapLai.Focus();
                return false;
            }
            return true;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            if (bSua == true)
            {
                i_id = i_id;
                txtHoTen.Text = s_hoTen;
                txtTenDangNhap.Text = s_tenDangNhap;
            }
            else
            {
                i_id = cuser.maxid_bv_login() + 1;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatKhauNhapLai_TextChanged(object sender, EventArgs e)
        {
            //if (txtMatKhau.Text != txtMatKhauNhapLai.Text)
            //{ 
            //    MessageBox.Show("Mật khẩu nhập lại không khớp, vui lòng kiểm tra lại!","BV115");
            //    txtMatKhauNhapLai.Focus();
            //    return;
            //}
        }

    }
}