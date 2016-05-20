using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediIT115
{
    public partial class frmMessage_List : Form
    {
        private DataTable dt_;
        public frmMessage_List()
        {
            InitializeComponent();
        }
        public frmMessage_List(DataTable dt)
        {
            dt_ = new DataTable();
            dt_ = dt;
            InitializeComponent();
        }
        private void frmMessage_List_Load(object sender, EventArgs e)
        {
            dview.DataSource = dt_;
        }

    }
}