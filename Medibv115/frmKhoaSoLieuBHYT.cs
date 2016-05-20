using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibBaocao;
using DataOracle;
using Entity;

namespace MediIT115
{
    public partial class frmKhoaSoLieuBHYT : Form
    {
        private m_option Data_option=new m_option();
        public frmKhoaSoLieuBHYT()
        {
            InitializeComponent();
        }

        private void frmKhoaSoLieuBHYT_Load(object sender, EventArgs e)
        {
            lbtitle.Text += " : " + AccessData.s_tenkhuvuc;
            try{
                date_lock.Value =Data_option.f_get_BHYT_LockDate("1");
            }catch{}

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Data_option.f_set_BHYT_LockDate("1", date_lock.Value);
        }

        private void txtExv_chidinh_Click(object sender, EventArgs e)
        {
            Export_Oracle ex_oralce = new Export_Oracle();
            int i_result = 0;
            int n=int.Parse(txtSoThang.Text);
            DateTime ngayhh=dExport.Value;
            ex_oralce.f_deletetemp("bv115.temp_v_chidinh");
            for(int i=0;i<n;i++)
            {
                i_result+=ex_oralce.f_ExportFromV_chidinh(ngayhh.AddMonths(-i)," and idtrongoi='42252' ");
            }
            MessageBox.Show(i_result.ToString());
        }

        private void txtbhytcn_Click(object sender, EventArgs e)
        {
            Export_Oracle ex_oralce = new Export_Oracle();
            int i_result = 0;
            int n = int.Parse(txtSoThang.Text);
            DateTime ngayhh = dExport.Value;
            ex_oralce.f_deletetemp("bv115.bhyt_cn");
            i_result += ex_oralce.f_ExportFrombhyt( " and length(macn)>4 ");
            for (int i = 0; i < n; i++)
            {
                i_result += ex_oralce.f_ExportFrombhyt(ngayhh.AddMonths(-i), " and length(macn)>4 ");
            }
            MessageBox.Show(i_result.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export_Oracle ex_oralce = new Export_Oracle();
            int i_result = 0;

            i_result += ex_oralce.f_Exportd_dmbdbh();
          
            MessageBox.Show(i_result.ToString());
        }
    }
}