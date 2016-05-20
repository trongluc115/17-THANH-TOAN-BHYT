using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data;
using DataUpdate;


namespace DataOracle
{
    public class CPhanQuyen
    {
        private CBV_loginDAO bvlogin = new CBV_loginDAO();
        private CConnection_Oracle conn = new CConnection_Oracle();
        private CMenuItem mn = new CMenuItem();
        private DataSet ds;

        public DataSet Load_TenUser()
        {
          ds= bvlogin.load_bv_login();
          return ds;
        }
        public DataSet dm_bc_menuItem()
        {
            ds = mn.dm_bv_menuItem();
            return ds;
        }
              
        public void upbv_dlogin_right(int id, string sRight)
        {
            bvlogin.upd_bv_login(id, sRight);
        }
        public void del_bv_dlogin_right(int id)
        {
            bvlogin.del_bv_login(id);
        }
        public void delrec(DataTable dt, string exp)
        {
            conn.delrec(dt,exp);
        }
        public void updrec_right( DataTable dt,  int id, string sRight)
         {
             string exp = "id=" + id;
             if (conn.LayDongTheoDieuKien(dt, exp) == null)
             {
                 DataRow row = dt.NewRow();
                 row["id"] = id;
                 row["menuitem"] = sRight;
                 dt.Rows.Add(row);
             }
             else
             {
                 dt.Select(exp)[0]["menuitem"] = sRight;
             }
         }        
        private object getrowbyid(DataTable dt, string exp)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
}
