using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;

namespace DataOracle
{
    public class Thekho_Oracle
    {
        #region khai bao bien
        AccessData OracleData;
        private string schema = AccessData.schema;
        DataSet ds;
        string sql = "";
        #endregion
        public Thekho_Oracle()
        {
            OracleData = new AccessData(); 
        }
        public DataTable f_getTheKho(DateTime solieuthang,DateTime tungay,DateTime denngay,string s_mabd)
        {
            DataTable dt_result=new DataTable();
            try
            {
                sql = " select ngayduyetdk,so sophieukhoa,ten,tenhc,tenkp,tenphieu,sum(slthuc) soluong from (";
                sql+="	select  spk.so,a.id,to_char(a.ngayud,'dd/mm/yyyy')ngayud,to_char(c.ngay,'dd/mm/yyyy') ngaydutru,to_char(nd.ngay,'dd/mm/yyyy') ngayduyetdk,	";
                sql+="	c.phieu,a.mabn,bn.hoten,bn.namsinh,b.makho,b.mabd,d.ten,d.hamluong,d.tenhc,d.dang, b.slyeucau,B.SLTHUC SLTHUC,TO_CHAR(e.ten) tenphieu,dkp.ten tenkp	";
                sql+="	from {database}.d_dutrull a	";
                sql+="	inner join {database}.d_dutruct b on a.id= b.id	";
                sql+="	inner join {database}.d_duyet c on a.idduyet=c.id	";
                sql+="	inner join {database}.d_ngayduyet nd on a.id=nd.idduyet 	";
                sql+="	inner join medibv115.d_sophieukhoa spk on spk.loai=nd.loai 	";
                sql+="	and spk.makp=nd.makp and spk.phieu=nd.phieu and spk.makho= b.makho	";
                sql+="	and to_char(nd.ngay,'dd/mm/yyyy')=to_char(spk.ngay,'dd/mm/yyyy') and spk.nhom=nd.nhom	";
                sql+="	inner join medibv115.d_loaiphieu e on e.id=c.phieu	";
                sql+="	inner join d_dmbd d on b.mabd=d.id	";
                sql+="	left join d_duockp dkp on dkp.id=nd.makp	";
                sql+="	left join btdbn bn on a.mabn=bn.mabn	";
                sql+="	where   b.mabd={s_mabd}  and c.done>0 and b.makho=2	";
                sql+="	union 	";
                sql += "	select  spk.so,a.id,to_char(a.ngayud,'dd/mm/yyyy')ngayud,to_char(c.ngay,'dd/mm/yyyy') ngaydutru,to_char(nd.ngay,'dd/mm/yyyy') ngayduyetdk,	";
                sql += "	c.phieu,a.mabn,bn.hoten,bn.namsinh,b.makho,b.mabd,d.ten,d.hamluong,d.tenhc,d.dang, b.slyeucau,B.SLTHUC SLTHUC,TO_CHAR(e.ten) tenphieu,dkp.ten tenkp	";
                sql += "	from {database}.d_hoantrall a	";
                sql += "	inner join {database}.d_hoantract b on a.id= b.id	";
                sql += "	inner join {database}.d_duyet c on a.idduyet=c.id	";
                sql += "	inner join {database}.d_ngayduyet nd on a.id=nd.idduyet 	";
                sql += "	inner join medibv115.d_sophieukhoa spk on spk.loai=nd.loai 	";
                sql += "	and spk.makp=nd.makp and spk.phieu=nd.phieu and spk.makho= b.makho	";
                sql += "	and to_char(nd.ngay,'dd/mm/yyyy')=to_char(spk.ngay,'dd/mm/yyyy') and spk.nhom=nd.nhom	";
                sql += "	inner join medibv115.d_loaiphieu e on e.id=c.phieu	";
                sql += "	inner join d_dmbd d on b.mabd=d.id	";
                sql += "	left join d_duockp dkp on dkp.id=nd.makp	";
                sql += "	left join btdbn bn on a.mabn=bn.mabn	";
                sql += "	where   b.mabd={s_mabd}  and c.done>0 and b.makho=2	";
                sql += "	union 	";
                sql+="	select  spk.so,c.id,to_char(a.ngayud,'dd/mm/yyyy')ngayud,to_char(c.ngay,'dd/mm/yyyy') ngaydutru,to_char(nd.ngay,'dd/mm/yyyy') ngayduyetdk,	";
                sql+="	c.phieu,a.mabn,bn.hoten,bn.namsinh,b.makho,b.mabd,d.ten,d.hamluong,d.tenhc,d.dang, b.slyeucau,B.SLTHUC SLTHUC,TO_CHAR(e.ten) tenphieu,dkp.ten tenkp	";
                sql+="	from {database}.d_xtutrucll a	";
                sql+="	inner join {database}.d_xtutrucct b on a.id= b.id	";
                sql+="	inner join {database}.d_duyet c on a.idduyet=c.id	";
                sql+="	inner join {database}.d_ngayduyet nd on a.id=nd.idduyet 	";
                sql+="	inner join medibv115.d_sophieukhoa spk on spk.loai=nd.loai 	";
                sql+="	and spk.makp=nd.makp and spk.phieu=nd.phieu and spk.makho= b.makho	";
                sql+="	and to_char(nd.ngay,'dd/mm/yyyy')=to_char(spk.ngay,'dd/mm/yyyy') and spk.nhom=nd.nhom	";
                sql+="	inner join medibv115.d_loaiphieu e on e.id=c.phieu	";
                sql+="	inner join d_dmbd d on b.mabd=d.id	";
                sql+="	left join d_duockp dkp on dkp.id=nd.makp	";
                sql+="	left join btdbn bn on a.mabn=bn.mabn	";
                sql+="	where   b.mabd={s_mabd} and c.done>0 and b.makho=2	";
                sql+="	union all	";
                sql+="	select  a.sotoa,a.id,to_char(a.ngayud,'dd/mm/yyyy')ngayud,to_char(a.ngay,'dd/mm/yyyy')  ngaydutru,to_char(a.ngay,'dd/mm/yyyy') ngayduyet,	";
                sql+="	a.SOTOA,a.mabn,bn.hoten,bn.namsinh,b.makho,b.mabd,d.ten,d.hamluong,d.tenhc,d.dang, b.SOLUONG slyeucau,b.SOLUONG slthuc,to_char('PHIEU XUAT') tenphieu,dkp.tenKP tenkp	";
                sql+="	from {database}.bhytkb a	";
                sql+="	inner join {database}.bhytthuoc b on a.id= b.id	";
                sql+="	inner join d_dmbd d on b.mabd=d.id	";
                sql+="	left join btdkp_bv dkp on dkp.MAKP=A.makp	";
                sql+="	left join btdbn bn on a.mabn=bn.mabn	";
                sql+="	where   b.mabd={s_mabd}  and b.makho=2	";
                sql+= " ) where SUBSTR(ngayduyetdk,0,2) BETWEEN '{s_tungay}' AND '{s_denngay}' group by ngayduyetdk,so,ten,tenhc,tenkp,tenphieu ";
                sql = sql.Replace("{database}", m_format.getdatabase(solieuthang));

                sql = sql.Replace("{s_tungay}",tungay.ToString("dd/MM/yyyy").Substring(0,2));
                sql = sql.Replace("{s_denngay}", denngay.ToString("dd/MM/yyyy").Substring(0, 2));
                sql = sql.Replace("{s_mabd}", s_mabd);
                ds = OracleData.get_data(sql);
                dt_result = ds.Tables[0];
            }
            catch { }
            return dt_result;

        }
        
      
      

    }
}
