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
    public partial class frmUpdate_giavp : Form
    {
        public frmUpdate_giavp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v_giavpbh_Oracle data = new v_giavpbh_Oracle();
            foreach (DataGridViewRow row in dGrid.Rows)
            {
                if (row.IsNewRow == false)
                { 
                    string s_id=row.Cells["id"].Value.ToString();
                    string s_ten37=row.Cells["ten37"].Value.ToString();
                    string s_gia37=row.Cells["gia37"].Value.ToString();
                    string s_stt37=row.Cells["stt37"].Value.ToString();

                    data.f_update_medibv115_v_giavp(s_id, s_ten37, s_gia37, s_stt37);
                }
            }
        }
    }
}
