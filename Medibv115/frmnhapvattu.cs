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
    public partial class frmnhapvattu: Form
    {
        Ccdha_thuocphimOracle dataOracle = new Ccdha_thuocphimOracle();
        private string _tableName = "";
        private string _title = "";

        AccessData OraData;
        string sql = "";
        DataSet ds = new DataSet();
        private string _s_id = "";
        private string _s_mavp = "";
        private string _s_autosave = "0";
        
        
        
        bool flagIsNew = false;
        public frmnhapvattu()
        {
            InitializeComponent();
        }
        public frmnhapvattu(string tablename, string title,string s_id,string s_mavp,string s_autosave)
        {
            _tableName = tablename;
            _title = title;
            _s_id = s_id;
            _s_mavp = s_mavp;
            _s_autosave = s_autosave;
            InitializeComponent();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            txtToolStrip.Text = _title;
            init_cbloaiyc();
            f_loadDanhSach();
            if (_s_autosave == "1")
            {
                f_save();
                this.Close();
            }
            
        }
        #region init
        private void init_cbloaiyc()
        {
            try
            {
                
                DataTable dtdm_loaibc = dataOracle.f_getdanhmuc_vattu().Tables[0];
                cbLoai.DataSource = dtdm_loaibc;
                cbLoai.DisplayMember = "NAME";
                cbLoai.ValueMember = "ID";

                
                
               

            }
            catch { }
        }
        #endregion 
        private void f_loadDanhSach()
        {
            ds = dataOracle.f_get(_s_id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = dataOracle.f_getdinhmuc(_s_mavp);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dDanhMuc.Rows.Add(dr.ItemArray);
            }
            
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            f_save();
            this.Close();
        }
        private void f_save()
        {
            
            dataOracle.f_delete(long.Parse(_s_id));
            foreach (DataGridViewRow dr in dDanhMuc.Rows)
            {
                if (dr.IsNewRow == false)
                {
                    CCDHA_THUOCPHIM item = new CCDHA_THUOCPHIM();
                    item.Id = _s_id;
                    item.Mabd = int.Parse(dr.Cells["cbloai"].Value.ToString());
                    item.Mavp = int.Parse(_s_mavp);
                    item.Soluong = double.Parse(dr.Cells["soluong"].Value.ToString());
                    item.Sl_phimhu = double.Parse(dr.Cells["sl_hu"].Value.ToString());
                    item.Stt = dr.Index.ToString(); ;
                    dataOracle.f_insert(item);
                }
            
            }
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


     

  
    }
}