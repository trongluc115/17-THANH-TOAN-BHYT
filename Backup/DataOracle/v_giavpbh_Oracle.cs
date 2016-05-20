using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
namespace DataOracle
{
    public class v_giavpbh_Oracle
    {
         #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;
        DataSet ds;
        string sql = "";
        #endregion
        public v_giavpbh_Oracle()
        {
            OracleData = new AccessData();
        }
        #region get
        public DataTable getListBaoCao(v_giavpbh obj)
        {
            DataTable dt_refult=new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select * from bv115.v_giavpbh  ";
                
                
                sql = sql.Replace("@enable", obj.ENABLE.ToString());
                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public double getTiLeBHYTtra(string mavp)
        {
            double tile = 1;
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select BHYT from bv115.v_giavpbh where id={mavp} ";


                sql = sql.Replace("{mavp}", mavp);
                DataSet ds = OracleData.get_data(sql);
                tile =double.Parse( ds.Tables[0].Rows[0][0].ToString())/100;
                

            }
            catch
            {

            }
            return tile;
        }

        public int is_ktcgoi(string s_mavp)
        {
            
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select ktcgoi from bv115.v_giavpbh where id={mavp} ";


                sql = sql.Replace("{mavp}", s_mavp);
                DataSet ds = OracleData.get_data(sql);
                result= int.Parse(ds.Tables[0].Rows[0][0].ToString());


            }
            catch
            {

            }
            return result;
        }

        public DataTable getListBaoCaoFromChoice(DateTime tungay,DateTime denngay,string s_loaibn)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql  = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join v_giavp vp on vp.id=bhct.mavp ";
                sql += " join BV115.v_giavpbh vpbh on vp.id=vpbh.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and  vpbh.filter=1  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}",tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                if (s_loaibn != "-1")
                {
                    sql += " and bhll.loaibn=" + s_loaibn;
                }

                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public DataTable getListBaoCaoFromList(DateTime tungay, DateTime denngay, string s_loaibn,string s_listvp)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join v_giavp vp on vp.id=bhct.mavp ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay}  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                if (s_loaibn != "-1")
                {
                    sql += " and bhll.loaibn=" + s_loaibn;
                }
                if (s_listvp.Length > 0)
                {
                    sql += " and bhct.mavp in (" + s_listvp + ")";
                }

                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public DataTable getListM21_SYT(DateTime tungay, DateTime denngay,string dieukien)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select bhds.id ma_lk,row_number() over (order by bhds.id) stt,to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join v_giavp vp on vp.id=bhct.mavp ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} {dieukien} ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                sql = sql.Replace("{dieukien}", dieukien);
                sql = sql.Replace("bhds", "a");
                sql = sql.Replace("bhll", "b");
                sql = sql.Replace("bhct", "c");

                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        #endregion
    
        #region insert


        public int f_insert(v_bhytct obj)
        {
            int result = 0;
            try
            {
            }
            catch
            {
            }
            return result;
        }
        #endregion
        #region update
        public int f_update(v_giavpbh obj)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                
                sql = " update bv115.v_giavpbh  ";
                sql += " set id_type='{id_type}',filter={enable} ,ktcgoi={ktcgoi} ,bhyt={bhyt},id_byt='{id_byt}'";
                sql += " where id='{id}' ";
                sql = sql.Replace("{id_type}", obj.ID_TYPE);
                sql = sql.Replace("{id}", obj.ID.ToString());               
                sql = sql.Replace("{enable}", obj.ENABLE.ToString());
                sql = sql.Replace("{ktcgoi}", obj.Ktcgoi.ToString());
                sql = sql.Replace("{bhyt}", obj.BHYT.ToString());
                sql = sql.Replace("{id_byt}", obj.Id_byt.ToString());
                result = OracleData.f_execute_data(sql);
             }
            catch
            {

            }
            return result;
        }
        #endregion
        #region delete
        public int f_delete(long id)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //delete
                sql = "delete bv115.v_giavpbh  where id=@id ";
                sql = sql.Replace("@id", id.ToString());
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        #endregion
        public DataTable get_danhmucvp_bhyt(string timkiem)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select to_number(tbh.id) id,vp.ten ,vp.gia_bh,to_number(tbh.id_type),tbh.filter,tbh.ktcgoi,tbh.bhyt,tbh.id_byt  from bv115.v_giavpbh tbh ";
            sql += " join v_giavp vp on vp.id=tbh.id where  LOWER(vp.ten) like '%@timkiem%'";
            sql = sql.Replace("@timkiem", timkiem.ToLower());


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
    }
}
