using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using LibBaocao;
using System.Data;
using DataUpdate;
namespace DataOracle
{
    public class CThanhToanBHYTOracleNoiTru
    {
        #region khai bao bien
        CThanhToanBHYT thanhtoanbhyt;
        AccessData data;
        private string schema = AccessData.schema;
        DataSet ds;
        CConnection_Oracle ora_conn = new CConnection_Oracle();
        string sql = "";
        #endregion

        CThanhToanBHYT ThanhToanBHYT
        {
            get { return thanhtoanbhyt; }
        }
        #region phuong thuc
        public CThanhToanBHYTOracleNoiTru()
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
        private string getDate_yymmdd(string ngay)
        {
            string database = "";
            try
            {
                // - dd/mm/yyyy
                database = ngay.Substring(8, 2) + ngay.Substring(3, 2) + ngay.Substring(0, 2);
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
        public bool kiemtratrung(string sophieu, DateTime Ngay)
        {
            bool kq = false;
            sql = "select sophieu from "+schema+".v_bhytll ll where ll.sophieu='@sophieu' and to_char(ngay,'dd/mm/yyyy')='@ngay'";

            sql = sql.Replace("@sophieu", sophieu);
            sql = sql.Replace("@ngay", string.Format("{0:dd/MM/yyyy}", Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                if (dset.Tables[0].Rows.Count > 0)
                    kq = true;
            }
            catch { }
            return kq;
        }
        public DataTable kiemtratrung_trongngay(string loaibn, DateTime Ngay)
        {
            DataTable dt=new DataTable();
            bool kq = false;
            sql = " select b.sophieu,a.mabn,bn.hoten,to_char(A.ngayvao,'dd/mm/yyyy') NGAYVAO";
            sql += " ,to_char(A.ngayra,'dd/mm/yyyy') NGAYRA ,KP.tenkp TENKP,a.sothe,b.sotien TONGTIEN,b.bhyt BHYTTRA";
            sql += " from " + schema + ".v_bhytds a ";
            sql += " join " + schema + ".v_bhytll b on a.id=b.id ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " join btdbn bn on bn.mabn=a.mabn ";
            sql += " where to_char(a.ngayra,'dd/mm/yyyy')||a.mabn in ";
            sql += " (select to_char(a.ngayra,'dd/mm/yyyy')||a.mabn from " + schema + ".v_bhytds a ";
            sql += " join " + schema + ".v_bhytll b on a.id=b.id ";
            sql += " where b.loaibn=" + loaibn + " and to_char(b.ngay,'mm/yyyy')='@thang' ";
            sql += " group by to_char(a.ngayra,'dd/mm/yyyy')||a.mabn ";
            sql += " having count(*)>1 )";
            sql += " union ";
            sql += " select b.sophieu,a.mabn,bn.hoten,to_char(A.ngayvao,'dd/mm/yyyy') NGAYVAO";
            sql += " ,to_char(A.ngayra,'dd/mm/yyyy') NGAYRA ,KP.tenkp TENKP,a.sothe,b.sotien TONGTIEN,b.bhyt BHYTTRA";
            sql += " from " + schema + ".v_bhytds a ";
            sql += " join " + schema + ".v_bhytll b on a.id=b.id ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " join btdbn bn on bn.mabn=a.mabn ";
            sql += " where to_char(a.ngayvao,'dd/mm/yyyy')||a.mabn in ";
            sql += " (select to_char(a.ngayvao,'dd/mm/yyyy')||a.mabn from " + schema + ".v_bhytds a ";
            sql += " join " + schema + ".v_bhytll b on a.id=b.id ";
            sql += " where b.loaibn=" + loaibn + " and to_char(b.ngay,'mm/yyyy')='@thang' ";
            sql += " group by to_char(a.ngayvao,'dd/mm/yyyy')||a.mabn ";
            sql += " having count(*)>1) ";
            sql = sql.Replace("@thang", string.Format("{0:MM/yyyy}", Ngay));

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                dt = dset.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataTable kiemtratrung_MaVaoVien(string mavaovien)
        {
            DataTable dt = new DataTable();
            bool kq = false;
            sql = " select to_char(b.ngay,'dd/mm/yyyy') NGAYTHANHTOAN,to_char(A.ngayvao,'dd/mm/yyyy') NGAYVAO";
            sql+=" ,to_char(A.ngayra,'dd/mm/yyyy') NGAYRA ,KP.tenkp TENKP,a.sothe,b.sotien TONGTIEN,b.bhyt BHYTTRA,B.SOPHIEU ";
            sql += " from " + schema + ".v_bhytds a ";
            sql += " join " + schema + ".v_bhytll b on a.id=b.id ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " where  mavaovien='{mavaovien}'";
            sql += " order by to_char(b.ngay,'yyyymmdd') desc";
            sql = sql.Replace("{mavaovien}", mavaovien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                dt = dset.Tables[0];
            }
            catch { }
            return dt;
        }
        public DataSet f_loadVienPhiChiTiet(string MaBN,DateTime Ngay,string MaQL,bool loadBHYT)
        {
            if(loadBHYT)
                       sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where a.maql='"+MaQL+"' and b.madoituong=1 and c.id_loai=l.id and vl.id=a.id and vl.loaibn<>3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            else
                       sql = "select c.ten ,c.DVT ,b.dongia ,b.SOLUONG ,B.SOTIEN  ,B.BHYTTRA,n.idnhombhyt,n.ten from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,v_giavp c,v_nhomvp n,v_loaivp l where a.maql='" + MaQL + "' and c.id_loai=l.id and vl.id=a.id and vl.loaibn<>3 and l.id_nhom=n.ma and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and b.madoituong in ('1','2','7') and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadThuocChiTiet(string MaBN, DateTime Ngay,string MaQL,bool loadBHYT)
        {
            if(loadBHYT)
                      sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where a.maql='"+MaQL+"' and  b.madoituong=1 and vl.id=a.id and vl.loaibn<>3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
            else
                      sql = "select c.ten ,c.hamluong,c.Dang ,b.SOLUONG ,b.dongia ,B.SOTIEN  ,B.BHYTTRA from xxxxx.v_ttrvds a,xxxxx.v_ttrvll vl,xxxxx.v_ttrvct b,d_dmbd c where a.maql='" + MaQL + "' and vl.id=a.id and vl.loaibn<>3 and a.id=b.id and c.id=b.mavp and a.mabn='" + MaBN + "' and to_char(a.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "' and vl.sobienlai not in (select sobienlai from xxxxx.v_hoantra where mabn=" + MaBN + ")"; 
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
        public string f_loadICD(string MaBN, DateTime Ngay)
        {
            string kq = "";
            string MaICD= "";
            
            sql = "select maicd from xxxxx.bhytkb where mabn="+MaBN+" and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
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
            sql = "select maicd from xxxxx.cdkemtheo where maql in (select maql from xxxxx.bhytkb where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "')";
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

        public string f_loadChanDoan(string MaBN, DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";
            
            sql = "select chandoan from xxxxx.bhytkb where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
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

            sql = "select chandoan from xxxxx.cdkemtheo where maql in (select maql from xxxxx.bhytkb where mabn=" + MaBN + " and to_char(Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "')";
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

        public string f_loadICDFull( string mavaovien,DateTime Ngay)
        {
            string kq = "";
            string MaICD = "";
            sql = " select  chandoan,stt from ";
            sql += " (select maicd chandoan,1 stt from {database}.v_thvpll where mavaovien='{mavaovien}' and idttrv>0 and  maicd is not null";
            sql += " union ";
            sql += " select maicd chandoan,0 stt from {database}.v_ttrvds where mavaovien='{mavaovien}' and  maicd is not null";
            sql += " union ";
            sql += " select cd.maicd chandoan,2 stt from {database}.cdkemtheo cd";
            sql += " join {database}.benhanpk ba on cd.maql=ba.maql where ba.mavaovien='{mavaovien}' and  cd.maicd is not null";
            sql += " ) kq group by chandoan,stt order by stt";
            sql = sql.Replace("{database}", getdatabase(Ngay));
            sql = sql.Replace("{mavaovien}", mavaovien);
            
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    string chandoan = row[0].ToString();
                    try
                    {
                        if (chandoan.Length > 2 && MaICD.IndexOf(chandoan.Substring(0, 3)) < 0)
                        {
                            MaICD = addString(MaICD, chandoan);
                        }
                    }catch{}
                }

            }
            catch { }
           
           
            return MaICD;
        }

        public string f_loadChanDoanFull( string mavaovien,DateTime Ngay)
        {
            string kq = "";
            string ChanDoan = "";
            sql = " select chandoan,stt from ";
            sql += " ( select chandoan||'_'||maicd chandoan,1 stt from {database}.v_thvpll where mavaovien='{mavaovien}' and idttrv>0 and  maicd is not null";
            sql += " union ";
            sql += " select chandoan||'_'||maicd chandoan,0 stt from {database}.v_ttrvds where mavaovien='{mavaovien}' and  maicd is not null";
            sql += " union ";
            sql += " select cd.chandoan||'_'||cd.maicd chandoan,2 stt from {database}.cdkemtheo cd ";
            sql += " join {database}.benhanpk ba on cd.maql=ba.maql where ba.mavaovien='{mavaovien}' and  cd.maicd is not null";
            sql += " ) kq group by chandoan,stt order by stt";
            sql = sql.Replace("{database}", getdatabase(Ngay));
            sql = sql.Replace("{mavaovien}", mavaovien);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    string chandoan = row[0].ToString();
                    if(chandoan.Length>5 && ChanDoan.IndexOf(chandoan.Substring(0,5))<0)
                    {
                        ChanDoan=addString(ChanDoan, chandoan );
                    }
                }

            }
            catch { }
           
            
            return ChanDoan;
        }
        public CThanhToanBHYT f_loadTT_BHYT(string MaBN, DateTime Ngay)
        {


            sql = "select kb.sothe,kb.mabv,nc.tenbv,bh.denngay,kb.traituyen,kb.sobienlai,kb.loaiba from xxxxx.bhytkb kb,xxxxx.bhyt bh,dmnoicapbhyt nc where nc.mabv=kb.mabv and kb.mabn=" + MaBN + " and bh.maql=kb.maql and to_char(kb.Ngay,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
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
        public int f_gettileBHYTtra(string mathe, string traituyen)
        {
            int kq = 0;
            string sql = "";
            
            try
            {   string kytu3 =mathe.Substring(2,1);

                sql = " select tl.bhyttra ";
                sql += " from bv_tilebhyt tl ";
                sql += " where  tl.kytu='{kytu3}' and tl.traituyen='{traituyen}'    ";
                sql = sql.Replace("{kytu3}", kytu3);
                sql = sql.Replace("{traituyen}", traituyen);
                DataSet ds = data.get_data(sql);

                kq = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            return kq;
        }
        public int f_gettileBHYTtra_3KT(string mathe, string loai)
            //0 dung tuyen, 1 traituyen,2 ktc
        {
            int kq = 0;
            string sql = "";

            try
            {
                string kytu3 = mathe.Substring(0, 3);

                sql = " select tl.TLDUNGTUYEN TL_DT,TLTRAITUYEN TL_TT,TL_KTC TT_KTC";
                sql += " from " + schema + ".BH_TILE tl ";
                sql += " where  tl.kytu='{kytu3}' and tl.Enable=1  ";
                sql = sql.Replace("{kytu3}", kytu3);
                
                DataSet ds = data.get_data(sql);

                kq = int.Parse(ds.Tables[0].Rows[0][int.Parse(loai)].ToString());
            }
            catch { }
            return kq;
        }
        public CThanhToanBHYT f_loadTT_BHYT_CLS(string MaVaoVien, DateTime Ngay)
        {


            sql = "select ds.id idtt,ds.maql,bh.sothe,bh.mabv,nc.tenbv,bh.ngay HSD,bh.tungay,bh.traituyen,ll.sobienlai,ll.loaibn ";
           
            sql+=" from xxxxx.v_ttrvds ds ";
            sql+=" join xxxxx.v_ttrvbhyt bh on ds.id=bh.id ";
            sql+=" join dmnoicapbhyt nc on nc.mabv=bh.mabv ";
            sql+=" join xxxxx.v_ttrvll ll on ll.id=ds.id ";
            sql+=" where   ll.bhyt>0 and   ds.mavaovien='{mavaovien}'";
            sql+=" union ";

            sql += " select 0 idtt,bh.maql,bh.sothe,bh.mabv,nc.tenbv,bh.denngay HSD,bh.tungay,bh.traituyen,0 sobienlai,ba.loai loaibn";
            sql+=" from tiepdon ba ";
            sql+=" join bhyt bh on ba.maql=bh.maql ";
            sql+=" join dmnoicapbhyt nc on nc.mabv=bh.mabv ";
            sql += " where     ba.mavaovien={mavaovien} ";
            sql += " union ";

            sql += " select 0 idtt,bh.maql,bh.sothe,bh.mabv,nc.tenbv,bh.denngay HSD,bh.tungay,bh.traituyen,0 sobienlai,ba.loai loaibn ";
            sql += " from xxxxx.tiepdon ba ";
            sql += " join xxxxx.bhyt bh on ba.maql=bh.maql ";
            sql += " join dmnoicapbhyt nc on nc.mabv=bh.mabv ";
            sql += " where     ba.mavaovien={mavaovien} ";

            
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            sql = sql.Replace("{mavaovien}", MaVaoVien);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                int irow = dset.Tables[0].Rows.Count-1;
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

                thanhtoanbhyt.Macn = f_getMaCN(thanhtoanbhyt.MaQuanLy, Ngay);
            }
            catch { }

            return thanhtoanbhyt;
        }

        public string  f_getMaCN(string MaQL, DateTime Ngay)
        {


            string result = "";

            sql = " select bh.macn MACN";
            sql += " from bhyt bh ";
            sql += " where     bh.MaQL={MaQL} and bh.macn is not null";
            sql += " union ";
            sql += " select bh.macn MACN";
            sql += " from xxxxx.bhyt bh ";
            sql += " where     bh.MaQL={MaQL} and bh.macn is not null";


            sql = sql.Replace("xxxxx", getdatabase(Ngay));
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
        public CThanhToanBHYT f_loadSoPhieu_IDTTRV(string maql,DateTime Ngay)
        {


            sql = "select ds.NgayVao,ds.ngayra,ds.mavaovien,ds.id from xxxxx.v_ttrvds ds where  maql='"+maql+"'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
               // thanhtoanbhyt.SoPhieu = dset.Tables[0].Rows[0]["SOTOA"].ToString();
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[0]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[0]["ID"].ToString());
                thanhtoanbhyt.NgayVao = DateTime.Parse(dset.Tables[0].Rows[0]["NgayVao"].ToString());
                thanhtoanbhyt.NgayRa = DateTime.Parse(dset.Tables[0].Rows[0]["NgayRa"].ToString());

            }
            catch { }

            return thanhtoanbhyt;
        }
        private string for_ngay_yyyymmdd(string ngay)
        {
            return ngay.Substring(6, 4) + ngay.Substring(3, 2) + ngay.Substring(0, 2);
        }
        private string getdatabase_haison(string ngay)
        {
            return "medibv115"+ngay.Substring(3, 2)+ngay.Substring(8, 2) ;
        }
        public DataSet f_loadNgayNhapVien_MaQL(string MaBN, string tungay,string denngay,bool LocNgay)
        {



            if (LocNgay == false)
            {
                sql = "select  to_char(ds.ngayvao,'dd/mm/yyyy hh:mi')||' - '||to_char(ds.ngayra,'dd/mm/yyyy hh:mi') dotdieutri,ds.mavaovien mavaovien";
                sql += " from xxxxx.v_thvpll ds ";
                sql += " where  ds.mabn='" + MaBN + "'";
                sql += " union ";
                sql += " select  to_char(td.ngay,'dd/mm/yyyy hh:mi')||' - '||to_char(td.ngay,'dd/mm/yyyy hh:mi') dotdieutri,td.mavaovien mavaovien";
                sql += " from xxxxx.tiepdon td ";
                sql += " where  td.mabn='" + MaBN + "'";
                sql += " union ";
                sql += " select  to_char(td.ngay,'dd/mm/yyyy hh:mi')||' - '||to_char(td.ngay,'dd/mm/yyyy hh:mi') dotdieutri,td.mavaovien mavaovien";
                sql += " from benhandt td ";
                sql += " where  td.mabn='" + MaBN + "'";
            }
            else
            {
                sql =  " select  to_char(ds.ngayvao,'dd/mm/yyyy hh:mi')||' - '||to_char(ds.ngayra,'dd/mm/yyyy hh:mi') dotdieutri,ds.mavaovien mavaovien ";
                sql+=" from xxxxx.v_ttrvds ds ";
                sql+=" join xxxxx.v_ttrvll ll on ds.id=ll.id ";
                sql += " where to_char(ll.ngay,'yyyymmdd') between '@tungay' and  '@denngay' and ds.mabn='@mabn'";
               
            }
            sql = sql.Replace("xxxxx", getdatabase_haison(tungay));
            sql = sql.Replace("@tungay",for_ngay_yyyymmdd(tungay) );
            sql = sql.Replace("@denngay", for_ngay_yyyymmdd(denngay));
            sql = sql.Replace("@mabn", MaBN);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
               


            }
            catch { }

            return dset;
        }
        public CThanhToanBHYT f_loadSoPhieu_IDTTRV_CLS(string MaBN, DateTime Ngay)
        {


            sql = "select ll.sophieu,DS.mavaovien,DS.id from xxxxx.v_ttrvds ds,xxxxx.v_ttrvll ll where  ll.id=ds.id and ds.mabn=" + MaBN + " and to_char(ds.NgayUD,'DDMMYY')='" + getFormatDDMMYYYY(Ngay) + "'";
            sql = sql.Replace("xxxxx", getdatabase(Ngay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                thanhtoanbhyt.SoPhieu = dset.Tables[0].Rows[0]["SOPHIEU"].ToString();
                thanhtoanbhyt.MaVaoVien = long.Parse(dset.Tables[0].Rows[0]["MAVAOVIEN"].ToString());
                thanhtoanbhyt.IDTTRV = long.Parse(dset.Tables[0].Rows[0]["ID"].ToString());


            }
            catch { }

            return thanhtoanbhyt;
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
        public DataSet f_loadDanhSachDaDuyet(string tungay, string denngay,string dieukien)
       {
        //  string sql="    select TO_CHAR(ds.MABN) MABN,B.HOTEN HOTEN,B.NAMSINH NAMSINH,ds.MAICD ICD10,ds.SOTHE SOTHEBHYT, ";
        //  sql+=" a.SOPHIEU SOTOA,A.sotien TONGTIEN,A.BHYT BHYTTRA,round(A.sotien-a.bhyt,2) BNTRA, ";
        //   sql+="      ds.MAVAOVIEN MAVAOVIEN,            ds.MABV MABV,to_char(A.NGAY,'dd/mm/yyyy') NGAY,B.PHAI GIOITINH , ";
        //   sql+=" ds.NGAYVAO NGAYVAO,ds.NGAYRA NGAYRA,ds.CHANDOAN CHANDOAN,a.THUOC THUOC,a.MAU MAU,a.XETNGHIEM XETNGHIEM, ";
        //   sql+=" A.CDHA CDHA,A.DVKTTHUONG DVKTTHONGTHUONG,A.DVKTCAO DVKTCAO, ";
        //   sql+=" a.VTTH VATTUYTE,a.KHAMBENH TIENKHAM,a.GIUONG GIUONG,a.CPVC CHIPHIVC,a.KHAC KHAC, ";
        //   sql+=" a.TDCN THAMDOCHUCNANG,ds.TRAITUYEN TRAITUYEN,ds.ID  ";
        //    sql+="            from BV115.V_BHYTDS DS ";
        //    sql+=" join BV115.V_BHYTLL a on ds.id=a.id ";
        //    sql += " join btdbn b on b.mabn=ds.mabn ";
        //    sql += " where to_char(a.ngay,'yyyymmdd') between '{tungay}' and '{denngay}'";
        //    sql=sql.Replace("'{tungay}'",f_formatNgay(tungay));
        //    sql=sql.Replace("'{denngay}'",f_formatNgay(denngay));

           string sql = "    select b.SOPHIEU SOPHIEU,TO_CHAR( A.MABN) MABN,bn.HOTEN HOTEN, case when a.MAICD is null then '-' else a.MAICD end  ICD10, ";
           sql += " b.sotien TONGTIEN, b.BHYT BHYTTRA,B.UBNDTRA,round( b.sotien-b.bhyt-B.UBNDTRA,2) BNTRA, kp.tenkp TENKP,";
           sql+="      to_char( b.NGAY,'dd/mm/yyyy') NGAYDUYET,  ";
           sql += "  to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char( A.NGAYRA,'dd/mm/yyyy') NGAYRA, ";
           sql += " case when ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1)=0  then 1 else ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) end   SONGAY, ";
            sql += " A.CHANDOAN CHANDOAN,b.THUOC THUOC,b.MAU MAU,b.XETNGHIEM XETNGHIEM, ";
           sql+=" b.CDHA CDHA, b.DVKTTHUONG DVKTTHONGTHUONG, b.DVKTCAO DVKTCAO, ";
           sql+=" b.VTTH VATTUYTE,b.KHAMBENH TIENKHAM,b.GIUONG GIUONG,b.CPVC CHIPHIVC,b.KHAC KHAC, ";
           sql += " b.TDCN THAMDOCHUCNANG,a.SOTHE SOTHE,to_char(a.tungay,'DD/MM/YYYY') TUNGAY,to_char(a.denngay,'DD/MM/YYYY') DENNGAY, A.TRAITUYEN TRAITUYEN, A.ID ,A.MAKP MAKP ,A.USERID USERID";
           sql += "            from " + schema + ".V_BHYTDS a ";
           sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' {dieukien} ";
            sql+= " order by b.sophieu ";
            sql=sql.Replace("{tungay}",f_formatNgay(tungay));
            sql=sql.Replace("{denngay}",f_formatNgay(denngay));
            sql = sql.Replace("{dieukien}", dieukien);
           
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        public DataSet f_Export_Excel(string tungay, string denngay, string dieukien)
        {
            string sql = "    select b.sophieu,LOWER(bn.HOTEN) HOTEN,bn.NAMSINH NAMSINH,to_number(bn.phai)+1 GIOITINH ";
            sql += " ,SUBSTR(a.SOTHE,1,15) MATHE,SUBSTR(a.SOTHE,-5,5) MA_DKBD,CASE(INSTR( a.MAICD,';')) ";
            sql += " WHEN -1 THEN a.MAICD  WHEN 0 THEN a.MAICD ELSE    SUBSTR(A.MAICD,0, INSTR( a.MAICD,';')-1) END  MABENH ";
            sql += " ,to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO, to_char(A.NGAYRA,'dd/mm/yyyy') NGAYRA ";
            sql += " ,ROUND(A.NGAYRA-A.NGAYVAO)+1 NGAYDTR ";
            sql += " ,b.sotien T_TONGCHI, B.XETNGHIEM T_XN ,b.CDHA+B.TDCN T_CDHA,b.THUOC-b.thuock2 T_THUOC,b.MAU T_MAU ";
            sql += " ,b.DVKTTHUONG T_PTTT,b.VTTH  T_VTYTTTH,0 T_VTYTTT ";
            sql += "  ,b.DVKTCAO T_DVKTC,b.thuock2 T_KTG,b.KHAMBENH T_KHAM,b.CPVC T_VCHUYEN  ";
            sql += "  ,round( b.sotien-b.bhyt,2) T_BNTRA, b.BHYT T_BHTRA ";
            sql += " ,b.ngoaidinhsuat T_NGOAIDS,1 LYDO_VV, ";
            sql += " CASE(INSTR( a.MAICD,';')) WHEN -1 THEN '' WHEN 0 THEN '' ELSE   SUBSTR(a.MAICD,INSTR( a.MAICD,';')+1,LENGTH(A.MAicd)- INSTR( a.MAICD,';')) END  BENHKHAC ";
            sql += " ,'BVND115' NOIKCB ";
            sql += " ,TO_CHAR(b.ngay,'YYYY') NAM_QT,TO_CHAR(b.ngay,'MM') THANG_QT ";
            sql += " ,to_char(A.TUNGAY,'dd/mm/yyyy') GT_TU,to_char(A.DENNGAY,'dd/mm/yyyy') GT_DEN";
            sql += "  ,bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,'' TT_TNGT,a.MABN MABN,a.chandoan CHANDOAN";
            sql += "            from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa    ";
            sql += " join btdquan qu on bn.maqu=qu.maqu     ";
            sql += " join btdtt tt on bn.matt=tt.matt    ";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public string f_gettamung(string mavaovien, DateTime TuNgay, DateTime DenNgay)
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
            return tongtamung;
        }
        private string f_getsqlchiphi(string sqlcp, string mavaovien, DateTime TuNgay, DateTime DenNgay)
        {

            string sqlGroup;
            try
            {
                DateTime dt1 = TuNgay;
                DateTime dt2 = DenNgay.AddMonths(1);
                
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int itu, iden;
                string mmyy = "";
                string str = sqlcp;
                string asql = "";
                bool be = true;
                sqlGroup = " select MAVP,TEN,DVT, SOLUONG,DONGIA DONGIA,kq.soluong*kq.dongia TONGTIEN,0 BHYTTRA,0 BNTRA,MADOITUONG,NGAY,ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,IDKHOA,STTNHOM,NHOM,BHYT,KYTHUAT, TINHTONG,IDNHOMBHYT  ";

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
                            string schema = "medibv115" + mmyy;
                            if(m_option.f_checkExist_Schema(schema))
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
                }
                sql += "           union all ";
                sql += "            select to_char(cd.ngay,'dd/mm/yyyy') ngay, CD.ID ID,cd.mavaovien,cd.maql,cd.mabn,to_char(cd.makp) MAKP,kp.tenkp ,'0' idkhoa, cd.madoituong,  ";
                sql += "            -2   sttnhom,  'Dịch vu kỹ thuật cao chi phí lớn' nhom,-1 MAVP,to_char(cd.ghichu_vn) ten,'Lần' dvt,cd.soluong,cd.dongia,100 bhyt,0 kythuat,2 tinhtong,'6' idnhombhyt  ";
                sql += "            from medibv115.bv_chidinhktc cd  ";
                sql += "            join medibv115.btdkp_bv kp on cd.makp=kp.makp ";

                sqlGroup += sql + "           ) kq ";
                sqlGroup += "           where mavaovien||mabn={ma_vao_vien} and madoituong=1 order by ngay ";
                //sqlGroup += "           group by NGAY,MAVP,TEN,DVT, SOLUONG,DONGIA,MADOITUONG, ID,MAVAOVIEN,MAQL,MABN,MAKP,TENKP,STTNHOM,NHOM,BHYT,KYTHUAT,TINHTONG,IDNHOMBHYT ";
                sqlGroup = sqlGroup.Replace("{ma_vao_vien}", mavaovien);

            }
            catch (Exception ex)
            {
                return "";

            }
            return sqlGroup;
        }
       
        public DataSet f_getv_ttrvkp_ct_ALL(string MaBN, string mavaovien, DateTime TuNgay, DateTime DenNgay,string loai)
        {

            string s_tam_ung = f_gettamung(mavaovien, TuNgay, DenNgay);
            string sqlcp;
           
    
            sqlcp= "           select to_char(cd.ngay,'dd/mm/yyyy') ngay,cd.id ID,cd.mavaovien,cd.maql,cd.mabn,to_char(cd.makp) MAKP,kp.tenkp ,TO_CHAR(cd.idkhoa) idkhoa, cd.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,cd.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,to_char(nhom.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.v_chidinh cd  ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp +="             where cd.madoituong<>5 and kpbh.loaibcbh in ({loai},2) and cd.mavp not in (select ktc.mavp from medibv115.bv_chidinhktc ktc where ktc.mavaovien=cd.mavaovien ) ";
            sqlcp += "           and to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";
            sqlcp += "           union all ";

            sqlcp += "           select to_char(cd.ngay,'dd/mm/yyyy') ngay,CD.ID ID,cd.mavaovien,cd.maql,cd.mabn,to_char(kp.makp) MAKP,kp.tenkp tenkp ,TO_CHAR(cd.idkhoa) idkhoa,cd.madoituong,  case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sqlcp += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,round(cd.giamua,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ,to_char(nhomvp.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.d_tienthuoc cd  ";
            sqlcp += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.d_duockp dkp on cd.makp=dkp.id ";
            sqlcp += "           join medibv115.btdkp_bv kp on dkp.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "           where cd.madoituong<>5 and kpbh.loaibcbh in ({loai},2) ";
            sqlcp += "           and to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";
            sqlcp += "          union all ";

            sqlcp += "           select to_char(kb.ngay,'dd/mm/yyyy') ngay,kb.ID ID,kb.mavaovien,kb.maql,kb.mabn,to_char(kp.makp) MAKP,kp.tenkp tenkp ,TO_CHAR('0') idkhoa,1 madoituong,  case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sqlcp += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,round(td.giamua,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ,to_char(nhomvp.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.bhytthuoc cd  ";
            sqlcp += "           join {data_user}.d_theodoi td on cd.sttt=td.id ";
            sqlcp += "           join {data_user}.bhytkb kb on kb.id=cd.id ";   
            sqlcp += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on kb.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "           where  kpbh.loaibcbh in ({loai},2)    ";
            sqlcp += "           and to_char(kb.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";

            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("@tungay",string.Format("{0:yyyy/MM/dd}",TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));

           

            string sqlgroup = f_getsqlchiphi(sqlcp, mavaovien, TuNgay, DenNgay);

           
            sql = sqlgroup;
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_getv_ttrvkp_ct_ALL_FROMVP(string MaBN, string mavaovien, DateTime TuNgay, DateTime DenNgay, string loai)
        {

            string s_tam_ung = f_gettamung(mavaovien, TuNgay, DenNgay);
            string sqlcp;

            sqlcp = "           select to_char(ct.ngay,'dd/mm/yyyy') ngay,ct.idtonghop ID,ds.mavaovien,ds.maql,ds.mabn,to_char(ct.makp) MAKP,kp.tenkp ,TO_CHAR(cd.id) idkhoa, cd.madoituong,  case when vp.kythuat=0 then -1 else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,ct.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,ct.soluong,ct.dongia,vp.bhyt,vp.kythuat,2 tinhtong ,to_char(nhom.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.v_ttrvds ds  ";
            sqlcp += "           join {data_user}.v_ttrvll ll on ds.id=ll.id     ";
            sqlcp += "           join {data_user}.v_ttrvct ct on ct.id=ds.id     ";
            sqlcp += "           join medibv115.v_giavp vp on ct.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "             where ct.madoituong<>5 and kpbh.loaibcbh in ({loai},2)  ";
            sqlcp += "           and to_char(ds.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";
            /*sqlcp += "           union all ";

            sqlcp += "           select to_char(cd.ngay,'dd/mm/yyyy') ngay,CD.ID ID,cd.mavaovien,cd.maql,cd.mabn,to_char(kp.makp) MAKP,kp.tenkp tenkp ,TO_CHAR(cd.idkhoa) idkhoa,cd.madoituong,  case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sqlcp += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,round(cd.giamua,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ,to_char(nhomvp.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.d_tienthuoc cd  ";
            sqlcp += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.d_duockp dkp on cd.makp=dkp.id ";
            sqlcp += "           join medibv115.btdkp_bv kp on dkp.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "           where cd.madoituong<>5 and kpbh.loaibcbh in ({loai},2) ";
            sqlcp += "           and to_char(cd.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";
            sqlcp += "          union all ";

            sqlcp += "           select to_char(kb.ngay,'dd/mm/yyyy') ngay,kb.ID ID,kb.mavaovien,kb.maql,kb.mabn,to_char(kp.makp) MAKP,kp.tenkp tenkp ,TO_CHAR('0') idkhoa,1 madoituong,  case when vp.kythuat=0 then -1 else nhomvp.stt end  sttnhom,  ";
            sqlcp += "          case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mabd mavp, to_char(vp.ten) ten,to_char(vp.dang) dvt,cd.soluong,round(td.giamua,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ,to_char(nhomvp.idnhombhyt) idnhombhyt";
            sqlcp += "           from {data_user}.bhytthuoc cd  ";
            sqlcp += "           join {data_user}.d_theodoi td on cd.sttt=td.id ";
            sqlcp += "           join {data_user}.bhytkb kb on kb.id=cd.id ";
            sqlcp += "           join medibv115.d_dmbd vp on cd.mabd=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on kb.makp=kp.makp ";
            sqlcp += "           join bv115.btdkp_bhyt kpbh on kp.makp=kpbh.makp ";
            sqlcp += "           where  kpbh.loaibcbh in ({loai},2)    ";
            sqlcp += "           and to_char(kb.ngay,'yyyy/mm/dd') between '@tungay'  and '@denngay' ";*/
            sqlcp = sqlcp.Replace("{loai}", loai);
            sqlcp = sqlcp.Replace("@tungay", string.Format("{0:yyyy/MM/dd}", TuNgay));
            sqlcp = sqlcp.Replace("@denngay", string.Format("{0:yyyy/MM/dd}", DenNgay));

            string sqlgroup = f_getsqlchiphi(sqlcp, mavaovien, TuNgay, DenNgay);


            sql = sqlgroup;
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public string f_loadSoPhieu(string mavaovien, DateTime Ngay)
        {

            string ketqua = "";
            sql = "select th.makho||kb.sotoa sotoa from {database}.bhytkb kb ";
            sql += " join {database}.bhytthuoc th on kb.id=th.id ";
            sql+=" where  kb.mavaovien={mavv} ";
            sql += " group by th.makho||kb.sotoa ";
            
            sql = sql.Replace("{database}", getdatabase(Ngay));
            sql = sql.Replace("{mavv}", mavaovien);
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                ketqua = dset.Tables[0].Rows[0]["SOTOA"].ToString();
                


            }
            catch { }

            return ketqua;
        }
        #endregion
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
        public DataSet f_getv_ttrvkp_ct_BV115(string MaBN,string idduyet)
        {

           
            string sqlcp = "           select ds.mavaovien,ds.mabn,to_char(cd.makp) MAKP,cd.makp idkhoa ,kp.tenkp , cd.madoituong, cd.ngay, case when vp.kythuat=0 then -cd.id_ktcao else nhom.stt end  sttnhom,  ";
            sqlcp += "         case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhom.ten) end nhom,cd.mavp, to_char(vp.ten) ten,to_char(vp.dvt) DVT,cd.soluong,cd.dongia,vp.bhyt,vp.kythuat,2 tinhtong,cd.sotien sotien,cd.bhyttra bhyttra,cd.idnhombhyt idnhombhyt ,ll.tilethe,ll.tilehuong";
            sqlcp += "           from " + schema + ".v_bhytct cd  ";
            sqlcp += "           join " + schema + ".v_bhytds ds on ds.id=cd.id ";
            sqlcp += "           join " + schema + ".v_bhytll ll on ll.id=ds.id ";
            sqlcp += "           join medibv115.v_giavp vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.v_loaivp loai on vp.id_loai=loai.id ";
            sqlcp += "           join medibv115.v_nhomvp nhom on loai.id_nhom=nhom.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += " where     cd.id={idduyet}";
            sqlcp += "           union all ";
            sqlcp += "           select ds.mavaovien,ds.mabn,to_char(kp.makp) MAKP,cd.makp idkhoa,kp.tenkp tenkp ,cd.madoituong, cd.ngay, case when vp.kythuat=0 then -cd.id_ktcao else nhomvp.stt end  sttnhom,  ";
            sqlcp += "           case when vp.kythuat=0 then 'Dịch vu kỹ thuật cao chi phí lớn' else to_char(nhomvp.ten) end nhom, cd.mavp mavp, to_char(vp.ten||' '||vp.hamluong) ten,to_char(vp.dang) dvt,cd.soluong,round(cd.dongia,2) dongia,vp.bhyt,vp.kythuat,1 tinhtong ,cd.sotien sotien,cd.bhyttra bhyttra,cd.idnhombhyt idnhombhyt,ll.tilethe,ll.tilehuong ";
            sqlcp += "           from " + schema + ".v_bhytct cd  ";
            sqlcp += "           join " + schema + ".v_bhytds ds on ds.id=cd.id ";
            sqlcp += "           join " + schema + ".v_bhytll ll on ll.id=ds.id ";
            sqlcp += "           join medibv115.d_dmbd vp on cd.mavp=vp.id ";
            sqlcp += "           join medibv115.d_dmnhom nhomd on vp.manhom=nhomd.id ";
            sqlcp += "           join medibv115.v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma ";
            sqlcp += "           join medibv115.btdkp_bv kp on cd.makp=kp.makp ";
            sqlcp += " where     cd.id={idduyet}";


            string sqlGroup = " select MAVAOVIEN,MABN,MAKP,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,DONGIA DONGIA,BHYT,KYTHUAT, TINHTONG,sum(SOLUONG) SOLUONG,sum(kq.sotien) TONGTIEN, sum(BHYTTRA) BHYTTRA,sum(SOTIEN-BHYTTRA) BNTRA ,tilethe,tilehuong";
            sqlGroup += "           from ";
            sqlGroup += "           ( ";
            sqlGroup += sqlcp;
            sqlGroup += "           ) kq ";
            
            sqlGroup += "           group by MAVAOVIEN,MABN,MAKP,TENKP,MADOITUONG,STTNHOM,NHOM,MAVP,TEN,DVT,DONGIA,BHYT,KYTHUAT,TINHTONG,TILETHE,TILEHUONG ";

            sql  = " select 0 DONE,'1' LOAIBA,1 MADOITUONGVAO, 0 MATT,ba.mabn MABN,ba.mavaovien MAVAOVIEN,ba.maql MAQL, 0 IDKHOA, ";
            sql += " bn.hoten HOTEN,bn.namsinh NAMSINH, TO_CHAR(bn.phai) PHAI,  bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI ,  ";
            sql += " cd.madoituong MADOITUONG,dt.doituong DOITUONG, ba.sothe SOTHE,ba.maphu MAPHU, ";
            sql += " to_char(ba.tungay,'dd/mm/yyyy')||'^'||to_char(ba.denngay,'dd/mm/yyyy') DENNGAY,  '^' NOIGIOITHIEU, ba.mabv||'^'||ndk.tenbv NOICAP, ";
            sql += " '-' GIUONG,  to_char(cd.makp) MAKP,cd.tenkp TENKP,to_char(ba.ngayvao,'hh24:mi dd/mm/yyyy') NGAYVAO,to_char(ba.ngayra,'hh24:mi dd/mm/yyyy') NGAYRA, ";
            sql += " ba.chandoan  CHANDOAN,ba.maicd MAICD,cd.sttnhom STTNHOM ,cd.nhom NHOM,  case when cd.bhyt=100 then 1 else 2 end STTLOAI,  ";
            sql += " case when cd.bhyt=100 then 'Trong danh mục BHYT' else 'Ngoài danh mục BHYT' end LOAI,  to_char(ba.ngayra,'hh24:mi dd/mm/yyyy') NGAY,   ";
            sql += " cd.mavp MA,cd.ten TEN,cd.DVT DVT,cd.soluong SOLUONG,cd.dongia DONGIA,cd.TONGTIEN sotien, 0 TAMUNG, ";
            sql += " case when cd.madoituong='1' and not (substr(ba.sothe,0,2)='GD' and ba.huongktc=0  and cd.kythuat=0 ) then tl.bhyttra else 0 end BHYT,0 BHYT0117, ";
            sql += " case when cd.madoituong='7' then cd.TONGTIEN else 0 end TCSOTIEN,0 DICHSO,0 MIEN,  ";
            sql += " cd.bhyttra BHYTTRA,  ";
            sql += " cd.tongtien-cd.bhyttra BNTRA,0 DICHSOTRA,  ";
            sql += " 0 SBLTAMUNG,'' SOLUUTRU,  '' NGUOINHA,1 PHUONGPHAP,1 HINHTHUC,'' KETQUA,'' KHU,'' NGAYPT,  0 TENPT,0	MASO,0	SOPHIEU, ";
            sql += " 0	LANIN,''	Image,''	Imagetk,0	Imageuser, '-' mabs,'-' tenbs,kprv.tenkp makprv,'' cholam,0 gianovat, ";
            sql += " 0 idttrv,0 sotientra,ba.traituyen traituyen,  cd.soluong*cd.dongia vattu,TO_CHAR(sysdate) ngay1,TO_CHAR(sysdate) ngay2,TO_CHAR(sysdate) ngay3, ";
            sql += " TO_CHAR(sysdate) ngaytrinh,sysdate ngayduyet,cd.kythuat kythuat, cd.dongia m_gia_bhyt, ";
            sql += " cd.tongtien m_thanhtien, ";
            sql += " cd.bhyttra m_bhyt_tra, ";
            sql += " case when cd.madoituong='2' then cd.tongtien else 0 end  m_benhnhan_thuphi, ";
            sql += " case when cd.madoituong='7' then cd.tongtien else 0 end m_benhnhan_dichvu, ";
            sql += " case when cd.madoituong='1'  then cd.tongtien-cd.bhyttra end  m_benhnhan_khac, 0  m_diengiai,  cd.tinhtong,	172500 m_giatranbhyt,'Khác'	lydocapcuu, ";
            sql += " 0	thanhtoandot,''	tenhc   ,to_char(TILETHE) TYLETHE,to_char(TILEHUONG)    TYLEHUONG    ";
            sql += " from " + schema + ".v_bhytds ba     ";
            sql += " join btdbn bn on ba.mabn=bn.mabn      ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa    ";
            sql += " join btdquan qu on bn.maqu=qu.maqu     ";
            sql += " join btdtt tt on bn.matt=tt.matt    ";
            sql += " join ( ";


            sql += "            {sql_chiphi}   ) cd on ba.mavaovien=cd.mavaovien    ";
            sql += " join doituong dt on cd.madoituong=dt.madoituong     ";
            sql += " join DMNOICAPBHYT  ndk on ndk.mabv=ba.mabv     ";
            sql += " join bv_tilebhyt tl on tl.kytu=substr(ba.sothe,3,1) and ba.traituyen=tl.traituyen    ";
            sql += " join btdkp_bv kprv on kprv.makp=ba.makp    ";
            sql += " where  ba.id={idduyet}  ";


            int kq = 0;

            sql = sql.Replace("{MABN}", MaBN);
           
            sql = sql.Replace("{sql_chiphi}", sqlGroup);
            sql = sql.Replace("{idduyet}", idduyet);
            //sql = sql.Replace("{ngay_ra}", String.Format("{0:dd/MM/yyyy HH:mm}", DenNgay));
            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);

            }
            catch { }
            return dset;
        }
        public DataSet f_loadBCMau79_80(string tungay, string denngay,string loaibn,bool canngheo,string KTCAO,string ThuocUT)
        {
            string sql =" select   A.MABN MABN,BN.HOTEN HOTEN,BN.NAMSINH NAMSINH,A.MAICD ICD10,A.SOTHE SOTHEBHYT,B.SOPHIEU SOTOA,B.SOTIEN TONGTIEN, ";
            sql+= " B.BHYT BHYTTRA,B.SOTIEN-B.BHYT BNTRA, BV.TENBV TENBV,'701' MATINH, ";
            sql+= "  case when a.MABV='79024' then 1 else  case when a.traituyen=0 then 2 else 3 end end  MANHOMTHE, ";

            sql += " case when a.MABV='79024' then (select tennhom from BV115.NHOMMATHE where id=1) ";
            sql += " else  case when a.traituyen=0 then (select tennhom from BV115.NHOMMATHE where id=2) ";
            sql += " else (select tennhom from BV115.NHOMMATHE where id=3) end end NHOMTHE, ";
            sql+= "  SUBSTR(a.sothe,0,2) LOAITHE,A.ID IDTTRV,A.MAVAOVIEN MAVAOVIEN, ";
            sql+= " A.MABV MABV,to_char(A.TUNGAY,'DD/MM/YYYY') TUNGAY,to_char(A.DENNGAY,'DD/MM/YYYY') NGAYHD,'' SOBIENLAI,BN.PHAI GIOITINH , ";
            sql+= " A.NGAYVAO NGAYVAO,A.NGAYRA NGAYRA,B.LOAI LOAIBN, ";
            sql+= " A.CHANDOAN CHANDOAN,B.THUOC THUOC,B.MAU MAU,B.XETNGHIEM XETNGHIEM, ";
            sql+= " B.CDHA CDHA,B.DVKTTHUONG DVKTTHONGTHUONG,B.DVKTCAO DVKTCAO, ";
            sql+= " B.VTTH VATTUYTE,B.KHAMBENH TIENKHAM,B.GIUONG GIUONG,B.CPVC CHIPHIVC,B.KHAC KHAC, ";
            sql+= " B.TDCN THAMDOCHUCNANG,'1011' MMYY,to_char(b.ngay,'DD/MM/YYYY') NGAYLAMVIEC, ";
            sql+= " A.TRAITUYEN TRAITUYEN,A.ID ID ";
            sql += " from " + schema + ".V_BHYTDS a  ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id  ";
            sql+= " join btdbn bn on a.mabn=bn.mabn  ";
            sql+= " join dmnoicapbhyt bv on bv.mabv=a.mabv ";
            sql+= " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' ";
            if (canngheo)
            {
                sql += " and substr(a.SOTHE,0,2) in ('CN') and substr(a.mabv,0,2) in ('79') and b.sotien-b.bhyt>0 ";
            }

            

            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }

        public DataSet f_loadBCMau79_80_DK(string tungay, string denngay, string loaibn, bool canngheo, string KTCAO, string ThuocUT,string dieukien)
        {
            string sql = " select   A.MABN MABN,BN.HOTEN HOTEN,BN.NAMSINH NAMSINH,A.MAICD ICD10,A.SOTHE SOTHEBHYT,B.SOPHIEU SOTOA,B.SOTIEN TONGTIEN, ";
            sql += " B.BHYT BHYTTRA,B.SOTIEN-B.BHYT BNTRA, BV.TENBV TENBV,'701' MATINH, ";
            sql += "  case when substr(a.sothe,-5,5)='79024' then 1 else  case when a.traituyen=0 then 2 else 3 end end  MANHOMTHE, ";

            sql += " case when substr(a.sothe,-5,5)='79024' then (select tennhom from BV115.NHOMMATHE where id=1) ";
            sql += " else  case when a.traituyen=0 then (select tennhom from BV115.NHOMMATHE where id=2) ";
            sql += " else (select tennhom from BV115.NHOMMATHE where id=3) end end NHOMTHE, ";
            sql += "  SUBSTR(a.sothe,0,2) LOAITHE,A.ID IDTTRV,A.MAVAOVIEN MAVAOVIEN, ";
            sql += " A.MABV MABV,to_char(A.TUNGAY,'DD/MM/YYYY') TUNGAY,to_char(A.DENNGAY,'DD/MM/YYYY') NGAYHD,'' SOBIENLAI,BN.PHAI GIOITINH , ";
            sql += " A.NGAYVAO NGAYVAO,A.NGAYRA NGAYRA,B.LOAIBN LOAIBN, ";
            sql += " A.CHANDOAN CHANDOAN,B.THUOC THUOC,B.THUOCK THUOCK,B.MAU MAU,B.XETNGHIEM XETNGHIEM, ";
            sql += " B.CDHA+B.TDCN CDHA,B.DVKTTHUONG DVKTTHONGTHUONG,B.DVKTCAO DVKTCAO, ";
            sql += " B.VTTH VATTUYTE,B.KHAMBENH+B.GIUONG TIENKHAM,B.GIUONG GIUONG,B.NGOAIDINHSUAT NGOAIDS,B.KHAC CHIPHIVC,0 KHAC,B.VTYTTL,B.THUOCK THUOCTL, ";
            sql += " B.TDCN THAMDOCHUCNANG,'1011' MMYY,to_char(A.ngayvao,'DD/MM/YYYY')||' - '||to_char(A.ngayra,'DD/MM/YYYY') NGAYLAMVIEC, ";
            sql += " A.TRAITUYEN TRAITUYEN,A.ID ID ,case when ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1)=0  then 1 else ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) end   SONGAY";
            sql += " from " + schema + ".V_BHYTDS a  ";
            sql += " inner join " + schema + ".V_BHYTLL b on  a.id=b.id  ";
            sql += " inner join btdbn bn on a.mabn=bn.mabn  ";
            sql += " left join dmnoicapbhyt bv on bv.mabv=substr(a.sothe,-5,5) ";// a.mabv 
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien";
            //if (canngheo)
            //{
            //    sql += " and substr(a.SOTHE,0,2) in ('CN') and substr(a.mabv,0,2) in ('79') and b.sotien-b.bhyt>0 ";
            //}



            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        public DataSet f_loadBCMau20(string tungay, string denngay, string dieukien, bool canngheo, string dsnhombhyt, string ThuocUT,string s_madoituong)
        {
            string sql = " select x.mavp mabd,dm.ten ten,dm.hamluong,round(x.dongia,2) dongia,sum(x.soluong) soluong, ";
            sql+=" round(x.dongia,2)*round(sum(x.soluong),2) sotien,BHKP.KHOXUAT tenkho,dm.tenhc,dm.dang||'-'||dm.duongdung dang,dm.sodk QD05, ";
            sql+="  nc.ten tennuoc,h.ten tenhang ";
            sql+="  from BV115.v_bhytct x  ";
            sql += " join " + schema + ".v_bhytll b on b.id=x.id ";
            sql += " join " + schema + ".v_bhytds a on a.id=b.id ";
            sql += " join " + schema + ".BTDKP_BHYT BHKP ON BHKP.MAKP=X.MAKP ";
           // sql += " join BV115.v_bhytds ds on ds.id=ll.id ";
            sql+=" join d_dmbd dm on x.mavp=dm.id  ";
            sql+=" join d_dmnuoc nc on nc.id=dm.manuoc  ";
            sql+=" join d_dmhang h on dm.mahang=h.id  ";
            sql+=" join d_dmnhom nhomd on dm.manhom=nhomd.id  ";
            //sql+=" join v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma  ";
            sql += " where   to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' and  x.idnhombhyt  in (@nhombhyt) and x.madoituong="+s_madoituong+" @dieukien";
            sql+=" group by x.mavp,dm.ten,dm.hamluong,round(x.dongia,2) ,dm.tenhc,dm.dang||'-'||dm.duongdung,dm.sodk,  ";
            sql += " nc.ten,h.ten,BHKP.KHOXUAT  ";

            
            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        public DataSet f_loadBCMau20_XuatExcel(string tungay, string denngay, string dieukien, bool canngheo, string dsnhombhyt, string ThuocUT)
        {
            string sql = "";
            sql = "	select nbhyt.ten tennhom,dm.stt_27,dm.soqd_27,dm.apthau_27,kq.mavp ,dm.ten tenvp,dm.hamluong,dm.tenhc,dm.dang donvi,dm.duongdung dang,dm.sodk QD05,nc.ten tennuoc,h.ten tenhang, kq.dongia,  ";	  
            sql+="	SUM(kq.slngoaitru) SLNGOAITRU,sum(kq.slnoitru) SLNOITRU,	  ";
            sql+="	 kq.dongia*SUM(kq.slngoaitru) THANHTIEN_NGOAITRU,	  ";
            sql+="	 kq.dongia*SUM(kq.slnoitru) THANHTIEN_NOITRU	  ";
            sql+="	from (	  ";
            sql+="	 select ct.makp, ct.idnhombhyt idnhombhyt,ct.mavp mavp,round(ct.dongia,2),dongia,	  ";
            sql+="	 case when b.loaibn=1 then round(ct.soluong,2) else 0 end slngoaitru,	  ";
            sql+="	 case when b.loaibn=0 then round(ct.soluong,2) else 0 end slnoitru	  ";
            sql += "	 from " + schema + ".v_bhytct ct  	  ";
            sql += "	 join " + schema + ".v_bhytll b on b.id=ct.id 	  ";
            sql += "	 join " + schema + ".v_bhytds a on a.id=b.id  	  ";
            sql+="	 where     to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' 	  ";
            sql+="	 and ct.idnhombhyt in (@nhombhyt)  and ct.madoituong=1 	 @dieukien ";
            sql+="	 ) kq	  ";
            sql += "	 join " + schema + ".BTDKP_BHYT BHKP ON BHKP.MAKP=kq.MAKP  	  ";
            sql+="	 join d_dmbd dm on kq.mavp=dm.id  	";
            sql+="	 join d_dmnuoc nc on nc.id=dm.manuoc 	  ";
            sql+="	 join d_dmhang h on dm.mahang=h.id  	  ";
            sql+="	 join d_dmnhom nhomd on dm.manhom=nhomd.id  	  ";
            sql+="	 join v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma 	  ";
            sql += "	 inner join " + schema + ".v_nhombhyt nbhyt on nbhyt.id=kq.idnhombhyt 	  ";
            sql += "	 group by nbhyt.ten ,dm.stt_27,dm.soqd_27,dm.apthau_27,kq.mavp ,dm.ten , dm.hamluong,dm.tenhc,dm.dang,dm.duongdung,dm.sodk,nc.ten,h.ten,kq.dongia	  ";



            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }

        public DataSet f_loadBCMau20_XuatExcel2(string tungay, string denngay, string dieukien, bool canngheo, string dsnhombhyt, string ThuocUT,string s_madoituong)
        {
            string sql = "";
            sql = "	select nbhyt.ten tennhom,dm.STT_27 DT_STT,dm.STT_27 DT_BV,dm.stt_27 DT_NGAY,dm.soqd_27 DT_NHOM,kq.mavp GHICHU ,kq.mavp masobyt,dm.tenhc TENHC,dm.ten TENVP,dm.duongdung DUONGDUNG,dm.dang DANGBAOCHE,dm.hamluong HAMLUONG,dm.dang DANGTRINHBAY,h.ten TENHANG,nc.ten TENNUOC,dm.sodk SOGIAYPHEP, dm.dang DONVI,kq.dongia GIAMUA,kq.dongia giattbh,  ";
            sql += "	SUM(kq.slngoaitru) SLNGOAITRU,sum(kq.slnoitru) SLNOITRU,	  ";
            sql += "	 kq.dongia*SUM(kq.slngoaitru) THANHTIEN_NGOAITRU,	  ";
            sql += "	 kq.dongia*SUM(kq.slnoitru) THANHTIEN_NOITRU	  ";
            sql += "	from (	  ";
            sql += "	 select ct.makp, ct.idnhombhyt idnhombhyt,ct.mavp mavp,round(ct.dongia,2) dongia,	  ";
            sql += "	 case when b.loaibn=1 then round(ct.soluong,2) else 0 end slngoaitru,	  ";
            sql += "	 case when b.loaibn=0 then round(ct.soluong,2) else 0 end slnoitru	  ";
            sql += "	 from " + schema + ".v_bhytct ct  	  ";
            sql += "	 join " + schema + ".v_bhytll b on b.id=ct.id 	  ";
            sql += "	 join " + schema + ".v_bhytds a on a.id=b.id  	  ";
            sql += "	 where     to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' 	  ";
            sql += "	 and ct.idnhombhyt in (@nhombhyt)  and ct.madoituong=" + s_madoituong + " and ct.dongia<>0	 @dieukien ";
            sql += "	 ) kq	  ";
            sql += "	 join " + schema + ".BTDKP_BHYT BHKP ON BHKP.MAKP=kq.MAKP  	  ";
            sql += "	 join d_dmbd dm on kq.mavp=dm.id  	";
            sql += "	 join d_dmnuoc nc on nc.id=dm.manuoc 	  ";
            sql += "	 join d_dmhang h on dm.mahang=h.id  	  ";
            sql += "	 join d_dmnhom nhomd on dm.manhom=nhomd.id  	  ";
            sql += "	 join v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma 	  ";
            sql += "	 inner join " + schema + ".v_nhombhyt nbhyt on nbhyt.id=kq.idnhombhyt 	  ";
            sql += "	 group by nbhyt.ten ,dm.STT_21,dm.STT_6282,dm.stt_27,dm.soqd_27,dm.apthau_27,kq.mavp ,dm.ten , dm.hamluong,dm.tenhc,dm.dang,dm.duongdung,dm.sodk,nc.ten,h.ten,kq.dongia	  ";



            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        
        public DataSet f_loadBCMau20DK(string tungay, string denngay, string dieukien, bool canngheo, string dsnhombhyt, string DieuKien)
        {
            string sql = " select x.mavp mabd,dm.ten ten,dm.hamluong,round(x.dongia,2) dongia,sum(x.soluong) soluong, ";
            sql += " round(x.dongia,2)*round(sum(x.soluong),2) sotien,BHKP.KHOXUAT tenkho,dm.tenhc,dm.dang||'-'||dm.duongdung dang,dm.sodk QD05, ";
            sql += "  nc.ten tennuoc,h.ten tenhang,BHKP.KHOXUAT ";
            sql += "  from " + schema + ".v_bhytct x  ";
            sql += " join " + schema + ".v_bhytll b on b.id=x.id ";
            sql += " join " + schema + ".BTDKP_BHYT BHKP ON BHKP.MAKP=X.MAKP ";
            sql += " join " + schema + ".v_bhytds a on a.id=b.id ";
            sql += " join d_dmbd dm on x.mavp=dm.id  ";
            //sql += " join bv115.d_dmbdbh dbh on dbh.id=x.mavp ";
            sql += " join d_dmnuoc nc on nc.id=dm.manuoc  ";
            sql += " join d_dmhang h on dm.mahang=h.id  ";
            sql += " join d_dmnhom nhomd on dm.manhom=nhomd.id  ";
            sql += " join v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma  ";
            sql += " where   to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' and  nhomvp.idnhombhyt  in (@nhombhyt) and x.thuock=1 and x.madoituong=1 @dieukien";
            sql += " group by x.mavp,dm.ten,dm.hamluong,round(x.dongia,2) ,dm.tenhc,dm.dang||'-'||dm.duongdung,dm.sodk,  ";
            sql += " nc.ten,h.ten,BHKP.KHOXUAT  ";


            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
           // sql = sql.Replace("{loaibn}", loaibn);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        public DataSet f_loadBCMau21(string tungay, string denngay, string dieukien, bool VTYT, string dsnhombhyt, string ThuocUT)
        {
            string sql = " select ct.mavp mabd,vp.ten,round(ct.dongia,2) dongia,nbhyt.ten tenkho, ";
            sql+= " round(ct.soluong,2) soluong, round(ct.dongia,2)*round(ct.soluong,2) sotien " ;
            sql += " from " + schema + ".v_bhytct ct ";
            sql += " join " + schema + ".v_bhytll b on b.id=ct.id ";
            sql += " join " + schema + ".v_bhytds a on a.id=b.id ";
            sql += " join v_giavp vp on ct.mavp=vp.id ";

            sql += " join " + schema + ".v_nhombhyt nbhyt on nbhyt.id=ct.idnhombhyt ";
            sql += " where     to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' and nbhyt.id in (@nhombhyt)  and ct.madoituong=1 and ct.dongia<>0 @dieukien";

            if (VTYT)
            {
                sql = " select x.mavp mabd,dm.ten ten,dm.hamluong,round(x.dongia,2) dongia,sum(x.soluong) soluong, ";
                sql += " round(x.dongia,2)*round(sum(x.soluong),2) sotien,nhomvp.ten tenkho,dm.tenhc,dm.dang||'-'||dm.duongdung dang,dm.sodk QD05, ";
                sql += "  nc.ten tennuoc,h.ten tenhang ";
                sql += "  from " + schema + ".v_bhytct x  ";
                sql += " join " + schema + ".v_bhytll b on b.id=x.id ";
                sql += " join " + schema + ".v_bhytds a on a.id=b.id ";
                sql += " join d_dmbd dm on x.mavp=dm.id  ";
                sql += " join d_dmnuoc nc on nc.id=dm.manuoc  ";
                sql += " join d_dmhang h on dm.mahang=h.id  ";
                sql += " join d_dmnhom nhomd on dm.manhom=nhomd.id  ";
                sql += " join v_nhomvp nhomvp on nhomd.nhomvp=nhomvp.ma  ";
                sql += " where    to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' and nhomvp.idnhombhyt in (@nhombhyt)  and x.madoituong=1 @dieukien";
                sql += " group by x.mavp,dm.ten,dm.hamluong,round(x.dongia,2) ,dm.tenhc,nhomvp.ten,dm.dang||'-'||dm.duongdung,dm.sodk,  ";
                sql += " nc.ten,h.ten ";
            }

            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }
        public DataSet f_loadBCMau21_XuatExcel(string tungay, string denngay, string dieukien, bool VTYT, string dsnhombhyt, string ThuocUT)
        {
            string sql = "";
            sql = "	select 0 stt,nbhyt.ten tennhom,vp.ma mahoa1,loaivp.ma mahoa2,kq.mavp ,vp.ten tenvp, kq.dongia,	  ";
            sql+="	SUM(kq.slngoaitru) SLNGOAITRU,sum(kq.slnoitru) SLNOITRU,	  ";
            sql+="	 kq.dongia*SUM(kq.slngoaitru) THANHTIEN_NGOAITRU,	  ";
            sql+="	 kq.dongia*SUM(kq.slnoitru) THANHTIEN_NOITRU	  ";
            sql+="	from (	  ";
            sql+="	 select ct.idnhombhyt idnhombhyt,ct.mavp mavp,round(ct.dongia,2),dongia,	  ";
            sql+="	 case when b.loaibn=1 then round(ct.soluong,2) else 0 end slngoaitru,	  ";
            sql+="	 case when b.loaibn=0 then round(ct.soluong,2) else 0 end slnoitru	  ";
            sql += "	 from " + schema + ".v_bhytct ct  	  ";
            sql += "	 join " + schema + ".v_bhytll b on b.id=ct.id 	  ";
            sql += "	 join " + schema + ".v_bhytds a on a.id=b.id  	  ";
            sql+="	 where     to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' 	  ";
            sql+="	 and ct.idnhombhyt in (@nhombhyt)  and ct.madoituong=1 and ct.dongia<>0	@dieukien  ";
            sql+="	 ) kq	  ";
            sql+="	     inner join v_giavp vp on kq.mavp=vp.id 	  ";
            sql += "	 inner join v_loaivp loaivp on loaivp.id=vp.id_loai 	  ";
            sql += "	 inner join " + schema + ".v_nhombhyt nbhyt on nbhyt.id=kq.idnhombhyt 	  ";
            sql += "	 group by nbhyt.ten ,vp.ma ,loaivp.ma,kq.mavp ,vp.ten , kq.dongia	  ";

            sql = sql.Replace("{tungay}", f_formatNgay(tungay));
            sql = sql.Replace("{denngay}", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);
            sql = sql.Replace("@nhombhyt", dsnhombhyt);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);


            }
            catch { }

            return dset;
        }

        public DataSet f_Export_Excel2(string tungay, string denngay, string dieukien)
        {
            string sql = " select b.sophieu,a.mabn||'_'||b.sophieu mabn,LOWER(bn.HOTEN) HOTEN,";
            sql += " case when bn.ngaysinh is null or bn.ngaysinh='' then bn.NAMSINH else to_char(bn.ngaysinh,'yyyy') end as NAMSINH,";
            sql += " to_number(bn.phai)+1 GIOITINH ";
            sql += " ,SUBSTR(a.SOTHE,1,15) MATHE,SUBSTR(a.SOTHE,-5,5) MA_DKBD,CASE(INSTR( a.MAICD,';')) ";
            sql += " WHEN -1 THEN a.MAICD  WHEN 0 THEN a.MAICD ELSE SUBSTR(A.MAICD,0, INSTR( a.MAICD,';')-1) END MABENH ";
            sql += " ,to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char(A.NGAYRA,'dd/mm/yyyy') NGAYRA ";
            sql += " ,case when ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1)=0  then 1 else ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) end    songay ";
            sql += " ,b.sotien T_TONGCHI, B.XETNGHIEM T_XN ,b.CDHA+B.TDCN T_CDHA,b.THUOC T_THUOC,b.MAU T_MAU ";
            sql += " ,b.DVKTTHUONG T_PTTT,b.VTTH  T_VTYTTTH,b.VTYTTL T_VTYTTT ";
            sql += "  ,b.DVKTCAO T_DVKTC,b.thuock T_KTG,B.KHAMBENH+B.GIUONG T_KHAM,b.CPVC+b.khac T_VCHUYEN ";
            sql += "  ,round( b.sotien-b.bhyt,2) T_BNTRA, b.BHYT T_BHTRA ";
            sql += " ,b.ngoaidinhsuat T_NGOAIDS,a.traituyen LYDO_VV, ";
            sql += " CASE(INSTR( a.MAICD,';')) WHEN -1 THEN '' WHEN 0 THEN '' ELSE   SUBSTR(a.MAICD,INSTR( a.MAICD,';')+1,LENGTH(A.MAicd)- INSTR( a.MAICD,';')) END  BENHKHAC ";
            sql += " ,'BVND115' NOIKCB,kp.tenkp as khoa";
            sql += " ,TO_CHAR(b.ngay,'YYYY') NAM_QT,TO_CHAR(b.ngay,'MM') THANG_QT ";
            sql += " ,to_char(A.TUNGAY,'dd/mm/yyyy') GT_TU,to_char(A.DENNGAY,'dd/mm/yyyy') GT_DEN";
            sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,";
            // sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,";
            sql += " '' TT_TNGT,a.MABN MABN,a.chandoan CHANDOAN";
            sql += "  ,case when a.MABV='79024' then 1 else  case when substr(a.mabv,0,2)='79' and a.mabv!='79024' then 2 else 3 end end  MANHOMTHE, ";
            sql += "  case when a.MABV='79024' then 'Bệnh nhân nội tỉnh, khám, chữa bệnh ban đầu' else  case when substr(a.mabv,0,2)='79' and a.mabv!='79024' then 'Bệnh nhân nội tỉnh đến' else 'Bệnh nhân ngoại tỉnh đến' end end  NHOMTHE ";
            sql += " from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa ";
            sql += " join btdquan qu on bn.maqu=qu.maqu ";
            sql += " join btdtt tt on bn.matt=tt.matt";
            sql += " inner join btdkp_bv kp on a.makp=kp.makp ";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_Excel_M79_80(string tungay, string denngay, string dieukien)
        {
            string sql = " select case when a.MABV='79024' then '1.Bệnh nhân nội tỉnh, khám, chữa bệnh ban đầu' else  case when substr(a.mabv,0,2)='79' and a.mabv!='79024' then '2.Bệnh nhân nội tỉnh đến' else '3.Bệnh nhân ngoại tỉnh đến' end end  NHOMBAOCAO ,'BENH NHAN KCB' TUYENBAOCAO";
            sql += " ,UPPER(bn.HOTEN) HOTEN";
            sql += " ,case when bn.ngaysinh is null or bn.ngaysinh='' then bn.NAMSINH else to_char(bn.ngaysinh,'yyyy') end as NAMSINH ";
            sql += " ,to_number(bn.phai)+1 GIOITINH ";
            sql += " ,SUBSTR(a.SOTHE,1,15) MATHE,SUBSTR(a.SOTHE,-5,5) MA_DKBD,CASE(INSTR( a.MAICD,';')) ";
            sql += " WHEN -1 THEN a.MAICD  WHEN 0 THEN a.MAICD ELSE SUBSTR(A.MAICD,0, INSTR( a.MAICD,';')-1) END MABENH ";
            sql += " ,to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char(A.NGAYRA,'dd/mm/yyyy') NGAYRA ";
            sql += " ,ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY')) NGAYDTRI ";
            sql += " , B.XETNGHIEM T_XN ,b.CDHA+B.TDCN T_CDHA,b.THUOC T_THUOCDT,b.thuock T_THUOC_TILE,b.MAU T_MAU ";
            sql += " ,b.DVKTTHUONG T_PTTT,b.VTTH  T_VTYT,b.VTYTTL T_VTYT_TILE ";
            sql += "  ,b.DVKTCAO T_DVKTC_TILE,b.KHAMBENH+b.GIUONG T_KHAM,b.CPVC T_CPVC ";
            sql += "  ,b.sotien T_TONGCP,round( b.sotien-b.bhyt,2) T_BNTRA, b.BHYT T_BHTRA ";
            sql += " ,b.ngoaidinhsuat T_NGOAIDS,1 LYDO_VV, ";
            sql += " CASE(INSTR( a.MAICD,';')) WHEN -1 THEN '' WHEN 0 THEN '' ELSE   SUBSTR(a.MAICD,INSTR( a.MAICD,';')+1,LENGTH(A.MAicd)- INSTR( a.MAICD,';')) END  BENHKHAC ";
            sql += " ,'BVND115' NOIKCB,kp.tenkp as khoa";
            sql += " ,TO_CHAR(b.ngay,'YYYY') NAM_QT,TO_CHAR(b.ngay,'MM') THANG_QT ";
            sql += " ,to_char(A.TUNGAY,'dd/mm/yyyy') GT_TU,to_char(A.DENNGAY,'dd/mm/yyyy') GT_DEN";
            sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,b.CHIPHI20_NGOAI T_TNT_NGOAI,b.CHIPHI31_NGOAI T_THAMPHAN_NGOAI,b.CHIPHI32_NGOAI T_THUOC_UT_NGOAI,b.KTUNGBUOU_NGOAI T_KYTHUATUB_NGOAI,";
            // sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,";
            sql += " '' TT_TNGT,a.MABN MABN,a.chandoan CHANDOAN,";
            sql += " b.sophieu ";
            sql += " from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa ";
            sql += " join btdquan qu on bn.maqu=qu.maqu ";
            sql += " join btdtt tt on bn.matt=tt.matt";
            sql += " inner join btdkp_bv kp on a.makp=kp.makp ";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_Excel_M79_80_SYT(string tungay, string denngay, string dieukien)
        {
            string sql = " select to_char(a.id) ma_lk,ROW_NUMBER() OVER (ORDER BY a.sothe)  stt,to_char(a.mabn) ma_bn ";
            sql += " ,UPPER(bn.HOTEN) hoten";
            sql += " ,case when bn.ngaysinh is null or bn.ngaysinh='' then to_char(bn.NAMSINH) else to_char(bn.ngaysinh,'yyyymmdd') end as ngay_sinh ";
            sql += " ,to_number(bn.phai)+1 gioi_tinh, bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt dia_chi";
            sql += " ,SUBSTR(a.SOTHE,1,15) ma_the,SUBSTR(a.SOTHE,-5,5) ma_dkbd ";
            sql += " ,to_char(A.TUNGAY,'yyyymmdd') gt_the_tu,to_char(A.DENNGAY,'yyyymmdd') gt_the_den ";
            sql += " ,CASE(INSTR( a.MAICD,';')) WHEN -1 THEN a.MAICD  WHEN 0 THEN a.MAICD ELSE SUBSTR(A.MAICD,0, INSTR( a.MAICD,';')-1) END ma_benh ";
            sql += " ,CASE(INSTR( a.MAICD,';')) WHEN -1 THEN '' WHEN 0 THEN '' ELSE   SUBSTR(a.MAICD,INSTR( a.MAICD,';')+1,LENGTH(A.MAicd)- INSTR( a.MAICD,';')) END  ma_benhkhac ";
            sql += " ,a.chandoan ten_benh,a.traituyen ma_lydo_vvien,' ' ma_noi_chuyen,' ' ma_tai_nan ";
            sql += " ,to_char(A.NGAYVAO,'yyyymmddHH24mi ') NGAY_VAO,to_char(A.NGAYRA,'yyyymmddHH24mi') NGAY_RA ";
            sql += " ,ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY')) so_ngay_dtri ";
            //sql += " , B.XETNGHIEM T_XN ,b.CDHA+B.TDCN T_CDHA,b.THUOC T_THUOCDT,b.thuock T_THUOC_TILE,b.MAU T_MAU ";
            //sql += " ,b.DVKTTHUONG T_PTTT,b.VTTH  T_VTYT,b.VTYTTL T_VTYT_TILE ";
            //sql += "  ,b.DVKTCAO T_DVKTC_TILE,b.KHAMBENH+b.GIUONG T_KHAM,b.CPVC T_CPVC ";
            sql += " , '' ket_qua_dtri,'No' tinh_trang_rv, b.tilehuong muc_huong";
            sql += "  ,b.sotien t_tongchi,round( b.sotien-b.bhyt,2) T_bntt, b.BHYT T_BHTT,B.UBNDTRA T_NGUONKHAC ";
            sql += " ,b.ngoaidinhsuat T_NGOAIDS ";
          //  sql += " ,'BVND115' NOIKCB,kp.tenkp as khoa";
            sql += " ,TO_CHAR(b.ngay,'YYYY') NAM_QT,TO_CHAR(b.ngay,'MM') THANG_QT ";
            
           // sql += "  ,b.CHIPHI20_NGOAI T_TNT_NGOAI,b.CHIPHI31_NGOAI T_THAMPHAN_NGOAI,b.CHIPHI32_NGOAI T_THUOC_UT_NGOAI,b.KTUNGBUOU_NGOAI T_KYTHUATUB_NGOAI";
            // sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,";
            sql += " ,'' TT_TNGT,a.MABN MABN";
            sql += " ,b.sophieu ";
            sql += " from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa ";
            sql += " join btdquan qu on bn.maqu=qu.maqu ";
            sql += " join btdtt tt on bn.matt=tt.matt";
            sql += " inner join btdkp_bv kp on a.makp=kp.makp ";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_ExcelXHH(string tungay, string denngay, string dieukien)
        {
            string sql;


            sql = " select kq.sophieu sophieu,kp.tenkp,kq.mabn,bn.hoten, ";
            sql+=" SUM(case when kq.nhom='CT64' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as CT64, ";
            //sql+=" SUM(case when kq.nhom='MRI' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as MRI, ";
            sql+=" SUM(case when kq.nhom='PETCT' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as PETCT, ";
            sql+=" SUM(case when kq.nhom='PTNSOI' and kq.idnhombhyt<>6 then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as PTNSOI, ";
            sql += " SUM(case when kq.nhom NOT IN ('DSAKTC','DSATH') and kq.idnhombhyt=6  then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as PT_KTC, ";
            //sql+=" SUM(case when kq.nhom='KTC' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as KTC, ";
            //sql += " SUM(case when (kq.nhom='DSAKTC' and kq.idnhombhyt<>6) then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as DSAKTC, ";
            sql += " SUM(case when kq.nhom='DSATH' and kq.idnhombhyt<>6 then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as DSATH, ";
            sql += " SUM(case when kq.nhom in ('DSATH','DSAKTC') and kq.idnhombhyt=6 then  KQ.BHYTTRA ELSE 0 end)  as DSATH_KTC, ";
            sql += " SUM(case when kq.nhom='GOIKTC' then  KQ.BHYTTRA ELSE 0 end)  as GOIKTC, ";
            sql+=" SUM(case when kq.nhom='SCANNER' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as SCANNER, ";
            sql+=" SUM(case when kq.nhom='SAMTQ' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as SAMTQ, ";
            sql+=" SUM(case when kq.nhom='NOISOI' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as NOISOI, ";
            sql+=" SUM(case when kq.nhom='NOISOITMH' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as NOISOITMH, ";
            sql+=" SUM(case when kq.nhom='SATIM' then  KQ.SOLUONG*KQ.DONGIA ELSE 0 end)  as SATIM ";
            
            sql+=" from ( ";
            sql += " select b.sophieu,A.mabn,a.makp,e.viettat nhom,c.dongia,c.soluong,c.bhyttra,c.idnhombhyt ";
            sql += " from         " + schema + ".V_BHYTds a ";
            sql += " inner join " + schema + ".V_BHYTLL b on a.id=b.id ";
            sql += " inner join " + schema + ".V_BHYTCT C on a.id=c.id ";
            sql += " inner join " + schema + ".V_GIAVPBH d on d.id=c.mavp ";
            sql += " inner join " + schema + ".nhomxhh e on d.id_type=e.id ";
            sql += " where c.madoituong=1 and e.xhh='XHH' and to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql+=" ) kq ";
            sql+=" inner join btdkp_bv kp on kp.makp=kq.makp ";
            sql+=" inner join btdbn bn on bn.mabn=kq.mabn ";
            sql += " GROUP BY kq.sophieu,kp.tenkp,kq.mabn,bn.hoten ";



            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_ExcelKiemTra(string tungay, string denngay, string dieukien)
        {

            string sql = "    select  TO_CHAR(b.SOPHIEU) SOPHIEU,TO_CHAR( A.MABN) MABN,bn.HOTEN HOTEN, a.MAICD ICD10, ";
            sql += " b.sotien TONGTIEN, b.BHYT BHYTTRA,B.UBNDTRA,round( b.sotien-b.bhyt-B.UBNDTRA,2) BNTRA, kp.tenkp TENKP,";
            sql += "      to_char( b.NGAY,'dd/mm/yyyy') NGAYDUYET,  ";
            sql += "  to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char( A.NGAYRA,'dd/mm/yyyy') NGAYRA,ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) SONGAY,A.CHANDOAN CHANDOAN,b.THUOC THUOC,b.MAU MAU,b.XETNGHIEM XETNGHIEM, ";
            sql += " b.CDHA CDHA, b.DVKTTHUONG DVKTTHONGTHUONG, b.DVKTCAO DVKTCAO, ";
            sql += " b.VTTH VATTUYTE,b.KHAMBENH TIENKHAM,b.GIUONG GIUONG,b.CPVC CHIPHIVC,b.KHAC KHAC, ";
            sql += " b.TDCN THAMDOCHUCNANG,a.SOTHE SOTHEBHYT,to_char(a.tungay,'DD/MM/YYYY') TUNGAY,to_char(a.denngay,'DD/MM/YYYY') DENNGAY, A.TRAITUYEN TRAITUYEN, A.ID ,A.MAKP MAKP ,A.USERID USERID";
            sql += "            from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql += "  and a.id not in (select id from " + schema + ".V_BHYTCT )";

            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_ExcelKiemTra2(string tungay, string denngay, string dieukien)
        {

            string sql = "    select  TO_CHAR(b.SOPHIEU) SOPHIEU,TO_CHAR( A.MABN) MABN,bn.HOTEN HOTEN, a.MAICD ICD10, ";
            sql += " b.sotien TONGTIEN, b.BHYT BHYTTRA,B.UBNDTRA,round( b.sotien-b.bhyt-B.UBNDTRA,2) BNTRA, kp.tenkp TENKP,";
            sql += "      to_char( b.NGAY,'dd/mm/yyyy') NGAYDUYET,  ";
            sql += "  to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char( A.NGAYRA,'dd/mm/yyyy') NGAYRA,ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) SONGAY,A.CHANDOAN CHANDOAN,b.THUOC THUOC,b.MAU MAU,b.XETNGHIEM XETNGHIEM, ";
            sql += " b.CDHA CDHA, b.DVKTTHUONG DVKTTHONGTHUONG, b.DVKTCAO DVKTCAO, ";
            sql += " b.VTTH VATTUYTE,b.KHAMBENH TIENKHAM,b.GIUONG GIUONG,b.CPVC CHIPHIVC,b.KHAC KHAC, ";
            sql += " b.TDCN THAMDOCHUCNANG,a.SOTHE SOTHEBHYT,to_char(a.tungay,'DD/MM/YYYY') TUNGAY,to_char(a.denngay,'DD/MM/YYYY') DENNGAY, A.TRAITUYEN TRAITUYEN, A.ID ,A.MAKP MAKP ,A.USERID USERID";
            sql += "            from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdkp_bv kp on kp.makp=a.makp";
            sql += " where to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}' @dieukien ";
            sql += "  and (b.sotien >(  select sum(c.soluong*c.dongia) ";
            sql += "                        from bv115.V_BHYTCT c";
            sql += "                        where c.id=a.id AND C.MADOITUONG=1)+10 ";
            sql += "  or b.sotien <(  select sum(c.soluong*c.dongia) ";
            sql += "                        from bv115.V_BHYTCT c";
            sql += "                        where c.id=a.id AND C.MADOITUONG=1)-10 )";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
        public DataSet f_Export_Excel_UBNDTRA(string tungay, string denngay, string dieukien)
        {
            string sql = " select b.sophieu,LOWER(bn.HOTEN) HOTEN,";
            sql += "  bn.NAMSINH as NAMSINH,";
            sql += " to_number(bn.phai)+1 GIOITINH ";
            sql += " ,SUBSTR(a.SOTHE,1,15) MATHE,A.MACN MACN,SUBSTR(a.SOTHE,-5,5) MA_DKBD,CASE(INSTR( a.MAICD,';')) ";
            sql += " WHEN -1 THEN a.MAICD  WHEN 0 THEN a.MAICD ELSE SUBSTR(A.MAICD,0, INSTR( a.MAICD,';')-1) END MABENH ";
            sql += " ,to_char(A.NGAYVAO,'dd/mm/yyyy') NGAYVAO,to_char(A.NGAYRA,'dd/mm/yyyy') NGAYRA ";
            sql += " ,case when ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1)=0  then 1 else ROUND(TO_DATE(TO_CHAR(A.NGAYRA,'DD/MM/YYYY'),'DD/MM/YYYY')-TO_DATE(TO_CHAR(A.NGAYVAO,'DD/MM/YYYY'),'DD/MM/YYYY'),1) end    songay ";
            sql += " ,b.sotien T_TONGCHI, B.XETNGHIEM T_XN ,b.CDHA+B.TDCN T_CDHA,b.THUOC T_THUOC,b.MAU T_MAU ";
            sql += " ,b.DVKTTHUONG T_PTTT,b.VTTH  T_VTYTTTH,b.VTYTTL T_VTYTTT ";
            sql += "  ,b.DVKTCAO T_DVKTC,b.thuock T_KTG,b.KHAMBENH T_KHAM,b.CPVC T_VCHUYEN ";
            sql += "  ,round( b.sotien-b.bhyt-b.ubndtra,2) T_BNTRA, b.BHYT T_BHTRA,round(b.ubndtra,2) T_UBNDTRA ";
            sql += " ,round(b.ubndtra,2) T_NGOAIDS,a.traituyen LYDO_VV, ";
            sql += " CASE(INSTR( a.MAICD,';')) WHEN -1 THEN '' WHEN 0 THEN '' ELSE   SUBSTR(a.MAICD,INSTR( a.MAICD,';')+1,LENGTH(A.MAicd)- INSTR( a.MAICD,';')) END  BENHKHAC ";
            sql += " ,'BVND115' NOIKCB,kp.tenkp as khoa";
            sql += " ,TO_CHAR(b.ngay,'YYYY') NAM_QT,TO_CHAR(b.ngay,'MM') THANG_QT ";
            sql += " ,to_char(A.TUNGAY,'dd/mm/yyyy') GT_TU,to_char(A.DENNGAY,'dd/mm/yyyy') GT_DEN";
            sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt||'-MA_GD: '||cn.MACN DIACHI,";
            // sql += "  , bn.sonha||', '||bn.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt DIACHI,";
            sql += " '' TT_TNGT,b.sophieu MABN,a.chandoan CHANDOAN";
            sql += "  ,case when a.MABV='79024' then 1 else  case when substr(a.mabv,0,2)='79' and a.mabv!='79024' then 2 else 3 end end  MANHOMTHE, ";
            sql += "  case when a.MABV='79024' then 'Bệnh nhân nội tỉnh, khám, chữa bệnh ban đầu' else  case when substr(a.mabv,0,2)='79' and a.mabv!='79024' then 'Bệnh nhân nội tỉnh đến' else 'Bệnh nhân ngoại tỉnh đến' end end  NHOMTHE ";
            sql += " from " + schema + ".V_BHYTDS a ";
            sql += " join " + schema + ".V_BHYTLL b on  a.id=b.id ";
            sql += " join btdbn bn on bn.mabn= a.mabn ";
            sql += " join btdpxa px on bn.maphuongxa=px.maphuongxa ";
            sql += " join btdquan qu on bn.maqu=qu.maqu ";
            sql += " join btdtt tt on bn.matt=tt.matt";
            sql += " left join bv115.bhyt_cn cn on cn.sothe=a.sothe ";
            sql += " inner join btdkp_bv kp on a.makp=kp.makp ";
            sql += " where b.ubndtra>0 and to_char(b.ngay,'yyyymmdd') between '{tungay}' and '{denngay}'  @dieukien ";
            sql = sql.Replace("'{tungay}'", f_formatNgay(tungay));
            sql = sql.Replace("'{denngay}'", f_formatNgay(denngay));
            sql = sql.Replace("@dieukien", dieukien);

            DataSet dset = new DataSet();
            try
            {
                dset = data.get_data(sql);
                AccessData.Export_SQL = sql;
            }
            catch { }

            return dset;
        }
    }
}
