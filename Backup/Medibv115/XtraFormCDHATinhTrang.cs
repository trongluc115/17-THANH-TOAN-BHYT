using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MediIT115
{
    public partial class XtraFormCDHATinhTrang : DevExpress.XtraEditors.XtraForm
    {
        private string s_mid = "";
        public XtraFormCDHATinhTrang()
        {
            InitializeComponent();
        }
        public XtraFormCDHATinhTrang(string s_id,string s_mabn)
        {
            InitializeComponent();
            s_mid = s_id;

        }

        private void XtraFormCDHATinhTrang_Load(object sender, EventArgs e)
        {

        }
    }
}