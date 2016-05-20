using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibBaocao;
using DataMySQL;
using DataOracle;
namespace MediIT115
{
    public partial class frmKTCAO : Form
    {

        AccessData OraData;
        string sql = "";
        private string _tableName = "";
        private string _title = "";
        private string _mabn = "";
        private string _mavaovien = "";
        private string _hoten = "";
        private string _makp = "";
        private string _maql="";
        private DataSet dsdanhmuc;
        private int _tileBHYTtra = 0;

        bool flagIsNew = false;
        public frmKTCAO()
        {
            
            InitializeComponent();
        }
        public frmKTCAO(string tablename, string title)
        {
            _tableName = tablename;
            _title = title;
            InitializeComponent();
        }
        public frmKTCAO(string tablename, string title,string mabn, string hoten, string mavaovien,string makp,string maql)
        {
            _tableName = tablename;
            _title = title;
            _mabn = mabn;
            _mavaovien = mavaovien;
            _hoten = hoten;
            _makp = makp;
            _maql=maql;
           
            OraData = new AccessData();
            
            InitializeComponent();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            txtToolStrip.Text = _title;
            dsdanhmuc = new DataSet();
            txtMaBN.Text = _mabn;
            txtTen.Text = _hoten;
            _tileBHYTtra = f_gettileBHYTtra();
            lbcp1.Text = lbcp1.Text.Replace("{tile_BHYT}",_tileBHYTtra.ToString());
            f_loaddanhmucKTC();
            f_loaddanhmucVattu();
            f_loaddanhmucKTCTimKiem(" ");
            f_loadDanhSach();
            dgridtimkiem.Visible = false;
            controlToolStrip("cancel");
            panel1.Enabled = false;

            
        }
        private void f_loaddanhmucKTC() 
        {
                try
                {
                    sql = " select vp.id ma, vp.ten ten from v_giavp vp  where   vp.gia_cu=0 ";
                    dsdanhmuc = OraData.get_data(sql);
                }
                catch { }
        }
        private void f_loaddanhmucVattu()
        {

            try
            {
                sql = " select vp.id ma, vp.ten||' '||vp.hamluong ten from d_dmbd vp  ";
                cstext.set_labelname("Tên vật tư");
                DataSet dsvattu = OraData.get_data(sql);
                cstext.set_dateSource(dsvattu.Tables[0]);
            }
            catch { }

        }
        private void f_loaddanhmucKTCTimKiem(string timkiem)
        {

            try
            {
                dgridtimkiem.Rows.Clear();
                DataTable dt=dsdanhmuc.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString().ToLower().IndexOf(timkiem.ToLower()) > 0)
                    {
                        dgridtimkiem.Rows.Add(item.ItemArray);
                    }
                }
                
            }
            catch { }

        }
        private string f_clearDot(string s)
        {
            return s.Replace(".", "");
        }
        private string f_insertDot(string s)
        {
            string result = "";
            string temp = f_clearDot(s);
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
        private void TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)sender;
                textbox.Text = f_insertDot(textbox.Text);

            }
            catch { }
        }
        private void TextBox_Setfocus(object sender, EventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)sender;
                textbox.Text = f_clearDot(textbox.Text);
            }
            catch { }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {

                    case Keys.Down: dgridtimkiem.Select();
                        break;
                    case Keys.Up: dgridtimkiem.Select();
                        break;
                    case  Keys.Escape:
                        dgridtimkiem.Visible = false;
                        break;
                    case  Keys.Tab: 
                        if(txtmavp.Text.Length == 0)
                            MessageBox.Show("Chọn kỹ thuật cao");
                        break;
                    case Keys.Enter:
                        dgridtimkiem.Visible = false;
                        SendKeys.Send("(Tab}");
                        break;
                }
               

            }
            catch { }
        }

        private void Control_KeyDown_grid(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                           int row =  dgridtimkiem.CurrentCell.RowIndex;

                    txtmavp.Text = dgridtimkiem.Rows[row].Cells[0].Value.ToString();
                    txttenvp.Text = dgridtimkiem.Rows[row].Cells[1].Value.ToString();
                    txttenvp.Select();
                    break;    
                    case Keys.Escape:
                        dgridtimkiem.Visible = false;
                        break;
                }

                
                

            }
            catch { }
        }
        private int  f_gettileBHYTtra() {
            int kq = 0;
            try
            {
                
                sql =  " select tl.bhyttra ";
                sql += " from benhandt ba ";
                sql += " join bhyt bh on bh.maql=ba.maql ";
                sql += " join bv_tilebhyt tl on tl.kytu=substr(bh.sothe,3,1) and bh.traituyen=tl.traituyen    ";
                sql += " WHERE  ba.mavaovien='{0}'";
                sql = sql.Replace("{0}", _mavaovien);
                DataSet ds = OraData.get_data(sql);

                kq = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            return kq;
        }
      
        private void f_loadDanhSach()
        {
            try
            {
                dDanhMuc.Rows.Clear();
                sql = " SELECT TO_CHAR(KTC.NGAY,'DD/MM/YYYY') NGAY,dt.doituong,to_char(ktc.ghichu_vn) ten, ";
                sql += " '' dvt,ktc.soluong soluong,ktc.dongia dongia,dl.hoten,ktc.maql,ktc.mavaovien,ktc.id,ktc.userid ";
                sql += " from BV_chidinhKTC KTC ";
                sql +=" join benhandt ba on KTC.MAVAOVIEN=ba.MAVAOVIEN ";
                sql +=" join doituong dt on dt.madoituong=ktc.madoituong ";
                sql += " join v_giavp vp on ktc.mavp=vp.id ";
                sql += " join dlogin dl on ktc.userid=dl.id where ktc.mabn='{0}' and to_char(ktc.ngay,'dd/mm/yyyy')=to_char(sysdate,'dd/mm/yyyy')";
                sql += " union ";
                sql += " SELECT TO_CHAR(KTC.NGAY,'DD/MM/YYYY') NGAY,dt.doituong,to_char(vp.ten) ten, ";
                sql += " '' dvt,ktc.soluong soluong,ktc.dongia dongia,dl.hoten,ktc.maql,ktc.mavaovien,ktc.id,ktc.userid ";
                sql += " from BV_chidinhKTC KTC ";
                sql += " join benhandt ba on KTC.MAVAOVIEN=ba.MAVAOVIEN ";
                sql += " join doituong dt on dt.madoituong=ktc.madoituong ";
                sql += " join d_dmbd vp on ktc.mavp=vp.id ";
                sql += " join dlogin dl on ktc.userid=dl.id where ktc.mabn='{0}' and to_char(ktc.ngay,'dd/mm/yyyy')=to_char(sysdate,'dd/mm/yyyy')";
                
                sql = sql.Replace("{0}", _mabn);
                DataSet ds = OraData.get_data(sql);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    dDanhMuc.Rows.Add(dr.ItemArray);
                }
            }
            catch { }

            
        }
        private bool f_kiemtra()
        {
            long kq;
            try {
                if (txtmavp.Text.Length == 0)
                {
                    MessageBox.Show("Chọn tên kỹ thuật cao");
                    txttenvp.Select();
                    return false;
                }
                if (long.TryParse(f_clearDot(txtcp1.Text), out kq) == false)
                {
                    MessageBox.Show("Giá trị chưa hợp lệ!");

                    txtcp1.Select();
                    return false;
                }
                if (long.TryParse(f_clearDot(txtcp2.Text),out kq) == false)
                {
                    MessageBox.Show("Giá trị chưa hợp lệ!");
                    txtcp2.Select();
                    return false;
                }
                    
            }
            catch { }
            return true;
        }
      
        private void toolSave_Click(object sender, EventArgs e)
        {
            
            try
            {

                if (f_kiemtra() == false) return;
                controlToolStrip("save");

                string id;
                if (flagIsNew == true)
                {
                    long cpttbhyt = (long.Parse(f_clearDot(txtcp2.Text))  * 100)/f_gettileBHYTtra();
                    long cpttthuphi = long.Parse(f_clearDot(txtcp1.Text))-cpttbhyt;
                   
                    string userid = AccessData.m_userid;
                    //PHAU THUAT KTC
                    sql = "insert into BV_chidinhKTC(id,mabn,mavaovien,maql,madoituong,mavp,ngay,makp,userid,ngayud,computer,ghichu_vn,soluong,dongia,giagoc) ";
                    sql += " values ({id},'{mabn}',{mavaovien},{maql},1,{mavp},sysdate,'{makp}','{userid}',sysdate,'{computer}','{ghichu_vn}',1,{dongia},0)  ";
                    string id1 = OraData.f_get_capid(userid);

                    sql = sql.Replace("{id}", id1);
                    sql = sql.Replace("{maql}", _maql);
                    sql = sql.Replace("{mabn}", _mabn);
                    sql = sql.Replace("{mavaovien}", _mavaovien);
                    sql = sql.Replace("{mavp}", txtmavp.Text);
                    sql = sql.Replace("{makp}", _makp);
                    sql = sql.Replace("{dongia}",cpttbhyt.ToString());
                    sql = sql.Replace("{userid}", AccessData.m_userid);
                    sql = sql.Replace("{computer}", Computer.getMachineName());
                    sql = sql.Replace("{ghichu_vn}", "Gói KTCao: " + txttenvp.Text);
                    OraData.execute_data(sql);

                  
                    sql = "insert into BV_chidinhKTC(id,mabn,mavaovien,maql,madoituong,mavp,ngay,makp,userid,ngayud,computer,ghichu_vn,soluong,dongia,giagoc) ";
                    sql += " values ({id},'{mabn}',{mavaovien},{maql},2,{mavp},sysdate,'{makp}','{userid}',sysdate,'{computer}','{ghichu_vn}',1,{dongia},0)  ";
                    string id2 = OraData.f_get_capid(userid);
                    //  MessageBox.Show(id1+"||"+id2);
                    
                    sql = sql.Replace("{id}", id2);
                    sql = sql.Replace("{maql}", _maql);
                    sql = sql.Replace("{mabn}", _mabn);
                    sql = sql.Replace("{mavaovien}", _mavaovien);
                    sql = sql.Replace("{mavp}", txtmavp.Text);
                    sql = sql.Replace("{makp}", _makp);
                    sql = sql.Replace("{dongia}",cpttthuphi.ToString());
                    sql = sql.Replace("{userid}", AccessData.m_userid);
                    sql = sql.Replace("{computer}", Computer.getMachineName());
                    sql = sql.Replace("{ghichu_vn}", "Bệnh nhân thanh toán chênh lệch: " + txttenvp.Text);
                    OraData.execute_data(sql);

                }
                else
                {

                }
                f_loadDanhSach();
            }
            catch { }
        }
        private void toolSave_Vattu(string mavp,string tenvp,string dongia,string soluong)
        {
            try
            {
                long kq;
              
                string id;
                if (flagIsNew == true)
                {
                    if (long.TryParse(f_clearDot(txtdongia.Text), out kq) == false)
                    {
                        MessageBox.Show("Đơn giá chưa hợp lệ");
                        txtdongia.Select();
                        return ;
                    }
                    string userid = AccessData.m_userid;
                    //PHAU THUAT KTC
                    sql = "insert into BV_chidinhKTC(id,mabn,mavaovien,maql,madoituong,mavp,ngay,makp,userid,ngayud,computer,ghichu_vn,soluong,dongia,giagoc) ";
                    sql += " values ({id},'{mabn}',{mavaovien},{maql},5,{mavp},sysdate,'{makp}','{userid}',sysdate,'{computer}','{ghichu_vn}',{so_luong},{dongia},0)  ";
                    string id1 = OraData.f_get_capid(userid);

                    sql = sql.Replace("{id}", id1);
                    sql = sql.Replace("{maql}", _maql);
                    sql = sql.Replace("{mabn}", _mabn);
                    sql = sql.Replace("{mavaovien}", _mavaovien);
                    sql = sql.Replace("{mavp}", mavp);
                    sql = sql.Replace("{makp}", _makp);
                    sql = sql.Replace("{so_luong}", soluong);
                    sql = sql.Replace("{dongia}", f_clearDot(txtdongia.Text));
                    sql = sql.Replace("{userid}", AccessData.m_userid);
                    sql = sql.Replace("{computer}", Computer.getMachineName());
                    sql = sql.Replace("{ghichu_vn}", "Vật tư đi kèm: " + tenvp);
                    OraData.execute_data(sql);
                    txtdongia.Text = "0";
               
                }
                else
                {

                }
                f_loadDanhSach();
            }
            catch { }
        }
        private void controlToolStrip(string code)
        {
            switch (code)
            {
                case "new":
                    toolDelete.Enabled = false;
                 

                    toolCancel.Enabled = true;
                    toolSave.Enabled = true;
                    panel1.Enabled = true;
                    toolNew.Enabled = false;
                    flagIsNew = true;
                    f_setThongTin("", "","0");
                    break;
                case "edit":
                    toolDelete.Enabled = false;
                    toolNew.Enabled = false;
                    toolSave.Enabled = true;

                    toolCancel.Enabled = true;
                  
                    panel1.Enabled = true;
                    flagIsNew = false;
                    break;
                case "cancel":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                    
                    toolSave.Enabled = false;
                    panel1.Enabled = false;
                    break;
                case "save":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                
                    toolSave.Enabled = false;
                    panel1.Enabled = false;
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
                try
                {
                    int row = dDanhMuc.CurrentCell.RowIndex;

                    txtmaql.Text = dDanhMuc.Rows[row].Cells[7].Value.ToString();
                    txtID.Text = dDanhMuc.Rows[row].Cells[9].Value.ToString();
                }
                catch { }
            }
            catch { }
        }
        private void f_setThongTin(string id, string ten,string Enable)
        {
            try {
               
               
            }
            catch { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (_maql.CompareTo(txtmaql.Text)==0)
            {
                try
                {
                    controlToolStrip("save");

                    string id;

                    sql = "DELETE BV_chidinhktc ";
                    sql += " WHERE ID={id} and userid={userid} ";
                    sql = sql.Replace("{id}", txtID.Text);
                    sql = sql.Replace("{userid}", AccessData.m_userid);
                    int roweffect=OraData.f_execute_data(sql);
                    if (roweffect == 0)
                    {
                        MessageBox.Show("Bạn không có quyền xóa!");
                    }
                    else
                    {
                        f_loadDanhSach();
                    }
                }
                catch { }
            }
            else { MessageBox.Show("Không thể xóa, bệnh nhân đã ra viện!"); }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //AccessData d = new AccessData();
            //CThanhToanBHYTOracle data = new CThanhToanBHYTOracle();

            ////DataSet ds = data.f_loadBaoCaoMau20(tungay, denngay, "");

            //DataSet ds = data.f_getv_ttrvkp_ct (_mabn, _mavaovien, DateTime.Today, DateTime.Today);
            //frmReport a = new frmReport(d, ds.Tables[0], "rpt_ttravien_kp_ct.rpt", "", "", "", "", "", "", "", "", "", "");
            //a.Show();          
            
           
            
           
        }

        

        private void txttenvp_Leave(object sender, EventArgs e)
        {
            
        }

        private void txttenvp_Enter(object sender, EventArgs e)
        {
            dgridtimkiem.Visible = true;
        }

        private void dgridtimkiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

             

                    int row = dgridtimkiem.CurrentCell.RowIndex;

                    txtmavp.Text = dgridtimkiem.Rows[row].Cells[0].Value.ToString();
                    txttenvp.Text = dgridtimkiem.Rows[row].Cells[1].Value.ToString();
               



            }
            catch { }
        }

        private void txttenvp_TextChanged(object sender, EventArgs e)
        {
            
            f_loaddanhmucKTCTimKiem(txttenvp.Text);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cstext.get_id() + "||" + cstext.get_name());
            
            toolSave_Vattu(cstext.get_id(), cstext.get_name(), "0", "1");
            cstext.Select();
            cstext.set_name("");
        }

        

       

      
       
       
       
       
    }
}