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
    public partial class frmXepLichCDHA : Form
    {
        CBenhNhan BN;
        CThanhToanBHYT BHYT;
        DataSet ds = new DataSet();
        BaseFormat mformat = new BaseFormat();
        double _khambenh=0;
        private List<string> Listthuock;
        public frmXepLichCDHA()
        {
            InitializeComponent();
            
            
        }
        private void add_SoPhieu()
        { 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }
        
        
        
        

        
    

     
     


        private string f_clearDot(string s)
        {
            return s.Replace(".", "");
        }
        private string f_insertDot(string s)
        {
            string result = "";
            string temp = s;
            string num="";
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

   
        
        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Chitiet_CP();
        }

        private void lbloai_Click(object sender, EventArgs e)
        {
            Load_Chitiet_CP();
        }

        
        private void bnLuuTN_Click(object sender, EventArgs e)
        {
          
        }

        
  
        private void f_TimKiem(string timkiem)
        {

            try
            {
               
                foreach (DataGridViewRow item in dview.Rows)
                    
                {
                    if (item.Cells["SoHDDV"].Value.ToString().IndexOf(timkiem,0)!=-1 || timkiem.Length==0)
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }

            }
            catch { }

        }
        
        private void txtSoBienLai_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            f_suadaduyet();
        }
        private void f_suadaduyet()
        {
            cdha_dvll_Oracle dvll_Oracle = new cdha_dvll_Oracle();
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["Chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check==false)
                { 
                    dvll_Oracle.f_delete(long.Parse(item.Cells["id_"].Value.ToString()));
                }
            }
            Load_Chitiet_CP();

        }

        private void chkAll1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dview.Rows)
            {
                item.Cells[0].Value = chkAll1.Checked;
                
            }
    
        }

        private void chkAll2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                item.Cells[0].Value = chkAll2.Checked;
            }
        }

        private void dview_Click(object sender, EventArgs e)
        {
          //  dview.EndEdit();
        }
        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dview.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                }
                else
                {
                    chk.Value = chk.FalseValue;
                }

            }
            
        }

        private void dview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            SendKeys.Send("{RIGHT}");
            SendKeys.Send("{LEFT}");
            lbSoLuong.Text = CountChoice().ToString();
            
        }

        private void dview_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void f_ingiayhen()
        {
            foreach (DataGridViewRow dr in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = dr.Cells["chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && dr.Visible == true)
                {
                    DataGridViewRow item = dr;
                    DataTable mydt = new DataTable();
                    DataRow mydr;
                    mydt.Columns.Add(new DataColumn("MABN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("HOTEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NAMSINH", typeof(string)));
                    mydt.Columns.Add(new DataColumn("TENVP", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NGAY_HEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("GIO_HEN", typeof(string)));
                    mydt.Columns.Add(new DataColumn("NOITHUCHIEN", typeof(string)));
                    mydr = mydt.NewRow();
                    mydr[0] = item.Cells["mabn_"].Value.ToString();
                    mydr[1] = item.Cells["hoten_"].Value.ToString();
                    mydr[2] = item.Cells["namsinh_"].Value.ToString();
                    mydr[3] = item.Cells["tenvp_"].Value.ToString();
                    mydr[4] = item.Cells["NGAY_HEN"].Value.ToString();
                    mydr[5] = item.Cells["GIO_HEN"].Value.ToString();
                    mydr[6] = cbarea.Text;
                    mydt.Rows.Add(mydr);
                    AccessData d = new AccessData();
                    string s_reportname = "phieuhen.rpt";
                    string s_title = "";
                    frmReport a = new frmReport(d, mydt, s_reportname, s_title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
                    a.Show();
                }

            }
        }




        private void ddsdaduyet_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow item = ddsdaduyet.CurrentRow;
            DataTable mydt = new DataTable();
            DataRow mydr;
            mydt.Columns.Add(new DataColumn("MABN", typeof(string)));
            mydt.Columns.Add(new DataColumn("HOTEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("NAMSINH", typeof(string)));
            mydt.Columns.Add(new DataColumn("TENVP", typeof(string)));
            mydt.Columns.Add(new DataColumn("NGAY_HEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("GIO_HEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("NOITHUCHIEN", typeof(string)));
            mydr = mydt.NewRow();
            mydr[0] = item.Cells["mabn_"].Value.ToString();
            mydr[1] = item.Cells["hoten_"].Value.ToString();
            mydr[2] = item.Cells["namsinh_"].Value.ToString();
            mydr[3] = item.Cells["tenvp_"].Value.ToString();
            mydr[4] = item.Cells["NGAY_HEN"].Value.ToString();
            mydr[5] = item.Cells["GIO_HEN"].Value.ToString();
            mydr[6] = cbarea.Text;
            mydt.Rows.Add(mydr);
            AccessData d = new AccessData();
            string s_reportname = "phieuhen.rpt";
            string s_title="";
            frmReport a = new frmReport(d, mydt, s_reportname, s_title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
            a.Show();
        }

        private void btTraKQ_Click(object sender, EventArgs e)
        {
            save_trakq();
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
        private void save_trakq()
        {

            cdha_dvll_Oracle cdhadvl_O = new cdha_dvll_Oracle();

            // DataGridViewRow row = dview.SelectedRows[0];
            int stt = 0;
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["TRAKQ"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    cdha_dvll vct = new cdha_dvll();
                    vct.ID = long.Parse(item.Cells["id_"].Value.ToString());
                    vct.TRAKQ = "1";
                    cdhadvl_O.f_update_trakq(vct);
                    
                }
                else
                {
                    cdha_dvll vct = new cdha_dvll();
                    vct.ID = long.Parse(item.Cells["id_"].Value.ToString());
                    vct.TRAKQ = "0";
                    cdhadvl_O.f_update_trakq(vct);
                
                }

            }
            Load_Chitiet_CP();
        }

   

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmXepLichCDHA_Load(object sender, EventArgs e)
        {
            init();
            panel3.Visible = false;
            pnchuyen.Visible = false;
        }
        private void init()
        {
            try {
                cdha_hen_Oracle Data_cdha_hen = new cdha_hen_Oracle();
                ds = Data_cdha_hen.f_getCDHA_Loai("");
                cbCDHA_loai.DataSource = ds.Tables[0];
                cbCDHA_loai.DisplayMember = "Name";
                cbCDHA_loai.ValueMember = "ID";
                cbCDHA_loai.SelectedIndex = 0;

                ds = Data_cdha_hen.f_getCDHA_NOITHUCHIEN(AccessData.s_makhuvuc);
                cbarea.DataSource = ds.Tables[0];
                cbarea.DisplayMember = "Name";
                cbarea.ValueMember = "ID";
                cbarea.SelectedIndex = 0;

                ds = Data_cdha_hen.f_getCDHA_NOITHUCHIEN("-1");
                DataTable dt = ds.Tables[0].Copy();
                cbNoiChuyen.DataSource = dt;
                cbNoiChuyen.DisplayMember = "Name";
                cbNoiChuyen.ValueMember = "ID";
                cbNoiChuyen.SelectedIndex = 0;

                xml_read();
            }
            catch { }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            f_loadDS();
        }
        private void f_loadDS()
        {
            Load_Chitiet_CP();
            f_loaddsdaduyet();
        }
        private void Load_Chitiet_CP()
        {
            try
            {

                cdha_hen_Oracle dataOracle = new cdha_hen_Oracle();
               
              
               
                DateTime ngayvao = dngayvao.Value;
                DateTime ngayra = dngayra.Value;
                string s_dieukien = cbCDHA_loai.SelectedValue.ToString();
                DataTable dtcp = dataOracle.f_getDanhSach( ngayvao, ngayra,s_dieukien).Tables[0];
                dview.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    dview.Rows.Add(item.ItemArray);
                }





            }
            catch { }
        }
        private void f_loaddsdaduyet()
        {
            try
            {
                cdha_hen_Oracle dvll_Ora = new cdha_hen_Oracle();
                DateTime tungay = dngaybc.Value;
                DateTime denngay = dngaybc.Value;
                string s_dieukien = cbCDHA_loai.SelectedValue.ToString();
                string s_noithuchien = cbarea.SelectedValue.ToString();
                DataTable dtcp = dvll_Ora.f_getCLS_DADUYET(tungay, denngay, s_dieukien, s_noithuchien);
                ddsdaduyet.Rows.Clear();

                foreach (DataRow item in dtcp.Rows)
                {
                    ddsdaduyet.Rows.Add(item.ItemArray);
                }
                format_grid();
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            cdha_hen_Oracle cdha_hen_O = new cdha_hen_Oracle();

            // DataGridViewRow row = dview.SelectedRows[0];
            int stt = 0;
            foreach (DataGridViewRow item in dview.Rows)
            {
                DataGridViewCell oCell = item.Cells["check"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    cdha_hen vct = new cdha_hen();
                    //sql = "insert into BV115.cdha_hen (id,ngaycd,ngaychup,mabn,mabs,mavp,soLuong,makp,madoituong,dongia,userid) ";
                    vct.ID = long.Parse(item.Cells["ID"].Value.ToString());
                    vct.NGAYCD = DateTime.ParseExact(item.Cells["NGAY"].Value.ToString(), "dd/MM/yyyy HH:mm", null);
                    vct.NGAYCHUP = dngaybc.Value.Date;
                    vct.MABN = item.Cells["MABN"].Value.ToString();
                    vct.MABSCD = item.Cells["MaBS"].Value.ToString();
                    vct.MAVP = item.Cells["MAVP"].Value.ToString();
                    vct.SOLUONG = float.Parse(item.Cells["SL"].Value.ToString());
                    vct.MAKP = item.Cells["MAKP"].Value.ToString();
                    vct.MADOITUONG = item.Cells["MADOITUONG"].Value.ToString();
                                  
                    vct.DONGIA = float.Parse(item.Cells["DONGIA"].Value.ToString());
                    vct.USERTN = AccessData.m_userid;
                    vct.STT = stt;
                    vct.NOITHUCHIEN = cbarea.SelectedValue.ToString();
                    cdha_hen_O.f_insert(vct);
                    stt++;
                }

            }
            f_loadDS(); 
        }
        private int CountChoice()
        {
            int result=0;
            foreach (DataGridViewRow item in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = item.Cells["chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && item.Visible == true)
                {
                    result++;
                }
            }
            return result;
        }
        private void btnXepLich_Click(object sender, EventArgs e)
        {

            TimeSpan ts;
            DateTime Fromday = dTimeStart.Value;
          
          
            
            double db_tgtrungbinh =double.Parse( txtTGTB.Text);
        
            foreach (DataGridViewRow dr in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = dr.Cells["chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && dr.Visible == true)
                {
                    dr.Cells["GIO_HEN"].Value = string.Format("{0:HH:mm}", Fromday);
                    Fromday = Fromday.AddMinutes(db_tgtrungbinh);
                }
                
            }
                       
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            cdha_hen_Oracle O_henData=new cdha_hen_Oracle();
            foreach (DataGridViewRow dr in ddsdaduyet.Rows)
            {
                DataGridViewCell oCell = dr.Cells["chon_"];
                bool check = Convert.ToBoolean(oCell.Value);
                if (check == true && dr.Visible == true)
                {
                    O_henData.f_delete(long.Parse(dr.Cells["id_"].Value.ToString()));
             
                }

            }
            f_loadDS();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cdha_hen_Oracle O_henData = new cdha_hen_Oracle();
            string s_thuchien = "0";
            string s_noithuchien = cbarea.SelectedValue.ToString();
            foreach (DataGridViewRow dr in ddsdaduyet.Rows)
            {
                s_thuchien = "0";
                try
                {
                    DataGridViewCell oCell = dr.Cells["TRAKQ"];
                    bool check = Convert.ToBoolean(oCell.Value);
                    if (check == true && dr.Visible == true)
                    {
                        s_thuchien = "1";
                    }
                }
                catch { }
                
                string s_thoigian = dr.Cells["NGAY_HEN"].Value.ToString()+" " + mformat.f_GetTime(dr.Cells["GIO_HEN"].Value.ToString());
                string s_id= dr.Cells["id_"].Value.ToString();
                O_henData.f_update_thoigianhen(s_thoigian,s_thuchien,s_id,s_noithuchien);
               
             

            }
            f_loadDS();
        }
        
        private void dngaybc_ValueChanged(object sender, EventArgs e)
        {
            f_loadDS();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_loadDS();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //pn_init.Visible = false;
            cbarea.Enabled = false;
            cbCDHA_loai.Enabled = false;
            panel3.Visible = true;
            f_loadDS();
            xml_write();
        }
        private void xml_write()
        {
            try
            {
                CXml xml_file = new CXml();
                xml_file.WriteXML("ROOM", cbarea.SelectedValue.ToString(), "ConfigCDHA.xml");
                xml_file.WriteXML("TECH", cbCDHA_loai.SelectedValue.ToString(), "ConfigCDHA.xml");

            }
            catch { }
        }
        private void xml_read()
        {
            try
            {
                CXml xml_file = new CXml();
                string s_room = xml_file.ReadXML("ROOM", "ConfigCDHA.xml");
                string s_tech = xml_file.ReadXML("TECH", "ConfigCDHA.xml");
                f_set_ComboBox(cbarea, s_room);
                f_set_ComboBox(cbCDHA_loai, s_tech);
            }
            catch { }
        }
        private void f_set_ComboBox(ComboBox cb, string s_value)
        {
            try
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.SelectedValue.ToString().CompareTo(s_value) == 0)
                    {
                        break;
                    }
                }
            }
            catch { }

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            f_TimKiemTen(txtSearch.Text);
        }
        private void f_TimKiemTen(string timkiem)
        {

            try
            {

                foreach (DataGridViewRow item in dview.Rows)
                {
                    if (item.Cells["HOTEN"].Value.ToString().ToLower().IndexOf(timkiem.ToLower(), 0) != -1 || timkiem.Length == 0 || item.Cells["MABN"].Value.ToString().ToLower().IndexOf(timkiem.ToLower(), 0) != -1)
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }

            }
            catch { }

        }

        private void btPrintPH_Click(object sender, EventArgs e)
        {
            f_ingiayhen();
        }
        private void f_indanhsach()
        {
            DataTable mydt = new DataTable();
            mydt.Columns.Add(new DataColumn("MABN", typeof(string)));
            mydt.Columns.Add(new DataColumn("HOTEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("NAMSINH", typeof(string)));
            mydt.Columns.Add(new DataColumn("TENVP", typeof(string)));
            mydt.Columns.Add(new DataColumn("NGAY_HEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("GIO_HEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("NOITHUCHIEN", typeof(string)));
            mydt.Columns.Add(new DataColumn("BSCHIDINH", typeof(string)));
            mydt.Columns.Add(new DataColumn("KHOAPHONGCD", typeof(string)));
            mydt.Columns.Add(new DataColumn("KHOAPHONGHD", typeof(string)));
            foreach (DataGridViewRow dr in ddsdaduyet.Rows)
            {
                
                    DataGridViewRow item = dr;
                  
                    DataRow mydr;
                    
                    mydr = mydt.NewRow();
                    mydr[0] = item.Cells["mabn_"].Value.ToString();
                    mydr[1] = item.Cells["hoten_"].Value.ToString();
                    mydr[2] = item.Cells["namsinh_"].Value.ToString();
                    mydr[3] = item.Cells["tenvp_"].Value.ToString();
                    mydr[4] = item.Cells["NGAY_HEN"].Value.ToString();
                    mydr[5] = item.Cells["GIO_HEN"].Value.ToString();
                    mydr[6] = cbarea.Text;
                    mydr[7] = item.Cells["BSCD_"].Value.ToString();
                    mydr[8] = item.Cells["TENKP_"].Value.ToString();
                    mydr[9] = item.Cells["KPHD"].Value.ToString();

                    mydt.Rows.Add(mydr);
                   
                
               

            } 
            AccessData d = new AccessData();
                string s_reportname = "danhsachhen.rpt";
                string s_title = "";
                frmReport a = new frmReport(d, mydt, s_reportname, s_title, "họ tên", "Giam đốc", "", "", "", "", "", "", "");
                a.Show();
        }

        private void btListHen_Click(object sender, EventArgs e)
        {
            f_indanhsach();
        }

        private void cbChuyen_Click(object sender, EventArgs e)
        {
            pnchuyen.Visible = true;
        }

        private void btLuuChuyen_Click(object sender, EventArgs e)
        {
            cdha_hen_Oracle O_henData = new cdha_hen_Oracle();
                string s_thuchien = "0";
                string s_noithuchien = cbNoiChuyen.SelectedValue.ToString();
                foreach (DataGridViewRow dr in ddsdaduyet.Rows)
                {
                    
                    DataGridViewCell oCellChon = dr.Cells["chon_"];
                    bool checkchon=false;
                    try{
                        checkchon = Convert.ToBoolean(oCellChon.Value);
                    }catch{}
                    if (checkchon == true && dr.Visible == true)
                    {
                        s_thuchien = "0";
                        DataGridViewCell oCell = dr.Cells["TRAKQ"];
                        bool check=false;
                        try
                        {
                             check= Convert.ToBoolean(oCell.Value);
                        }
                        catch { }
                        if (check == true && dr.Visible == true)
                        {
                            s_thuchien = "1";
                        }
                                       
                        string s_thoigian = string.Format("{0:dd/MM/yyyy} 00:00",dngaychuyen.Value );
                        string s_id = dr.Cells["id_"].Value.ToString();
                        O_henData.f_update_thoigianhen(s_thoigian, s_thuchien, s_id, s_noithuchien);
                    }


                }
            
                f_loadDS();
                pnchuyen.Visible = false;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            pnchuyen.Visible = false;
        }

       
    }
}