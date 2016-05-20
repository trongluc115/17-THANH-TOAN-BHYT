using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data;
using LibBaocao;
using DataUpdate;


namespace DataOracle
{
    public class CBV_dloginDAO
    {
        private CConnection_Oracle ora_conn = new CConnection_Oracle();
        string schema = CConnection_Oracle.schema;
        private DataSet ds = new DataSet();
        private string sql = "";

        public void upd_bv_dlogin(int i_id, string s_right)
        {
            sql = " update bv115.bv_dlogin set right='" + s_right + "' where id=" + i_id;
            ora_conn.setData(sql);
        }
        public void ins_bv_dlogin(int maxid, string s_HoTen, string s_tenDangNhap, string s_MatKhau, int i_NhomKho)
        {
            sql = "insert into bv115.bv_dlogin (id,hoten,userid,password_,manhom) values (" + maxid + ",'" + s_HoTen + "','" + s_tenDangNhap + "','" + s_MatKhau + "','" + i_NhomKho + "')";
            ora_conn.setData(sql);
        }
        public void ins_bv_dlogin(int id, string s_HoTen, string s_tenDangNhap, string s_MatKhau)
        {
            sql = "insert into bv115.bv_dlogin (id,hoten,userid,password_) values (" + id + ",'" + s_HoTen + "','" + s_tenDangNhap + "','" + s_MatKhau + "')";
            ora_conn.setData(sql);
        }
        public int maxid_bvdlogin()
        {
            int s_maxid = 0;
            sql = " select max(id) from bv115.bv_dlogin";
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
        public void upd_bv_dlogin(int i_id, string s_right, int i_nhomkho)
        {
            sql = " update bv115.bv_dlogin set right='" + s_right + "' where id=" + i_id;
            //libc.execute_data(sql);
            ora_conn.getData(sql);
        }
        public DataSet load_bv_dlogin()
        {
            sql = " select * from bv115.bv_dlogin";
            ds = ora_conn.getData(sql);
            return ds;
        }
        public DataSet load_bv_dlogin_nhomkho(int i_kho)
        {
            sql = " select * from bv115.bv_dlogin where nhomkho in (" + i_kho + ")";
            ds = ora_conn.getData(sql);//libc.get_data(sql);
            return ds;
        }
        public DataSet load_bv_dlogin_HoTen_TenDangNhap()
        {
            sql = " select hoten||_||userid from bv115.bv_dlogin";
            ds = ora_conn.getData(sql);//libc.get_data(sql);
            return ds;
        }
        public void del_bv_dlogin(int id)
        {
            sql = "delete from bv115.bv_dlogin where id=" + id;
            ora_conn.setData(sql);
        }
    }
}
