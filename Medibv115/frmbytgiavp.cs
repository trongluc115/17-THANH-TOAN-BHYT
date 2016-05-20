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
    public partial class frmbytgiavp : Form
    {
        private v_giavpbh_Oracle data_oracle = new v_giavpbh_Oracle();
        public frmbytgiavp()
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



            DataTable dtdm_dichvu = data_oracle.getBYT_v_giavp("");
            dgridChiTiet.DataSource = dtdm_dichvu;

         
        }
        private void f_loadcbb()
        {
            try
            {
              

             
            }
            catch { }
        
        }
        private void Filt_Search(string ten)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[dgridChiTiet.DataSource];
                DataView list = (DataView)manager.List;
                list.RowFilter = "TEN like '%" + ten.Trim() + "%'";
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
               
                string s_id = dgridChiTiet.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtID.Text = s_id;
            }
            catch { }
        }

        private void dgridChiTiet_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = dgridChiTiet.SelectedRows[0];
                string s_id = row.Cells["ID"].Value.ToString();
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
             
                DataTable dtdm_chitiet = data_oracle.getBYT_v_giavp(txtID.Text);
                ten.Text = dtdm_chitiet.Rows[0]["TEN"].ToString();
                txtBHYTtra.Text = dtdm_chitiet.Rows[0]["BHYT"].ToString();
                txtdonvi.Text = dtdm_chitiet.Rows[0]["DONVI"].ToString();               
                txtidbyt.Text = dtdm_chitiet.Rows[0]["ID_BYT"].ToString();                
                txttenbyt.Text = dtdm_chitiet.Rows[0]["TEN_BYT"].ToString();
                txtqdstt.Text = dtdm_chitiet.Rows[0]["QD_STT"].ToString();
                txtgiacu.Text = dtdm_chitiet.Rows[0]["giacu"].ToString();

              
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
           
        
        }
        private void f_update()
        {
            try{
                v_giavpbh item = new v_giavpbh();
                item.ID = long.Parse(txtID.Text);
                item.Id_byt = txtidbyt.Text;                
                item.Ten_byt=txttenbyt.Text;
                item.Qd_stt = txtqdstt.Text;
                item.BHYT = int.Parse(txtBHYTtra.Text);
                try {
                    item.Giacu = double.Parse(txtgiacu.Text);
                }catch{}
                data_oracle.f_updateBYT(item);
            }catch{}
        }
       

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        # region list

      

       
      

       
        #endregion 

        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

               
                if (e.KeyCode == Keys.F5)
                {
                    if (txtID.Text.Length > 0)
                    {
                        f_update();
                    }

                   

                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();

                }
                if (e.KeyCode == Keys.F3)
                {
                    f_load();

                }


            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_load();
        }
     
     
    }
}
