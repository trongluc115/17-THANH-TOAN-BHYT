using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class DT_history_Oracle
    {
        #region khai bao bien
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public DT_history_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public DataTable f_get(string s_mabs,string s_idnhom)                          
        {
            DataTable result = new DataTable();
            try
            {
                sql = " select a.ID,b.TEN,a.NOIDUNG,to_char(a.TUNGAY,'dd/mm/yyyy') tungay,to_char(a.DENNGAY,'dd/mm/yyyy') denngay,a.value,to_char(a.NGAY,'dd/mm/yyyy') ngay ";
               
                sql += " from " + schema + ".DT_HISTORY a";
                sql += " inner join " + schema + ".DT_LOAI b on a.id_loai=b.id ";
                //sql += " inner join " + schema + ".DT_NHOM c on b.id_nhom=c.id ";
                sql += " where  a.MABS='" + s_mabs + "' and b.id_nhom='"+s_idnhom+"'";
                sql += " order by a.id desc ";
              
                ds = OracleData.get_data(sql);
                result = ds.Tables[0];
            }
            catch { }
            return result;

        }
        public DataTable f_gettoreport(string s_mabs)
        {
            DataTable result = new DataTable();
            try
            {
                sql = " select a.MA ma,a.HOTEN HOTEN ,TO_CHAR(a.NGAYSINH,'DD/MM/YYYY') NGAYSINH,a.MAKP,b.tenkp TENKP,a.DIENTHOAI,a.DIDONG, ";
                sql += " a.MESSAGE,c.ten CHUYENKHOA,a.NGONNGU,a.PHAI,a.DTNUOCNGOAI,a.BANGCAP,a.KINHNGHIEM, ";
                sql += " a.DIACHI,a.NGAYUD ,d.ten TRINHDO,e.ten TENNHOM,a.NHOM MANHOM";
                sql += " ,g.ID MALOAI,h.TEN TENLOAI,g.NOIDUNG ,to_char(g.TUNGAY,'dd/mm/yyyy') tungay,to_char(g.DENNGAY,'dd/mm/yyyy') denngay,to_char(g.NGAY,'dd/mm/yyyy') ngay,g.value,k.ten TENNHOMQL ";
                sql += " from " + schema + ".DMNV a ";
                sql += " left join MEDIBV115.BTDKP_BV b ON a.makp=b.makp ";
                sql += " left join medibv115.dmchuyenkhoa c on a.chuyenkhoa=c.id ";
                sql += " left join bv115.trinhdo d on a.trinhdo=d.id ";
                sql += " left join medibv115.nhomnhanvien e on e.id=a.nhom ";
                sql += " inner join " + schema + ".DT_HISTORY g on a.ma=g.mabs";
                sql += " inner join " + schema + ".DT_LOAI h on g.id_loai=h.id ";
                sql += " inner join " + schema + ".DT_NHOM k on h.id_nhom=k.id ";
                sql += " where  a.MA='" + s_mabs + "'";
                

                

                ds = OracleData.get_data(sql);
                result = ds.Tables[0];
            }
            catch { }
            return result;
        }
        public int f_insert(CDT_history obj)
        {
            int result = 0;
            try
            {


                
                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into " + schema + ".DT_HISTORY(ID,MABS,ID_LOAI,NOIDUNG,TUNGAY,DENNGAY,NGAY,NGAYUD,VALUE) ";
                sql += " VALUES ( {ID},'{MABS}','{ID_LOAI}','{NOIDUNG}',{TUNGAY},{DENNGAY},{NGAY},sysdate,{VALUE})";
                
                sql=sql.Replace("{ID}",m_option.f_get_capid(obj.Mabs));
                sql=sql.Replace("{MABS}",obj.Mabs);
                sql=sql.Replace("{ID_LOAI}",obj.Id_loai);
                sql=sql.Replace("{NOIDUNG}",obj.Noidung);
                
                sql = sql.Replace("{TUNGAY}", m_format.f_formatdata(obj.Tungay.ToString(), "date"));
                sql = sql.Replace("{DENNGAY}", m_format.f_formatdata(obj.Denngay.ToString(), "date"));
                sql = sql.Replace("{NGAY}", m_format.f_formatdata(obj.Ngay.ToString(), "date"));
                sql = sql.Replace("{VALUE}", obj.Value.ToString());
                
                
                

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update(CDT_history obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "update " + schema + ".DT_HISTORY ";
                sql += " SET ID={ID},MABS='MABS',ID_LOAI='ID_LOAI',NOIDUNG='NOIDUNG',TUNGAY={TUNGAY}, ";
                sql+= " DENNGAY={DENNGAY},NGAY={NGAY} ";
                sql += " WHERE ID={ID}";

                sql = sql.Replace("{ID}", obj.Id);
                sql = sql.Replace("{MABS}", obj.Mabs);
                sql = sql.Replace("{ID_LOAI}", obj.Id_loai);
                sql = sql.Replace("{NOIDUNG}", obj.Noidung);
                sql = sql.Replace("{TUNGAY}", m_format.f_formatdata(obj.Tungay.ToString(), "date"));
                sql = sql.Replace("{DENNGAY}", m_format.f_formatdata(obj.Denngay.ToString(), "date"));
                sql = sql.Replace("{NGAY}", m_format.f_formatdata(obj.Ngay.ToString(), "date"));
                
                

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
                sql = "delete " + schema + ".DT_HISTORY where id={id} ";
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
