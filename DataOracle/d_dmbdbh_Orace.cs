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
        public DataTable getBYT_d_dmbd(string s_ma)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select a.id,a.ten,a.hamluong,a.dang DONVI,b.ID_BYT,b.BV_APTHAU,b.QD_STT,b.NGAYHIEULUC ";
                sql+= " ,b.HIEULUCDEN,b.SOQD_MUASAM,b.NHOM_BYT,b.TEN_BYT ";
                sql+= " from bv115.d_dmbdbh  b ";
                sql += " inner join medibv115.d_dmbd a on a.id=b.id ";
                if (s_ma.Length > 0)
                {
                    sql += " where a.id='" + s_ma + "'";
                }


                
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
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,bd.ten||' - '||bd.hamluong tenvp,bd.dang donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn,BA.SOVAOVIEN ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " left join medibv115.benhandt ba on ba.maql=bhds.maql ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                sql += " join BV115.d_dmbdbh bdbh on bd.id=bdbh.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and  bdbh.filter=1  AND bhct.madoituong=1";
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
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,bd.ten||' - '||bd.hamluong tenvp,bd.dang donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn,ba.SOVAOVIEN SOBA_NOITRU,bangtr.sovaovien SOBA_NGOAITRU,bhct.madoituong MADOITUONG,bhct.tile TILE,bhct.IDNHOMBHYT NHOMBHYT  ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                sql += " left join medibv115.benhandt ba on ba.mavaovien=bhds.mavaovien ";
                sql += " left join medibv115.benhanngtr bangtr on bangtr.mavaovien=bhds.mavaovien ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and bhct.madoituong=1 ";
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
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and  bd.manhom=25 and bhct.madoituong=1  ";
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
                sql += " ,CASE WHEN bdbh.id_byt IS NULL THEN '0' ELSE bdbh.id_byt END ma_thuoc,bd.nhom ma_nhom,bd.ten ten_thuoc,bd.dang don_vi_tinh,bd.hamluong ham_luong ";
                sql += " ,bd.duongdung duong_dung,'' lieu_dung,bd.sodk so_dang_ky,bhct.soluong so_luong";
                sql +="   , bhct.dongia don_gia,bd.bhyt tyle_tt,bhct.dongia*bhct.soluong thanh_tien,kpsyt.makpbo ma_khoa ";
                sql += " ,'9999' ma_bac_si,bhds.maicd ma_benh ";
                sql += " ,to_char(bhct.ngay,'ddmmyyyyhh24mi') ngay_yl,0 ma_pttt ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join d_dmbd bd on bd.id=bhct.mavp ";
                sql += " left join BV115.d_dmbdbh bdbh on bd.id=bdbh.id ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " left join bv115.btdkp_bhyt kpsyt on bhct.makp=kpsyt.makp ";
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
        public int f_updateBYT(d_dmbdbh obj)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " update {schema}.d_dmbdbh  ";
                sql += " set ID_BYT='{ID_BYT}',BV_APTHAU='{BV_APTHAU}' ";
                sql += " ,QD_STT='{QD_STT}',NGAYHIEULUC='{NGAYHIEULUC}',HIEULUCDEN='{HIEULUCDEN}' ";
                sql += " ,SOQD_MUASAM='{SOQD_MUASAM}',NHOM_BYT='{NHOM_BYT}' ";
                sql += " ,TEN_BYT='{TEN_BYT}' ";
                sql += " where id={id} ";
                
                sql = sql.Replace("{id}", obj.ID.ToString());                
                sql = sql.Replace("{schema}", schema);
                sql = sql.Replace("{ID_BYT}", obj.Idbyt);
                sql = sql.Replace("{BV_APTHAU}", obj.Bv_apthau);
                sql = sql.Replace("{QD_STT}", obj.Qd_stt);
                sql = sql.Replace("{NGAYHIEULUC}", obj.Ngayhieuluc);
                sql = sql.Replace("{HIEULUCDEN}", obj.Hieulucden);
                sql = sql.Replace("{SOQD_MUASAM}", obj.Sodq_muasam);
                sql = sql.Replace("{NHOM_BYT}", obj.Nhom_bhyt);
                sql = sql.Replace("{TEN_BYT}", obj.Ten_byt);  
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

