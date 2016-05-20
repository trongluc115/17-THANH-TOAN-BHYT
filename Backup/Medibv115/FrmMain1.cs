using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibBaocao;
using DataOracle;
using DataUpdate;
using DataMySQL;
using System.Globalization;
using System.Diagnostics;
using DataUpdate;

namespace MediIT115
{
    public partial class FrmMain1 : Form
    {
        AccessData libbc = new AccessData();
        private string s_right = "";
        private string s_userid = "";
        private int i_userid = 0;
        private string s_password = "";
        private string s_tenDangNhap = "";
        private CConnection_Oracle ora_con = new CConnection_Oracle();
        private bool bvisable = false;

        //auto update
        private Oracle_autoUpdate ud = new Oracle_autoUpdate();
        private DataTable dtupdate = new DataTable();
        private string fileName = string.Empty;
        private string arguments = string.Empty;
        private bool waitUntilFinished = false;
        private int waitMillisecs = -1;
        //end
        public FrmMain1()
        {
            InitializeComponent();
            //kiểm tra version để update
            dtupdate = null;
            dtupdate = ud.dt_autoUpdate();
           
            if (dtupdate != null)
            {
                if (dtupdate.Rows[0]["capnhat"].ToString() == "1")
                {
                    if (this.ProductVersion != dtupdate.Rows[0]["version"].ToString())
                    {
                        fileName = "AutoUpdate.exe";
                        using (Process p = new Process())
                        {
                            p.StartInfo.FileName = fileName;
                            if (arguments.Length > 0)
                            {
                                p.StartInfo.Arguments = arguments;
                            }
                            //p.StartInfo.WindowStyle=System.Diagnostics.ProcessWindowStyle.Hidden;
                            p.Start();

                            Application.Exit();
                            if (this.waitMillisecs != -1)
                            {
                                p.WaitForExit(waitMillisecs);
                            }
                            else
                            {
                                if (this.waitUntilFinished == true)
                                {
                                    p.WaitForExit();
                                }
                            }
                            p.Close();
                        }
                    }
                }
                //lưu version máy
                DataTable dtversion = new DataTable();
                string s_ComputerName = Computer.getMachineName();
                ud = new Oracle_autoUpdate();
                dtversion = ud.dtversionComputer(s_ComputerName);
                if (dtversion != null)
                {
                    ud.upd_version(int.Parse(dtversion.Rows[0]["id"].ToString()), s_ComputerName, this.ProductVersion, 0);
                }
                else
                {
                    int maxid = 0;
                    maxid = ud.maxid() + 1;
                    ud.ins_version(maxid, s_ComputerName, this.ProductVersion, 0);
                }
                //end lưu version máy
            }
            //end kiểm tra version để update
        }

        private void menuItem23_Click(object sender, EventArgs e)
        {
            //showform( new frmMenuItem(libbc, f_get_menu()));
            
        }
        private TreeNode f_get_menu()
        {           
            TreeNode node = new TreeNode("Chức năng");
            node.Tag = "menuChucnang";
            node.Name = "menuChucnang";
            foreach (MenuItem item in this.mainMenu1.MenuItems)
            {
                MenuItem item2 = item;
                //if (((item2 == this.menuItem4) || (item2 == this.menuItem5)) || (item2 == this.menuItem6))
                //{
                //    break;
                //}
                TreeNode node2 = new TreeNode(item2.Text.Replace("&", ""));
                node2.Tag = item2.MergeOrder.ToString().PadLeft(4, '0');
                node.Nodes.Add(node2);
                if (item2.MenuItems.Count > 0)
                {
                    this.f_Add_Node(node2, item2);
                }
            }
            node.ExpandAll();
            return node;

        }
        private void f_Add_Node(TreeNode v_node, MenuItem v_item)
        {
            foreach (MenuItem item in v_item.MenuItems)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.MenuItem")
                {
                    MenuItem item2 = item;
                    if (item2.Text != "-")
                    {
                        TreeNode node = new TreeNode(item2.Text.Replace("&", ""));
                        node.Tag = item2.MergeOrder.ToString().PadLeft(4, '0');
                        node.Name = item2.Name.ToString();
                        v_node.Nodes.Add(node);
                        if (item2.MenuItems.Count > 0)
                        {
                            this.f_Add_Node(node, item2);
                        }
                    }
                }
            }
        }
        private void initformatRegion()
        {
            try
            {

                CultureInfo culture = new CultureInfo("en-US");
               
                //System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                
            }
            catch { }
        }
        private void FrmMain1_Load(object sender, EventArgs e)
        {
            bvisable = false;
            initformatRegion();
            frmLogin2 login = new frmLogin2();
            login.ShowDialog(this);
            if (login.mExit)
            {
                Application.Exit();
            }
            else
            {
                if (login.mUserid != "" || (login.mTenDangNhap == login.mUserAdmin && login.mPassword == login.mPasswordAdmin))
                {
                    if (login.mTenDangNhap == login.mUserAdmin && login.mPassword == login.mPasswordAdmin)
                    {
                        bvisable = true;
                    }
                    this.s_userid = login.mUserid;
                    this.s_right = login.mRight;
                    this.i_userid = login.iUserid;
                    this.s_password = login.mPassword;
                    this.s_tenDangNhap = login.mTenDangNhap;
                }
                else
                {
                    Application.Exit();
                    return;
                }
                this.gan_right();               
           }
        }
 
        private void gan_right()
        {
            int num = 0;
            int num2 = 0;
            bool visible = false;
            s_right = "+" + s_right.Trim('+') + "+";
            DataTable dtQuyen = new DataTable("quyen");
            CMenuItem mn = new CMenuItem();                
            dtQuyen =mn.dm_bv_menuItem().Tables[0];
            dtQuyen.PrimaryKey = new DataColumn[1] { dtQuyen.Columns["id"] };
            CBV_loginDAO bvdlogin = new CBV_loginDAO();           

            for (int i = 0; i < (this.mainMenu1.MenuItems.Count); i++)
            {
                //visible = false;               
                visible = bvisable;               
                for (int j = 0; j < this.mainMenu1.MenuItems[i].MenuItems.Count; j++)
                {
                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems.Count == 0)
                    {
                        if (this.mainMenu1.MenuItems[i].MenuItems[j].Text != "-")
                        {
                            string s_MergeOrder = this.mainMenu1.MenuItems[i].MenuItems[j].MergeOrder.ToString().PadLeft(4, '0');
                            this.mainMenu1.MenuItems[i].MenuItems[j].Visible = (bvisable == true) ? true :((this.s_right.IndexOf("+" + s_MergeOrder + "+") != -1) && (dtQuyen.Rows.Find(s_MergeOrder) != null));
                            if (!visible)
                            {
                                visible = this.mainMenu1.MenuItems[i].MenuItems[j].Visible;
                            }
                        }
                        else
                        {
                           this.mainMenu1.MenuItems[i].MenuItems[j].Visible = false;                         
                        }
                    }
                    else
                    {
                        num = 0;
                        for (int k = 0; k < this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems.Count; k++)
                        {
                            if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count == 0)
                            {
                                if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Text != "-")
                                {
                                    string s_MergeOrder = this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MergeOrder.ToString().PadLeft(4, '0');
                                    this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible =(bvisable ==true)?true:( (this.s_right.IndexOf("+" + s_MergeOrder + "+") != -1) && (dtQuyen.Rows.Find(s_MergeOrder) != null));
                                }
                                else
                                {
                                   this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = false;
                                }                                
                                 num += this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible ? 1 : 0;                             
                            }
                            else
                            {
                                num2 = 0;
                                for (int l = 0; l < this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count; l++)
                                {
                                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Text != "-")
                                    {
                                        string s_MergeOrder = this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].MergeOrder.ToString().PadLeft(4, '0');
                                        this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Visible =(bvisable ==true)? true :(  (this.s_right.IndexOf("+" + s_MergeOrder + "+") != -1) && (dtQuyen.Rows.Find(s_MergeOrder) != null));
                                    }
                                    else
                                    {
                                        this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Visible = false;
                                    }
                                        num2 += this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Visible ? 1 : 0;                                    
                                }
                                this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = num != 0;
                            }
                        }
                        this.mainMenu1.MenuItems[i].MenuItems[j].Visible = num != 0;
                        if (!visible)
                        {
                            visible = num != 0;
                        }
                    }
                    this.mainMenu1.MenuItems[i].Visible = visible;
                }
            }         
        }
       
        private void menuItem24_Click(object sender, EventArgs e)
        {
            showform(new frmPhanQuyen(this.f_get_menu()));           
            
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem26_Click(object sender, EventArgs e)
        {
            //frmLogin f = new frmLogin();
            //f.MdiParent = this;
            //f.Show();          
            FrmMain1_Load(null,e);
        }

        private void menuItem25_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đồng ý tạo cấu trúc dữ liệu ?", "BV115", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                //ora_con.tao_table(ora_con.schema);
            }            
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            frmQLKTCAO frm = new frmQLKTCAO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            frmQLBHYT_trathe frm = new frmQLBHYT_trathe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            frmTiepNhanKB frm = new frmTiepNhanKB();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetBHYTNgoaiTru());
            
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            showform(new frmBaoCaoNoiTruBHYT("1"));
            
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetBHYTNoiTru());
            
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            showform(new frmBaoCaoNoiTruBHYT("0"));
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            //frmBaoCaoBenhNhanNoiTruTaiNhapVien frm = new frmBaoCaoBenhNhanNoiTruTaiNhapVien();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            showform( new frmBCDuocMau20());
            
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            showform(new frmBCCLSMau21());
            
        }

        private void menuItem19_Click(object sender, EventArgs e)
        {
            frmdoimatkhau frm = new frmdoimatkhau();
            frm.Show();
        }

        private void menuItem20_Click(object sender, EventArgs e)
        {
            //frmDanhMucORA frm = new frmDanhMucORA(ora_con.schema+".dm_nhombc", "NHÓM BÁO CÁO");
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {
            showform( new frmDanhMucThuocBH());
            
        }

        private void menuItem22_Click(object sender, EventArgs e)
        {
            showform(new frmDanhMucVienPhiBH());
            
        }

        private void menuItem28_Click(object sender, EventArgs e)
        {
            //frmTKBenhNhanNoiTruTaiNHapVien f = new frmTKBenhNhanNoiTruTaiNHapVien();
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem29_Click(object sender, EventArgs e)
        {
            //frmKhoaPhong kp = new frmKhoaPhong();
            ////kp.MdiParent = this;
            //kp.ShowDialog();
            //if (kp.bOk == true)
            //{
            //   // frmDSBenhNhanNoiTruHienDien_Nhap_Xuat_RaVien frm = new frmDSBenhNhanNoiTruHienDien_Nhap_Xuat_RaVien(kp.Makp, kp.Tenkp);
            //    frmTongHopTinhHinhBenhNhanTaiKhoa frm = new frmTongHopTinhHinhBenhNhanTaiKhoa(kp.Makp,kp.Tenkp);
            //    //frm.MdiParent = this;
            //    frm.Show();
            //}
        }

        private void menuItem31_Click(object sender, EventArgs e)
        {
            //frmThongSoLCD f = new frmThongSoLCD(ora_con);
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem33_Click(object sender, EventArgs e)
        {
            //frmMapPhong f = new frmMapPhong();
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem34_Click(object sender, EventArgs e)
        {
            //frmMapGiuong f = new frmMapGiuong();
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem36_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetBHYTEdit());
        }

        private void menuItem37_Click(object sender, EventArgs e)
        {
            showform(new frmBaoCaoNoiTruBHYTEdit("0"));
        }
        private void showform(Form obj)
        {
            obj.MdiParent = this;
            obj.Show();
        }

        private void menuItem38_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetBHYTNoiTru(1));
        }

        private void menu3053_Click(object sender, EventArgs e)
        {
            showform(new frmBaoCaoNoiTruBHYTEditUser("0"));
        }

        private void menuItem40_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetCDHA());
        }

        private void menuItem41_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetBoPhan());
        }

        private void menuItem42_Click(object sender, EventArgs e)
        {
            showform(new frmBCCDHA());
        }

        private void menuItem43_Click(object sender, EventArgs e)
        {
            showform(new frmXepLichCDHA());
        }

        private void menuItem44_Click(object sender, EventArgs e)
        {
            showform(new frmDanhSachHen());
        }

        private void menuItem45_Click(object sender, EventArgs e)
        {
            showform(new frmDuyetCDHANT());
        }

        private void menuItem47_Click(object sender, EventArgs e)
        {
            showform(new frmKhoaSoLieuCDHA());
        }

        private void menuItem48_Click(object sender, EventArgs e)
        {
            showform(new frmKhoaSoLieuBHYT());
        }
    }
}