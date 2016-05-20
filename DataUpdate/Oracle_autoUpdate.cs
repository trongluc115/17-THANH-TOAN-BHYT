using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataUpdate
{
  public  class Oracle_autoUpdate
    {
      private CConnection_Oracle conn = new CConnection_Oracle();
      private string sql = "";
      private int num = 0;
      private DataSet ds = new DataSet();
      private string schema = CConnection_Oracle.schema;
      public int ins_version(string s_path,string s_version,int i_autoUpdate)
      {
        num = conn.setData("insert into "+schema+".bv_autoupdate (id,computer,version,ngayud,capnhat) values (1,'"+s_path+"','"+s_version+"',sysdate,"+i_autoUpdate+")");
        return num;
      }
      public int ins_version(int i_id, string s_computer,string s_version, int i_autoUpdate)
      {
          num = conn.setData("insert into " + schema + ".bv_autoupdate (id,computer,version,ngayud,capnhat) values ("+i_id+",'" + s_computer + "','" + s_version + "',sysdate," + i_autoUpdate + ")");
          return num;
      }
      public int upd_version(int i_id,string s_computer,string s_version, int i_autoUpdate)
      {
          num = conn.setData("update " + schema + ".bv_autoupdate set id=" + i_id + ",version='" + s_version + "',ngayud=sysdate,capnhat=" + i_autoUpdate + " where computer='" + s_computer + "'");
          return num;
      }
      public int upd_version( string s_path,string s_version, int i_autoUpdate)
      {
          num = conn.setData("update " + schema + ".bv_autoupdate set computer='" + s_path + "',version='" + s_version + "',ngayud=sysdate,capnhat=" + i_autoUpdate + " where id=1");
          return num;
      }
      public int maxid()
      {
          sql = "select max(id) from " + schema + ".bv_autoupdate";
          ds = conn.getData(sql);
          try
          {
              if (ds.Tables[0].Rows.Count > 0)
              {
                  return int.Parse(ds.Tables[0].Rows[0][0].ToString());
              }
              else { return 0; }
          }
          catch
          {
              return 0;

          }
      }

      public DataTable dtversionComputer(string s_computer)
      {
          sql = "select * from " + schema + ".bv_autoupdate where computer='"+s_computer+"'";
          ds = conn.getData(sql);
          try
          {
              if (ds.Tables[0].Rows.Count > 0)
              {
                  return ds.Tables[0];
              }
              else { return null; }
          }
          catch
          {
              return null;
          }
      }
      public DataTable dt_autoUpdate()
      {
          sql = "select * from " + schema + ".bv_autoupdate where id='1'";
          ds = conn.getData(sql);
          try
          {
              if (ds.Tables[0].Rows.Count > 0)
              {
                  return ds.Tables[0];
              }
              else { return null; }
          }
          catch
          {
              return null;
          
          }
      }
      
    }
}
