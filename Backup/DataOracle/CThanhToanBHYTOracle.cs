using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
namespace DataOracle
{
    public class CThanhToanBHYTOracle
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData data;
        DataSet ds;
        string sql = "";
        #endregion
        CThanhToanBHYT ThanhToanBHYT
        {
            get { return thanhtoanbhyt; }
        }
        #region phuong thuc
        public CThanhToanBHYTOracle()
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
        private string getdatabase(DateTime Ngay)
        {
            string database = "";
            try
            {
                database = "medibv115" + string.Format("{0:MMyy}", Ngay);
            }
            catch { }
            return database;
        }
        private string getdatabase(string ngay)
        {
            string database = "";
            try
            {
               
                database = "medibv115" + ngay.Substring(3, 2)+ngay.Substring(8, 2);
            }
            catch { }
            return database;
        }
        private string getFormatDDMMYYYY(DateTime Ngay)
        {
            string database = "";
            try
            {
                database =  string.Format("{0:ddMMyy}", Ngay);
            }
            catch { }
            return database;
        }
        public DataSet f_loadVienPhiChiTiet(string MaBN,DateTime Ngay,bool loadBHYT)
        {
            if(loadBHYT)
                       sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where b.madoituong=1 and c.id_loai=l.id and vl.id=a.id and vl.loaibn=3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            else
                       sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where  c.id_loai=l.id and vl.id=a.id and vl.loaibn=3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadChiDinh(string MaBN, DateTime Ngay )
        {

            sql = "select c.ten||' ( SL:'||a.soluong||') - K/P:'||kp.tenkp tenvp,a.mavp id  from xxxxx.v_chidinh a,v_giavp c,btdkp_bv kp where c.id=a.mavp and a.makp=kp.makp and a.mabn='" + MaBN + "' and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";


            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadChiDinh_v_chidinh(string MaBN, DateTime Ngay)
        {

            sql = "select 0,a.mavp mavp,c.ten tenvp,a.soluong soluong,kp.tenkp tenkp,a.mabn MaBN,to_char(a.ngay,'dd/mm/yyyy') ngaycd,'-' ngayxoa,' ' nguoixoa,a.makp makp  from xxxxx.v_chidinh a,v_giavp c,btdkp_bv kp where c.id=a.mavp and a.makp=kp.makp and a.mabn='" + MaBN + "' and to_char(a.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";

            sql = "SELECT 0,v.id mavp,v.ten tenvp, TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,10)+1, INSTR(a.noidung,'^',1,10+1) - INSTR(a.noidung,'^',1,10)-1 )) SOLUONG,c.tenkp tenkp,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 )) MABN,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,25)+1, INSTR(a.noidung,'^',1,25+1) - INSTR(a.noidung,'^',1,25)-1 )) NGAY_CHI_DINH,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) NGAY_XOA,b.hoten nguoixoa,c.makp makp ";
            sql += " FROM xxxxx.eve_upd_del a,dlogin b,btdkp_bv c,v_giavp v ";
            sql += " WHERE  a.TABLEID=42 and  a.command='del' and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 ))='" + MaBN + "' ";
            sql += " and a.userid=b.id and c.makp=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,7)+1, INSTR(a.noidung,'^',1,7+1) - INSTR(a.noidung,'^',1,7)-1 )) and v.id=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) AND TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,8)+1, INSTR(a.noidung,'^',1,8+1) - INSTR(a.noidung,'^',1,8)-1 ))  not in ('9') and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) in (select cc.id from v_nhomvp aa,v_loaivp bb,v_giavp cc where aa.ma in (5,6,15) and aa.ma=bb.id_nhom and cc.id_loai=bb.id) and ";
            sql += " TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) like  '%" + string.Format("{0:dd/MM/yyyy}", Ngay) + "%' ";


            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public int f_loadTongTien_v_chidinh(string MaBN, DateTime Ngay)
        {

            sql = "select sum(a.soluong *a.dongia) sotien  from xxxxx.v_chidinh a where  a.mabn='" + MaBN + "' and to_char(a.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and a.madoituong=1 and idkhoa=0";
            int kq = 0;
           

            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                kq=int.Parse(dset.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            return kq;
        }
        public string f_gettamung( string mavaovien, DateTime TuNgay, DateTime DenNgay)
        {
            string tongtamung = "";
            try
            {
                DateTime dt1 = TuNgay;
                DateTime dt2 = DenNgay;
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int itu, iden;
                string mmyy = "";
                string str = " SELECT MAVAOVIEN,SOTIEN  FROM {data_user}.V_TAMUNG WHERE mavaovien=" + mavaovien + " AND DONE=0  ";
                string asql = "";
                bool be = true;
                string sqlT_ung = " SELECT MAVAOVIEN,SUM(SOTIEN)TAMUNG FROM (";
               
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
                                sqlT_ung += asql;
                                be = false;
                            }
                            else
                            {
                                sqlT_ung += " union all " + asql;
                            }
                        }
                    }
                }
                sqlT_ung += " ) group by mavaovien ";
                DataSet ds_tung = data.get_data(sqlT_ung);
                tongtamung = ds_tung.Tables[0].Rows[0][1].ToString();

            }
            catch (Exception ex)
            {
                return "0";

            }
            return  tongtamung;
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
        public DataSet f_getv_ttrvkp_ct_from_bv115(string MaBN,string mavaovien, DateTime TuNgay,DateTime DenNgay)
        {

            string s_tam_ung = f_gettamung(mavaovien, TuNgay, DenNgay);
            string sqlcp = "";

            sql =" select 1 DONE,ba.LOAIBA LOAIBA,ba.MADOITUONG MADOITUONGVAO, 0 MATT,ba.mabn MABN,ba.mavaovien MAVAOVIEN,ba.maql MAQL, 0 IDKHOA, ";
            sql+=" bn.hoten HOTEN,bn.namsinh NAMSINH, TO_CHAR(bn.phai) PHAI,  bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI ,  ";
            sql+=" cd.madoituong MADOITUONG,dt.doituong DOITUONG, bh.sothe SOTHE,bh.maphu MAPHU, ";
            sql+=" to_char(bh.tungay,'dd/mm/yyyy')||'^'||to_char(bh.denngay,'dd/mm/yyyy') DENNGAY,  '^' NOIGIOITHIEU, bh.mabv||'^'||ndk.tenbv NOICAP, ";
            sql+=" hd.giuong GIUONG,  to_char(cd.makp) MAKP,cd.tenkp TENKP,to_char(hd.ngayvv,'dd/mm/yyyy hh24:mi') NGAYVAO,to_char(hd.ngay,'dd/mm/yyyy hh24:mi') NGAYRA, ";
            sql+=" ba.chandoan || ';('||ba.MAICD||';)' CHANDOAN,ba.maicd MACID,cd.sttnhom STTNHOM ,cd.nhom NHOM,  case when cd.bhyt=100 then 1 else 2 end STTLOAI,  ";
            sql+=" case when cd.bhyt=100 then 'Trong danh mục BHYT' else 'Ngoài danh mục BHYT' end LOAI,  to_char(ba.ngay,'dd/mm/yyyy hh24:mi') NGAY,   ";
            sql+=" cd.mavp MA,cd.ten TEN,cd.DVT DVT,cd.soluong SOLUONG,cd.dongia DONGIA,cd.soluong*cd.dongia SOTIEN, {tam_ung} TAMUNG, ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra else 0 end BHYT,0 BHYT0117, ";
            sql+=" case when cd.madoituong='7' then cd.tongtien else 0 end TCSOTIEN,0 DICHSO,0 MIEN,  ";
            sql += " case when cd.madoituong=1 and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra*cd.soluong*cd.dongia/100 else 0 end BHYTTRA,  ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then (100-tl.bhyttra)*cd.soluong*cd.dongia/100 else cd.soluong*cd.dongia end BNTRA,0 DICHSOTRA,  ";
            sql+=" 0 SBLTAMUNG,ba.sovaovien SOLUUTRU,  '' NGUOINHA,1 PHUONGPHAP,1 HINHTHUC,'' KETQUA,'' KHU,'' NGAYPT,  0 TENPT,0	MASO,0	SOPHIEU, ";
            sql+=" 0	LANIN,''	Image,''	Imagetk,0	Imageuser,  bs.ma mabs,bs.hoten tenbs,kprv.tenkp makprv,'' cholam,0 gianovat, ";
            sql+=" 0 idttrv,0 sotientra,bh.traituyen traituyen,  cd.soluong*cd.dongia vattu,TO_CHAR(bh.ngay1) ngay1,TO_CHAR(bh.ngay2) ngay2,TO_CHAR(bh.ngay3) ngay3, ";
            sql+=" TO_CHAR(bh.ngaytrinh) ngaytrinh,bh.ngayduyet ngayduyet,cd.kythuat kythuat, cd.dongia m_gia_bhyt, ";
            sql+=" cd.dongia*cd.soluong m_thanhtien, ";
            sql += " case when cd.madoituong=1 and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra*cd.soluong*cd.dongia/100 else 0 end m_bhyt_tra, ";
            sql+=" case when cd.madoituong='2' then cd.tongtien else 0 end  m_benhnhan_thuphi, ";
            sql+=" case when cd.madoituong='7' then cd.tongtien else 0 end m_benhnhan_dichvu, ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then (100-tl.bhyttra)*cd.soluong*cd.dongia/100 else 0 end m_benhnhan_khac, 0  m_diengiai,  cd.tinhtong,	157500 m_giatranbhyt,'Khác'	lydocapcuu, ";
            sql+=" 0	thanhtoandot,''	tenhc           ";
            sql+=" from benhandt ba     ";
            sql+=" join btdbn bn on ba.mabn=bn.mabn      ";
            sql+=" join btdpxa px on bn.maphuongxa=px.maphuongxa    ";
            sql+=" join btdquan qu on bn.maqu=qu.maqu     ";
            sql+=" join btdtt tt on bn.matt=tt.matt    ";
            sql+=" join ( ";
            sql+="                 select MAVAOVIEN,MABN,MAKP,IDKHOA,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,sum(SOLUONG) SOLUONG,DONGIA,BHYT,KYTHUAT,sum(kq.soluong*kq.dongia) TONGTIEN, TINHTONG  ";
            sql+="           from ";
            sql += "           ( ";

            sql+="            select cd.mavaovien,cd.mabn,to_char(cd.makp) MAKP,cd.idkhoa,kp.tenkp , cd.madoituong, cd.ngay, ";
            sql+="            -2   sttnhom,  'Dịch vu kỹ thuật cao chi phí lớn' nhom,-1 MAVP,to_char(cd.ghichu_vn) ten,'Lần' dvt,cd.soluong,cd.dongia,100 bhyt,0 kythuat,2 tinhtong  ";
            sql+="            from medibv115.bv_chidinhktc cd  ";
            sql+="            join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
        

          
            sql+="           ) kq ";
            sql += "           where mabn={MABN} and madoituong<>5 ";
            sql+="           group by MAVAOVIEN,MABN,MAKP,IDKHOA,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,DONGIA,BHYT,KYTHUAT,TINHTONG ";
            sql+="  ";
            sql+="          ";
            sql+="               ) cd on ba.mavaovien=cd.mavaovien     ";
            sql+=" join doituong dt on cd.madoituong=dt.madoituong     ";
            sql+=" join bhyt bh on bh.maql=ba.maql     ";
            sql+=" join DMNOICAPBHYT  ndk on ndk.mabv=bh.mabv     ";
            sql+=" join hiendien hd on hd.mavaovien=ba.mavaovien     ";
            sql += " join bv_tilebhyt tl on tl.kytu=substr(bh.sothe,3,1) and bh.traituyen=tl.traituyen    ";
            sql+=" join dmbs bs on ba.mabs=bs.ma     ";
            sql+=" join btdkp_bv kprv on kprv.makp=hd.makp    ";
            sql += " where ba.mabn='{MABN}'  ";


            int kq = 0;
        
            sql = sql.Replace("{MABN}", MaBN);
            sql = sql.Replace("{tam_ung}",s_tam_ung);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_getv_ttrvkp_ct_ALL(string MaBN, string mavaovien, DateTime TuNgay, DateTime DenNgay)
        {

            string s_tam_ung = f_gettamung(mavaovien, TuNgay, DenNgay);
            string sqlcp =  "           select cd.mavaovien,cd.mabn,to_char(cd.makp) MAKP,cd.idkhoa,kp.tenkp , cd.madoituong, cd.ngay, case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,cd.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong ";
            sqlcp += "           from {data_user}.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp where cd.paid=0 and cd.mavp not in (select ktc.mavp from medibv115.bv_chidinhktc ktc where ktc.mavaovien=cd.mavaovien )";
            sqlcp += "           union all ";

           

            sqlcp += "           select cd.mavaovien,cd.mabn,to_char(kp.makp) MAKP,cd.idkhoa,kp.tenkp tenkp ,cd.madoituong, cd.ngay, case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sqlcp += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,round(cd.giamua,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ";
            sqlcp += "           from {data_user}.d_tienthuoc cd  ";
            sqlcp += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.d_duockp dkp on cd.makp=dkp.id ";
            sqlcp += "           join medibv115.btdkp_bv kp on dkp.makp=kp.makp ";
            string sqlgroup = f_getsqlchiphi(sqlcp, mavaovien, TuNgay, DenNgay);

            sql = " select 0 DONE,ba.LOAIBA LOAIBA,ba.MADOITUONG MADOITUONGVAO, 0 MATT,ba.mabn MABN,ba.mavaovien MAVAOVIEN,ba.maql MAQL, 0 IDKHOA, ";
            sql += " bn.hoten HOTEN,bn.namsinh NAMSINH, TO_CHAR(bn.phai) PHAI,  bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI ,  ";
            sql += " cd.madoituong MADOITUONG,dt.doituong DOITUONG, bh.sothe SOTHE,bh.maphu MAPHU, ";
            sql += " to_char(bh.tungay,'dd/mm/yyyy')||'^'||to_char(bh.denngay,'dd/mm/yyyy') DENNGAY,  '^' NOIGIOITHIEU, bh.mabv||'^'||ndk.tenbv NOICAP, ";
            sql += " '' GIUONG,  to_char(cd.makp) MAKP,cd.tenkp TENKP,to_char(hd.ngayvv,'dd/mm/yyyy hh24:mi') NGAYVAO,to_char(hd.ngay,'dd/mm/yyyy hh24:mi') NGAYRA, ";
            sql += " ba.chandoan || ';('||ba.MAICD||';)' CHANDOAN,ba.maicd MACID,cd.sttnhom STTNHOM ,cd.nhom NHOM,  case when cd.bhyt=100 then 1 else 2 end STTLOAI,  ";
            sql += " case when cd.bhyt=100 then 'Trong danh mục BHYT' else 'Ngoài danh mục BHYT' end LOAI,  to_char(ba.ngay,'dd/mm/yyyy hh24:mi') NGAY,   ";
            sql += " cd.mavp MA,cd.ten TEN,cd.DVT DVT,cd.soluong SOLUONG,cd.dongia DONGIA,cd.soluong*cd.dongia SOTIEN, {tam_ung} TAMUNG, ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra else 0 end BHYT,0 BHYT0117, ";
            sql += " case when cd.madoituong='7' then cd.tongtien else 0 end TCSOTIEN,0 DICHSO,0 MIEN,  ";
            sql += " case when cd.madoituong=1 and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra*cd.soluong*cd.dongia/100 else 0 end BHYTTRA,  ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then (100-tl.bhyttra)*cd.soluong*cd.dongia/100 else cd.soluong*cd.dongia end BNTRA,0 DICHSOTRA,  ";
            sql += " 0 SBLTAMUNG,ba.sovaovien SOLUUTRU,  '' NGUOINHA,1 PHUONGPHAP,1 HINHTHUC,'' KETQUA,'' KHU,'' NGAYPT,  0 TENPT,0	MASO,0	SOPHIEU, ";
            sql += " 0	LANIN,''	Image,''	Imagetk,0	Imageuser,  bs.ma mabs,bs.hoten tenbs,kprv.tenkp makprv,'' cholam,0 gianovat, ";
            sql += " 0 idttrv,0 sotientra,bh.traituyen traituyen,  cd.soluong*cd.dongia vattu,TO_CHAR(bh.ngay1) ngay1,TO_CHAR(bh.ngay2) ngay2,TO_CHAR(bh.ngay3) ngay3, ";
            sql += " TO_CHAR(bh.ngaytrinh) ngaytrinh,bh.ngayduyet ngayduyet,cd.kythuat kythuat, cd.dongia m_gia_bhyt, ";
            sql += " cd.dongia*cd.soluong m_thanhtien, ";
            sql += " case when cd.madoituong=1 and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then tl.bhyttra*cd.soluong*cd.dongia/100 else 0 end m_bhyt_tra, ";
            sql += " case when cd.madoituong='2' then cd.tongtien else 0 end  m_benhnhan_thuphi, ";
            sql += " case when cd.madoituong='7' then cd.tongtien else 0 end m_benhnhan_dichvu, ";
            sql += " case when cd.madoituong='1' and not (substr(bh.sothe,0,2)='GD' and bh.huongktcao=0  and cd.kythuat=0 ) then (100-tl.bhyttra)*cd.soluong*cd.dongia/100 else 0 end m_benhnhan_khac, 0  m_diengiai,  cd.tinhtong,	157500 m_giatranbhyt,'Khác'	lydocapcuu, ";
            sql += " 0	thanhtoandot,''	tenhc           ";
            sql += " from benhandt ba     ";
            sql += " join btdbn bn on ba.mabn=bn.mabn      ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa    ";
            sql += " join btdquan qu on bn.maqu=qu.maqu     ";
            sql += " join btdtt tt on bn.matt=tt.matt    ";
            sql += " join ( ";
          /*  sql += "                 select MAVAOVIEN,MABN,MAKP,IDKHOA,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,sum(SOLUONG) SOLUONG,max(DONGIA) dongia,BHYT,KYTHUAT,sum(kq.soluong*kq.dongia) TONGTIEN, TINHTONG  ";
            sql += "           from ";
            sql += "           ( ";
            sql +=" select cd.mavaovien,cd.mabn,to_char(cd.makp) MAKP,cd.idkhoa,kp.tenkp , cd.madoituong, cd.ngay, case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sql += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,cd.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong ";
            sql += "           from medibv1150714.v_chidinh cd  ";
            sql += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sql += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sql += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sql += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp where cd.paid=0 ";
            sql += "           union all ";

            sql += "            select cd.mavaovien,cd.mabn,to_char(cd.makp) MAKP,cd.idkhoa,kp.tenkp , cd.madoituong, cd.ngay, ";
            sql += "            -2   sttnhom,  'Dịch vu kỹ thuật cao chi phí lớn' nhom,-1 MAVP,to_char(cd.ghichu_vn) ten,'Lần' dvt,cd.soluong,cd.dongia,100 bhyt,0 kythuat,2 tinhtong  ";
            sql += "            from medibv115.bv_chidinhktc cd  ";
            sql += "            join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sql += "           union all ";

            sql += "           select cd.mavaovien,cd.mabn,to_char(kp.makp) MAKP,cd.idkhoa,kp.tenkp tenkp ,cd.madoituong, cd.ngay, case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sql += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,cd.giamua dongia,vp.bhyt,vp.kythuat,1 tinhtong ";
            sql += "           from medibv1150714.d_tienthuoc cd  ";
            sql += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sql += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sql += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sql += "           join medibv115.d_duockp dkp on cd.makp=dkp.id ";
            sql += "           join medibv115.btdkp_bv kp on dkp.makp=kp.makp ";
            sql += "           ) kq ";
            sql += "           where mabn={MABN} and madoituong<>5 ";
            sql += "           group by MAVAOVIEN,MABN,MAKP,IDKHOA,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,BHYT,KYTHUAT,TINHTONG ";*/

            sql += "            {sql_chiphi}   ) cd on ba.mavaovien=cd.mavaovien     ";
            sql += " join doituong dt on cd.madoituong=dt.madoituong     ";
            sql += " join bhyt bh on bh.maql=ba.maql     ";
            sql += " join DMNOICAPBHYT  ndk on ndk.mabv=bh.mabv     ";
            sql += " join hiendien hd on hd.mavaovien=ba.mavaovien     ";
            sql += " join bv_tilebhyt tl on tl.kytu=substr(bh.sothe,3,1) and bh.traituyen=tl.traituyen    ";
            sql += " join dmbs bs on ba.mabs=bs.ma     ";
            sql += " join btdkp_bv kprv on kprv.makp=hd.makp    ";
            sql += " where ba.mabn='{MABN}'  ";


            int kq = 0;

            sql = sql.Replace("{MABN}", MaBN);
            sql = sql.Replace("{tam_ung}", s_tam_ung);
            sql = sql.Replace("{sql_chiphi}", sqlgroup);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadChiDinh_v_chidinh_user(string userid, DateTime Ngay)
        {

//          sql = "select 0,a.mavp mavp,c.ten tenvp,a.soluong soluong,kp.tenkp tenkp,a.mabn MaBN,to_char(a.ngay,'dd/mm/yyyy') ngaycd,'-' ngayxoa,' ' nguoixoa,a.makp makp  from xxxxx.v_chidinh a,v_giavp c,btdkp_bv kp where c.id=a.mavp and a.makp=kp.makp and  to_char(a.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";

            sql = "SELECT 0,v.id mavp,v.ten tenvp, TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,10)+1, INSTR(a.noidung,'^',1,10+1) - INSTR(a.noidung,'^',1,10)-1 )) SOLUONG,c.tenkp tenkp,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 )) MABN,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,25)+1, INSTR(a.noidung,'^',1,25+1) - INSTR(a.noidung,'^',1,25)-1 )) NGAY_CHI_DINH,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) NGAY_XOA,b.hoten nguoixoa,c.makp makp,TO_CHAR(SUBSTR(a.noidung, 0, INSTR(a.noidung,'^',1,0+1) -1 )) idchidinh,b.id Userid,bn.hoten ";
            sql +=" FROM xxxxx.eve_upd_del a,dlogin b,btdkp_bv c,v_giavp v,btdbn bn ";
            sql += " WHERE  a.userid='"+userid+"' and a.TABLEID=42 and  a.command='del' ";
            sql+=" and a.userid=b.id and c.makp=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,7)+1, INSTR(a.noidung,'^',1,7+1) - INSTR(a.noidung,'^',1,7)-1 )) and v.id=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) AND TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,8)+1, INSTR(a.noidung,'^',1,8+1) - INSTR(a.noidung,'^',1,8)-1 ))  not in ('9') and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) in (select cc.id from v_nhomvp aa,v_loaivp bb,v_giavp cc where aa.ma in (5,6,15) and aa.ma=bb.id_nhom and cc.id_loai=bb.id) and ";
            sql+=" TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) like  '%"+string.Format("{0:MM/dd/yyyy}",Ngay)+"%' ";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 ))=bn.mabn ";

            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadChiDinh_v_chidinh_user(string userid, DateTime Ngay, string iddatuyet)
        {

            //          sql = "select 0,a.mavp mavp,c.ten tenvp,a.soluong soluong,kp.tenkp tenkp,a.mabn MaBN,to_char(a.ngay,'dd/mm/yyyy') ngaycd,'-' ngayxoa,' ' nguoixoa,a.makp makp  from xxxxx.v_chidinh a,v_giavp c,btdkp_bv kp where c.id=a.mavp and a.makp=kp.makp and  to_char(a.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";

            sql = "SELECT 0,v.id mavp,v.ten tenvp, TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,10)+1, INSTR(a.noidung,'^',1,10+1) - INSTR(a.noidung,'^',1,10)-1 )) SOLUONG,c.tenkp tenkp,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 )) MABN,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,25)+1, INSTR(a.noidung,'^',1,25+1) - INSTR(a.noidung,'^',1,25)-1 )) NGAY_CHI_DINH,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) NGAY_XOA,b.hoten nguoixoa,c.makp makp,TO_CHAR(SUBSTR(a.noidung, 0, INSTR(a.noidung,'^',1,0+1) -1 )) idchidinh,b.id Userid ,bn.hoten";
            sql += " FROM xxxxx.eve_upd_del a,dlogin b,btdkp_bv c,v_giavp v,btdbn bn ";
            sql += " WHERE  a.userid='" + userid + "' and a.TABLEID=42 and  a.command='del' ";
            sql += " and a.userid=b.id and c.makp=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,7)+1, INSTR(a.noidung,'^',1,7+1) - INSTR(a.noidung,'^',1,7)-1 )) and v.id=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) AND TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,8)+1, INSTR(a.noidung,'^',1,8+1) - INSTR(a.noidung,'^',1,8)-1 ))  not in ('9') and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) in (select cc.id from v_nhomvp aa,v_loaivp bb,v_giavp cc where aa.ma in (5,6,15) and aa.ma=bb.id_nhom and cc.id_loai=bb.id) and ";
            sql += " TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) like  '%" + string.Format("{0:MM/dd/yyyy}", Ngay) + "%' ";
            sql += " and TO_CHAR(SUBSTR(a.noidung, 0, INSTR(a.noidung,'^',1,0+1) -1 ))not in (" + iddatuyet + ")";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 ))=bn.mabn ";


            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadChiDinh_v_chidinh_MaBN(string MaBN, DateTime Ngay, string iddatuyet)
        {

            //          sql = "select 0,a.mavp mavp,c.ten tenvp,a.soluong soluong,kp.tenkp tenkp,a.mabn MaBN,to_char(a.ngay,'dd/mm/yyyy') ngaycd,'-' ngayxoa,' ' nguoixoa,a.makp makp  from xxxxx.v_chidinh a,v_giavp c,btdkp_bv kp where c.id=a.mavp and a.makp=kp.makp and  to_char(a.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";

            sql = "SELECT 0,v.id mavp,v.ten tenvp, TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,10)+1, INSTR(a.noidung,'^',1,10+1) - INSTR(a.noidung,'^',1,10)-1 )) SOLUONG,c.tenkp tenkp,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 )) MABN,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,25)+1, INSTR(a.noidung,'^',1,25+1) - INSTR(a.noidung,'^',1,25)-1 )) NGAY_CHI_DINH,TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) NGAY_XOA,b.hoten nguoixoa,c.makp makp,TO_CHAR(SUBSTR(a.noidung, 0, INSTR(a.noidung,'^',1,0+1) -1 )) idchidinh,b.id Userid ,bn.hoten";
            sql += " FROM xxxxx.eve_upd_del a,dlogin b,btdkp_bv c,v_giavp v,btdbn bn ";
            sql += " WHERE   a.TABLEID=42 and  a.command='del' ";
            sql += " and a.userid=b.id and c.makp=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,7)+1, INSTR(a.noidung,'^',1,7+1) - INSTR(a.noidung,'^',1,7)-1 )) and v.id=TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) AND TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,8)+1, INSTR(a.noidung,'^',1,8+1) - INSTR(a.noidung,'^',1,8)-1 ))  not in ('9')  ";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) like  '%" + string.Format("{0:MM/dd/yyyy}", Ngay) + "%' ";
            sql += " and TO_CHAR(SUBSTR(a.noidung, 0, INSTR(a.noidung,'^',1,0+1) -1 ))not in (" + iddatuyet + ")";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 ))=bn.mabn  ";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,1)+1, INSTR(a.noidung,'^',1,1+1) - INSTR(a.noidung,'^',1,1)-1 ))='"+MaBN+"'";


            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadUser_v_chidinh(DateTime Ngay)
        {

            sql = "select distinct b.hoten ||' - '||b.userid ten,id id";

            sql += " FROM xxxxx.eve_upd_del a,dlogin b ";
            sql += " WHERE  a.TABLEID=42 and  a.command='del' ";
            sql += " and a.userid=b.id and  TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,35)+1, INSTR(a.noidung,'^',1,35+1) - INSTR(a.noidung,'^',1,35)-1 )) like  '%" + string.Format("{0:MM/dd/yyyy}", Ngay) + "%'";
            sql += " and TO_CHAR(SUBSTR(a.noidung, INSTR(a.noidung,'^',1,9)+1, INSTR(a.noidung,'^',1,9+1) - INSTR(a.noidung,'^',1,9)-1 )) in (select cc.id from v_nhomvp aa,v_loaivp bb,v_giavp cc where aa.ma in (5,6,15) and aa.ma=bb.id_nhom and cc.id_loai=bb.id)";
            sql += " order by ten";

            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadVienPhiChiTietKhacNgay(string MaBN, DateTime Ngay, bool loadBHYT)
        {
            if (loadBHYT)
                sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where b.madoituong=1 and c.id_loai=l.id and vl.id=a.id and vl.loaibn=3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(vl.ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")";
            else
                sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where  c.id_loai=l.id and vl.id=a.id and vl.loaibn=3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(vl.ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadThuocChiTiet(string MaBN, DateTime Ngay,bool loadBHYT)
        {
            if(loadBHYT)
                      sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where  b.madoituong=1 and vl.id=a.id and vl.loaibn=3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            else
                      sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where  vl.id=a.id and vl.loaibn=3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadThuocChiTietKhacNgay(string MaBN, DateTime Ngay, bool loadBHYT)
        {
            if (loadBHYT)
                sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where  b.madoituong=1 and vl.id=a.id and vl.loaibn=3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")";
            else
                sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where  vl.id=a.id and vl.loaibn=3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
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
        public string f_loadICD(string MaQL,DateTime Ngay)
        {
            string kq = "";
            string MaICD= "";
            
            sql = "select maicd from xxxxx.bhytkb where maql='"+MaQL+"'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    MaICD = addString(MaICD, row[0].ToString());
                }

            }
            catch { }
            sql = "select maicd from xxxxx.cdkemtheo where maql='" + MaQL + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    MaICD = addString(MaICD, row[0].ToString());
                }

            }
            catch { }
            return MaICD;
        }

        public string f_loadChanDoan(string MaQL,DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";

            sql = "select chandoan from xxxxx.bhytkb where maql='" + MaQL + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan = addString(ChanDoan, row[0].ToString());
                }

            }
            catch { }

            sql = "select chandoan from xxxxx.cdkemtheo where maql='" + MaQL + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));

            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan = addString(ChanDoan, row[0].ToString());
                }

            }
            catch { }

            sql = "select ten from xxxxx.trieuchung where maql='" + MaQL + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));

            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan = addString(ChanDoan, row[0].ToString());
                }

            }
            catch { }
            return ChanDoan;
        }

        public string f_loadICDFull(string MaBN, DateTime Ngay)
        {
            string kq = "";
            string MaICD = "";
           
            sql = "select maicd from xxxxx.benhanpk where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    MaICD = addString(MaICD,row[0].ToString());
                }

            }
            catch { }
            sql = "select maicd from xxxxx.cdkemtheo where maql in (select maql from xxxxx.benhanpk where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "')";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));

            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    MaICD = addString(MaICD, row[0].ToString());
                }

            }
            catch { }
            return MaICD;
        }

        public string f_loadChanDoanFull(string MaBN, DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";
            
            sql = "select chandoan from xxxxx.benhanpk where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan=addString(ChanDoan, row[0].ToString() );
                }

            }
            catch { }
            sql = "select chandoan from xxxxx.cdkemtheo where maql in (select maql from xxxxx.benhanpk where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "')";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));

            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan= ChanDoan = addString(ChanDoan, row[0].ToString());
                }

            }
            catch { }
            sql = "select ten from xxxxx.trieuchung where maql in (select maql from xxxxx.bhytkb where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "')";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));

            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    ChanDoan = addString(ChanDoan, row[0].ToString());
                }

            }
            catch { }
            return ChanDoan;
        }
        public CThanhToanBHYT f_loadTT_BHYT_TiepNhan(string MaBN, DateTime Ngay)
        {


            sql = "select bh.sothe SOTHE,bh.mabv MABV,nc.tenbv TENBV,bh.denngay DENNGAY,bh.traituyen TRAITUYEN from xxxxx.bhyt bh,dmnoicapbhyt nc where nc.mabv=bh.mabv and bh.mabn='" + MaBN + "' and  to_char(bh.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoTheBHYT = dset.Tables[0].Rows[0]["SOTHE"].ToString();
                thanhtoanbhyt.MaBV = dset.Tables[0].Rows[0]["MABV"].ToString();
                thanhtoanbhyt.NoiDangKyBHYT = dset.Tables[0].Rows[0]["TENBV"].ToString();
                thanhtoanbhyt.TraiTuyen = int.Parse(dset.Tables[0].Rows[0]["TRAITUYEN"].ToString());
                thanhtoanbhyt.HSD = DateTime.Parse(dset.Tables[0].Rows[0]["DENNGAY"].ToString());
                
            }
            catch { }

            return thanhtoanbhyt;
        }
        public CThanhToanBHYT f_loadTT_BHYT(string MaBN, DateTime Ngay)
        {


            sql = "select kb.sothe,kb.mabv,nc.tenbv,bh.denngay,kb.traituyen,kb.sobienlai,kb.loaiba from xxxxx.bhytkb kb,xxxxx.bhyt bh,dmnoicapbhyt nc where nc.mabv=kb.mabv and kb.mabn='" + MaBN + "' and bh.maql=kb.maql and to_char(kb.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoTheBHYT = dset.Tables[0].Rows[0]["SOTHE"].ToString();
                thanhtoanbhyt.MaBV = dset.Tables[0].Rows[0]["MABV"].ToString();
                thanhtoanbhyt.NoiDangKyBHYT = dset.Tables[0].Rows[0]["TENBV"].ToString();
                thanhtoanbhyt.TraiTuyen = int.Parse(dset.Tables[0].Rows[0]["TRAITUYEN"].ToString());
                thanhtoanbhyt.HSD = DateTime.Parse(dset.Tables[0].Rows[0]["DENNGAY"].ToString());
                thanhtoanbhyt.LoaiBA = dset.Tables[0].Rows[0]["LOAIBA"].ToString();
                thanhtoanbhyt.SoBienLai = dset.Tables[0].Rows[0]["SOBIENLAI"].ToString();
            }
            catch { }

            return thanhtoanbhyt;
        }
        public CThanhToanBHYT f_loadTT_BHYT_CLS(string MaBN, DateTime Ngay)
        {


            sql = "select bh.sothe,bh.mabv,nc.tenbv,bh.ngay,bh.traituyen,ll.sobienlai,ll.loaibn from xxxxx.v_ttrvds ds,xxxxx.v_ttrvbhyt bh,dmnoicapbhyt nc,xxxxx.v_ttrvll ll where ll.id=ds.id and nc.mabv=bh.mabv and ds.mabn=" + MaBN + " and ds.id=bh.id and to_char(ds.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoTheBHYT = dset.Tables[0].Rows[0]["SOTHE"].ToString();
                thanhtoanbhyt.MaBV = dset.Tables[0].Rows[0]["MABV"].ToString();
                thanhtoanbhyt.NoiDangKyBHYT = dset.Tables[0].Rows[0]["TENBV"].ToString();
                thanhtoanbhyt.TraiTuyen = int.Parse(dset.Tables[0].Rows[0]["TRAITUYEN"].ToString());
                thanhtoanbhyt.HSD = DateTime.Parse(dset.Tables[0].Rows[0]["NGAY"].ToString());
                thanhtoanbhyt.LoaiBA = dset.Tables[0].Rows[0]["LOAIBN"].ToString();
                thanhtoanbhyt.SoBienLai = dset.Tables[0].Rows[0]["SOBIENLAI"].ToString();
            }
            catch { }

            return thanhtoanbhyt;
        }
        public CThanhToanBHYT f_loadSoPhieu_IDTTRV(string MaBN, DateTime Ngay)
        {


            sql = "select kb.sotoa,kb.mavaovien,kb.idttrv,kb.maql from xxxxx.bhytkb kb where  kb.mabn=" + MaBN + " and to_char(kb.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoPhieu = dset.Tables[0].Rows[0]["SOTOA"].ToString();
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[0]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[0]["IDTTRV"].ToString());
                thanhtoanbhyt.MaQuanLy = dset.Tables[0].Rows[0]["MAQL"].ToString();
                

            }
            catch { }

            return thanhtoanbhyt;
        }
        public CThanhToanBHYT f_loadSoPhieu_IDTTRV_CLS(string MaBN, DateTime Ngay)
        {


            sql = "select ll.sophieu,DS.mavaovien,DS.id,ds.maql from xxxxx.v_ttrvds ds,xxxxx.v_ttrvll ll where  ll.id=ds.id and ds.mabn=" + MaBN + " and to_char(ds.NgayVao,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoPhieu = dset.Tables[0].Rows[0]["SOPHIEU"].ToString();
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[0]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[0]["ID"].ToString());
                thanhtoanbhyt.MaQuanLy = dset.Tables[0].Rows[0]["MAQL"].ToString();

            }
            catch { }

            return thanhtoanbhyt;
        }

        private string for_ngay_yyyymmdd(string ngay)
        {
            return ngay.Substring(6, 4) + ngay.Substring(3, 2) + ngay.Substring(0, 2);
        }
        public DataSet f_loadDanhSachChuaDuyet(string tungay,string denngay,string IDDaDuyet)
        {
            if (IDDaDuyet.Length == 0)
            {
                sql = "select  kp.tenkp,kb.mabn, bn.hoten, bn.namsinh, kb.sotoa,kb.sothe,kb.thuoc,kb.mavaovien, kb.idttrv ,kb.traituyen from xxxxx.bhytkb kb,btdbn bn,btdkp_bv kp where kb.makp=kp.makp and bn.mabn=kb.mabn and  kb.loaiba=3 and to_char(kb.Ngay,'YYYYMMDD')>='" + for_ngay_yyyymmdd(tungay) + "' and to_char(kb.Ngay,'YYYYMMDD')<='" + for_ngay_yyyymmdd(denngay) + "' ";
            }
            else
            {
                sql = "select  kp.tenkp,kb.mabn, bn.hoten, bn.namsinh, kb.sotoa,kb.sothe,kb.thuoc,kb.mavaovien, kb.idttrv ,kb.traituyen from xxxxx.bhytkb kb,btdbn bn,btdkp_bv kp where kb.makp=kp.makp and bn.mabn=kb.mabn and  kb.loaiba=3 and to_char(kb.Ngay,'YYYYMMDD')>='" + for_ngay_yyyymmdd(tungay) + "' and to_char(kb.Ngay,'YYYYMMDD')<='" + for_ngay_yyyymmdd(denngay) + "' and kb.idttrv not in (" + IDDaDuyet + ")";
            }
            sql = sql.Replace("xxxxx", getdatabase(tungay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                

            }
            catch { }

            return dset;
        }
        public DataSet f_loadDanhSachCLSChuaDuyet(string tungay, string denngay, string IDDaDuyet)
        {
        
        
          /* sql = "select  kp.tenkp,ds.mabn, bn.hoten, bn.namsinh, ll.sotien TONGTIEN,ll.bhyt BHYTTRA, ";
           sql += " (select  bhkb.sotoa FROM xxxxx.bhytkb bhkb where ds.mavaovien=bhkb.mavaovien) SOPHIEU";
            sql+=" from xxxxx.v_ttrvds ds ";
            sql+= " join xxxxx.v_ttrvll ll on ds.id=ll.id";
            sql+= " join btdbn bn on bn.mabn=ds.mabn ";
            sql+= " join btdkp_bv kp on ll.makp=kp.makp ";
            sql+=" where   ll.bhyt>0 and  ll.loaibn=3 and ll.sotien>15000 ";
            sql+=" and to_char(ll.ngay,'YYYYMMDD') between '@tungay' and '@denngay' ";
            sql+=" and ds.mavaovien not in ";
            sql += " (select bhds.mavaovien from bv115.v_bhytds bhds where to_char(bhds.ngayvao,'YYYYMMDD') between '@tungay' and '@denngay' ) "; ; */
           // sql+=" group by kp.tenkp,ds.mabn, bn.hoten, bn.namsinh, ll.sotien";
            sql = "select  kp.tenkp,ds.mabn, bn.hoten, bn.namsinh, ll.sotien TONGTIEN,ll.bhyt BHYTTRA, ";
            sql += "   bhkb.sotoa  SOPHIEU,to_char(ds.ngayvao,'dd/mm/yyyy') NGAYVAO,to_char(ds.ngayra,'dd/mm/yyyy') NGAYRA";
            sql += " from xxxxx.v_ttrvds ds ";
            sql += " join xxxxx.v_ttrvll ll on ds.id=ll.id";
            sql += " join xxxxx.bhytkb bhkb on ds.mavaovien=bhkb.mavaovien ";
            sql += " join btdbn bn on bn.mabn=ds.mabn ";
            sql += " join btdkp_bv kp on ll.makp=kp.makp ";
            sql += " where   ll.bhyt>0 and  ll.loaibn=3 and ll.sotien>15000 ";
            sql += " and to_char(ll.ngay,'YYYYMMDD') between '@tungay' and '@denngay' ";
            sql += " and ds.mavaovien not in ";
            sql += " (select bhds.mavaovien from bv115.v_bhytds bhds where to_char(bhds.ngayvao,'YYYYMMDD') between '@tungay' and '@denngay' ) "; 
            sql = sql.Replace("xxxxx", getdatabase(tungay));
            sql = sql.Replace("@tungay", for_ngay_yyyymmdd(tungay));
            sql = sql.Replace("@denngay", for_ngay_yyyymmdd(denngay));

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        private string f_formatNgay(string ngay)
        {
            string kq = "";
            try
            {

                kq = ngay.Substring(6, 4) + ngay.Substring(3, 2) + ngay.Substring(0, 2);
            }
            catch { }
            return kq;
        }

        #endregion
    }
}
