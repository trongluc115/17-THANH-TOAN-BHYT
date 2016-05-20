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
    public partial class frmPhanQuyen : Form
    {
        private CPhanQuyen pq = new CPhanQuyen(); 
        private DataSet ds = new DataSet();
        private DataSet adsRight = new DataSet();
        private TreeView treeView1;
        private string strRight = "";
        public frmPhanQuyen()
        {
         
            InitializeComponent();
            f_Load_Tree();

        }
        public frmPhanQuyen(TreeNode tn )
        {            
           InitializeComponent();
           treeViewMenuItem.Nodes.Add(tn);  
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            frmThemNguoiDung f = new frmThemNguoiDung(ds);
           // f.MdiParent = this;
            f.ShowDialog();
          //  ds = f.dsright;
            ds = pq.Load_TenUser();
            dtgUser.DataSource = ds.Tables[0];
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            strRight = "";
            f_Get_Right();
            luu_right();
            butThem.Focus();            

        }
        private void f_Get_Right()
        {
            foreach (TreeNode anode in treeViewMenuItem.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Get_Right(anode);
                }
            }
        }
        private void f_Get_Right(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        if (anode.Checked)
                        {
                            strRight += anode.Tag.ToString() + "+";
                        }
                        f_Get_Right(anode);
                    }
                    else
                    {
                        if (anode.Checked)
                        {
                            strRight += anode.Tag.ToString() + "+";
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void luu_right()
        {
            try
            {
                pq.upbv_dlogin_right(int.Parse(dtgUser[dtgUser.CurrentCell.RowNumber, 0].ToString()), strRight);
                MessageBox.Show("Lưu thành công !", "BV115");
                pq.updrec_right(ds.Tables[0], int.Parse(dtgUser[dtgUser.CurrentCell.RowNumber, 0].ToString()), strRight);
            }
            catch {
                MessageBox.Show("Không cập nhật được !","BV115");
            }
        }

        private void butKethuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            ds = pq.Load_TenUser();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("Icon");                    
                   // AddGridTableStyle();
                    dtgUser.DataSource = ds.Tables[0];
                }
            }          
           
            ref_text();
        }
        private void AddGridTableStyle()
        {
            dtgUser.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.RowHeadersVisible = false;
            ts.ColumnHeadersVisible = false;
            ts.GridLineColor = Color.White;

            //DataGridIconColumn iconColumn = new DataGridIconColumn(this.imgList, new delegateGetIconIndexForRow(MyGetImageIndexForRow));
            //iconColumn.HeaderText = "";
            //iconColumn.MappingName = "Icon";
            //iconColumn.Width = this.imgList.Images[0].Size.Width;
            //ts.GridColumnStyles.Add(iconColumn);
            //dtgUser.TableStyles.Add(ts);
            DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();

            TextCol1 = new DataGridTextBoxColumn();
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dtgUser.TableStyles.Add(ts);

            TextCol1 = new DataGridTextBoxColumn();
            TextCol1.MappingName = "hoten";
            TextCol1.HeaderText = "hoten";
            TextCol1.Width = 150;
            ts.GridColumnStyles.Add(TextCol1);
            dtgUser.TableStyles.Add(ts);

           
            TextCol1.MappingName = "username";
            TextCol1.HeaderText = "username";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dtgUser.TableStyles.Add(ts);

            TextCol1 = new DataGridTextBoxColumn();
            TextCol1.MappingName = "password";
            TextCol1.HeaderText = "password";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dtgUser.TableStyles.Add(ts);

            TextCol1 = new DataGridTextBoxColumn();
            TextCol1.MappingName = "menuitem";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dtgUser.TableStyles.Add(ts);  
        }
        private void ref_text()
        {
            try
            {
                //i_nhom = int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 4].ToString());
               // txtRight.Text = dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString();
                string s = dtgUser[dtgUser.CurrentCell.RowNumber, 1].ToString();
                txtuser.Text = dtgUser[dtgUser.CurrentCell.RowNumber,1].ToString() + "_ " + dtgUser[dtgUser.CurrentCell.RowNumber, 2].ToString();//userid_hoten
                f_Set_Right();
            }
            catch 
                //(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Set_Right()
        {
            foreach (TreeNode anode in treeViewMenuItem.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    if (dtgUser[dtgUser.CurrentCell.RowNumber, 4].ToString().Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                    {
                        anode.Checked = true;
                    }
                    else 
                        anode.Checked = false;
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
                        if (dtgUser[dtgUser.CurrentCell.RowNumber, 4].ToString().Trim().IndexOf(anode.Tag.ToString() + "+") != -1)//menuitem
                        {
                            anode.Checked = true;
                        }
                        else 
                            anode.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_Tree()
        {
            adsRight = pq.dm_bc_menuItem();
            try
            {
                treeViewMenuItem.Nodes.Clear();
            }
            catch (Exception ex)
            { }
            TreeNode anode, anode1;
            anode1 = new TreeNode("Chức năng");
            anode1.Tag = "menuChucnang";
            anode1.Name = "menuChucnang";
            treeViewMenuItem.Nodes.Add(anode1);
            foreach (DataRow r in adsRight.Tables[0].Select("id_goc='-1'", "id"))
            {
                anode = new TreeNode(r["ten"].ToString());
                anode.Tag = r["id"].ToString().Trim();
                anode.ForeColor = Color.Black;
                if (adsRight.Tables[0].Select("id_goc='" + anode.Tag.ToString() + "'", "stt").Length > 0)
                {
                    f_Add_Node(anode);
                }
                anode1.Nodes.Add(anode);
            }
            treeViewMenuItem.ExpandAll();
            treeViewMenuItem.SelectedNode = anode1;
        }
        private void f_Add_Node(TreeNode v_node)
        {
            try
            {
                TreeNode anode;
                foreach (DataRow r in adsRight.Tables[0].Select("id_goc='" + v_node.Tag.ToString() + "'", "stt"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id"].ToString().Trim();
                    anode.ForeColor = Color.Black;
                    if (adsRight.Tables[0].Select("id_goc='" + anode.Tag.ToString() + "'", "stt").Length > 0)
                    {
                        f_Add_Node(anode);
                    }
                    v_node.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }

        private void treeViewMenuItem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    f_Chon_Quyen(e.Node, e.Node.Checked);
                }
            }
            catch
            {
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

        private void txtNodeTextSearch_Enter(object sender, EventArgs e)
        {
            txtNodeTextSearch.Text = "";
        }

        private void txtNodeTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) treeViewMenuItem.Focus();
        }

        private void txtNodeTextSearch_TextChanged(object sender, EventArgs e)
        {
            NodeTextSearch();
        }

        private void NodeTextSearch()
        {
            ClearBackColor();
            FindByText();
        }

        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }

        private void FindByText()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }

        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtNodeTextSearch.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }

        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }

        private void txtTimTenUser_Enter(object sender, EventArgs e)
        {
            txtTimTenUser.Text = "";
        }

        private void txtTimTenUser_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTimTenUser)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dtgUser.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.RowFilter = "hoten like '%" + txtTimTenUser.Text.Trim() + "%' or username like '%" + txtTimTenUser.Text.Trim() + "%'";
                    ref_text();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); return; }
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Không được hủy !", "BV115");
                return;
            }
            if (MessageBox.Show("Đồng ý hủy ?", "BV115", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pq.del_bv_dlogin_right(int.Parse(dtgUser[dtgUser.CurrentCell.RowNumber, 0].ToString()));            
                pq.delrec(ds.Tables[0], "id=" + int.Parse(dtgUser[dtgUser.CurrentCell.RowNumber, 0].ToString()));
                ds.AcceptChanges();
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            toolStripMenuItem13.Text = toolStripMenuItem13.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
        }
        private void f_Set_All(bool bAll)
        {
            foreach (TreeNode anode in treeViewMenuItem.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Chon_Quyen(anode, bAll);
                }
            }
        }
        private void dtgUser_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();           
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            // frmThemNguoiDung(DataSet dset, int userid,string s_hoTen, string tenDangNhap, string psw, string right, bool change)
            frmThemNguoiDung f = new frmThemNguoiDung(ds, int.Parse(dtgUser[dtgUser.CurrentCell.RowNumber, 0].ToString()), dtgUser[dtgUser.CurrentCell.RowNumber, 1].ToString(), dtgUser[dtgUser.CurrentCell.RowNumber, 2].ToString(), dtgUser[dtgUser.CurrentCell.RowNumber, 3].ToString(), dtgUser[dtgUser.CurrentCell.RowNumber, 4].ToString(), true);
            f.ShowDialog();
           // ds = f.dsright;
            ds = pq.Load_TenUser();
            dtgUser.DataSource = ds.Tables[0];
        }

        private void butCopyts_Click(object sender, EventArgs e)
        {

        }
    }
}