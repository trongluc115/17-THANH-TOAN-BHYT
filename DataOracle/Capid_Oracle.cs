using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class Capid_Oracle
    {
        #region khai bao bien
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public Capid_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public string f_get(string s_table)
        {
            string result = "";
            try
            {
                sql=" select CUR_ID ";                              
                sql += " from " + schema + ".CAPID ";
                sql+= " where  TABLENAME='"+s_table+"'";
                
                ds = OracleData.get_data(sql);
                result = ds.Tables[0].Rows[0]["cur_id"].ToString();
            }
            catch { }
            return result;

        }
        
        public int f_update(CCapid obj)
        {
            int result = 0;
            try
            {   string userid = AccessData.m_userid;
                //PHAU THUAT KTC
            sql = "update " + schema + ".capid set CUR_ID='{s_curid}' ";
            sql += " where tablename='{s_table}' ";
                

                sql = sql.Replace("{s_curid}", obj.S_curid);
                sql = sql.Replace("{s_table}", obj.S_table);
              


                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update_one(string s_table)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "update " + schema + ".capid set CUR_ID=CUR_ID+1 ";
                sql += " where tablename='{s_table}' ";


                
                sql = sql.Replace("{s_table}", s_table);



                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_delete(string s_table)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //delete
                sql = "delete " + schema + ".capid where tablename='{s_table}' ";
                sql = sql.Replace("{s_table}", s_table);
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }

    }
}
