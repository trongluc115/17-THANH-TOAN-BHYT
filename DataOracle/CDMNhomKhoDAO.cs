using System;
using System.Collections.Generic;
using System.Text;
using DataUpdate;
using System.Data;

namespace DataOracle
{
   public class CDMNhomKhoDAO
    {
       CConnection_Oracle conn = new CConnection_Oracle();
       private DataSet ds;
       public DataSet load_DM_NhomKho()
       {
           ds=conn.getData("select * from medibv115.d_dmnhomkho");
           return ds;
       }
    }
}
