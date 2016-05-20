using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class e_bhytll_Oracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public e_bhytll_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public int f_insert(v_bhytll obj)
        { 
            int result=0;
              try
                {

           
                   
                    string userid = AccessData.m_userid;
                    //PHAU THUAT KTC
                    sql = "insert into " + schema + ".e_bhytll(ID,DIEMTHU,LOAIBN,LOAI,QUYENSO,SOBIENLAI,NGAY,MAKP,SOTIEN,TAMUNG,MIEN,";
                  sql+="BHYT,NOPTHEM,THIEU,VATTU,LANIN,IDTONGHOP,CHENHLECH,THUA,KETOAN,QUYENSODV,SOBIENLAIDV,BHYTGHICHU,";
                  sql+="USERID,USERIDNL,MIENCS,MIENDV,MIENCS_NGAYTT,NGAYUD,SOPHIEU,QUYENSOQUYETTOAN,KHAMBENH,THUOC,MAU,";
                  sql += " XETNGHIEM,CDHA,DVKTTHUONG,DVKTCAO,VTTH,CPVC,TDCN,GIUONG,KHAC,TILEHUONG,TILETHE,THUOCK,UBNDTRA,VTYTTL) values ";
                  sql += "  ({ID},{DIEMTHU},{LOAIBN},{LOAI},{QUYENSO},{SOBIENLAI},{NGAY},{MAKP},{SOTIEN},{TAMUNG},{MIEN},";
                  sql+="{BHYT},{NOPTHEM},{THIEU},{VATTU},{LANIN},{IDTONGHOP},{CHENHLECH},{THUA},{KETOAN},{QUYENSODV},{SOBIENLAIDV},{BHYTGHICHU},";
                  sql += "{USERID},{USERIDNL},{MIENCS},{MIENDV},{MIENCS_NGAYTT},{NGAYUD},{SOPHIEU},{QUYENSOQUYETTOAN},{KHAMBENH},{THUOC},{MAU},";
                  sql+="{XETNGHIEM},{CDHA},{DVKTTHUONG},{DVKTCAO},{VTTH},{CPVC},{TDCN},{GIUONG},{KHAC},{TILEHUONG},{TILETHE},{THUOCK},{UBNDTRA},{VTYTTL})";

                    sql=sql.Replace("{ID}",obj.ID.ToString());
                    sql=sql.Replace("{DIEMTHU}",obj.DIEMTHU.ToString());
                    sql=sql.Replace("{LOAIBN}",obj.LOAIBN.ToString());
                    sql=sql.Replace("{LOAI}",obj.LOAI.ToString());
                    sql=sql.Replace("{QUYENSO}",obj.QUYENSO.ToString());
                    sql=sql.Replace("{SOBIENLAI}",obj.SOBIENLAI.ToString());
                    sql = sql.Replace("{NGAY}", m_format.f_formatdata(obj.NGAY.ToString(),"date"));
                    sql = sql.Replace("{MAKP}", m_format.f_formatdata(obj.MAKP.ToString()));
                    sql=sql.Replace("{SOTIEN}",obj.SOTIEN.ToString());
                    sql=sql.Replace("{TAMUNG}",obj.TAMUNG.ToString());
                    sql=sql.Replace("{MIEN}",obj.MIEN.ToString());

                    sql=sql.Replace("{BHYT}",obj.BHYT.ToString());
                    sql = sql.Replace("{UBNDTRA}", obj.UBNDTRA.ToString());
                    sql=sql.Replace("{NOPTHEM}",obj.NOPTHEM.ToString());
                    sql=sql.Replace("{THIEU}",obj.THIEU.ToString());
                    sql=sql.Replace("{VATTU}",obj.VATTU.ToString());
                    sql=sql.Replace("{LANIN}",obj.LANIN.ToString());
                    sql=sql.Replace("{IDTONGHOP}",obj.IDTONGHOP.ToString());
                    sql=sql.Replace("{CHENHLECH}",obj.CHENHLECH.ToString());
                    sql=sql.Replace("{THUA}",obj.THUA.ToString());
                    sql=sql.Replace("{KETOAN}",obj.KETOAN.ToString());
                    sql=sql.Replace("{QUYENSODV}",obj.QUYENSODV.ToString());
                    sql=sql.Replace("{SOBIENLAIDV}",obj.SOBIENLAIDV.ToString());
                    sql=sql.Replace("{BHYTGHICHU}",m_format.f_formatdata(obj.BHYTGHICHU.ToString()));
                    sql=sql.Replace("{USERID}",obj.USERID.ToString());
                    sql=sql.Replace("{USERIDNL}",obj.USERIDNL.ToString());
                    sql=sql.Replace("{MIENCS}",obj.MIENCS.ToString());
                    sql=sql.Replace("{MIENDV}",obj.MIENDV.ToString());
                    sql=sql.Replace("{MIENCS_NGAYTT}",m_format.f_formatdata(obj.MIENCS_NGAYTT.ToString(),"date"));
                    sql = sql.Replace("{NGAYUD}", m_format.f_formatdata(obj.NGAYUD.ToString(), "date"));
                    sql=sql.Replace("{SOPHIEU}",obj.SOPHIEU.ToString());
                    sql=sql.Replace("{QUYENSOQUYETTOAN}",obj.QUYENSOQUYETTOAN.ToString());
                    sql=sql.Replace("{KHAMBENH}",obj.KHAMBENH.ToString());
                    sql=sql.Replace("{THUOC}",obj.THUOC.ToString());
                    sql=sql.Replace("{MAU}",obj.MAU.ToString());
                    sql=sql.Replace("{XETNGHIEM}",obj.XETNGHIEM.ToString());
                    sql=sql.Replace("{CDHA}",obj.CDHA.ToString());
                    sql=sql.Replace("{DVKTTHUONG}",obj.DVKTTHUONG.ToString());
                    sql=sql.Replace("{DVKTCAO}",obj.DVKTCAO.ToString());
                    sql=sql.Replace("{VTTH}",obj.VTTH.ToString());
                    sql=sql.Replace("{CPVC}",obj.CPVC.ToString());
                    sql=sql.Replace("{TDCN}",obj.TDCN.ToString());
                    sql=sql.Replace("{GIUONG}",obj.GIUONG.ToString());
                    sql=sql.Replace("{KHAC}",obj.KHAC.ToString());
                    sql = sql.Replace("{TILETHE}", obj.TILETHE.ToString());
                    sql = sql.Replace("{TILEHUONG}", obj.TILEHUONG.ToString());
                    sql = sql.Replace("{THUOCK}", obj.THUOCK.ToString());
                    sql = sql.Replace("{VTYTTL}", obj.VTYTTL.ToString());

                  
                  
                   // string id1 = OraData.f_get_capid(userid);
                    result = OracleData.f_execute_data(sql);

              
    
                }catch 
                {
    
                }
                return result;
        }
          public int f_update(v_bhytll obj)
        {
            int result = 0;
            try
            {



                string userid = AccessData.m_userid;

                sql = "update " + schema + ".e_bhytll ";
                sql += " set  SOPHIEU={SOPHIEU},UBNDTRA={UBNDTRA} ";
                
                sql += " where id={ID} ";


                sql = sql.Replace("{ID}", obj.ID.ToString());
                sql = sql.Replace("{SOPHIEU}", m_format.f_formatdata(obj.SOPHIEU));
                sql = sql.Replace("{UBNDTRA}", obj.UBNDTRA.ToString());
                



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
                sql = "delete " + schema + ".e_bhytll where id={id} ";
                sql = sql.Replace("{id}", id.ToString());
                 result = OracleData.f_execute_data(sql);



            }
            catch
            {

            }
            return result;
        }
        public int f_getsophieu()
        {
            int result = 0;
            try
            {

                string userid = AccessData.m_userid;
                result = f_sophieu();
                sql = "update " + schema + ".e_sophieu ";
                sql += " set  SOPHIEU=SOPHIEU+1";
                sql += " where id=1 ";
                OracleData.f_execute_data(sql);

            }
            catch
            {

            }
            return result;
        }
        private int f_sophieu()
        {
            int result = 0;
            try
            {                

                sql = "SELECT  MAX(SOPHIEU) FROM " + schema + ".e_sophieu ";
                
                result = int.Parse(OracleData.get_data(sql).Tables[0].Rows[0][0].ToString());

            }
            catch
            {

            }
            return result;
        }

    }
}
