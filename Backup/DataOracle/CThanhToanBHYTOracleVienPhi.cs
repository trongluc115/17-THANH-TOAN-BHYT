using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
using DataUpdate;
namespace DataOracle
{
    public class CThanhToanBHYTOracleVienPhi
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData data;
        DataSet ds;
        string sql = "";
        private string schema = CConnection_Oracle.schema;
        #endregion
      
        #region phuong thuc
        public CThanhToanBHYTOracleVienPhi()
        {
            thanhtoanbhyt = new CThanhToanBHYT();
            data = new AccessData();
            ds = new DataSet();
        }
        private long f_getTongTien(long IDTTRV)
        {
            long result = 0;
            sql = "select * from medibv115";
            try
            {
                ds = data.get_data(sql);
                result = long.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch { result = 0; }
            return result;
        }
        public DataTable f_getHoaDon(DateTime ngay,string mabn)
        {
            DataTable table = new DataTable();
            sql = "select a.id idttrv,to_char(a.ngayvao,'dd/mm/yyyy hh:mi')||'-'||to_char(a.ngayra,'dd/mm/yyyy hh:mi') dotdieutri ";
            sql += " from {userdata}.v_ttrvds a";
            sql += " inner join {userdata}.v_ttrvll b on a.id=b.id ";
            sql += " where a.mabn='{mabn}'";
            
            sql = sql.Replace("{userdata}",m_format.getdatabase(ngay));
            sql = sql.Replace("{mabn}", mabn);
            try
            {
                ds = data.get_data(sql);
                table = ds.Tables[0];
            }
            catch { }
            return table;
        }


        public DataTable f_getv_ttrvkp_ct_ALL_FROMVP(string MaBN, string idttrv, DateTime TuNgay,  string loai)
        {

            
            string sqlcp;
            sqlcp=" select MAVP,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,bhyttra BHYTTRA,0 BNTRA,MADOITUONG,NGAY,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT ,0 THUOCK,IDKTCAO ";
            sqlcp += " from (";
            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, ct.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,ct.soluong,   ct.dongia  dongia ,vp.bhyt,vp.kythuat,2 tinhtong , to_char(nhom.idnhombhyt)idnhombhyt,0 idktcao,ct.bhyttra bhyttra";
            sqlcp += "           from {datauser}.v_ttrvds ds  ";
            sqlcp += "           join {datauser}.v_ttrvll ll on ds.id=ll.id     ";
            sqlcp += "           join {datauser}.v_ttrvct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.v_giavp vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where ct.madoituong=1 and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.id={idttrv}";
            sqlcp += "           union all ";

            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, ct.madoituong  madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dang) DVT,ct.soluong,  ct.dongia dongia,vp.bhyt,vp.kythuat,2 tinhtong , to_char(nhom.idnhombhyt)  idnhombhyt,0 idktcao,ct.bhyttra bhyttra";
            sqlcp += "           from {datauser}.v_ttrvds ds  ";
            sqlcp += "           join {datauser}.v_ttrvll ll on ds.id=ll.id     ";
            sqlcp += "           join {datauser}.v_ttrvct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.d_dmbd vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on nhomd.nhomvp=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where ct.madoituong=1  and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.id={idttrv}";
            sqlcp += " ) kq";
            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("{idttrv}", idttrv);
            sqlcp = sqlcp.Replace("{datauser}", m_format.getdatabase(TuNgay));
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            

           


           
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sqlcp);

            }
            catch { }
            return dset.Tables[0];
        }
        public DataTable f_getv_ttrvkp_ct_ALL_FROMVPKTC(string MaBN, string idttrv, DateTime TuNgay, string loai)
        {


            string sqlcp;
            sqlcp = " select MAVP,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,bhyttra BHYTTRA,0 BNTRA,MADOITUONG,NGAY,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT ,0 THUOCK,IDKTCAO ";
            sqlcp += " from (";
            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, ct.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,ct.soluong, case when ct.gia_bh>0 then ct.gia_bh else ct.dongia end dongia ,vp.bhyt,vp.kythuat,2 tinhtong ,case when ct.id_ktcao>0 then '6' else to_char(nhom.idnhombhyt) end idnhombhyt,ct.id_ktcao idktcao,ct.bhyttra bhyttra";
            sqlcp += "           from {datauser}.v_ttrvds ds  ";
            sqlcp += "           join {datauser}.v_ttrvll ll on ds.id=ll.id     ";
            sqlcp += "           join {datauser}.v_ttrvct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.v_giavp vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where (ct.madoituong=1 or (ct.madoituong in (5,2) and ct.id_ktcao>0)) and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.id={idttrv}";
            sqlcp += "           union all ";

            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, case when ct.id_ktcao>0 and ct.madoituong=2 then 5 else ct.madoituong end madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dang) DVT,ct.soluong, case when ct.gia_bh>0 then ct.gia_bh else ct.dongia end dongia,vp.bhyt,vp.kythuat,2 tinhtong ,case when ct.id_ktcao>0 then '14' else to_char(nhom.idnhombhyt) end idnhombhyt,ct.id_ktcao idktcao,ct.bhyttra bhyttra";
            sqlcp += "           from {datauser}.v_ttrvds ds  ";
            sqlcp += "           join {datauser}.v_ttrvll ll on ds.id=ll.id     ";
            sqlcp += "           join {datauser}.v_ttrvct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.d_dmbd vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on nhomd.nhomvp=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where (ct.madoituong=1 or (ct.id_ktcao>0 and ct.madoituong=2  and ct.gia_bh<>ct.dongia) or (ct.madoituong=5 and ct.id_ktcao>0)) and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.id={idttrv}";
            sqlcp += " ) kq";
            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("{idttrv}", idttrv);
            sqlcp = sqlcp.Replace("{datauser}", m_format.getdatabase(TuNgay));
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));






            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sqlcp);

            }
            catch { }
            return dset.Tables[0];
        }



        public DataTable f_getv_ttrvkp_ct_ALL_FROMVPedit(string MaBN, string idttrv, DateTime TuNgay, string loai,string sophieu)
        {


            string sqlcp;
            sqlcp = " select MAVP,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,0 BHYTTRA,0 BNTRA,MADOITUONG,NGAY,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT  ";
            sqlcp += " from (";
            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, ct.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,ct.soluong,ct.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,to_char(nhom.idnhombhyt) idnhombhyt";
            sqlcp += "           from " + schema + ".v_bhytds ds  ";
            sqlcp += "           join " + schema + ".v_bhytll ll on ds.id=ll.id     ";
            sqlcp += "           join " + schema + ".v_bhytct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.v_giavp vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where ct.madoituong=1 and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.mabn='{mabn}' and ll.sophieu='{sophieu}'";
            sqlcp += "           union all ";

            sqlcp += "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(ct.id) idkhoa, ct.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dang) DVT,ct.soluong,ct.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,to_char(nhom.idnhombhyt) idnhombhyt";
            sqlcp += "           from " + schema + ".v_bhytds ds  ";
            sqlcp += "           join " + schema + ".v_bhytll ll on ds.id=ll.id     ";
            sqlcp += "           join " + schema + ".v_bhytct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.d_dmbd vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on nhomd.nhomvp=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on ct.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where ct.madoituong=1 and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and ds.mabn='{mabn}' and  ll.sophieu='{sophieu}' ";
            sqlcp += " ) kq";
            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("{idttrv}", idttrv);
            sqlcp = sqlcp.Replace("{datauser}", m_format.getdatabase(TuNgay));
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("{mabn}", MaBN);
            sqlcp = sqlcp.Replace("{sophieu}", sophieu);






            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sqlcp);

            }
            catch { }
            return dset.Tables[0];
        }
       
        
        private string f_getsqlchiphi(string sqlcp,string mavaovien, DateTime TuNgay, DateTime DenNgay)
        {
            
            string sqlGroup;
            try
            {
                DateTime dt1 = TuNgay;
                DateTime dt2 = DenNgay;
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int itu, iden;
                string mmyy = "";
                string str = sqlcp;
                string asql = "";
                bool be = true;
                sqlGroup =" select MAVAOVIEN,MABN,MAKP,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,sum(SOLUONG) SOLUONG,DONGIA DONGIA,BHYT,KYTHUAT,sum(kq.soluong*kq.dongia) TONGTIEN, TINHTONG  ";
                            
                sqlGroup += "           from ";
                sqlGroup += "           ( ";

                for (int i = y1; i <= y2; i++)
                {
                    itu = (i == y1) ? m1 : 1;
                    iden = (i == y2) ? m2 : 12;
                    for (int j = itu; j <= iden; j++)
                    {
                        mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                        if (data.bMmyy(mmyy))
                        {

                            asql = str.Replace("{data_user}", "medibv115" + mmyy);
                            if (be)
                            {
                                sqlGroup += asql;
                                be = false;
                            }
                            else
                            {
                                sqlGroup += " union all " + asql;
                            }
                        }
                    }
                }
                sql += "           union all ";
                sql += "            select cd.mavaovien,cd.mabn,to_char(cd.makp) MAKP,cd.idkhoa,kp.tenkp , cd.madoituong, cd.ngay, ";
                sql += "            -2   sttnhom,  'Dịch vu kỹ thuật cao chi phí lớn' nhom,-1 MAVP,to_char(cd.ghichu_vn) ten,'Lần' dvt,cd.soluong,cd.dongia,100 bhyt,0 kythuat,2 tinhtong  ";
                sql += "            from medibv115.bv_chidinhktc cd  ";
                sql += "            join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
                
                sqlGroup += sql +"           ) kq ";
                sqlGroup += "           where mavaovien={ma_vao_vien} and madoituong<>5 ";
                sqlGroup += "           group by MAVAOVIEN,MABN,MAKP,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,DONGIA,BHYT,KYTHUAT,TINHTONG ";
                sqlGroup = sqlGroup.Replace("{ma_vao_vien}", mavaovien);

            }
            catch (Exception ex)
            {
                return "";

            }
            return sqlGroup;
        }
        
        
        
        
        private string addString(string chuoigoc, string chuoiadd)
        {
            string result = chuoigoc;
            try
            {
                if (chuoigoc.IndexOf(chuoiadd, 0) < 0)
                {
                    result = chuoigoc + ";" + chuoiadd;
                }
            }
            catch { }
            return result;
        }
        public CThanhToanBHYT f_loadTT_BHYT(string idttrv, DateTime Ngay)
        {


            sql = "select ds.id idtt,ds.maql,bh.sothe,bh.mabv,nc.tenbv,bh.ngay HSD,bh.tungay,bh.traituyen,ll.sobienlai,ll.loaibn ,ds.mavaovien MAVAOVIEN ";

            sql += " from {datauser}.v_ttrvds ds ";
            sql += " join {datauser}.v_ttrvbhyt bh on ds.id=bh.id ";
            sql += " join dmnoicapbhyt nc on nc.mabv=bh.mabv ";
            sql += " join {datauser}.v_ttrvll ll on ll.id=ds.id ";
            sql += " where   ll.bhyt>0 and   ds.id='{idttrv}'";
                       

            sql = sql.Replace("{datauser}", m_format.getdatabase(Ngay));
            sql = sql.Replace("{idttrv}", idttrv);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                int irow = dset.Tables[0].Rows.Count - 1;
                thanhtoanbhyt.SoTheBHYT = dset.Tables[0].Rows[irow]["SOTHE"].ToString();
                thanhtoanbhyt.MaBV = dset.Tables[0].Rows[irow]["MABV"].ToString();
                thanhtoanbhyt.NoiDangKyBHYT = dset.Tables[0].Rows[irow]["TENBV"].ToString();
                thanhtoanbhyt.TraiTuyen = int.Parse(dset.Tables[0].Rows[irow]["TRAITUYEN"].ToString());
                thanhtoanbhyt.HSD = DateTime.Parse(dset.Tables[0].Rows[irow]["HSD"].ToString());
                thanhtoanbhyt.TuNgay = DateTime.Parse(dset.Tables[0].Rows[irow]["TUNGAY"].ToString());
                thanhtoanbhyt.LoaiBA = dset.Tables[0].Rows[irow]["LOAIBN"].ToString();
                thanhtoanbhyt.SoBienLai = dset.Tables[0].Rows[irow]["SOBIENLAI"].ToString();
                thanhtoanbhyt.MaQuanLy = dset.Tables[0].Rows[irow]["MAQL"].ToString();
                thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[irow]["IDTT"].ToString());
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[irow]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.Macn = f_getMaCN(thanhtoanbhyt.MaQuanLy, Ngay);
            }
            catch { }

            return thanhtoanbhyt;
        }
        public CThanhToanBHYT f_loadTT_BHYT_Edit(string mabn,string sophieu)
        {


            sql = "select ds.maql,ds.sothe,ds.mabv,to_char(ds.tungay,'dd/mm/yyyy') tungay,to_char(ds.denngay,'dd/mm/yyyy') denngay ";
            sql+= " ,ds.traituyen,ll.sobienlai,ll.loaibn ,ds.mavaovien MAVAOVIEN,DS.MACN ";
            sql += " ,ds.maicd,ds.chandoan,TO_CHAR(DS.NGAYVAO,'DD/MM/YYYY HH24:mi') NGAYVAO";
            sql += " ,TO_CHAR(DS.NGAYRA,'DD/MM/YYYY HH24:mi') NGAYRA, ds.makp makp,ll.ubndtra ubndtra ";
            sql += " from "+schema+".v_bhytds ds ";
            sql += " inner join " + schema + ".v_bhytll ll on ds.id=ll.id ";
            sql += " where   ds.mabn='{mabn}' and   ll.sophieu='{sophieu}'";
           
            sql = sql.Replace("{mabn}",mabn);
            sql = sql.Replace("{sophieu}", sophieu);
            

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                int irow = dset.Tables[0].Rows.Count - 1;
                thanhtoanbhyt.SoTheBHYT = dset.Tables[0].Rows[irow]["SOTHE"].ToString();
                thanhtoanbhyt.MaBV = dset.Tables[0].Rows[irow]["MABV"].ToString();
                //thanhtoanbhyt.NoiDangKyBHYT = dset.Tables[0].Rows[irow]["TENBV"].ToString();
                thanhtoanbhyt.TraiTuyen = int.Parse(dset.Tables[0].Rows[irow]["TRAITUYEN"].ToString());
                thanhtoanbhyt.HSD = m_format.DateTime_parse(dset.Tables[0].Rows[irow]["DENNGAY"].ToString());
                thanhtoanbhyt.TuNgay = m_format.DateTime_parse(dset.Tables[0].Rows[irow]["TUNGAY"].ToString());
                thanhtoanbhyt.LoaiBA = dset.Tables[0].Rows[irow]["LOAIBN"].ToString();
                thanhtoanbhyt.SoBienLai = dset.Tables[0].Rows[irow]["SOBIENLAI"].ToString();
                thanhtoanbhyt.MaQuanLy = dset.Tables[0].Rows[irow]["MAQL"].ToString();
                //thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[irow]["IDTT"].ToString());
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[irow]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.Macn = dset.Tables[0].Rows[irow]["MACN"].ToString();
                thanhtoanbhyt.ICD = dset.Tables[0].Rows[irow]["MAICD"].ToString();
                thanhtoanbhyt.ChanDoan = dset.Tables[0].Rows[irow]["CHANDOAN"].ToString();
                thanhtoanbhyt.NgayVao = m_format.DateTime_parse_HHmm(dset.Tables[0].Rows[irow]["NGAYVAO"].ToString());
                thanhtoanbhyt.NgayRa = m_format.DateTime_parse_HHmm(dset.Tables[0].Rows[irow]["NGAYRA"].ToString());
                thanhtoanbhyt.Makp = dset.Tables[0].Rows[irow]["MAKP"].ToString();
                thanhtoanbhyt.Ubndtra =long.Parse( dset.Tables[0].Rows[irow]["UBNDTRA"].ToString());
            }
            catch { }

            return thanhtoanbhyt;
        }
        public string f_getMaCN(string MaQL, DateTime Ngay)
        {


            string result = "";

            sql = " select bh.macn MACN";
            sql += " from bhyt bh ";
            sql += " where     bh.MaQL={MaQL} and bh.macn is not null";
            sql += " union ";
            sql += " select bh.macn MACN";
            sql += " from {userdata}.bhyt bh ";
            sql += " where     bh.MaQL={MaQL} and bh.macn is not null";


            sql = sql.Replace("userdata", m_format.getdatabase(Ngay));
            sql = sql.Replace("{MaQL}", MaQL);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                int irow = dset.Tables[0].Rows.Count - 1;

                result = dset.Tables[0].Rows[irow]["MACN"].ToString();
            }
            catch { }

            return result;
        }
        public string f_loadChanDoanFull(string idttrv, DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";
          
            sql = " select chandoan||'_'||maicd chandoan,0 stt ";
            sql += " from {userdata}.v_ttrvds ";
            sql += " where id='{idttrv}' and  maicd is not null";
         
           
            sql = sql.Replace("{userdata}", m_format.getdatabase(Ngay));
            sql = sql.Replace("{idttrv}", idttrv);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    string chandoan = row[0].ToString();
                    ChanDoan = addString(ChanDoan, chandoan);
                   
                }

            }
            catch { }


            return ChanDoan;
        }
        public CThanhToanBHYT f_loadKhoaPhong_UBNDTra(string idttrv, DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";
            CThanhToanBHYT obj=new CThanhToanBHYT();
            sql = " select b.makp makp,round(b.miencs,0) miencs";
            sql += " from {userdata}.v_ttrvll  b";
            sql += " where b.id='{idttrv}' ";


            sql = sql.Replace("{userdata}", m_format.getdatabase(Ngay));
            sql = sql.Replace("{idttrv}", idttrv);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                obj.Makp = dset.Tables[0].Rows[0]["makp"].ToString();
                obj.Ubndtra =long.Parse( dset.Tables[0].Rows[0]["miencs"].ToString());
                

            }
            catch { }


            return obj;
        }
        public string f_loadICDFull(string idttrv, DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";

            sql = " select maicd chandoan,0 stt ";
            sql += " from {userdata}.v_ttrvds ";
            sql += " where id='{idttrv}' and  maicd is not null";


            sql = sql.Replace("{userdata}", m_format.getdatabase(Ngay));
            sql = sql.Replace("{idttrv}", idttrv);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    string chandoan = row[0].ToString();
                    ChanDoan = addString(ChanDoan, chandoan);

                }

            }
            catch { }


            return ChanDoan;
        }

        #endregion
    }
}
