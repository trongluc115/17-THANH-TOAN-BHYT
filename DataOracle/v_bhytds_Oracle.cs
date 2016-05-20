using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;


namespace DataOracle
{
    public class v_bhytds_Oracle
    {
        #region khai bao bien

        AccessData OracleData;
        DataSet ds;
        private string schema = AccessData.schema;
        string sql = "";
      
        private CEve_log eve_log = new CEve_log();
        private CEve_logDAO eve_logDAO = new CEve_logDAO();
  
        #endregion
        public v_bhytds_Oracle()
        {
             OracleData = new AccessData(); 
        }
      
        public int f_insert(v_bhytds obj)
        {
            int result = 0;
            try
            {

                

                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into "+schema+".v_bhytds(ID,MABN,MAVAOVIEN,MAQL,IDKHOA,GIUONG,NGAYVAO,NGAYRA,CHANDOAN, ";
                sql+=" MAICD,SOTHE,MAPHU,TUNGAY,DENNGAY,MABV,NOIGIOITHIEU,TRAITUYEN,COMPUTER,USERID,NGAYUD,MAICDKT,CHANDOANKT,BCKTC,BCTHUOCUB,MAKP,HUONGKTC,MACN) ";
                
                sql += " values ({ID},{MABN},{MAVAOVIEN},{MAQL},{IDKHOA},{GIUONG},{NGAYVAO},{NGAYRA},{CHANDOAN},";
                sql += " {MAICD},{SOTHE},{MAPHU},{TUNGAY},{DENNGAY},{MABV},{NOIGIOITHIEU},{TRAITUYEN},{COMPUTER},{USERID},{NGAYUD},{MAICDKT},{CHANDOANKT},{BCKTC},{BCTHUOCUB},{MAKP},{HUONGKTC},{MACN}) ";
               
                sql=sql.Replace("{ID}",obj.ID.ToString());
                sql=sql.Replace("{MABN}",m_format.f_formatdata(obj.MABN.ToString()));
                sql=sql.Replace("{MAVAOVIEN}",obj.MAVAOVIEN.ToString());
                sql=sql.Replace("{MAQL}",obj.MAQL.ToString());
                sql=sql.Replace("{IDKHOA}",obj.IDKHOA.ToString());
                sql=sql.Replace("{GIUONG}",m_format.f_formatdata(obj.GIUONG.ToString()));
                sql=sql.Replace("{NGAYVAO}",m_format.f_formatdata(obj.NGAYVAO.ToString(),"date"));
                sql = sql.Replace("{NGAYRA}", m_format.f_formatdata(obj.NGAYRA.ToString(), "date"));
                sql=sql.Replace("{CHANDOAN}",m_format.f_formatdata(obj.CHANDOAN.ToString()));
                sql=sql.Replace("{MAICD}",m_format.f_formatdata(obj.MAICD.ToString()));
                sql=sql.Replace("{SOTHE}",m_format.f_formatdata(obj.SOTHE.ToString()));
                sql=sql.Replace("{MAPHU}",m_format.f_formatdata(obj.MAPHU.ToString()));
                sql = sql.Replace("{TUNGAY}", m_format.f_formatdata(obj.TUNGAY.ToString(), "date"));
                sql = sql.Replace("{DENNGAY}", m_format.f_formatdata(obj.DENNGAY.ToString(), "date"));
                sql=sql.Replace("{MABV}",m_format.f_formatdata(obj.MABV.ToString()));
                sql=sql.Replace("{NOIGIOITHIEU}",m_format.f_formatdata(obj.NOIGIOITHIEU.ToString()));
                sql=sql.Replace("{TRAITUYEN}",obj.TRAITUYEN.ToString());
                sql=sql.Replace("{COMPUTER}",m_format.f_formatdata(obj.COMPUTER.ToString()));
                sql=sql.Replace("{USERID}",obj.USERID.ToString());
                sql = sql.Replace("{NGAYUD}",  m_format.f_formatdata(obj.NGAYUD.ToString(), "date"));
                sql=sql.Replace("{MAICDKT}",m_format.f_formatdata(obj.MAICDKT.ToString()));
                sql = sql.Replace("{CHANDOANKT}", m_format.f_formatdata(obj.CHANDOANKT.ToString()));
                sql = sql.Replace("{BCKTC}", m_format.f_formatdata(obj.BCKTC.ToString()));
                sql = sql.Replace("{BCTHUOCUB}", m_format.f_formatdata(obj.BCThuocUB.ToString()));
                sql = sql.Replace("{MAKP}", m_format.f_formatdata(obj.MaKP.ToString()));
                sql = sql.Replace("{HUONGKTC}", m_format.f_formatdata(obj.HuongKTC.ToString()));
                sql = sql.Replace("{MACN}", m_format.f_formatdata(obj.Macanngheo.ToString()));
              
            
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_delete(CThanhToanBHYT thanhtoan)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //delete
                sql = "delete "+schema+".v_bhytds where id={id} ";
                sql = sql.Replace("{id}", thanhtoan.ID.ToString());
                result = OracleData.f_execute_data(sql);

                eve_log.Action = "DELETE";
                eve_log.Content = schema + ".v_BHYTDS_" + thanhtoan.ID.ToString() + "_" + thanhtoan.MaBN + "_" + thanhtoan.SoTheBHYT;
                eve_logDAO.f_insert(eve_log);


            }
            catch
            {

            }
            return result;
        }
        public string f_get_capid(string userid)
        {
            string kq = "";
            try
            {
                AccessData data = new AccessData();
                sql = " select to_char(systimestamp,'yymmddhh24misssssff')||'{userid}' capid from dual";
                sql = sql.Replace("{userid}", userid);
                ds = data.get_data(sql);
                kq = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            return kq;
        }
        public int f_update_ICD(v_bhytds obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                
                sql = "update "+schema+".v_bhytds ";
                sql += " set  MAICD={MAICD} ,CHANDOAN={CHANDOAN} ";
                sql += " where id={ID} ";
                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{CHANDOAN}", m_format.f_formatdata(obj.CHANDOAN.ToString()));
                sql = sql.Replace("{MAICD}", m_format.f_formatdata(obj.MAICD.ToString()));
                

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update_ICD9(string s_maicd9,string s_id)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;

                sql = "update " + schema + ".v_bhytds ";
                sql += " set  MAICD9='{MAICD}' ";
                sql += " where id='{ID}' ";
                sql = sql.Replace("{ID}", s_id);
                sql = sql.Replace("{MAICD}", s_maicd9);


                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update(v_bhytds obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;

                sql = "update "+schema+".v_bhytds ";
                sql += " set  MAICD={MAICD} ,CHANDOAN={CHANDOAN},MAKP={MAKP} ";
                sql += " ,sothe={SOTHE},NGAYVAO=TO_DATE('{NGAYVAO}','dd/MM/yyyy'),NGAYRA=TO_DATE('{NGAYRA}','dd/MM/yyyy')";
                sql += " ,TUNGAY=TO_DATE('{TUNGAY}','dd/MM/yyyy'),DENNGAY=TO_DATE('{DENNGAY}','dd/MM/yyyy') ";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", obj.ID.ToString());

                sql = sql.Replace("{CHANDOAN}", m_format.f_formatdata(obj.CHANDOAN.ToString()));
                sql = sql.Replace("{MAICD}", m_format.f_formatdata(obj.MAICD.ToString()));
                sql = sql.Replace("{SOTHE}", m_format.f_formatdata(obj.SOTHE));
                sql = sql.Replace("{MAKP}", m_format.f_formatdata(obj.MaKP));
                sql = sql.Replace("{NGAYVAO}", string.Format("{0:dd/MM/yyyy}",obj.NGAYVAO));
                sql = sql.Replace("{NGAYRA}", string.Format("{0:dd/MM/yyyy}",obj.NGAYRA));
                sql = sql.Replace("{TUNGAY}", string.Format("{0:dd/MM/yyyy}", obj.TUNGAY));
                sql = sql.Replace("{DENNGAY}", string.Format("{0:dd/MM/yyyy}", obj.DENNGAY));



                result = OracleData.f_execute_data(sql);
                eve_log.Action = "UPDATE";
                eve_log.Content = schema + ".v_BHYTDS_" + obj.ID.ToString() + "_" + obj.MABN + "_" + obj.SOTHE + "_" + string.Format("{0:dd/MM/yyyy}", obj.NGAYVAO);
                eve_log.Content += "_" + string.Format("{0:dd/MM/yyyy}", obj.NGAYRA) + "_" + obj.MAICD.ToString();
                eve_logDAO.f_insert(eve_log);


            }
            catch
            {

            }
            return result;
        }
    }
}
