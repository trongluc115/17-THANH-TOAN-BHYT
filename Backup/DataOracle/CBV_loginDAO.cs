using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data;
using LibBaocao;
using DataUpdate;


namespace DataOracle
{
    public class CBV_loginDAO
    {
        private CConnection_Oracle ora_conn = new CConnection_Oracle();
        string schema = CConnection_Oracle.schema;
        private DataSet ds = new DataSet();
        private string sql = "";
        public string userAdmin = "itbv115";
        public string passwordAdmin = "itbv115@dministrator";
        
        public void upd_bv_login(int i_id, string s_right)
        {
            sql = " update " + schema + ".bv_login set menuitem='" + s_right + "' where id=" + i_id;
            ora_conn.setData(sql);
        }
        public int upd_bv_login(int i_id, string s_HoTen, string s_tenDangNhap, string s_MatKhau)
        {
            sql = "update " + schema + ".bv_login set hoten='" + s_HoTen + "',username='" + s_tenDangNhap + "',password='" + s_MatKhau + "' where  id=" + i_id;
            int num = ora_conn.setData(sql);
            return num;

        }
        public void ins_bv_login(int maxid, string s_HoTen, string s_tenDangNhap, string s_MatKhau, int i_NhomKho)
        {
            sql = "insert into " + schema + ".bv_login (id,hoten,username,password,manhom) values (" + maxid + ",'" + s_HoTen + "','" + s_tenDangNhap + "','" + s_MatKhau + "','" + i_NhomKho + "')";
            ora_conn.setData(sql);
        }
        public void ins_bv_login(int id, string s_HoTen, string s_tenDangNhap, string s_MatKhau)
        {
            sql = "insert into " + schema + ".bv_login (id,hoten,username,password) values (" + id + ",'" + s_HoTen + "','" + s_tenDangNhap + "','" + s_MatKhau + "')";
            ora_conn.setData(sql);
        }
        public int maxid_bvlogin()
        {
            int s_maxid = 0;
            sql = " select nvl(max(id),0) from " + schema + ".bv_login";
            ds = ora_conn.getData(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s_maxid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return s_maxid;
        }
        public void upd_bv_login(int i_id, string s_right, int i_nhomkho)
        {
            sql = " update " + schema + ".bv_login set menuitem='" + s_right + "' where id=" + i_id;
            //libc.setData(sql);
            ora_conn.setData(sql);
        }
        public DataSet load_bv_login()
        {
            sql = " select * from " + schema + ".bv_login";
            ds = ora_conn.getData(sql);
            return ds;
        }

        public DataSet load_bv_login_nhomkho(int i_kho)
        {
            sql = " select * from " + schema + ".bv_login where nhomkho in (" + i_kho + ")";
            ds = ora_conn.getData(sql);
            return ds;
        }

        public DataSet load_bv_login_HoTen_TenDangNhap()
        {
            sql = " select hoten||_||user from " + schema + ".bv_login";
            ds = ora_conn.getData(sql);//libc.get_data(sql);
            return ds;
        }
        public DataSet load_bv_login(string s_id)
        {
            sql = " select * from " + schema + ".bv_login where id='"+s_id+"'";
            ds = ora_conn.getData(sql);//libc.get_data(sql);
            return ds;
        }
        public DataSet load_bv_login(string username, string password)
        {
            ora_conn = new CConnection_Oracle();
            ds = new DataSet();
            sql = "select * from " + schema + ".bv_login where Upper(username)=Upper('" + username + "') and password='" + password + "'";

            ds = ora_conn.getData(sql);
            // AccessData libc = new AccessData();
            //ds=libc.get_data(sql);
            return ds;
        }

        public void del_bv_login(int id)
        {
            sql = "delete from " + schema + ".bv_login where id=" + id;
            ora_conn.setData(sql);
        }
    }
}
