using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class Export_Oracle
    {
        #region khai bao bien
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public Export_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public int f_ExportFromV_chidinh(DateTime ngay,string dieukien)
        {
            int result = 0;
            try
            {
                sql = " insert into bv115.temp_v_chidinh(ID,MABN,MAVAOVIEN,MAQL,IDKHOA,NGAY,LOAI,MAKP,MADOITUONG,MAVP,MABS,USERID,IDTRONGOI) ";
                sql += " select ID,MABN,MAVAOVIEN,MAQL,IDKHOA,NGAY,LOAI,MAKP,MADOITUONG,MAVP,MABS,USERID,IDTRONGOI from " + m_format.getdatabase(ngay) + ".v_chidinh";
                sql+= " where  1=1 "+dieukien;                
                result=OracleData.f_execute_data(sql);              
            }
            catch { }
            return result;

        }
        public int f_ExportFrombhyt(DateTime ngay, string dieukien)
        {
            int result = 0;
            try
            {
                sql = "  insert into bv115.bhyt_cn(MAQL,SOTHE,MACN,TUNGAY,DENNGAY,MMYY)  ";
                sql += " select MAQL,SOTHE,MACN,TUNGAY,DENNGAY,to_char(ngayud,'MMYY') MMYY  from " + m_format.getdatabase(ngay) + ".bhyt ";
                sql += " where  1=1 " + dieukien;
                result = OracleData.f_execute_data(sql);
            }
            catch { }
            return result;

        }
        public int f_Exportd_dmbdbh()
        {
            int result = 0;
            try
            {
                sql = "  insert into bv115.d_dmbdbh(id,id_type,filter,bhyt) ";
                sql += " select id,0,0,bhyt from d_dmbd where id not in (select id from bv115.d_dmbdbh) and tenhc is not null ";
                
                
                result = OracleData.f_execute_data(sql);
            }
            catch { }
            return result;

        }
        public int f_ExportFrombhyt(string dieukien)
        {
            int result = 0;
            try
            {
                sql = "  insert into bv115.bhyt_cn(MAQL,SOTHE,MACN,TUNGAY,DENNGAY,MMYY)  ";
                sql += " select MAQL,SOTHE,MACN,TUNGAY,DENNGAY,to_char(ngayud,'MMYY') MMYY  from medibv115.bhyt ";
                sql += " where  1=1 " + dieukien;
                result = OracleData.f_execute_data(sql);
            }
            catch { }
            return result;

        }
        
       
        public int f_deletetemp(string s_table)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                //delete
                sql = "delete "  +s_table ;                
                result = OracleData.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }

    }
}
