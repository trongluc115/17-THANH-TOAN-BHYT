using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class cdha_dvll_Oracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;

        DataSet ds;
        string sql = "";
        #endregion
        public cdha_dvll_Oracle()
        {
            OracleData = new AccessData();
        }
        #region get
        public DataTable d_getCLS(DateTime tungay,DateTime denngay,string mabn)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select  cd.id id  ,vp.ten||' (' ||to_char(cd.soluong)||' '||vp.dvt ||') ' || to_char(cd.ngay,'dd/mm/yy')||' BS '||log.hoten  ten ";
            sql+=" from {database}.v_chidinh cd ";
            sql+=" join medibv115.v_giavp vp on vp.id=cd.mavp ";;
            sql += " join dlogin log on cd.userid=log.id ";
            sql += " where mabn='{mabn}'   ";
            sql += " and to_char(cd.ngay,'yyyymmdd') between '{tungay}' and '{denngay}'";
            sql = sql.Replace("{database}",m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}",mabn);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getCLS_DADUYET(DateTime tungay, DateTime denngay, string mabn,string done)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.sohd,dvll.sobl,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia,dvll.soluong*dvll.dongia tongtien, ";
            sql += " log.hoten,kp.tenkp,dvll.id,to_char(dvll.ngaycd,'dd/mm/yyyy') ngay,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,to_char(dvll.ngaythuchien,'dd/mm/yyyy') ngay ";
            sql += " from bv115.cdha_dvll dvll ";            
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " where mabn='{mabn}'   ";
            sql += " and to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += " and dvll.cdhakhu='{s_cdhakhu}' ";
            if (done != "-1")
            {
                sql += " and done={DONE} ";
            }
            sql = sql.Replace("{database}", m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}", mabn);
            sql = sql.Replace("{DONE}", done);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_cdhakhu}",AccessData.s_makhuvuc);
            


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_get_after_CDHAnoitru(DateTime tungay, DateTime denngay, string mabn, string done,string s_noithuchien)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.sohd,dvll.sobl,bn.hoten,bn.namsinh,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia,dvll.soluong*dvll.dongia tongtien, ";
            sql += " log.hoten,kp.tenkp,dvll.id,to_char(dvll.ngaycd,'dd/mm/yyyy') ngay,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,to_char(dvll.ngaythuchien,'dd/mm/yyyy') ngay ,bvlog.hoten tenktv";
            sql += " from bv115.cdha_dvll dvll ";
            sql += " inner join btdbn bn on dvll.mabn=bn.mabn ";
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " left join bv115.bv_login bvlog on dvll.userid=bvlog.id ";
            sql += " where dvll.mabn like '%{mabn}%'  ";
            sql += " and to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += " and dvll.cdhakhu='{s_cdhakhu}' and dvll.noithuchien='"+s_noithuchien+"' ";

            if (done != "-1")
            {
                sql += " and done={DONE} ";
            }
            sql = sql.Replace("{database}", m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}", mabn);
            sql = sql.Replace("{DONE}", done);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_cdhakhu}", AccessData.s_makhuvuc);



            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getCLS_daduyet_bophan(DateTime tungay, DateTime denngay, string mabn, string done,string s_loaikt)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.sohd,dvll.sobl,bn.hoten,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia,dvll.soluong*dvll.dongia tongtien, ";
            sql += " log.hoten,kp.tenkp,dvll.id,to_char(dvll.ngaycd,'dd/mm/yyyy') ngay,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,to_char(dvll.ngaythuchien,'dd/mm/yyyy') ngay ";
            sql += " from bv115.cdha_dvll dvll ";
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join medibv115.cdha_kythuat kt on kt.idvp=dvll.mavp "; 
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join btdbn bn on bn.mabn=dvll.mabn ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " where dvll.mabn like '%{mabn}%'  and dvll.cdhakhu='"+ AccessData.s_makhuvuc + "' ";
            sql += " and to_char(dvll.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += " and kt.id_loai={s_loaikt}";
            if (done != "-1")
            {
                sql += " and done={DONE} ";
            }
            sql = sql.Replace("{database}", m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}", mabn);
            sql = sql.Replace("{DONE}", done);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));

            sql = sql.Replace("{s_loaikt}", s_loaikt);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        
        public DataTable f_getCLS_chuaduyet_bophan(DateTime tungay, DateTime denngay, string mabn, string done,string s_loaikt)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.sohd,dvll.sobl,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,bn.mabn,bn.hoten,bn.namsinh,dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia,dvll.soluong*dvll.dongia tongtien, ";
            sql += " log.hoten,kp.tenkp,dvll.id ";
            sql += " from bv115.cdha_dvll dvll ";
            sql += " join btdbn bn on bn.mabn=dvll.mabn ";
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join medibv115.cdha_kythuat kt on kt.idvp=dvll.mavp "; ;
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " where dvll.mabn like '%{mabn}%'  and dvll.cdhakhu='" + AccessData.s_makhuvuc + "' ";
            sql += " and to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += " and kt.id_loai={s_loaikt}";
            if (done != "-1")
            {
                sql += " and done={DONE} ";
            }
            sql = sql.Replace("{database}", m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}", mabn);
            sql = sql.Replace("{DONE}", done);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));

            sql = sql.Replace("{s_loaikt}", s_loaikt);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_M01(DateTime tungay, DateTime denngay,string s_cdhakhu)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = " select  kq.khuvuc noichidinh,kq.sohd,kq.mabn,kq.hoten,kq.namsinh,SUM(kq.DONGIA*kq.SOLUONG) sotien, ";
            sql+= " sum(case when kq.nhom_cdha in ('CT') then soluong else 0 end ) CT, ";
            sql+=" sum(case when kq.nhom_cdha in ('SA') then soluong else 0 end ) SIEUAM, ";
            sql+=" sum(case when kq.nhom_cdha in ('XQ') then soluong else 0 end ) XQUANG, ";
            sql+=" sum(case when kq.nhom_cdha in ('XN') then soluong else 0 end ) XETNGHIEM, ";
            sql+=" sum(case when kq.nhom_cdha in ('MR') then soluong else 0 end ) MRI,";
            sql += " sum(case when kq.nhom_cdha in ('ST') then soluong else 0 end ) SIEUAMTIM, ";
            sql += " sum(case when kq.nhom_cdha in ('DT') then soluong else 0 end ) DIENTIM ,";
            sql += " sum(case when kq.nhom_cdha in ('KB') then soluong else 0 end ) KB";
            sql+=" from  ";
            sql+=" ( ";
            sql+=" select kv.name khuvuc,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai ,cd.soluong,cd.dongia,vp.id_loai,nhvp.nhom_cdha ";
            sql+=" from bv115.CDHA_DVLL cd   ";
            sql+=" join v_giavp vp on cd.mavp=vp.id ";
            sql+=" join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql+=" join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql+=" join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += "  where  to_char(cd.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' and cd.cdhakhu='"+s_cdhakhu+"'";
            sql+=" )kq ";
            sql += " GROUP BY kq.khuvuc,kq.sohd,kq.mabn,kq.hoten,kq.namsinh ";
            
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public bool f_checkExist_Schema(string s_schema)
        {
            bool result = false;
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string mmyy = s_schema.Substring(9,4);
            string sql = " select * from tables where mmyy='"+mmyy+"'";
            
            
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                    result=true;
            }
            catch { }
            return result;
            




        
        }
        public DataTable f_getBAOCAO_PHIM(DateTime tungay, DateTime denngay,string sNhom_filter)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime idate = tungay.AddMonths(-1);
            string stutruc = "";
            string scdhact = "";
            bool key = true;
            string  schema = m_format.getdatabase(idate);
            while (f_checkExist_Schema(schema) && idate <=denngay.AddMonths(1))
            {
                
                if (key == false)
                {
                    stutruc += " union ";
                    scdhact += " union ";
                }
                else
                {
                    key = false;
                }

                stutruc += " select * from "+schema+".d_xtutrucct ";
                scdhact += " select id,idduoc_tutruc,idchidinh,makp,makt from "+schema+".cdha_bnct";
                
                idate = idate.AddMonths(1);
                schema = m_format.getdatabase(idate);

                
            }



            string sql= 	" select dvll.id,xtuct.*,bn.mabn,bn.hoten,bn.namsinh,kp.tenkp,vp.ten tenvp,dc.id idvt,dc.ten||' '||hamluong VTTH,	";
            sql += "	 xtuct.slyeucau DUTRU,  0 DADUYET,xtuct.sl_phimhu phimhu,to_char(dvll.ngaychup,'DD/MM/YYYY hh24:mi') NGAYCHIDINH,	 ";
            sql += "	 to_char(dvll.ngaythuchien,'DD/MM/YYYY') NGAYTHUCHIEN,nhomdc.id idnhom,  nhomdc.ten tennhom,'-' userid 	";
            sql += "	 from 	";
            sql += "	 ( " + scdhact +"	 ) bnct	";
            sql += "	 join bv115.cdha_dvll dvll on dvll.id=bnct.idchidinh 	";
            sql += "	 join 	";
            sql += "	 ("+ stutruc + "	 ) xtuct on bnct.idduoc_tutruc=xtuct.id 	";
            sql += "	 join btdbn bn on dvll.mabn=bn.mabn	";
            sql += "	 join btdkp_bv kp on kp.makp=bnct.makp   	";
            sql += "	 join cdha_kythuat kt on kt.id=bnct.makt 	";
            sql += "	 join v_giavp vp on vp.id=kt.idvp  	";
            sql += "	 join d_dmbd dc on xtuct.mabd=dc.id  	";
            sql += "	 join d_dmnhom nhomdc on nhomdc.id=dc.manhom  	";
            sql += "	 join  bv115.cdha_nhom nhcdha on vp.id_loai=nhcdha.id_loai  	";
            sql += "	 where  (to_char(dvll.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}') and dvll.done>0	";
            sql += "	 AND xtuct.slyeucau>0 and nhomdc.id=74    	";
            sql += "	 and xtuct.makho=12     and  instr ('{nhom_filter}',nhcdha.nhom_cdha) >0	";

            
            string datatutruc = m_format.getdatabase(tungay.AddMonths(1));
            sql = sql.Replace("{data_tutruc}", datatutruc);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{nhom_filter}", sNhom_filter);
            

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_PHIMDV(DateTime tungay, DateTime denngay, string sNhom_filter)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            
                        

            string sql = " select dvll.id,bn.mabn,bn.hoten,bn.namsinh,kp.tenkp,vp.ten tenvp,dc.id idvt,dc.ten||' '||hamluong VTTH,	";
            sql += "	 tp.soluong DUTRU,  0 DADUYET,tp.sl_phimhu phimhu,to_char(dvll.ngaychup,'DD/MM/YYYY hh24:mi') NGAYCHIDINH,	 ";
            sql += "	 to_char(dvll.ngaythuchien,'DD/MM/YYYY') NGAYTHUCHIEN,dvll.userid userid ,'-' tennhom	";
            sql += "	 from 	";
            sql += "	 bv115.cdha_dvll dvll 	";
            sql += "	 inner join bv115.cdha_thuocphim tp on dvll.id=tp.id 	";
            sql += "	 join btdbn bn on dvll.mabn=bn.mabn	";
            sql += "	 join btdkp_bv kp on kp.makp=dvll.makp   	";
            sql += "	 join v_giavp vp on vp.id=dvll.mavp  	";
                      
            sql += "	 join d_dmbd dc on tp.mabd=dc.id  	";
            sql += "	 join  bv115.cdha_nhom nhcdha on vp.id_loai=nhcdha.id_loai  	";
            sql += "	 where  (to_char(dvll.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}') and dvll.done>0	";
            sql += "	 and  instr ('{nhom_filter}',nhcdha.nhom_cdha) >0	";


            string datatutruc = m_format.getdatabase(tungay.AddMonths(1));
            
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{nhom_filter}", sNhom_filter);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_CDHA_PHIM(DateTime tungay, DateTime denngay, string s_noithuchien,string s_madoituong)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();



            string sql = " select dvll.id,bn.mabn,bn.hoten,bn.namsinh,kp.tenkp,vp.ten tenvp,dc.id idvt,dc.ten||' '||hamluong VTTH,	";
            sql += "	 tp.soluong DUTRU,  0 DADUYET,tp.sl_phimhu phimhu,to_char(dvll.ngaythuchien,'DD/MM/YYYY hh24:mi') NGAYCHIDINH,	 ";
            sql += "	 to_char(dvll.ngaythuchien,'DD/MM/YYYY') NGAYTHUCHIEN,dvll.userid userid ,'-' tennhom,to_char(dvll.ngaychup,'DD/MM/YYYY hh24:mi') NGAYTIEPDON";
            sql += "	 from 	";
            sql += "	 bv115.cdha_dvll dvll 	";
            sql += "	 inner join bv115.cdha_thuocphim tp on dvll.id=tp.id 	";
            sql += "	 join btdbn bn on dvll.mabn=bn.mabn	";
            sql += "	 join btdkp_bv kp on kp.makp=dvll.makp   	";
            sql += "	 join v_giavp vp on vp.id=dvll.mavp  	";

            sql += "	 join d_dmbd dc on tp.mabd=dc.id  	";
            sql += "	 join  bv115.cdha_nhom nhcdha on vp.id_loai=nhcdha.id_loai  	";
            sql += "	 where  (to_char(dvll.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}') and dvll.done>0	";
            sql += "	 and  instr (',{s_noithuchien},',','||dvll.noithuchien||',') >0	";
            if (s_madoituong.Length > 0)
            {
                sql += " and cd.madoituong in (" + s_madoituong + ")";
            }
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_noithuchien}", s_noithuchien);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }

        public DataTable f_getBAOCAO_M02_TRAKQ_khu(DateTime tungay, DateTime denngay, string s_cdhakhu)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "";
            sql += " select kv.name NOICHIDINH,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai  ,cd.soluong SOLUONG ";
            sql += " ,cd.dongia,cd.dongia*cd.soluong thanhtien,vp.id_loai,nhvp.nhom_cdha  nhomcdha,vp.dvt DVT,VP.TEN TENVP,cd.done done,cd.trakq";
            sql += " from bv115.CDHA_DVLL cd   ";
            sql += " join v_giavp vp on cd.mavp=vp.id ";
            sql += " join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql += " join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql += " join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += "  where  to_char(cd.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}'  ";
            sql += " and cd.cdhakhu='{s_cdhakhu}' ";
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{NHOM_CDHA}", AccessData._NHOM_CDHA);
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_cdhakhu}", s_cdhakhu);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_M02(DateTime tungay, DateTime denngay,string Nhom)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
      
            string sql = ""; 
            sql += " select kv.name NOICHIDINH,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai  ,cd.soluong SOLUONG ";
            sql+=" ,cd.dongia,cd.dongia*cd.soluong thanhtien,vp.id_loai,nhvp.nhom_cdha  nhomcdha,vp.dvt DVT,VP.TEN TENVP,cd.done done,cd.trakq";
            sql += " from bv115.CDHA_DVLL cd   ";
            sql += " join v_giavp vp on cd.mavp=vp.id ";
            sql += " join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql += " join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql += " join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += "  where  cd.done=0 and to_char(cd.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}'  ";
            sql += " and instr('{NHOM_CDHA}',nhvp.NHOM_CDHA)>0 ";
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{NHOM_CDHA}", AccessData._NHOM_CDHA);
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_M02_dathuchien(DateTime tungay, DateTime denngay, string sNhom_Filter)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "";
            sql += " select kv.name NOICHIDINH,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai  ,cd.soluong SOLUONG ";
            sql += " ,cd.dongia,cd.dongia*cd.soluong thanhtien,vp.id_loai,nhvp.nhom_cdha  nhomcdha,vp.dvt DVT,VP.TEN TENVP,cd.done done,cd.trakq,log.hoten bschidinh,to_char(cd.ngaychup,'dd/mm/yyyy') NGAYTIEPNHAN,to_char(cd.ngaythuchien,'dd/mm/yyyy') NGAYTHUCHIEN ";
            sql += " from bv115.CDHA_DVLL cd   ";
            sql += " inner join dlogin log on cd.mabs=log.id ";
            sql += " join v_giavp vp on cd.mavp=vp.id ";
            sql += " join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql += " join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql += " join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += "  where cd.done=1 and  to_char(cd.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}'  ";
            sql += " and instr('{NHOM_CDHA}',nhvp.NHOM_CDHA)>0 ";
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{NHOM_CDHA}", sNhom_Filter);
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_CDHA_M02_dathuchien(DateTime tungay, DateTime denngay, string s_noithuchien,string s_madoituong)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "";
            sql += " select kv.name NOICHIDINH,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai ,cd.madoituong ,cd.soluong SOLUONG ";
            sql += " , cd.dongia,cd.dongia*cd.soluong thanhtien,vp.id_loai,nhvp.nhom_cdha  nhomcdha,vp.dvt DVT,VP.TEN TENVP,cd.done done,cd.trakq,log.hoten bschidinh,to_char(cd.ngaychup,'dd/mm/yyyy') NGAYTIEPNHAN,to_char(cd.ngaythuchien,'dd/mm/yyyy') NGAYTHUCHIEN ";
            sql += " , logha.hoten BSCDHA";
            sql += " from bv115.CDHA_DVLL cd   ";
            sql += " left join dlogin log on cd.mabs=log.id ";
            sql += " join v_giavp vp on cd.mavp=vp.id ";
            sql += " join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql += " join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql += " join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += " left join {medibv115}.cdha_bnct bnct on bnct.idchidinh=cd.id ";
            sql += " left join {medibv115}.cdha_bnll bnll on bnll.id=bnct.id ";
            sql += " left join cdha_dlogin logha on logha.id=bnll.userid  ";
            

            sql += "  where cd.done=1 and  to_char(cd.ngaythuchien,'yyyymmdd') between '{tungay}' and '{denngay}'  ";
            sql += " and instr(',{s_noithuchien},',','||cd.noithuchien||',')>0 ";
            if (s_madoituong.Length > 0)
            { 
                sql+= " and cd.madoituong in ("+s_madoituong+")";
            }
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{medibv115}", m_format.getdatabase(tungay));
            sql = sql.Replace("{s_noithuchien}", s_noithuchien);
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }

        #endregion 
        public int f_insert(cdha_dvll obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into BV115.cdha_dvll (id,ngaycd,ngaychup,mabn,mabs,mabsth,mavp,soLuong,sobl,sohd,makp,madoituong,dongia,userid,CDHAKHU) ";
                sql += " values ({ID},{NGAYCD},{NGAYCHUP},'{MABN}',{MABSCD},{MABSTH},{MAVP},{SOLUONG},{SOBL},{SOHD},{MAKP},{MADOITUONG},{DONGIA},{USERID},{CDHAKHU}) ";
                               
                
                sql=sql.Replace("{ID}",obj.ID.ToString());
                sql = sql.Replace("{NGAYCD}", m_format.f_formatdata(obj.NGAYCD.ToString(),"date"));
                sql = sql.Replace("{NGAYCHUP}", m_format.f_formatdata(obj.NGAYCHUP.ToString(), "date"));
                sql = sql.Replace("{MABN}", obj.MABN.ToString());
                sql=sql.Replace("{MAKP}",m_format.f_formatdata(obj.MAKP.ToString()));
                sql=sql.Replace("{MADOITUONG}",m_format.f_formatdata(obj.MADOITUONG.ToString()));
                sql=sql.Replace("{MAVP}",m_format.f_formatdata(obj.MAVP.ToString()));
                sql=sql.Replace("{SOLUONG}",obj.SOLUONG.ToString());
                sql=sql.Replace("{DONGIA}",obj.DONGIA.ToString());
                sql = sql.Replace("{SOBL}", m_format.f_formatdata(obj.SOBL.ToString()));
                sql = sql.Replace("{SOHD}",m_format.f_formatdata( obj.SOHD.ToString()));
                sql = sql.Replace("{MABSCD}", m_format.f_formatdata(obj.MABSCD.ToString()));
                sql = sql.Replace("{MADOITUONG}",m_format.f_formatdata( obj.MADOITUONG.ToString()));
                sql = sql.Replace("{USERID}", AccessData.m_userid);


                
                sql=sql.Replace("{MABSCD}",m_format.f_formatdata(obj.MABSCD.ToString()));
                sql = sql.Replace("{MABSTH}", m_format.f_formatdata(obj.MABSTH.ToString()));
                sql = sql.Replace("{CDHAKHU}", m_format.f_formatdata(obj.Cdhakhu.ToString()));
                sql = sql.Replace("{NGAYUD}", m_format.f_formatdata(obj.NGAYUD.ToString(), "date"));

                
                result = OracleData.f_execute_data(sql);
                f_update_v_chidinh(obj.ID.ToString(), "nhapvt", "1");



            }
            catch
            {

            }
            return result;
        }
        public int f_insert_bv(cdha_dvll obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into BV115.cdha_dvll (id,ngaycd,ngaychup,mabn,mabs,mabsth,mavp,soLuong,sobl,sohd,makp,madoituong,dongia,userid,maktv,CDHAKHU,NGAYTHUCHIEN,DONE,NGAYUD,NOITHUCHIEN) ";
                sql += " values ({ID},{NGAYCD},{NGAYCHUP},'{MABN}',{MABSCD},{MABSTH},{MAVP},{SOLUONG},{SOBL},{SOHD},{MAKP},{MADOITUONG},{DONGIA},{USERID},{USERID},{CDHAKHU},{NGAYCHUP},1,sysdate,{NOITHUCHIEN}) ";


                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{NGAYCD}", m_format.f_formatdata(obj.NGAYCD.ToString(), "date"));
                sql = sql.Replace("{NGAYCHUP}", m_format.f_formatdata(obj.NGAYCHUP.ToString(), "date"));
                sql = sql.Replace("{MABN}", obj.MABN.ToString());
                sql = sql.Replace("{MAKP}", m_format.f_formatdata(obj.MAKP.ToString()));
                sql = sql.Replace("{MADOITUONG}", m_format.f_formatdata(obj.MADOITUONG.ToString()));
                sql = sql.Replace("{MAVP}", m_format.f_formatdata(obj.MAVP.ToString()));
                sql = sql.Replace("{SOLUONG}", obj.SOLUONG.ToString());
                sql = sql.Replace("{DONGIA}", obj.DONGIA.ToString());
                sql = sql.Replace("{SOBL}", m_format.f_formatdata(obj.SOBL.ToString()));
                sql = sql.Replace("{SOHD}", m_format.f_formatdata(obj.SOHD.ToString()));
                sql = sql.Replace("{MABSCD}", m_format.f_formatdata(obj.MABSCD.ToString()));
                sql = sql.Replace("{MADOITUONG}", m_format.f_formatdata(obj.MADOITUONG.ToString()));               
                sql = sql.Replace("{USERID}", AccessData.m_userid);

                sql = sql.Replace("{MABSCD}", m_format.f_formatdata(obj.MABSCD.ToString()));
                sql = sql.Replace("{MABSTH}", m_format.f_formatdata(obj.MABSTH.ToString()));
                sql = sql.Replace("{CDHAKHU}", m_format.f_formatdata(obj.Cdhakhu.ToString()));
                sql = sql.Replace("{NGAYUD}", m_format.f_formatdata(obj.NGAYUD.ToString(), "date"));
                sql = sql.Replace("{NOITHUCHIEN}", m_format.f_formatdata(obj.Noithuchien));

                result = OracleData.f_execute_data(sql);
                f_update_v_chidinh(obj.ID.ToString(), "nhapvt", "1");
                



            }
            catch
            {

            }
            return result;
        }
        public int f_update(cdha_dvll obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_dvll ";
                sql += " set done='{DONE}',NGAYTHUCHIEN={NGAYTHUCHIEN},NOITHUCHIEN='{NOITHUCHIEN}',MAKTV='{MAKTV}' , ngayud=sysdate";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{NGAYTHUCHIEN}", m_format.f_formatdata(obj.NGAYTHUCHIEN.ToString(), "date"));
                sql = sql.Replace("{DONE}", obj.DONE);
                sql = sql.Replace("{NOITHUCHIEN}", obj.Noithuchien);
                sql = sql.Replace("{MAKTV}", AccessData.m_userid);

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update_trakq(cdha_dvll obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_dvll ";
                sql += " set trakq={TRAKQ}, ngayud=sysdate";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{TRAKQ}", obj.TRAKQ);


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
                Ccdha_thuocphimOracle vattuOracle = new Ccdha_thuocphimOracle();
                vattuOracle.f_delete(id);
                sql = "delete BV115.cdha_dvll where id={id} ";
                sql = sql.Replace("{id}", id.ToString());
                result = OracleData.f_execute_data(sql);
                f_update_v_chidinh(id.ToString(), "nhapvt", "0");
                

            }
            catch
            {

            }
            return result;
        }
        private string f_getsqlchiphi2(string sqlcp, string mabn, DateTime TuNgay, DateTime DenNgay)
        {

            string sqlGroup;
            try
            {
                DateTime dt1 = TuNgay;
                DateTime dt2 = DenNgay;
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int itu, iden;
                string mmyy = "";
                string str = sqlcp;
                string asql = "";
                bool be = true;
                sqlGroup = " select 1 chon, (select vll.SOBIENLAIDV FROM {medibv_ttrv}.v_ttrvll vll where vll.id=kq.idttrv) SOHD ,(select vll.SOBIENLAI FROM {medibv_ttrv}.v_ttrvll vll where vll.id=kq.idttrv) SOBL ,MAVP,NGAY,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,0 BHYTTRA,0 BNTRA,MADOITUONG,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT ,'-' THUOCK,userid ";


                sqlGroup += "           from ";
                sqlGroup += "           ( ";

                for (int i = y1; i <= y2; i++)
                {
                    itu = (i == y1) ? m1 : 1;
                    iden = (i == y2) ? m2 : 12;
                    for (int j = itu; j <= iden; j++)
                    {
                        mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                        if (OracleData.bMmyy(mmyy))
                        {

                            asql = str.Replace("{data_user}", "medibv115" + mmyy);
                            if (be)
                            {
                                sqlGroup += asql;
                                be = false;
                            }
                            else
                            {
                                sqlGroup += " union all " + asql;
                            }
                        }
                    }
                }

                sqlGroup += sql + "           ) kq ";
                sqlGroup += "             order by ngay ";
                //sqlGroup += "           group by NGAY,MAVP,TEN,DVT, SOLUONG,DONGIA,MADOITUONG, ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,STTNHOM,NHOM,BHYT,KYTHUAT,TINHTONG,IDNHOMBHYT ";
                sqlGroup = sqlGroup.Replace("{ma_bn}", mabn);
                sqlGroup = sqlGroup.Replace("{medibv_ttrv}", "medibv115" + string.Format("{0:MMyy}", DateTime.Today));

            }
            catch (Exception ex)
            {
                return "";

            }
            return sqlGroup;
        }
        public DataSet f_getv_ttrvkp_ct_ALL3(string MaBN, string mavaovien, DateTime TuNgay, DateTime DenNgay, string loai)
        {

           // string s_tam_ung = f_gettamung(mavaovien, TuNgay, DenNgay);
            string sqlcp = "           select to_char(cd.ngay,'dd/mm/yyyy') ngay,cd.id ID,cd.mavaovien,cd.maql,cd.mabn,to_char(cd.makp) MAKP,kp.tenkp ,TO_CHAR(cd.idkhoa) idkhoa, cd.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,cd.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,to_char(nhom.idnhombhyt) idnhombhyt,cd.idttrv idttrv,cd.userid userid";
            sqlcp += "           from {data_user}.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join bv115.cdha_nhom cdnh on vp.id_loai=cdnh.id_loai ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            //    sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where cd.madoituong<>5  and cd.mabn='"+MaBN+"'  ";
            sqlcp += "           and to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' and cd.nhapvt <> '1'";


            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));

            string sqlgroup = f_getsqlchiphi2(sqlcp, MaBN, TuNgay, DenNgay);


            sql = sqlgroup;
            DataSet dset = new DataSet();
            try
            {
                dset = OracleData.get_data(sql);

            }
            catch { }
            return dset;
        }
        private string f_getsqlcp_noitru(string sqlcp, string mabn, DateTime TuNgay, DateTime DenNgay)
        {

            string sqlGroup;
            try
            {
                DateTime dt1 = TuNgay;
                DateTime dt2 = DenNgay;
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int itu, iden;
                string mmyy = "";
                string str = sqlcp;
                string asql = "";
                bool be = true;
                sqlGroup = " select 1 chon, (select vll.SOBIENLAIDV FROM {medibv_ttrv}.v_ttrvll vll where vll.id=kq.idttrv) SOHD ,(select vll.SOBIENLAI FROM {medibv_ttrv}.v_ttrvll vll where vll.id=kq.idttrv) SOBL ,MAVP,NGAY,HOTEN,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,0 BHYTTRA,0 BNTRA,MADOITUONG,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT ,'-' THUOCK,userid ";


                sqlGroup += "           from ";
                sqlGroup += "           ( ";

                for (int i = y1; i <= y2; i++)
                {
                    itu = (i == y1) ? m1 : 1;
                    iden = (i == y2) ? m2 : 12;
                    for (int j = itu; j <= iden; j++)
                    {
                        mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                        if (OracleData.bMmyy(mmyy))
                        {

                            asql = str.Replace("{data_user}", "medibv115" + mmyy);
                            if (be)
                            {
                                sqlGroup += asql;
                                be = false;
                            }
                            else
                            {
                                sqlGroup += " union all " + asql;
                            }
                        }
                    }
                }

                sqlGroup += sql + "           ) kq ";
                sqlGroup += "             order by ngay ";
                //sqlGroup += "           group by NGAY,MAVP,TEN,DVT, SOLUONG,DONGIA,MADOITUONG, ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,STTNHOM,NHOM,BHYT,KYTHUAT,TINHTONG,IDNHOMBHYT ";
                sqlGroup = sqlGroup.Replace("{ma_bn}", mabn);
                sqlGroup = sqlGroup.Replace("{medibv_ttrv}", "medibv115" + string.Format("{0:MMyy}", DateTime.Today));

            }
            catch (Exception ex)
            {
                return "";

            }
            return sqlGroup;
        }
        public DataSet f_get_cdha_bv(string MaBN, string mavaovien, DateTime TuNgay, DateTime DenNgay, string loai,string s_nhomkt)
        {

         
            string sqlcp = "           select to_char(cd.ngay,'dd/mm/yyyy') ngay,cd.id ID,cd.mavaovien,cd.maql,cd.mabn,to_char(cd.makp) MAKP,kp.tenkp ,TO_CHAR(cd.idkhoa) idkhoa, cd.madoituong,'-'  sttnhom,  ";
            sqlcp += "        '-' nhom,cd.mavp,bn.hoten||' '||bn.namsinh||' ('||bn.mabn ||')' HOTEN, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,'-' idnhombhyt,cd.idttrv idttrv,cd.userid userid";
            sqlcp += "           from {data_user}.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.cdha_kythuat kt on kt.idvp=vp.id ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += "           join medibv115.btdbn bn on bn.mabn=cd.mabn ";
            sqlcp += "             where kt.id_loai={s_nhomkt} and cd.mabn like  '%{s_mabn}%' and cd.hide=0 ";
            sqlcp += "           and to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' and cd.nhapvt<>'1' ";
            sqlcp = sqlcp.Replace("{s_nhomkt}", s_nhomkt);
            sqlcp = sqlcp.Replace("{s_mabn}", MaBN);
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));

            string sqlgroup = f_getsqlcp_noitru(sqlcp, MaBN, TuNgay, DenNgay);


            sql = sqlgroup;
            DataSet dset = new DataSet();
            try
            {
                dset = OracleData.get_data(sql);

            }
            catch { }
            return dset;
        }

        public int f_update_v_chidinh(string s_id,string s_columnname,string s_value)
        {
            int result = 0;
            try
            {

                sql = " update {database}.v_chidinh ";
                sql += " set {s_columnname}={s_value} ";
                sql += " where id={s_id}  ";


                sql = sql.Replace("{s_id}", s_id);
                sql = sql.Replace("{s_value}", s_value);
                sql = sql.Replace("{s_columnname}", s_columnname);
                sql = sql.Replace("{database}", m_format.getdatabasefromid(s_id));
                result = OracleData.f_execute_data(sql);
               // f_update_done(s_id, (s_value == "0" ? "0" : "2"));
            }
            catch
            {

            }
            return result;
        }
        public int f_update_done(string s_id,string s_value)
        {
            int result = 0;
            try
            {

                sql = " update {database}.v_chidinh ";
                sql += " set done={s_value} ";//,done=" + (s_value=="0"?"0":"2");
                sql += " where id={s_id}  and done <> 1 ";


                sql = sql.Replace("{s_id}", s_id);
                sql = sql.Replace("{s_value}", s_value);
                sql = sql.Replace("{database}", m_format.getdatabasefromid(s_id));
                result = OracleData.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        

    }
}
