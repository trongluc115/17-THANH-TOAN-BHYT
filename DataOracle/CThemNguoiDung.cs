using System;
using System.Collections.Generic;
using System.Text;
using DataUpdate;


using System.Data;

namespace DataOracle
{
   public class CThemNguoiDung
    {

       private CConnection_Oracle conn = new CConnection_Oracle();
       private CBV_loginDAO bvlogin = new CBV_loginDAO();
       private CDMNhomKhoDAO dmnhomkho = new CDMNhomKhoDAO();
       private DataSet ds=new DataSet();
       private string sql = "";
       private int num = 0;
       public DataSet load_dm_nhomkho()
       {
           ds= dmnhomkho.load_DM_NhomKho();
           return ds;
       }
       public void ins_bv_login(int i_id, string s_HoTen, string s_tenDangNhap, string s_MatKhau, int i_NhomKho)
       {           
           bvlogin.ins_bv_login(i_id,s_HoTen,s_tenDangNhap,s_MatKhau,i_NhomKho);
       }
       public int maxid_bv_login()
       {
           return bvlogin.maxid_bvlogin();
       }

       public void ins_bv_login(int i_id, string s_HoTen, string s_tenDangNhap, string s_MatKhau)
       {
            bvlogin.ins_bv_login(i_id, s_HoTen, s_tenDangNhap, s_MatKhau);
       }

       public void upd_ins_bv_login(int i_id, string s_HoTen, string s_tenDangNhap, string s_MatKhau)
       {
           int num = bvlogin.upd_bv_login(i_id, s_HoTen, s_tenDangNhap, s_MatKhau);
           if (num == 0)
           {
               bvlogin.ins_bv_login(i_id, s_HoTen, s_tenDangNhap, s_MatKhau);
           }
       }

       public void updrec(DataTable dt, int id, string sTenDangNhap, string sMatKhau, string sHoTen)
       {
           string exp = "id=" + id;
           if (conn.LayDongTheoDieuKien (dt, exp) == null)
           {
               DataRow row = dt.NewRow();
               row["id"] = id;
               row["username"] = sTenDangNhap;
               row["password"] = sMatKhau;
               row["hoten"] = sHoTen;
               //row["nhomkho"] = nhomkho;
               //row["makho"] = makho;
               //row["makp"] = makp;
               dt.Rows.Add(row);
           }
           else
           {
               dt.Select(exp)[0]["hoten"] = sHoTen;             
               dt.Select(exp)[0]["username"] = sTenDangNhap;
               dt.Select(exp)[0]["password"] = sMatKhau;
           }
       }
    }
}
