using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class cdha_hen_Oracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;

        DataSet ds;
        string sql = "";
        #endregion
        public cdha_hen_Oracle()
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
        public DataTable f_getCLS_DADUYET(DateTime tungay, DateTime denngay,string s_filter,string s_noithuchien)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.stt,to_char(dvll.ngaycd,'dd/mm/yyyy hh24:mi') ngaycd,to_char(dvll.ngaychup,'dd/mm/yyyy') ngayhen,to_char(dvll.ngaychup,'hh24:mi') giohen,dvll.mabn,bn.hoten,bn.namsinh,";
            sql += " dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia, ";
            sql += " log.hoten,kp.tenkp,kphd.tenkp kphiendien ,dvll.id,bvlog.hoten";
            sql += " from bv115.cdha_hen dvll ";            
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join bv115.cdha_nhom nh on vp.id_loai=nh.id_loai";
            sql += " join medibv115.cdha_kythuat kt on dvll.mavp=kt.idvp ";
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " inner join  btdbn bn on dvll.mabn=bn.mabn";
            sql += " left join medibv115.hiendien hd on hd.mabn=dvll.mabn ";
            sql += " left join bv115.bv_login bvlog on bvlog.id=dvll.userid ";
            sql += " left join btdkp_bv kphd on hd.makp=kphd.makp ";
            sql += " where  to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += "  and dvll.noithuchien='{s_noithuchien}' ";
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_noithuchien}", s_noithuchien);

            if (s_filter.Length > 0)
            {
                sql += " and kt.id_loai=" + s_filter;
            }
            
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getCLS_DADUYET_KHOA(DateTime tungay, DateTime denngay, string s_MAKP)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 1 chon,dvll.trakq,dvll.stt,to_char(dvll.ngaycd,'dd/mm/yyyy hh24:mi') ngay_cd,to_char(dvll.ngaychup,'dd/mm/yyyy hh24:mi') ngay_HEN,nth.ten noithuchien,dvll.mabn,bn.hoten HOTEN,bn.namsinh NAMSINH,";
            sql += " dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia, ";
            sql += " log.hoten,kp.tenkp khoaphonghd,dvll.id ,dvth.ngaythuchien ngayth,dvth.ngayud ngaykq,nh.nhom_cdha nhom_cdha,bvlog.hoten nguoihen ";
            sql += " from bv115.cdha_hen dvll ";
            //sql += " join medibv115.hiendien hd on hd.mabn=dvll.mabn "; ;
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join bv115.cdha_nhom nh on vp.id_loai=nh.id_loai";
            sql += " join medibv115.cdha_kythuat kt on dvll.mavp=kt.idvp ";
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " inner join  btdbn bn on dvll.mabn=bn.mabn";
            sql += " left join BV115.DMNOITHUCHIEN NTH on nth.id=dvll.noithuchien ";
            sql += " left join BV115.cdha_dvll dvth on dvth.id=dvll.id ";
            sql += " left join BV115.bv_login bvlog on dvll.userid=bvlog.id ";
            sql += " where  to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            if (s_MAKP != "-1")
            {
                sql += " and dvll.makp='{s_makp}'";
            }
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));
            sql = sql.Replace("{denngay}", m_format.f_formatNgayYYYYMMDD(denngay));
            sql = sql.Replace("{s_makp}",s_MAKP);
            sql += " order by to_char(dvll.ngaychup,'yyyymmdd hh24:mi') ";
             try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getCLS_DADUYET2(DateTime tungay, DateTime denngay, string mabn, string done)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select 0 chon,dvll.trakq,dvll.sohd,dvll.sobl,to_char(dvll.ngaychup,'dd/mm/yyyy') ngay,bn.mabn,bn.hoten,bn.namsinh,dvll.mavp mavp,vp.ten tenvp,dvll.madoituong,vp.dvt, dvll.soluong,dvll.dongia,dvll.soluong*dvll.dongia tongtien, ";
            sql += " log.hoten,kp.tenkp,dvll.id ";
            sql += " from bv115.cdha_dvll dvll ";
            sql += " join btdbn bn on bn.mabn=dvll.mabn ";
            sql += " join medibv115.v_giavp vp on vp.id=dvll.mavp "; ;
            sql += " join bv115.cdha_nhom nh on vp.id_loai=nh.id_loai";
            sql += " join btdkp_bv kp on dvll.makp=kp.makp ";
            sql += " join dlogin log on dvll.mabs=log.id ";
            sql += " where dvll.mabn like '%{mabn}%'   ";
            sql += " and to_char(dvll.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            sql += " and instr('{NHOM_CDHA}',nh.NHOM_CDHA)>0 ";
            if (done != "-1")
            {
                sql += " and done={DONE} ";
            }
            sql = sql.Replace("{database}", m_format.getdatabase(tungay));
            sql = sql.Replace("{mabn}", mabn);
            sql = sql.Replace("{DONE}", done);
            sql = sql.Replace("{tungay}", m_format.f_formatNgayYYYYMMDD(tungay));

            sql = sql.Replace("{NHOM_CDHA}", AccessData._NHOM_CDHA);


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable f_getBAOCAO_M01(DateTime tungay, DateTime denngay)
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
            sql += " sum(case when kq.nhom_cdha in ('DT') then soluong else 0 end ) DIENTIM ";
            sql+=" from  ";
            sql+=" ( ";
            sql+=" select kv.name khuvuc,CD.sohd,cd.mabn mabn,bn.hoten,bn.namsinh,nhvp.tenloai ,cd.soluong,cd.dongia,vp.id_loai,nhvp.nhom_cdha ";
            sql+=" from bv115.CDHA_DVLL cd   ";
            sql+=" join v_giavp vp on cd.mavp=vp.id ";
            sql+=" join bv115.cdha_nhom nhvp on vp.id_loai=nhvp.id_loai ";
            sql+=" join btdbn bn on cd.mabn=bn.mabn ";
            sql += " join bv115.btdkp_bhyt kp on  kp.makp=cd.makp ";
            sql+=" join bv115.dmkhuvuc kv on kp.khuvuc=kv.id ";
            sql += "  where  to_char(cd.ngaychup,'yyyymmdd') between '{tungay}' and '{denngay}' ";
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
        public DataTable f_getBAOCAO_M02_TRAKQ(DateTime tungay, DateTime denngay, string Nhom)
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

        #endregion 
        public int f_insert(cdha_hen obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = "insert into BV115.cdha_hen (id,ngaycd,ngaychup,mabn,mabs,mavp,soLuong,makp,madoituong,dongia,userid,noithuchien) ";
                sql += " values ({ID},{NGAYCD},{NGAYCHUP},'{MABN}',{MABSCD},{MAVP},{SOLUONG},{MAKP},{MADOITUONG},{DONGIA},{USERID},{NOITHUCHIEN}) ";
                sql=sql.Replace("{ID}",obj.ID.ToString());
                sql = sql.Replace("{NGAYCD}", m_format.f_formatdata(obj.NGAYCD.ToString(),"date"));
                sql = sql.Replace("{NGAYCHUP}", m_format.f_formatdata(obj.NGAYCHUP.ToString(), "date"));
                sql = sql.Replace("{MABN}", obj.MABN.ToString());
                sql=sql.Replace("{MAKP}",m_format.f_formatdata(obj.MAKP.ToString()));
                sql=sql.Replace("{MADOITUONG}",m_format.f_formatdata(obj.MADOITUONG.ToString()));
                sql=sql.Replace("{MAVP}",m_format.f_formatdata(obj.MAVP.ToString()));
                sql=sql.Replace("{SOLUONG}",obj.SOLUONG.ToString());
                sql=sql.Replace("{DONGIA}",obj.DONGIA.ToString());
                sql = sql.Replace("{NOITHUCHIEN}", obj.NOITHUCHIEN.ToString());
              
                sql = sql.Replace("{MABSCD}", m_format.f_formatdata(obj.MABSCD.ToString()));
                sql = sql.Replace("{MADOITUONG}",m_format.f_formatdata( obj.MADOITUONG.ToString()));
                sql = sql.Replace("{USERID}", AccessData.m_userid);
                 result = OracleData.f_execute_data(sql);
                 f_update_v_chidinh(obj.ID.ToString(), "hen", "1");



            }
            catch
            {

            }
            return result;
        }
        public int f_update(cdha_hen obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_hen ";
                sql += " set done='{DONE}',NGAYTHUCHIEN={NGAYTHUCHIEN},MAKTV='{MAKTV}' , ngayud=sysdate";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{NGAYTHUCHIEN}", m_format.f_formatdata(obj.NGAYTHUCHIEN.ToString(), "date"));
                sql = sql.Replace("{DONE}", obj.DONE);
                sql = sql.Replace("{MAKTV}", AccessData.m_userid);

                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update_trakq(cdha_hen obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_hen ";
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
        public int f_update_thoigianhen(string s_ngay,string s_thuchien,string s_id,string s_noithuchien)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_hen ";
                sql += " set ngaychup=to_date('{NGAYCHUP}','dd/mm/yyyy hh24:mi')";
                sql += " , trakq={s_thuchien},noithuchien={s_noithuchien} ";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", s_id);
                sql = sql.Replace("{NGAYCHUP}",s_ngay);
                sql = sql.Replace("{s_thuchien}", s_thuchien);
                sql = sql.Replace("{s_noithuchien}", s_noithuchien);


                result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_update_dathuchien(string s_thuchien, string s_id)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;
                //PHAU THUAT KTC
                sql = " update BV115.cdha_hen ";
                sql += " set  trakq={s_thuchien} ";
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", s_id);
                
                sql = sql.Replace("{s_thuchien}", s_thuchien);


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
                sql = "delete BV115.cdha_hen where id={id} ";
                sql = sql.Replace("{id}", id.ToString());
                result = OracleData.f_execute_data(sql);

                f_update_v_chidinh(id.ToString(), "hen", "0");

            }
            catch
            {

            }
            return result;
        }
        private string f_getsqlchiphi2(string sqlcp,  DateTime TuNgay, DateTime DenNgay)
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
                sqlGroup = " select kq.* ";


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
                
                
                
                

            }
            catch (Exception ex)
            {
                return "";

            }
            return sqlGroup;
        }
        public DataSet f_getDanhSach(DateTime TuNgay, DateTime DenNgay, string s_filter)
        {


            string sqlcp = "     select 0 chon,to_char(cd.ngay,'dd/mm/yyyy hh24:mi') ngay,cd.mabn,bn.hoten,bn.namsinh,cd.mavp,vp.ten tenvp,";
            sqlcp += "           vp.dvt,cd.soluong,cd.dongia,cd.madoituong,cd.id,cd.makp,kphd.tenkp kphiendien,kp.tenkp kpchidinh,nhom.ten nhomvp,cd.userid userid";
            sqlcp += "           from {data_user}.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join bv115.cdha_nhom cdnh on vp.id_loai=cdnh.id_loai ";
            sqlcp += "           join medibv115.cdha_kythuat kt on cd.mavp=kt.idvp ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += "           join medibv115.btdbn bn on bn.mabn=cd.mabn ";
            sqlcp += "           left join medibv115.hiendien hd on hd.mabn=cd.mabn ";
            sqlcp += "           left join btdkp_bv kphd on hd.makp=kphd.makp ";
            sqlcp += "           where  to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' and cd.hen<>'1' ";


            
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));
            if (s_filter.Length > 0)
            {
                sqlcp += " and kt.id_loai=" + s_filter;
            }
            //sqlcp += " order by to_char(cd.ngay,'yyyymmddhh24:mi') ";
            string sqlgroup = f_getsqlchiphi2(sqlcp,  TuNgay, DenNgay);


            sql = sqlcp;
            DataSet dset = new DataSet();
            try
            {
                dset = OracleData.get_data(sqlgroup);

            }
            catch { }
            return dset;
        }
        public DataSet f_getDanhSach_XepLich(DateTime TuNgay, DateTime DenNgay, string s_filter)
        {


            string sqlcp = "     select 0 chon,to_char(cd.ngay,'dd/mm/yyyy') ngay,cd.mabn,bn.hoten,bn.namsinh,cd.mavp,vp.ten tenvp,";
            sqlcp += "           vp.dvt,cd.soluong,cd.dongia,cd.madoituong,cd.id,cd.makp,kp.tenkp,nhom.ten nhomvp,cd.userid userid";
            sqlcp += "           from medibv1150815.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join bv115.cdha_nhom cdnh on vp.id_loai=cdnh.id_loai ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += "           join medibv115.btdbn bn on bn.mabn=cd.mabn ";
            sqlcp += "           where  to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' and cd.id not in (select id from bv115.cdha_hen)";



            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));

            //  string sqlgroup = f_getsqlchiphi2(sqlcp, "", TuNgay, DenNgay);


            sql = sqlcp;
            DataSet dset = new DataSet();
            try
            {
                dset = OracleData.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_getCDHA_Loai(string s_dieukien)
        {
            DataSet ds = new DataSet();
            try
            {
                sql = "select id id,ten name from medibv115.cdha_loai where 1=1 " + s_dieukien + " order by ten";
                ds=OracleData.get_data(sql);

            }
            catch { }
            return ds;
        
        }
        public DataSet f_getCDHA_NOITHUCHIEN(string s_cdhakhu)
        {
            DataSet ds = new DataSet();
            try
            {
                sql = "select id id,ten name from bv115.DMNOITHUCHIEN where ENABLE=1  ";
                if (s_cdhakhu != "-1")
                {
                    sql += " and id_khu='" + s_cdhakhu + "' ";
                }
                sql+=" order by ten";
                ds = OracleData.get_data(sql);

            }
            catch { }
            return ds;

        }
        public int f_update_v_chidinh(string s_id, string s_columnname, string s_value)
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
               // f_update_done(s_id,(s_value=="0"?"0":"2"));
            }
            catch
            {

            }
            return result;
        }
        public int f_update_done(string s_id, string s_value)
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
