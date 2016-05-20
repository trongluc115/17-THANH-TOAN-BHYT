using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class Ccdha_thuocphimOracle
    {
        #region khai bao bien
        
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public Ccdha_thuocphimOracle()
        {
            OracleData = new AccessData(); 
        }
        public int f_insert(CCDHA_THUOCPHIM obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into "+schema+".cdha_thuocphim(id,stt,mabd,soluong,sl_phimhu,ngayud)   values ";
                sql += "({ID},{STT},{MABD},{SOLUONG},{SL_PHIMHU},sysdate)";
                                             
                sql=sql.Replace("{ID}",obj.Id.ToString());
                sql=sql.Replace("{STT}",obj.Stt.ToString());
                sql = sql.Replace("{MABD}",obj.Mabd.ToString());
                sql=sql.Replace("{SOLUONG}",obj.Soluong.ToString());
                sql=sql.Replace("{SL_PHIMHU}",obj.Sl_phimhu.ToString());
                

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_delete(long id)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //delete
                sql = "delete " + schema + ".cdha_thuocphim where id={id} ";
                sql = sql.Replace("{id}", id.ToString());
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public DataSet f_get(string  s_id)
        {
            

            try
            {

                ds = new DataSet();

                string userid = AccessData.m_userid;
                //delete
                sql = "select a.mabd,b.ten,b.dang,a.soluong,a.sl_phimhu ";
                sql+= " from  " + schema + ".cdha_thuocphim a";
                sql+= " inner join d_dmbd b on a.mabd=b.id";
                sql+= " where a.id={s_id} ";
                sql = sql.Replace("{s_id}", s_id);
                ds=OracleData.get_data(sql);



            }
            catch
            {

            }
            return ds;
        }
        public DataSet f_getdinhmuc(string s_mavp)
        {


            try
            {

                ds = new DataSet();

                string userid = AccessData.m_userid;
                //delete
                sql = "SELECT a.mabd,'-','-',a.soluong,a.sl_phimhu FROM MEDIBV115.CDHA_DINHMUC_VATTU A ";
                sql+= " INNER JOIN MEDIBV115.CDHA_KYTHUAT B ON A.MAKT=B.ID ";
                sql+= " WHERE B.IDVP='{s_mavp}'";
                sql = sql.Replace("{s_mavp}", s_mavp);
                ds = OracleData.get_data(sql);



            }
            catch
            {

            }
            return ds;
        }
        public DataSet f_getdanhmuc_vattu()
        {


            try
            {

                ds = new DataSet();

                string userid = AccessData.m_userid;
                //delete
                sql = " SELECT DISTINCT a.mabd id,b.ten NAME FROM MEDIBV115.CDHA_DINHMUC_VATTU A ";
                sql += " INNER JOIN MEDIBV115.D_DMBD B on A.MABD=B.ID ORDER BY B.TEN ";
                
                
                ds = OracleData.get_data(sql);



            }
            catch
            {

            }
            return ds;
        }
        


    }
}
