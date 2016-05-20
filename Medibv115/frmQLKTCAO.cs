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
using DataMySQL;
using LibBaocao;
using DataOracle;
using Entity;
namespace MediIT115
{
    public partial class frmQLKTCAO : Form
    {

        AccessData OraData;
        bool flagIsNew = false;
        string sql = "";
        public frmQLKTCAO()
        {
            InitializeComponent();
            
           
        }
        private void frmQLThietBi_Load(object sender, EventArgs e)
        {
            OraData = new AccessData();
            f_LoadListKhoaPhong();
            f_load_danhsach("");
       
    
         
          
        }
        #region LoadCombobox
      
     
        
      
       
        private void f_LoadListKhoaPhong()
        {
            try
            {
                
                sql="select makp from dlogin where id={0}";
                sql=sql.Replace("{0}",AccessData.m_userid);
                DataSet ds1 = OraData.get_data(sql);
                string s_makp = ds1.Tables[0].Rows[0][0].ToString();
                
                sql = "select MAKP ID,TENKP TEN ";
                sql += " FROM BTDKP_BV WHERE LOAI=0 AND KHU=1 ";
                if(s_makp.Length>0)
                {
                   sql+=" and makp in ("+s_makp+"-1)";
                }
                sql += " ORDER BY TENKP ";
                DataSet ds = OraData.get_data(sql);
            
                cbKhoaPhong.DataSource = ds.Tables[0];
                cbKhoaPhong.DisplayMember = "Ten";
                cbKhoaPhong.ValueMember = "ID";
                cbKhoaPhong.SelectedIndex = 0;
            }
            catch { }
        }
      
        
        #endregion
        private DateTime f_convert_toDate(string date)
        {
            
            
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            // Alternate choice: If the string has been input by an end user, you might  
            // want to format it according to the current culture: 
            // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            DateTime dt = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            return dt;
        }
       
        private void setList(ComboBox cb, string value)
        {
            try
            {
                DataTable dt = (DataTable)cb.DataSource;
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ID"].ToString() == value)
                    {
                        
                        cb.SelectedIndex = i;
                        return;
                    }
                    i++;
                }
            }
            catch { }   
        }
        private void f_load_danhsach(string timkiem)
        {
            try
            {
                sql = " select rownum STT,a.* from ( ";
                sql += "select hd.mabn mabn,bn.hoten HOTEN,ph.ten PHAI,bn.namsinh  NAMSINH,to_char(HD.NGAYVV,'dd/mm/yyyy hh24:mi') NGAYVV,dt.doituong,bh.sothe SOTHE, ";
                sql += " bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI, ";
                sql += "ba.chandoan || ';('||ba.MAICD||';)' CHANDOAN,ba.maicd MACID,bs.hoten tenbs,to_char(Bh.denngay,'dd/mm/yyyy') DENNGAY,ba.mavaovien,ba.maql ";
                sql += "from hiendien hd ";
                sql += "join btdbn bn on hd.mabn=bn.mabn ";
                sql += "join dmphai ph on ph.ma=bn.phai ";
                sql += "join benhandt ba on ba.mavaovien=hd.mavaovien ";
                sql += "join doituong dt on ba.madoituong=dt.madoituong ";
                sql += "join bhyt bh on bh.maql=ba.maql ";
                sql += "join btdpxa px on bn.maphuongxa=px.maphuongxa ";
                sql += "join btdquan qu on bn.maqu=qu.maqu ";
                sql += "join btdtt tt on bn.matt=tt.matt ";
                sql += "join dmbs bs on ba.mabs=bs.ma ";
                sql += "where  ba.madoituong in (1) and hd.nhapkhoa=1 and hd.xuatkhoa=0 and hd.makp='{0}' and hd.mabn like '%{1}%' ";
               
                sql += " ) a";


                sql = sql.Replace("{0}", cbKhoaPhong.SelectedValue.ToString());
                sql = sql.Replace("{1}", timkiem);

                DataSet ds = OraData.get_data(sql);

                dview.DataSource = ds.Tables[0];
            }
            catch { }
            
        }
        private void btRefesh_Click(object sender, EventArgs e)
        {
            f_load_danhsach(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            f_load_danhsach(txttimkiem.Text);
        }

        private void cbKhoaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_load_danhsach("");
        }

        private void toolNhapKTCAO_Click(object sender, EventArgs e)
        {

            try
            {
               
              
                frmKTCAO frm = new frmKTCAO("BV_KTCAO", "NHẬP KỸ THUẬT CAO", txtmabn.Text,txthoten.Text,txtmavaovien.Text,cbKhoaPhong.SelectedValue.ToString(),txtmaql.Text);
                frm.Show();
            }
            catch { }
        }
        

        private void dview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dview.CurrentCell.RowIndex;
                txtmabn.Text = dview.Rows[row].Cells[1].Value.ToString();
                txthoten.Text = dview.Rows[row].Cells[2].Value.ToString();
                txtmaql.Text = dview.Rows[row].Cells[14].Value.ToString();
                txtmavaovien.Text = dview.Rows[row].Cells[13].Value.ToString();
                txtTuNgay.Value=f_convert_toDate(dview.Rows[row].Cells[5].Value.ToString());
            }
            catch { }

        }

        private void toolSave_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AccessData d = new AccessData();
            CThanhToanBHYTOracle data = new CThanhToanBHYTOracle();
            
            //DataSet ds = data.f_loadBaoCaoMau20(tungay, denngay, "");

            DataSet ds = data.f_getv_ttrvkp_ct_ALL(txtmabn.Text, txtmavaovien.Text, txtTuNgay.Value, txtDenNgay.Value);
            frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_ct.rpt", "", "", "", "", "", "", "", "", "", "");
            a.Show();
        }

        private void ckttdot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckttdot.Checked == true)
            {
                pnttdot.Enabled = true;
            }
            else
            {
                pnttdot.Enabled = false;
            }

        }
        
     

       

       
    }
}