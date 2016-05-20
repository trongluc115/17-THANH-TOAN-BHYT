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
    }
}