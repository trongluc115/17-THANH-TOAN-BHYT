using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;


namespace DataOracle
{
    public class CMenuItem
    {
        
        bv_menuitem bvmenuitem = new bv_menuitem();
        private string sql = "";
        private AccessData ora_conn = new AccessData();
        string schema = AccessData.schema;
        private DataSet ads = new DataSet();
       

        public void delete_bv_menuitem()
        {
            //  libc.execute_data("delete from bv115.bv_menuitem");
            sql="delete from " + schema + ".bv_menuitem";
            ora_conn.f_execute_data(sql);
        }

        public DataSet dm_bv_menuItem()
        {
            sql = "select * from " + schema + ".bv_menuitem";
            ads = ora_conn.get_data(sql);//libc.get_data("select * from bv115.bv_menuitem");
            return ads;
        }

        public bool upd_bv_menuitem(string id, string id_goc, decimal stt, string ten)
        {
            if (id != "menuChucnang")
            {
                sql = " update " + schema + ".bv_menuitem set id_goc='" + id_goc + "', stt='" + stt + "',ten='" + ten + "' where id='" + id + "'";
                try
                {
                    int num = 0;
                    num = ora_conn.f_execute_data(sql);
                    if (num == 0)
                    {
                        sql = "insert into " + schema + ".bv_menuitem(id,id_goc,stt,ten) values ('" + id + "','" + id_goc + "','" + stt + "','" + ten + "')";
                        ora_conn.f_execute_data(sql);
                    }
                }
                catch (Exception exception)
                {
                    //this.upd_error(exception.Message, this.sComputer, "bc_menuitem");
                    return false;
                }
            }
            return true;
        }

    }
}
