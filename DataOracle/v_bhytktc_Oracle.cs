using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class v_bhytktc_Oracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
         public v_bhytktc_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public int f_insert(v_bhytct obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into "+schema+".v_bhytktc(ID,STT,MADOITUONG,MAVP,SOLUONG,DONGIA,";
                sql+="GIAMUA,BHYTTRA,GIA_BH,MIEN,NGAYUD,ID_KTCAO,IDNHOMBHYT) values ";
                sql+="({ID},{STT},{MADOITUONG},{MAVP},{SOLUONG},{DONGIA},";
                sql+="{GIAMUA},{BHYTTRA},{GIA_BH},{MIEN},{NGAYUD},{ID_KTCAO},{IDNHOMBHYT})";
                               
                
                sql=sql.Replace("{ID}",obj.ID.ToString());
                sql=sql.Replace("{STT}",obj.STT.ToString());
                sql=sql.Replace("{MADOITUONG}",obj.MADOITUONG.ToString());
                sql=sql.Replace("{MAVP}",obj.MAVP.ToString());
                sql=sql.Replace("{SOLUONG}",obj.SOLUONG.ToString());
                sql=sql.Replace("{DONGIA}",obj.DONGIA.ToString());
                sql=sql.Replace("{BHYTTRA}",obj.BHYTTRA.ToString());
                sql=sql.Replace("{GIA_BH}",obj.GIA_BH.ToString());
                sql = sql.Replace("{GIAMUA}", obj.GIAMUA.ToString());
                sql=sql.Replace("{MIEN}",obj.MIEN.ToString());
                sql = sql.Replace("{NGAYUD}", m_format.f_formatdata(obj.NGAYUD.ToString(), "date"));
                sql=sql.Replace("{ID_KTCAO}",obj.ID_KTCAO.ToString());
                sql=sql.Replace("{IDNHOMBHYT}",obj.IDNHOMBHYT.ToString());

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
                sql = "delete " + schema + ".v_bhytktc where id={id} ";
                sql = sql.Replace("{id}", id.ToString());
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }

    }
}
