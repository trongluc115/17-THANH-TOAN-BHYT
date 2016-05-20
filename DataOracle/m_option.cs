using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;


namespace DataOracle
{
    public class m_option
    {
        public static string f_get_capid(string userid)
        {
            string kq = "";
            try
            {
                AccessData data = new AccessData();
                string sql = " select to_char(systimestamp,'yymmddhh24miss')||{userid} capid from dual";
                sql = sql.Replace("{userid}", userid);
                DataSet ds = data.get_data(sql);
                kq = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            return kq;
        }
        #region update
        public int f_update_dinhsuat(DateTime tungay,DateTime denngay,string loaibn)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                //sql =" update BV115.V_BHYTll set NGOAIDINHSUAT=BHYT ";
                //sql+=" WHERE ID IN (SELECT ";
                //sql+=" ID FROM  BV115.V_BHYTDS A WHERE ";
                //sql+=" (INSTR('+N18+K70+K71+K72+K73+K74+K75+K76+K77+H16.0+I00+I01+I02+I03+I04+I05+I06+I07+I08+I09+C38+I20+I21+I22+I23+I24+I25+I30+I31+I32+I33+I34+I35+I36+I37+I38+I39+I40+I41+I42+I43+I44+I45+I46+I47+I48+I49+I50+I51+I52+C00+C01+C02+C03+C04+C05+C06+C07+C08+C09+C10+C11+C12+C13+C14+C15+C16+C17+C18+C19+C20+C21+C22+C23+C24+C25+C26+C27+C28+C29+C30+C31+C32+C33+C34+C35+C36+C37+C38+C39+C40+C41+C42+C43+C44+C45+C46+C47+C48+C49+C50+C51+C52+C53+C54+C55+C56+C57+C58+C59+C60+C61+C62+C63+C64+C65+C66+C67+C68+C69+C70+C71+C72+C73+C74+C75+C76+C77+C78+C79+C80+C81+C82+C83+C84+C85+C86+C87+C88+C89+C90+C91+C92+C93+C94+C95+C96+C97+D00+D01+D02+D03+D04+D05+D06+D07+D08+D09+D66+D67+D68', ";
                //sql+=" SUBSTR(A.MAICD,1, 3))>0 or INSTR(A.MAICD,'N18')>0) and substr(a.sothe,-5,5)='79024') and to_char(ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
                //sql += " and ( exists (select 1 from bv115.v_bhytct ct  where ct.thuock in (31,32) and BV115.V_BHYTll.id=ct.id)  )";

                sql = " update BV115.V_BHYTll set NGOAIDINHSUAT=BHYT ";
                sql += " WHERE LOAIBN="+loaibn+" AND ID IN (SELECT ";
                sql += " ID FROM  BV115.V_BHYTDS A WHERE ";
                sql += " SUBSTR(A.MAICD,1, 3) IN (SELECT SUBSTR(MAICD,1, 3) FROM BV115.DM_ICDDINHSUAT) ";
                sql += " and substr(a.sothe,-5,5)='79024') and to_char(ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
           //     sql += " and ( exists (select 1 from bv115.v_bhytct ct  where ct.thuock in (31,32) and BV115.V_BHYTll.id=ct.id)  )";
              
             
                sql = sql.Replace("{tungay}",string.Format("{0:yyyyMMdd}",tungay) );
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_thuock(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = " update bv115.v_bhytll  set thuock2=(  ";
                sql+= " select round(sum(vct.dongia*vct.soluong),0) ";
                sql+= " from bv115.v_bhytct vct ";
                sql += " where vct.id=bv115.v_bhytll.id and vct.thuock>0 and vct.madoituong=1 )  ";
                sql += " where  to_char(bv115.v_bhytll.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
                sql += " and exists (select 1  from bv115.v_bhytct where bv115.v_bhytct.thuock>0 and bv115.v_bhytll.id=bv115.v_bhytct.id  ) ";
                

                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_CHIPHI_NGOAI(DateTime tungay, DateTime denngay,string MACP_NGOAI)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = " update bv115.v_bhytll  set CHIPHI{MACP_NGOAI}_NGOAI=(  ";
                sql += " select round(sum(vct.dongia*vct.soluong),0) ";
                sql += " from bv115.v_bhytct vct ";
                sql += " where vct.id=bv115.v_bhytll.id and vct.thuock={MACP_NGOAI} and vct.madoituong=1 )  ";
                sql += " where  to_char(bv115.v_bhytll.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
                sql += " and exists (select 1  from bv115.v_bhytct where bv115.v_bhytct.thuock={MACP_NGOAI} and bv115.v_bhytll.id=bv115.v_bhytct.id  ) ";


                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                sql = sql.Replace("{MACP_NGOAI}", MACP_NGOAI);
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_thuock0(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = " update bv115.v_bhytll  set thuock2=0 ";
                sql += " where  to_char(bv115.v_bhytll.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
                


                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_Keythuock0(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;

               sql = " update bv115.v_bhytct  set thuock=0 ";

                sql += " where exists(select 1 from  bv115.v_bhytll ";
                sql += " where  bv115.v_bhytct.id=bv115.v_bhytll.id and  to_char(bv115.v_bhytll.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}' ) ";
              
                
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));

                
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_ICD()
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;

                sql = " update bv115.v_bhytds set maicd= substr(maicd,2,length(maicd)-1)  where substr(maicd,1,1)=';' ";
                
                result = data.f_execute_data(sql);

            }
            catch
            {

            }
            return result;
        }
        public int f_update_Keythuock1(DateTime tungay, DateTime denngay,string type)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql = "";
                sql = " update bv115.v_bhytct  set thuock={type}";
                sql += " where exists (select 1 from  bv115.v_bhytll ";
                sql += " where  to_char(bv115.v_bhytll.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}' and  bv115.v_bhytct.id=bv115.v_bhytll.id) ";
                sql += " and exists (select 1  from bv115.d_dmbdbh  ";
                sql += " where bv115.d_dmbdbh.id=bv115.v_bhytct.mavp and bv115.d_dmbdbh.id_type={type} )";
                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                sql = sql.Replace("{type}", type);
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        
        public DataTable f_get_UBNDtra(DateTime tungay, DateTime denngay)
        {
            DataTable dt = new DataTable();
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = "   select to_char(a.ngay,'yyyyMMdd'),b.mabn,b.hoten,b.sothe,a.bhyt,round(a.sotien*a.tilethe/100,0),round(a.sotien*(a.tilehuong-a.tilethe)/100,0),a.ubndtra ";
                sql += "from  bv115.v_bhytll a  ";
                sql += " join  bv115.v_bhytds b ";
                sql += " join btdbn c join b.mabn=c.id ";
                sql += " where  ((a.tilehuong>a.tilethe and a.sotien>172500 ) or a.ubndtra>0)";
                sql += " and  to_char(a.ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";




                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                dt = data.get_data(sql).Tables[0];
            }
            catch
            {

            }
            return dt;
        }
         public int f_update_UBNDtra(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = "   update  bv115.v_bhytll set bhyt=round(sotien*tilethe/100,0),ubndtra=round(sotien*(tilehuong-tilethe)/100,0) ";
                sql+=" where  tilehuong>tilethe and sotien>172500 ";
                sql+= " and  to_char(ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";
                
        
                 

                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public int f_update_KiemtraTong(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = "   update bv115.v_bhytll set thuoc= sotien-(vtth+mau+xetnghiem+cdha+dvktthuong+dvktcao+cpvc+tdcn+giuong+khac+khambenh) ";
                sql+=" where  sotien<>mau+xetnghiem+cdha+dvktthuong+dvktcao+cpvc+tdcn+giuong+khac+thuoc+khambenh+vtth ";
                sql += " and  to_char(ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";




                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return result;
        }
        public DataTable f_get_KiemtraTong(DateTime tungay, DateTime denngay)
        {
            AccessData data = new AccessData();
            int result = 0;
            DataSet ds = new DataSet(); ;
            try
            {
                string userid = AccessData.m_userid;
                string sql;
                sql = "   select  sophieu,to_char(ngay,'dd/mm/yyyy'),id,thuoc, sotien-(vtth+mau+xetnghiem+cdha+dvktthuong+dvktcao+cpvc+tdcn+giuong+khac+khambenh+vtyttl+thuock) ";
                sql += " from bv115.v_bhytll ";
                
                sql += " where  sotien<>mau+xetnghiem+cdha+dvktthuong+dvktcao+cpvc+tdcn+giuong+khac+thuoc+khambenh+vtth + thuock+vtyttl";
                sql += " and  to_char(ngay,'yyyyMMdd') between '{tungay}' and '{denngay}'  ";

                sql = sql.Replace("{tungay}", string.Format("{0:yyyyMMdd}", tungay));
                sql = sql.Replace("{denngay}", string.Format("{0:yyyyMMdd}", denngay));
                ds = data.get_data(sql);
                //result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return ds.Tables[0];
        }
        public DataTable f_get_XuatExcel(string sql)
        {
            AccessData data = new AccessData();
            int result = 0;
            DataSet ds = new DataSet(); ;
            try
            {
                string userid = AccessData.m_userid;
                
                
                ds = data.get_data(sql);
                //result = data.f_execute_data(sql);
            }
            catch
            {

            }
            return ds.Tables[0];
        }
        public static bool f_checkExist_Schema(string s_schema)
        {
            bool result = false;
            AccessData data = new AccessData();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string mmyy = s_schema.Substring(9, 4);
            string sql = " select * from tables where mmyy='" + mmyy + "'";


            try
            {
                ds = data.get_data(sql);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                    result = true;
            }
            catch { }
            return result;






        }
        public DateTime f_get_CDHA_LockDate(string s_khu)
        {
           DateTime D_result=new DateTime();
           try {
                AccessData data = new AccessData();
                DataSet ds = new DataSet();

                string sql = "Select to_char(date_lock,'dd/mm/yyyy') from Bv115.CDHA_CONFIG where khu='" + s_khu + "'";
                ds = data.get_data(sql);
                string str_date = ds.Tables[0].Rows[0][0].ToString();
                D_result = m_format.DateTime_parse(str_date);
            }catch{}
            return D_result;

        }
        public int f_set_CDHA_LockDate(string s_khu,DateTime  d_lockdate)
        {
            int i_roweffect=0;
            DateTime result;
            try{
                AccessData data = new AccessData();
                DataSet ds = new DataSet();
                string sql = "update bv115.CDHA_CONFIG set  DATE_LOCK= to_date('"+string.Format("{0:dd/MM/yyyy}",d_lockdate) + "','dd/mm/yyyy') where khu='" + s_khu + "'";
                i_roweffect= data.f_execute_data(sql);
                
            }catch{}
            return i_roweffect;

        }
        public DateTime f_get_BHYT_LockDate(string s_id)
        {
            DateTime D_result = new DateTime();
            try
            {
                AccessData data = new AccessData();
                DataSet ds = new DataSet();

                string sql = "Select to_char(date_lock,'dd/mm/yyyy') from Bv115.m_CONFIG where id='" + s_id + "'";
                ds = data.get_data(sql);
                string str_date = ds.Tables[0].Rows[0][0].ToString();
                D_result = m_format.DateTime_parse(str_date);
            }
            catch { }
            return D_result;

        }
        public int f_set_BHYT_LockDate(string s_id, DateTime d_lockdate)
        {
            int i_roweffect = 0;
            DateTime result;
            try
            {
                AccessData data = new AccessData();
                DataSet ds = new DataSet();
                string sql = "update bv115.m_CONFIG set  DATE_LOCK= to_date('" + string.Format("{0:dd/MM/yyyy}", d_lockdate) + "','dd/mm/yyyy') where ID="+s_id;
                i_roweffect = data.f_execute_data(sql);

            }
            catch { }
            return i_roweffect;

        }
        

        #endregion
    }
}
