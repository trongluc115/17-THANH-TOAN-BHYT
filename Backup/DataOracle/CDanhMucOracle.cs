using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
using DataUpdate;
namespace DataOracle
{
    public class CDanhMucOracle
    {
        AccessData data = new AccessData();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        CConnection_Oracle ora_conn = new CConnection_Oracle();
        string sql = "";
        private string schema = CConnection_Oracle.schema;

        public string f_getid(string tablename)
        {
            string result = "";
            try {
                string sql = " select max(to_number(cur_id))+1 from bv115.capid where table='@tablename'";
                sql=sql.Replace("@tablename",tablename);
                ds = data.get_data(sql);
                result = ds.Tables[0].Rows[0][0].ToString();

                string sql_excute = " update  bv115.capid set cur_id=@cur_id where table='@tablename'";
                sql_excute = sql_excute.Replace("@tablename", tablename);
                sql_excute = sql_excute.Replace("@cur_id", result);
                data.execute_data(sql_excute);
                


            }
            catch { }
            return result;
            
        }
        public bool insert_danhmuc(string tablename,string  id, string  name,string enable)
        {
            bool result =true;
            try
            {
               
                string sql_excute = " insert @tablename(ID,NAME,ENABLE) VALUES (@ID,@NAME,@ENABLE) ";
                sql_excute = sql_excute.Replace("@tablename", tablename);
                sql_excute = sql_excute.Replace("@ID", id);
                sql_excute = sql_excute.Replace("@name", name);
                sql_excute = sql_excute.Replace("@ENABLE", enable);
                data.execute_data(sql_excute);

            }
            catch {
                result = false;
            }
            return result;

        }
        public DataTable get_danhmuc(string tablename,int enable)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            
            string sql = "select id ma,name ten ,enable  from @tablename where 1=1 @filter order by TEN ";
            if (enable != -1)
            {
                sql = sql.Replace("@filter", " and enable =" + enable);
            }
            else
            {
                sql = sql.Replace("@filter", "");
            }
            sql = sql.Replace("@tablename", tablename);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public  DataTable f_getDMDuoc_VienPhi()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = " select id id,rpad(lower(ten)||' '||hamluong||' ('||lower(DANG)||')   ',80)||lpad(TO_CHAR(ROUND(DONGIA,0)),15)  TEN,DANG||' ('||bhyt||') ' DONVI,ROUND(DONGIA,0) GIA_BH from d_dmbd ";
            sql+=" UNION ALL ";
            sql += " select id id,rpad(lower(TEN)||' ('||lower(DVT)||')   ',80)||lpad(TO_CHAR(ROUND(GIA_BH,0)),15) TEN,DVT||' ('||bhyt||')' DONVI,ROUND(GIA_BH,0) GIA_BH from V_GIAVP where id_loai  in (select id from v_loaivp where id_nhom not in (11) )  and gia_cu=0 ";
            try
            {
                ds = data.get_data(sql);
                dt=ds.Tables[0];
            }
            catch {  }
            return dt;
        }

        public DataTable get_danhmucbd_bhyt(string timkiem)
        {
            AccessData data = new AccessData()   ;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select to_number(tbh.id) id,bd.ten || ' ' ||bd.hamluong,to_number(tbh.id_type),tbh.filter,tbh.bhyt  from bv115.d_dmbdbh tbh ";
            sql += " join d_dmbd bd on bd.id=tbh.id where LOWER(bd.ten) || ' ' ||LOWER(bd.hamluong) like '%@timkiem%'";
            sql = sql.Replace("@timkiem", timkiem.ToLower());
            
            
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }

        public DataTable d_getDMKhoaPhong()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select makp id,tenkp ten from btdkp_bv order by tenkp ";
            
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable d_getDMKhoaPhong(string s_value)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select makp id,tenkp ten from btdkp_bv where 1=1 {dieukien} order by tenkp ";
            if (s_value.Length > 0)
            {
                sql = sql.Replace("{dieukien}", " and makp in (" + s_value + ")");
            }
            else
            {
                sql = sql.Replace("{dieukien}", "");
            }

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable d_getDM_BCDieuKien(string sudung)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select id ma,tenbaocao ten from bv115.bc_dieukien WHERE SUDUNG LIKE '%"+sudung+"%' order by tenbaocao ";

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable get_NHOMXHH()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select to_number(id) ID,LOAIBC ||'_'||XHH||'_'||VIETTAT NAME from bv115.NHOMXHH order by LOAIBC || '-' ||NHOMBC ";

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable d_getDM_NHOMBC()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select id ma,TENNHOM ten ,SUDUNG from bv115.DMNHOMBC order by TENNHOM";

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public string d_getDM_BCDieuKien_FromID(string id)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string result = "";
            string sql = "select dieukien value from bv115.bc_dieukien where id='@id'";
            sql = sql.Replace("@id", id);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
            }
            catch { }
            return result; 
        }
        public string f_get_idnhombhyt(string madichvu)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string idnhombhyt="0";
            string sql = "select nhomvp.idnhombhyt  from     medibv115.d_dmbd vp ";
            sql+=" join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id  ";
            sql+=" join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma  ";
            sql+=" where vp.id= {madv} ";
            sql+=" union  ";
            sql+=" select nhom.idnhombhyt  from  medibv115.v_giavp vp ";
            sql+=" join medibv115.v_loaivp loai on vp.id_loai=loai.id  ";
            sql+=" join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sql+=" where vp.id={madv} ";
            sql=sql.Replace("{madv}",madichvu);

            try
            {
                ds = data.get_data(sql);
                idnhombhyt=ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            return idnhombhyt;
        }
        public DataTable d_getDMNhomBHYT()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select  id,ten from BV115.v_nhombhyt where stt>0 order by stt ";

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable d_getDMDoiTuong()
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select  madoituong ma,doituong ten from Doituong order by madoituong ";

            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public double f_getgiaVP(string mavp)
        {
            double result = 0;
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select round(dongia,2) dongia from d_dmbd where id=@mavp ";
            sql+=" union select round(gia_bh,2) dongia from v_giavp where id=@mavp ";

            sql = sql.Replace("@mavp", mavp);

            try
            {
                ds = data.get_data(sql);
                result =double.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            return result;
        
        }
        public string  f_getNameVP(string mavp)
        {
            string s_name = "";
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select lower(ten)||' '||hamluong ten from d_dmbd where id=@mavp ";
            sql += " union select lower(ten) ten from v_giavp where id=@mavp ";

            sql = sql.Replace("@mavp", mavp);

            try
            {
                ds = data.get_data(sql);
                s_name = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            return s_name;

        }
        public string d_getDM_BCDieuKien_TenReport_FromID(string id)
        {
            string result = "";
            sql = "select tenreport value from " + schema + ".bc_dieukien where id='@id'";
            sql = sql.Replace("@id", id);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
            }
            catch { }
            return result;
        }

        public string d_getDM_BCDieuKien_TieuDeExcel_FromID(string id)
        {
            string result = "";
            sql = "select tieudeexcel value from " + schema + ".bc_dieukien where id='@id'";
            sql = sql.Replace("@id", id);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
            }
            catch { }
            return result;
        }

        public string d_getDM_BCDieuKien_TenBaoCao_FromID(string id)
        {
            string result = "";
            sql = "select tenbaocao value from " +schema + ".bc_dieukien where id='@id'";
            sql = sql.Replace("@id", id);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
            }
            catch { }
            return result;
        }
        public string getChanDoanFromICD(string maicd)
        {
            string result = "";
            sql = "select vviet  from icd10 where cicd10='{maicd}'";
            sql = sql.Replace("{maicd}", maicd);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
            }
            catch { }
            return result;
        
        }
        public DataTable d_getDMNhomCDHA(string filter)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select  nhom_cdha id,nhom_cdha ten from bv115.cdha_nhom where instr ('{filter}',nhom_cdha)>0 group by nhom_cdha ";
            sql = sql.Replace("{filter}", filter);
            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable d_getDMKHU(string filter)
        {
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = "select  id id,name name from bv115.dmcdhakhu order by name  ";
            sql = sql.Replace("{filter}", filter);
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
