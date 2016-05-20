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
    public partial class frmKhoaSoLieuCDHA : Form
    {
        private m_option Data_option=new m_option();
        public frmKhoaSoLieuCDHA()
        {
            InitializeComponent();
        }

        private void frmKhoaSoLieuCDHA_Load(object sender, EventArgs e)
        {
            lbtitle.Text += " : " + AccessData.s_tenkhuvuc;
            try{
                date_lock.Value =Data_option.f_get_CDHA_LockDate(AccessData.s_makhuvuc);
            }catch{}

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Data_option.f_set_CDHA_LockDate(AccessData.s_makhuvuc, date_lock.Value);
        }
    }
}