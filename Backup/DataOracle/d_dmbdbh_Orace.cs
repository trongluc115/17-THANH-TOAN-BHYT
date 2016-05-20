using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
using DataUpdate;
namespace DataOracle
{
    public class d_dmbdbh_Orace
    {
         #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;
        DataSet ds;
        CConnection_Oracle conn = new CConnection_Oracle();
        string schema = CConnection_Oracle.schema;
        string sql = "";
        #endregion
        public d_dmbdbh_Orace()
        {
            OracleData = new AccessData();
        }
        #region get
        public DataTable getListBaoCao(d_dmbdbh obj)
        {
            DataTable dt_refult=new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select * from bv115.d_dmbdbh  ";
                
                
                sql = sql.Replace("@enable", obj.ENABLE.ToString());
                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public double getTiLeThuocK(string mabd)
        {
            double tile = 1;
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select BHYT from bv115.d_dmbdbh where id={mabd} ";
                sql += " union select BHYT from bv115.v_giavpbh where id={mabd} ";


                sql = sql.Replace("{mabd}", mabd);
                DataSet ds = OracleData.get_data(sql);
                tile =double.Parse( ds.Tables[0].Rows[0][0].ToString())/100;
                

            }
            catch
            {

            }
            return tile;
        }
        public List<string> getDanhSachThuocK() // get danh sách thuốc thanh toán theo tỉ lệ. 
        {
            List<string> lst = new List<string>();
            
            
            try
            {
                string userid = AccessData.m_userid;

                //sql = " select a.id from bv115.d_dmbdbh a ";
                //sql += " inner join bv115.nhomxhh b on a.id_type=b.id  ";
                //sql += " where b.nhombhyt  in (13)";
                // thuốc tỉ lệ BHYT trả <100 ->Thanh toán theo tỉ lệ
                sql = " select bd.id from d_dmbd bd "; ;
                sql += " inner join d_dmnhom nhdc on bd.manhom=nhdc.id ";
                sql += " inner join v_nhomvp nhvp on nhdc.nhomvp=nhvp.ma ";
                sql += " where nhvp.IDNHOMBHYT=1 and bd.bhyt<100 and bd.bhyt>0 ";

                DataSet ds = OracleData.get_data(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(dr["id"].ToString());
                }
                


            }
            catch
            {

            }
            return lst;
        }
        public List<string> getListKTC() // lấy danh sách viện phí thanh toán theo ti le
        {
            List<string> lst = new List<string>();


            try
            {
                string userid = AccessData.m_userid;
                //sql = " select a.id from bv115.v_giavpbh a ";
                //sql +=" inner join bv115.nhomxhh b on a.id_type=b.id  ";
                //sql +=" where b.nhombhyt  in (6)";
                sql = " select vp.* from v_giavp vp  ";
                sql+= " inner join v_loaivp lvp on vp.id_loai=lvp.id ";
                sql+= " inner join v_nhomvp nvp on lvp.id_nhom=nvp.ma ";
                sql += "  where  vp.bhyt<100 and vp.bhyt>0 ";
                DataSet ds = OracleData.get_data(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(dr["id"].ToString());
                }



            }
            catch
            {

            }
            return lst;
        }

        public List<string> getListVTYT_TL() // lấy vật tu y tế thanh toán theo ti le
        {
            List<string> lst = new List<string>();


            try
            {
                string userid = AccessData.m_userid;
                sql = " select bd.id from d_dmbd bd ";;
                sql+= " inner join d_dmnhom nhdc on bd.manhom=nhdc.id ";
                sql+= " inner join v_nhomvp nhvp on nhdc.nhomvp=nhvp.ma ";
                sql += " where nhvp.IDNHOMBHYT=7 and bd.bhyt<100 and bd.bhyt>0 ";
                DataSet ds = OracleData.get_data(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(dr["id"].ToString());
                }



            }
            catch
            {

            }
            return lst;
        }

        public DataTable getListBaoCaoFromChoice(DateTime tungay,DateTime denngay,string s_loaibn)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,bd.ten||' - '||bd.hamluong tenvp,bd.dang donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                sql += " join BV115.d_dmbdbh bdbh on bd.id=bdbh.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and  bdbh.filter=1  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}",tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                if (s_loaibn != "-1" )
                {
                    sql += " and bhll.loaibn="+s_loaibn;
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
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,bd.ten||' - '||bd.hamluong tenvp,bd.dang donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay}  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                if (s_loaibn != "-1")
                {
                    sql += " and bhll.loaibn=" + s_loaibn;
                }
                if (s_listvp.Length>0)
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
        
        public DataTable getListBaoCaoFromThuocDongY(DateTime tungay, DateTime denngay)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,bd.ten||' - '||bd.hamluong tenvp,bd.dang donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                sql += " join BV115.d_dmbdbh bdbh on bd.id=bdbh.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and  bd.manhom=25  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));

                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }

        public DataTable getListM20_SYT(DateTime tungay, DateTime denngay, string dieukien)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select bhds.id ma_lk,row_number() over (order by bhds.id) stt ";
                sql += " ,bd.id ma_thuoc,bd.nhom ma_nhom,bd.ten ten_thuoc,bd.dang don_vi_tinh,bd.hamluong ham_luong ";
                sql += " ,bd.duongdung duong_dung,bd.sodk so_dang_ky,bhct.soluong so_luong,bhct.dongia don_gia,bd.bhyt tyle_tt ";
                sql += " ,bhds.makp ma_khoa,'[No]' ma_bac_si,bhds.maicd ma_benh ";
                sql += " ,to_char(bhct.ngay,'ddmmyyyyhh24mi') ngay_yl,bhll.loaibn ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
               // sql += " join BV115.d_dmbdbh bdbh on bd.id=bdbh.id ";
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
        public int f_update(d_dmbdbh obj)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                
                sql = " update {schema}.d_dmbdbh  ";
                sql += " set id_type='@id_type',filter=@enable ,bhyt=@bhyt";
                sql += " where id=@id ";
                sql = sql.Replace("@id_type", obj.ID_TYPE);
                sql = sql.Replace("@id", obj.ID.ToString());               
                sql = sql.Replace("@enable", obj.ENABLE.ToString());
                sql = sql.Replace("@bhyt", obj.BHYT.ToString());
                sql = sql.Replace("{schema}", schema);
                result = OracleData.f_execute_data(sql);
             }
            catch
            {

            }
            return result;
        }
        public int f_updateall(string tablename,string enable)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " update {schema}.{tablename}  ";
                sql += " set filter={enable}";


                sql = sql.Replace("{schema}", schema);
                sql = sql.Replace("{tablename}", tablename);
                sql = sql.Replace("{enable}", enable);
                
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
                sql = "delete bv115.d_bmbdbh  where id=@id ";
                sql = sql.Replace("@id", id.ToString());
                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        #endregion
    }
}
