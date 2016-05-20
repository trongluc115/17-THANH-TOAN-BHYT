using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MediIT115
{
    public partial class trongluc_search_textbox : UserControl
    {
        public DataTable datasource;
        public Control nextControl;
        public trongluc_search_textbox()
        {
            InitializeComponent();
        }
        #region keydown
        private void f_loaddanhmucKTCTimKiem(string timkiem)
        {

            try
            {
                dgridtimkiem.Rows.Clear();
                DataTable dt = datasource;
                foreach (DataRow item in
                    dt.Rows)
                {
                    if (item[1].ToString().ToLower().IndexOf(timkiem.ToLower()) >= 0)
                    {
                        dgridtimkiem.Rows.Add(item.ItemArray);
                    }
                }

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
                    case Keys.Escape:
                        dgridtimkiem.Visible = false;
                        break;
                    case Keys.Tab:
                        if (txtmavp.Text.Length == 0)
                            MessageBox.Show("Chọn kỹ thuật cao");
                        break;
                    case Keys.Return:
                        dgridtimkiem.Visible = false;
                        //SendKeys.Send("(Tab}{Home}");
                        nextControl.Select();
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
                    case Keys.Return:
                        int row = dgridtimkiem.CurrentCell.RowIndex;

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
        private void txttenvp_TextChanged(object sender, EventArgs e)
        {
            dgridtimkiem.Visible = true;
            f_loaddanhmucKTCTimKiem(txttenvp.Text);

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


        #endregion
        #region outvalue
        public string get_id()
        {
            return txtmavp.Text;
        }
        public string get_name()
        {
            return txttenvp.Text;
        }
        public void set_dateSource(DataTable table)
        {
            datasource = table;
        }
        public void set_labelname(string value)
        {
            
        }
        public void set_name(string value)
        {
           txttenvp.Text = value;
        }
        public void set_select_name()
        {
            txttenvp.Select();
        }
        

        #endregion

        private void trongluc_search_textbox_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            dgridtimkiem.Visible = false;
        }

        private void trongluc_search_textbox_Enter(object sender, EventArgs e)
        {
            txttenvp.Select();
        }
    }
}
