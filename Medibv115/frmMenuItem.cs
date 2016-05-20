using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOracle;
using Data;

namespace MediIT115
{
    public partial class frmMenuItem : Form
    {
        private LibBaocao.AccessData libbc;
        private CMenuItem ora_menuItem=new CMenuItem();
        private CDanhMucOracle ora_danhmuc;
        private CBV_loginDAO bv=new CBV_loginDAO();
        private string s_user = "";
        private DataSet ads;

        public frmMenuItem(LibBaocao.AccessData acc, TreeNode tn)
        {           
            InitializeComponent();
            libbc = acc;
            s_user = libbc.user;
            try
            {
                treeviewPhanquyen.Nodes.Clear();
                treeviewPhanquyen.Nodes.Add(tn);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void frmMenuItem_Load(object sender, EventArgs e)
        {
            try
            {
                ads = ora_menuItem.dm_bv_menuItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f_Set_Right();
        }

        private void f_Set_Right()
        {
            foreach (TreeNode anode in treeviewPhanquyen.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    if (ads.Tables[0].Select("id=" + anode.Tag.ToString()).Length > 0)
                    {
                        anode.Checked = true;
                    }
                }
            }
        }

        private void f_Set_Right(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Set_Right(anode);
                    }
                    else
                    {
                        if (ads.Tables[0].Select("id='" + anode.Tag.ToString() + "'").Length > 0)
                        {
                            anode.Checked = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void treeviewPhanquyen_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeviewPhanquyen.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void treeviewPhanquyen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.ForeColor = Color.Red;
        }

        private void f_Set_All(bool bAll)
        {
            foreach (TreeNode anode in treeviewPhanquyen.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Chon_Quyen(anode, bAll);
                }
            }
        }

        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ora_menuItem.delete_bv_menuitem();
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ora_menuItem.upd_bv_menuitem(r["id"].ToString(),r["id_goc"].ToString(), decimal.Parse(r["stt"].ToString()), r["ten"].ToString());
                }
                foreach (DataRow r1 in bv.load_bv_login().Tables[0].Rows)
                {
                    string s = "";
                    foreach (DataRow r2 in ora_menuItem.dm_bv_menuItem().Tables[0].Rows)
                    {
                        int k = r1["menuitem"].ToString().IndexOf(r2["id"].ToString() + "+");
                        if (r1["menuitem"].ToString().IndexOf(r2["id"].ToString() + "+") > -1)
                        {
                            s += r2["id"].ToString() + "+";
                        }
                    }
                    bv.upd_bv_login(int.Parse(r1["id"].ToString()), s);
                }
                MessageBox.Show("Lưu thành công !");
                butKetthuc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
        }

        private void treeviewPhanquyen_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                DataRow r;
                if (ads.Tables[0].Select("id='" + e.Node.Tag.ToString().PadLeft(4, '0') + "'").Length <= 0)
                {
                    if (e.Node.Checked)
                    {
                        r = ads.Tables[0].NewRow();
                        r["id"] = e.Node.Tag.ToString().PadLeft(4, '0');
                        r["ten"] = e.Node.Text;
                        r["stt"] = e.Node.Index;
                        if (e.Node.Parent != null)
                        {
                            if (e.Node.Parent.Tag.ToString() == "menuChucnang")
                            {
                                r["id_goc"] = "-1";
                            }
                            else
                            {
                                r["id_goc"] = e.Node.Parent.Tag.ToString().PadLeft(4, '0');
                            }
                        }
                        ads.Tables[0].Rows.Add(r);
                    }
                }
                else
                {
                    if (!e.Node.Checked)
                    {
                        r = libbc.getrowbyid(ads.Tables[0], "id='" + e.Node.Tag.ToString().PadLeft(4, '0') + "'");
                        if (r != null)
                        {
                            ads.Tables[0].Rows.Remove(r);
                        }
                    }

                }

                try
                {
                    if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                    {
                        f_Chon_Quyen(e.Node, e.Node.Checked);
                        if (e.Node.Checked)
                        {
                            f_Add_Idmenu_Cha(e.Node);
                        }
                        else
                        {
                            f_Remove_Idmenu_Cha(e.Node);

                        }
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void f_Add_Idmenu_Cha(TreeNode v_node)
        {
            DataRow r;
            if (v_node.Parent != null)
            {
                if (ads.Tables[0].Select("id='" + v_node.Parent.Tag.ToString().PadLeft(4, '0') + "'").Length <= 0)
                {
                    r = ads.Tables[0].NewRow();
                    r["id"] = v_node.Parent.Tag.ToString().PadLeft(4, '0');
                    r["ten"] = v_node.Parent.Text;
                    r["stt"] = v_node.Parent.Index;
                    if (v_node.Parent.Parent != null)
                    {
                        if (v_node.Parent.Parent.Tag.ToString() == "menuChucnang")
                        {
                            r["id_goc"] = "-1";
                        }
                        else r["id_goc"] = v_node.Parent.Parent.Tag.ToString().PadLeft(4, '0');
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                if (v_node.Parent != null)
                {
                    f_Add_Idmenu_Cha(v_node.Parent);
                }
            }
        }

        private void f_Remove_Idmenu_Cha(TreeNode v_node)
        {
            DataRow r;
            if (v_node.Parent != null)
            {
                foreach (TreeNode anode in v_node.Parent.Nodes)
                {
                    if (!bCheck_Menu_Con(v_node.Parent))
                    {
                        r = libbc.getrowbyid(ads.Tables[0], "id='" + v_node.Parent.Tag.ToString().PadLeft(4, '0') + "'");
                        if (r != null) ads.Tables[0].Rows.Remove(r);
                        break;
                    }
                    else break;

                }
                if (v_node.Parent != null)
                {
                    f_Remove_Idmenu_Cha(v_node.Parent);
                }
            }

        }

        private bool bCheck_Menu_Con(TreeNode v_node)
        {
            foreach (TreeNode anode in v_node.Nodes)
            {
                if (anode.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}