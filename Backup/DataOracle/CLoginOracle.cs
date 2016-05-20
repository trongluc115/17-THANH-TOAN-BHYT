using System;
using System.Collections.Generic;
using System.Text;
using Entity;

using DataUpdate;
using System.Data;

namespace DataOracle
{
    public class CLoginOracle
    {
        CConnection_Oracle conn = new CConnection_Oracle();
        CBV_loginDAO bvlogin = new CBV_loginDAO();
        
        public string userAdmin
        {
            get
            {
                return  bvlogin.userAdmin;
            }
        }
        public string passwordAdmin
        {
            get
            {
            return bvlogin.passwordAdmin;
            }
        }
        public  DataSet LoadDSUser(string username, string password)
        {
            try
            {
                CBV_loginDAO loginDAO = new CBV_loginDAO();
              return loginDAO.load_bv_login(username, password);
            }
            catch { return null; }
        }
        public bv_dlogin f_getUser(string s_id)
        {
            bv_dlogin result=new bv_dlogin();
            try
            {  
                CBV_loginDAO loginDAO = new CBV_loginDAO();
                DataSet ds = new DataSet();
                ds= loginDAO.load_bv_login(s_id);
                result.Khoaphong = ds.Tables[0].Rows[0]["MaKP"].ToString();
                result.Hoten = ds.Tables[0].Rows[0]["hoten"].ToString();
                result.Nhomcdha = ds.Tables[0].Rows[0]["NhomCDHA"].ToString();

            }
            catch { return null; }
            return result;
        }
    }
}
