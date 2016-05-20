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
        public DataTable getBYT_v_giavp(string s_ma)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select a.id,a.ten ten,b.bhyt bhyt,a.dvt DONVI,b.ID_BYT,b.QD_STT,b.giacu ";
                sql += " ,b.TEN_BYT ";
                sql += " from bv115.v_giavpbh  b ";
                sql += " inner join medibv115.v_giavp a on a.id=b.id ";
                sql += " where a.gia_cu=0 ";
                if (s_ma.Length > 0)
                {
                    sql += " and a.id='" + s_ma + "'";
                }



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
        public string sqlcdha_ketqua(DateTime ngayra,int i_month)
        {
            string s_sql = " select kqcls.mavp,kqcls.mabn,kqcls.mavaovien,kqcls.ngaycd ngaychidinh,kqcls.idchidinh,kqcls.mabs,nv.hoten tenbs,kqcls.mota,kqcls.ketluan,kqcls.ngayth from (";
                    
            DateTime ngaykq=ngayra;
            for (int i = 0; i < i_month; i++)
            {

                s_sql +=" select kt.idvp mavp,b.ngaychidinh ngaycd,a.mabn,a.mavaovien,b.idchidinh,b.mabs,b.mota,b.ketluan,a.ngaychup ngayth from "+  m_format.getdatabase(ngaykq) + ".cdha_bnct b ";
                s_sql += " inner join " + m_format.getdatabase(ngaykq) + ".cdha_bnll a on a.id=b.id  ";
                s_sql += " inner join cdha_kythuat kt on kt.id=b.makt ";

                if(i<i_month-1)
                {
                    s_sql+= " union all ";
                }
                ngaykq = ngaykq.AddMonths(-1);
            }
            s_sql += " ) kqcls left join dmbs nv on nv.ma=kqcls.mabs ";
            return s_sql;
            
        }
        public DataTable getListBaoCaoFromListKQ(DateTime tungay, DateTime denngay, string s_loaibn,string s_listvp)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,bhds.maicd,bhds.chandoan , ";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn ,ba.sovaovien,cls.ketluan,cls.tenbs";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " left join medibv115.benhandt ba on ba.mavaovien=bhds.mavaovien ";
                sql += " join v_giavp vp on vp.id=bhct.mavp ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " left join (" + sqlcdha_ketqua(denngay, 4) + " ) cls on bhds.mabn=cls.mabn and  bhds.mavaovien=cls.mavaovien ";
                sql += " and  bhct.mavp=cls.mavp ";//and to_char( bhct.ngay,'dd/mm/yyyy')=to_char( cls.ngaychidinh,'dd/mm/yyyy') ";
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
        public DataTable getListBaoCaoFromList(DateTime tungay, DateTime denngay, string s_loaibn, string s_listvp)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,bhds.maicd,bhds.chandoan , ";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn, ";
                sql += " ba.SOVAOVIEN SOBA_NOITRU,bangtr.sovaovien SOBA_NGOAITRU ,cd.idtrongoi SMART_CARD, ";
                sql += " bhct.madoituong MADOITUONG,bhct.tile TILE,bhct.IDNHOMBHYT NHOMBHYT ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";                
                sql += " inner join v_giavp vp on vp.id=bhct.mavp ";
                sql += " inner join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " left join btdkp_bv kp on kp.makp=bhct.makp ";
               
                sql += " left join medibv115.benhandt ba on ba.mavaovien=bhds.mavaovien ";
                sql += " left join medibv115.benhanngtr bangtr on bangtr.mavaovien=bhds.mavaovien ";
                sql += " left join bv115.temp_v_chidinh cd on cd.mavp=bhct.mavp and substr(bhct.idtonghop,0,14)=substr(cd.id,0,14) and bhds.mabn=cd.mabn ";
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and bhct.madoituong=1  ";
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
        public DataTable getListBaoCaoFromList_ICU(DateTime tungay, DateTime denngay, string s_loaibn, string s_listvp)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select bhct.id id,to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,bhds.maicd,bhds.chandoan , ";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn, ";
                sql += " ba.sovaovien  SOVAOVIEN ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " inner join v_giavp vp on vp.id=bhct.mavp ";
                sql += " inner join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " left join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " left join medibv115.benhandt ba on  ba.maql=bhds.maql ";               
                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and bhct.madoituong=1  ";
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
                sql+=" and ((vp.ten like '%Loại%'  and bhct.idnhombhyt=9) ";
                 sql+= " or  ( bhct.idnhombhyt in (5,6)  ";
                 sql+= " and exists(select 1  ";
                 sql+= " from bv115.v_bhytct ct  "; 
                 sql+= " inner join v_giavp a  ";
                 sql+= " on ct.mavp=a.id   ";
                 sql += " where a.ten like '%Loại%' and ct.idnhombhyt=9 and ct.id=bhds.id ) ))  ";
                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public DataTable getBCSmartCardFromList(DateTime tungay, DateTime denngay, string s_loaibn, string s_listvp)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select to_char(bhll.ngay,'dd/mm/yyyy') NGAYDUYETBH, bhds.mabn,bn.hoten,bhds.sothe,";
                sql += " to_char(bhds.ngayvao,'dd/mm/yyyy') ngayvao,to_char(bhds.ngayra,'dd/mm/yyyy') ngayra,bhds.maicd,bhds.chandoan , ";
                sql += " to_char(bhct.ngay,'dd/mm/yyyy') ngayylenh,vp.ten  tenvp,vp.dvt donvi,bhct.soluong,bhct.dongia,bhll.sophieu,kp.tenkp,bhll.loaibn, ";
                sql += " ba.sovaovien  SOVAOVIEN,cd.idtrongoi idtrongoi ";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " inner join v_giavp vp on vp.id=bhct.mavp ";
                sql += " inner join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " left join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " left join medibv115.benhandt ba on  ba.maql=bhds.maql ";
                sql += " inner join bv115.temp_v_chidinh cd on cd.mavp=bhct.mavp and substr(bhct.idtonghop,0,14)=substr(cd.id,0,14) and bhds.mabn=cd.mabn ";

                sql += " where to_char(bhll.ngay,'yyyymmdd') between {tungay} and {denngay} and bhct.madoituong=1  ";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                if (s_loaibn != "-1")
                {
                    sql += " and bhll.loaibn=" + s_loaibn;
                }
                //if (s_listvp.Length > 0)
                //{
                //    sql += " and bhct.mavp in (" + s_listvp + ")";
                //}

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

                sql = " select bhds.id ma_lk,row_number() over (order by bhds.id) stt,CASE WHEN vpbh.id_byt IS NULL THEN '0' ELSE vpbh.id_byt END ma_dich_vu,CASE WHEN vpbh.id_byt IS NULL THEN '0' ELSE vpbh.id_byt END ma_vat_tu, ";
                sql += " '' ma_nhom,vp.ten ten_dich_vu,vp.dvt don_vi_tinh,bhct.soluong so_luong,bhct.dongia don_gia,vp.bhyt tyle_tt,bhct.soluong*bhct.dongia thanh_tien,";
                sql += " kpsyt.makpbo ma_khoa, '999' ma_bac_si,bhds.maicd ma_benh, ";
                sql += " to_char(bhct.ngay,'yyyymmdd') ngay_yl,'' ngay_kq,'' ma_pttt";
                sql += " from BV115.v_bhytds bhds              ";
                sql += " join BV115.v_bhytll bhll on bhll.id=bhds.id ";
                sql += " join BV115.v_bhytct bhct on bhds.id=bhct.id ";
                sql += " join v_giavp vp on vp.id=bhct.mavp ";
                sql += " join btdbn bn on bhds.mabn=bn.mabn  ";
                sql += " join btdkp_bv kp on kp.makp=bhct.makp ";
                sql += " left join bv115.v_giavpbh vpbh on vpbh.id=bhct.mavp ";
                sql += " left join bv115.btdkp_bhyt kpsyt on bhds.makp=kpsyt.makp ";
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
        public DataTable getListM04_SYT(DateTime tungay, DateTime denngay, string dieukien)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select a.mabn,bn.hoten,bn.namsinh,to_char(ll.ngay,'dd/mm/yyyy') ngayth,kt.ten tenvp,ct.ketqua ,dv.ten donvi";

                sql += " from BV115.v_bhytds a              ";
                sql += " inner join medibv115MMYY.XN_PHIEU ll on a.maql=ll.maql ";
                sql += " inner join medibv115MMYY.XN_KETQUA ct on ll.id=ct.id ";
                sql += " inner join medibv115.XN_TEN kt on ct.id_ten=kt.id";
                sql += " left join medibv115.XN_DONVI dv on kt.donvi=dv.id";
                sql += " join btdbn bn on a.mabn=bn.mabn  ";


                sql += " where {dieukien} ";

                sql = sql.Replace("{dieukien}", dieukien);
                sql = sql.Replace("medibv115MMYY", m_format.getdatabase(tungay));
              


                DataSet ds = OracleData.get_data(sql);
                dt_refult = ds.Tables[0];

            }
            catch
            {

            }
            return dt_refult;
        }
        public DataTable getListM05_SYT(DateTime tungay, DateTime denngay, string dieukien)
        {
            DataTable dt_refult = new DataTable();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " select a.mabn,bn.hoten,bn.namsinh,to_char(c.ngay,'dd/mm/yyyy HH24:mi') ngaycd,to_char(cls.ngayth,'dd/mm/yyyy HH24:mi') ngayth,vp.ten tenvp,cls.mota,cls.ketluan ";
                
                sql += " from BV115.v_bhytds a              ";
                sql += " inner join BV115.V_BHYTCT C  on c.id=a.id ";
                sql += " inner join medibv115.v_giavp vp on vp.id=c.mavp ";
                sql += " inner join (" + sqlcdha_ketqua(denngay, 4) + " ) cls on a.mabn=cls.mabn and  a.mavaovien=cls.mavaovien ";
                sql += " and  c.mavp=cls.mavp and to_char( c.ngay,'dd/mm/yyyy')=to_char( cls.ngaychidinh,'dd/mm/yyyy') ";

                sql += " join btdbn bn on a.mabn=bn.mabn  ";
                
                sql += " where {dieukien} ";
           
                sql = sql.Replace("{dieukien}", dieukien);
              //  sql = sql.Replace("medibv115MMYY",m_format.getdatabase(tungay));
              //  sql = sql.Replace("bhds", "a");
            

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
        public int f_updateBYT(v_giavpbh obj)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " update bv115.v_giavpbh  ";
                sql += " set  id_byt='{id_byt}',qd_stt='{s_qd_stt}',ten_byt='{s_ten_byt}',bhyt={bhyt},giacu={giacu}";
                sql += " where id='{id}' ";

                sql = sql.Replace("{id}", obj.ID.ToString());

                sql = sql.Replace("{id_byt}", obj.Id_byt);
                sql = sql.Replace("{s_qd_stt}", obj.Qd_stt);
                sql = sql.Replace("{s_ten_byt}", obj.Ten_byt);
                sql = sql.Replace("{bhyt}", obj.BHYT.ToString());
                sql = sql.Replace("{giacu}", obj.Giacu.ToString());
                result = OracleData.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }

        public int f_update_medibv115_v_giavp(string s_id,string s_ten37,string s_dongia,string s_stt37)
        {
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;

                sql = " update medibv115.v_giavp  ";
                sql += " set  gia_bht3={s_dongia},ten_bht3='{s_ten37}',stt37='{s_stt37}'";
                sql += " where id='{s_id}' ";
                
                sql = sql.Replace("{s_id}", s_id);
                sql = sql.Replace("{s_dongia}", s_dongia);
                sql = sql.Replace("{s_ten37}", s_ten37);
                sql = sql.Replace("{s_stt37}", s_stt37);
                
                
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
