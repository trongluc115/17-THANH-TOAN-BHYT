using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class DMNV_Oracle
    {
        #region khai bao bien
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public DMNV_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public DataTable f_get(string s_ma)
        {
            DataTable result = new DataTable();
            try
            {
                sql = " select a.MA ma,a.HOTEN HOTEN ,TO_CHAR(a.NGAYSINH,'DD/MM/YYYY') NGAYSINH,a.MAKP,b.tenkp TENKP,a.DIENTHOAI,a.DIDONG, ";
                sql+= " a.MESSAGE,c.ten CHUYENKHOA,a.NGONNGU,a.PHAI,a.DTNUOCNGOAI,a.BANGCAP,a.KINHNGHIEM, ";
                sql += " a.DIACHI,a.NGAYUD ,d.ten TRINHDO,e.ten TENNHOM,a.NHOM MANHOM";
                sql += " from " + schema + ".DMNV a ";
                sql += " left join MEDIBV115.BTDKP_BV b ON a.makp=b.makp ";
                sql += " left join medibv115.dmchuyenkhoa c on a.chuyenkhoa=c.id ";
                sql += " left join bv115.trinhdo d on a.trinhdo=d.id ";
                sql += " left join medibv115.nhomnhanvien e on e.id=a.nhom ";
                if (s_ma.Length > 0)
                { 
                    sql+= " where  MA='"+s_ma+"'";
                }
                ds = OracleData.get_data(sql);
                result = ds.Tables[0];
            }
            catch { }
            return result;

        }
      
        public DataTable f_getbyid(string s_ma)
        {
            DataTable result = new DataTable();
            try
            {
                sql = " select MA,HOTEN,MAKP,VIETTAT,DIENTHOAI,DIDONG, ";
                sql += " MESSAGE,CHUYENKHOA,NGONNGU,PHAI,DTNUOCNGOAI,BANGCAP,KINHNGHIEM,TO_CHAR(NGAYSINH,'DD/MM/YYYY') NGAYSINH, ";
                sql += " DIACHI,NGAYUD,TRINHDO,NHOM MANHOM ";
                sql += " from " + schema + ".DMNV ";
                 sql += " where  MA='" + s_ma + "'";               
                ds = OracleData.get_data(sql);
                result = ds.Tables[0];
            }
            catch { }
            return result;

        }
        public int f_insert(CDMNV obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into " + schema + ".DMNV(MA,HOTEN,MAKP,VIETTAT,DIENTHOAI,DIDONG, ";
                sql+= " MESSAGE,CHUYENKHOA,NGONNGU,PHAI,DTNUOCNGOAI,BANGCAP,KINHNGHIEM,NGAYSINH, ";
                sql += " DIACHI,NGAYUD,TRINHDO) ";
                sql += " VALUES ( '{MA}','{HOTEN}','{MAKP}','{VIETTAT}','{DIENTHOAI}','{DIDONG}', ";
                sql += " '{MESSAGE}',{CHUYENKHOA},'{NGONNGU}',{PHAI},'{DTNUOCNGOAI}','{BANGCAP}','{KINHNGHIEM}',{NGAYSINH}, ";
                sql += " '{DIACHI}',sysdate,'{TRINHDO}') ";

                sql=sql.Replace("{MA}",obj.Ma);
                sql=sql.Replace("{HOTEN}",obj.Hoten);
                sql=sql.Replace("{MAKP}",obj.Makp);
                sql=sql.Replace("{VIETTAT}",obj.Viettat);
                sql=sql.Replace("{DIENTHOAI}",obj.Dienthoai);
                sql=sql.Replace("{DIDONG}",obj.Didong);
                sql=sql.Replace("{MESSAGE}",obj.Message);
                sql=sql.Replace("{CHUYENKHOA}",obj.Chuyenkhoa);
                sql=sql.Replace("{NGONNGU}",obj.Ngonngu);
                sql=sql.Replace("{PHAI}",obj.Phai);
                sql=sql.Replace("{DTNUOCNGOAI}",obj.Dtnuocngoai);
                sql=sql.Replace("{BANGCAP}",obj.Bangcap);
                sql=sql.Replace("{KINHNGHIEM}",obj.Kinhnghiem);
                sql=sql.Replace("{NGAYSINH}",m_format.f_formatdata(obj.Ngaysinh.ToString(),"date"));
                sql=sql.Replace("{DIACHI}",obj.Diachi);
                sql = sql.Replace("{TRINHDO}", obj.Trinhdo);
                

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update(CDMNV obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "update " + schema + ".DMNV set HOTEN='{HOTEN}',MAKP='{MAKP}',VIETTAT='{VIETTAT}',DIENTHOAI='{DIENTHOAI}',DIDONG='{DIDONG}', ";
                sql += " MESSAGE='{MESSAGE}',CHUYENKHOA={CHUYENKHOA},NGONNGU='{NGONNGU}',PHAI={PHAI},DTNUOCNGOAI='{DTNUOCNGOAI}',BANGCAP='{BANGCAP}', ";
                sql+= "KINHNGHIEM='{KINHNGHIEM}',NGAYSINH={NGAYSINH},DIACHI='{DIACHI}',TRINHDO='{TRINHDO}' ";
                sql += " where MA='{MA}' ";
                

                sql = sql.Replace("{MA}", obj.Ma);
                sql = sql.Replace("{HOTEN}", obj.Hoten);
                sql = sql.Replace("{MAKP}", obj.Makp);
                sql = sql.Replace("{VIETTAT}", obj.Viettat);
                sql = sql.Replace("{DIENTHOAI}", obj.Dienthoai);
                sql = sql.Replace("{DIDONG}", obj.Didong);
                sql = sql.Replace("{MESSAGE}", obj.Message);
                sql = sql.Replace("{CHUYENKHOA}", obj.Chuyenkhoa);
                sql = sql.Replace("{NGONNGU}", obj.Ngonngu);
                sql = sql.Replace("{PHAI}", obj.Phai);
                sql = sql.Replace("{DTNUOCNGOAI}", obj.Dtnuocngoai);
                sql = sql.Replace("{BANGCAP}", obj.Bangcap);
                sql = sql.Replace("{KINHNGHIEM}", obj.Kinhnghiem);
                sql = sql.Replace("{NGAYSINH}", m_format.f_formatdata(obj.Ngaysinh.ToString(), "date"));
                sql = sql.Replace("{DIACHI}", obj.Diachi);
                sql = sql.Replace("{TRINHDO}", obj.Trinhdo);


                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_delete(string id)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //delete
                sql = "delete " + schema + ".DMNV where id={id} ";
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
