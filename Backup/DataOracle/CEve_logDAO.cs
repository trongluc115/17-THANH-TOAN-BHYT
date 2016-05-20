using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using DataUpdate;
namespace DataOracle
{
    public class CEve_logDAO
    {
        private string schema = AccessData.schema;
        private CConnection_Oracle OracleData = new CConnection_Oracle();
        private string sql = "";
        public int f_insert(CEve_log log_obj )

        {
            int result = 0;
            try
            {
                
                log_obj.Userid= AccessData.m_userid;
                log_obj.Computer = Computer.getMachineName();
                log_obj.Id = m_option.f_get_capid(log_obj.Userid);

                //PHAU THUAT KTC
                sql = "insert into " + schema + ".eve_log(ID,USERID,COMPUTER,ACTION,CONTENT)";
                sql += " values ('{ID}','{USERID}','{COMPUTER}','{ACTION}','{CONTENT}')";
                
                sql = sql.Replace("{ID}", log_obj.Id);
                sql = sql.Replace("{USERID}", log_obj.Userid);
                sql = sql.Replace("{COMPUTER}", log_obj.Computer);
                sql = sql.Replace("{ACTION}", log_obj.Action);
                sql = sql.Replace("{CONTENT}", log_obj.Content);



                result = OracleData.setData(sql);



            }
            catch
            {

            }
            return result;
        }
    }
}
