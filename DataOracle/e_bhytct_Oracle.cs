using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class e_bhytct_Oracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
         public e_bhytct_Oracle()
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
                sql = "insert into "+schema+".e_bhytct(ID,STT,NGAY,MAKP,MADOITUONG,MAVP,SOLUONG,DONGIA,VAT,VATTU,SOTIEN,SOTHE,";
                sql+="GIAMUA,TRA,NGAYTRA,BHYTDUYET,BHYTTRA,IDTONGHOP,MAKPTHUCHIEN,GIA_BH,MIEN,MABS,NGAYUD,ID_KTCAO,IDNHOMBHYT) values ";
                sql+="({ID},{STT},{NGAY},{MAKP},{MADOITUONG},{MAVP},{SOLUONG},{DONGIA},{VAT},{VATTU},{SOTIEN},{SOTHE},";
                sql+="{GIAMUA},{TRA},{NGAYTRA},{BHYTDUYET},{BHYTTRA},{IDTONGHOP},{MAKPTHUCHIEN},{GIA_BH},{MIEN},{MABS},{NGAYUD},{ID_KTCAO},{IDNHOMBHYT})";
                               
                
                sql=sql.Replace("{ID}",obj.ID.ToString());
                sql=sql.Replace("{STT}",obj.STT.ToString());
                sql = sql.Replace("{NGAY}", m_format.f_formatdata(obj.NGAY.ToString(),"date"));
                sql=sql.Replace("{MAKP}",m_format.f_formatdata(obj.MAKP.ToString()));
                sql=sql.Replace("{MADOITUONG}",obj.MADOITUONG.ToString());
                sql=sql.Replace("{MAVP}",obj.MAVP.ToString());
                sql=sql.Replace("{SOLUONG}",obj.SOLUONG.ToString());
                sql=sql.Replace("{DONGIA}",obj.DONGIA.ToString());
                sql=sql.Replace("{VAT}",obj.VAT.ToString());
                sql=sql.Replace("{VATTU}",obj.VATTU.ToString());
                sql=sql.Replace("{SOTIEN}",obj.SOTIEN.ToString());
                sql=sql.Replace("{SOTHE}",m_format.f_formatdata(obj.SOTHE.ToString()));
                sql=sql.Replace("{GIAMUA}",obj.GIAMUA.ToString());
                sql=sql.Replace("{TRA}",obj.TRA.ToString());
                sql=sql.Replace("{NGAYTRA}",m_format.f_formatdata(obj.NGAYTRA.ToString(),"date"));
                sql=sql.Replace("{BHYTDUYET}",obj.BHYTDUYET.ToString());
                sql=sql.Replace("{BHYTTRA}",obj.BHYTTRA.ToString());
                sql=sql.Replace("{IDTONGHOP}",obj.IDTONGHOP.ToString());
                sql=sql.Replace("{MAKPTHUCHIEN}",m_format.f_formatdata(obj.MAKPTHUCHIEN.ToString()));
                sql=sql.Replace("{GIA_BH}",obj.GIA_BH.ToString());
                sql=sql.Replace("{MIEN}",obj.MIEN.ToString());
                sql=sql.Replace("{MABS}",m_format.f_formatdata(obj.MABS.ToString()));
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
                sql = "delete " + schema + ".e_bhytct where id={id} ";
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
