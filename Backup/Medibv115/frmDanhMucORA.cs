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
    public partial class frmDanhMucORA : Form
    {
        private string _tableName = "";
        private string _title = "";

        AccessData OraData;
        string sql = "";
     
        private string _mabn = "";
        private string _mavaovien = "";
        private string _hoten = "";
        private string _makp = "";
        private string _maql = "";
        private DataSet dsdanhmuc;
        private int _tileBHYTtra = 0;

        
        bool flagIsNew = false;
        public frmDanhMucORA()
        {
            InitializeComponent();
        }
        public frmDanhMucORA(string tablename, string title)
        {
            _tableName = tablename;
            _title = title;
            InitializeComponent();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            txtToolStrip.Text = _title;
           
            f_loadDanhSach();
            panel1.Enabled = false;
        }
        private void f_loadDanhSach()
        {
            try
            {
                dDanhMuc.Rows.Clear();
                CDanhMucOracle ora_danhmuc = new CDanhMucOracle();
                DataTable dt = ora_danhmuc.get_danhmuc(_tableName,-1);
                foreach (DataRow dr in dt.Rows)
                {
                    dDanhMuc.Rows.Add(dr.ItemArray);
                }
            }
            catch { }

            
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    controlToolStrip("save");
            //    string Enable = cbEnable.SelectedIndex.ToString();
            //    string id ;
            //    if (flagIsNew == true)
            //    {
            //        id = _MySQLCTiepNhanYC.getID(_tableName);
            //        txtMaBN.Text = id;
            //        _MySQLCTiepNhanYC.InsertDanhMuc(_tableName, id, txtTen.Text,Enable);
            //    }
            //    else {
            //        id = txtMaBN.Text;
            //        _MySQLCTiepNhanYC.UpdateDanhMuc(_tableName, id, txtTen.Text,Enable);
            //    }
            //    f_loadDanhSach();
            //}
            //catch { }
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
                    toolEdit.Enabled = false;
                    panel1.Enabled = true;
                    flagIsNew = false;
                    break;
                case "cancel":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                    toolEdit.Enabled = true;
                    toolSave.Enabled = false;
                    panel1.Enabled = false;
                    break;
                case "save":
                    toolDelete.Enabled = true;
                    toolNew.Enabled = true;

                    toolCancel.Enabled = false;
                    toolEdit.Enabled = true;
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
                int row=dDanhMuc.CurrentCell.RowIndex;
                f_setThongTin(dDanhMuc.Rows[row].Cells[0].Value.ToString(), dDanhMuc.Rows[row].Cells[1].Value.ToString(), dDanhMuc.Rows[row].Cells[2].Value.ToString());
            }
            catch { }
        }
        private void f_setThongTin(string id, string ten,string Enable)
        {
            try {
                txtMaBN.Text = id;
                txtTen.Text = ten;
                cbEnable.SelectedIndex = int.Parse(Enable);
            }
            catch { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}