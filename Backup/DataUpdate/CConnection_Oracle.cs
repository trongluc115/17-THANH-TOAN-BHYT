using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using System.IO;

namespace DataUpdate
{
    public class CConnection_Oracle
    {
        string sConn = "Data Source=medisoft;user id=medibv115;password=33odjpir";
        string service_name = "medisoft";
        string sql = "";
        string userid = "medibv";
        private OracleDataAdapter ora_da=new OracleDataAdapter();
        private OracleConnection ora_con=new OracleConnection();
        private OracleCommand ora_cmd=new OracleCommand();
        CXmlUpdate xml = new CXmlUpdate();
        private const string sformat = "dd/mm/yyyy";
        private DataSet ds = null;
        public string s_userAdmin = "medibv115";
        public string s_passwordAdmin = "33odjpir";
        public static string schema = "BV115";

        //public string Schema
        //{
        //    get { return schema; }
        //   // set { schema = value; }
        //}

        public CConnection_Oracle()
        {
            try
            {
               // sConn = xml.ReadXML(0, "maincode.xml");
            }
            catch { }
        }
        public int setData(string _sql)
        {
            int kq = 0;
            try
            {
                ora_con.Dispose();
                ora_con.Close();
                ora_con = new OracleConnection(sConn);
                ora_con.Open();
                ora_cmd = new OracleCommand(_sql, ora_con);
                kq = ora_cmd.ExecuteNonQuery();
                ora_con.Dispose();
                ora_con.Close();
            }
            catch { }
            return kq;
        }
        public DataSet getData(string sql)
        {


            try
            {
                if (ora_con != null)
                {
                    ora_con.Close(); ora_con.Dispose();
                }
                ds = new DataSet();
                ora_con = new OracleConnection(sConn);
                ora_con.Open();
                // sql = sql.Replace("medibv.", user.ToString().ToLower() + ".");
                ora_cmd = new OracleCommand(sql, ora_con);
                ora_cmd.CommandType = CommandType.Text;
                ora_da = new OracleDataAdapter(ora_cmd);
                ora_da.Fill(ds);
                ora_cmd.Dispose();
                ora_con.Close(); ora_con.Dispose();
            }
            catch (OracleException ex)
            {
                // upd_error(ex.Message.ToString().Trim() + sql, sComputer, "?");
            }

            return ds;
        }
        public void close()
        {
            if (this.ora_con != null)
            {
                this.ora_con.Close();
                this.ora_con.Dispose();
            }
        }
        public DataRow LayDongTheoDieuKien(DataTable dt, string exp)//getrowbyid
        {
            try
            {
                return dt.Select(exp)[0];
            }
            catch
            {
                return null;
            }
        }
        #region create schema bv115
     /*   public void tao_schema()
        {
            schema = schema.ToLower();
            if (!bSchema(schema))
            {
                string s_sql = "CREATE USER " + schema + " IDENTIFIED BY " + schema + " DEFAULT TABLESPACE MEDISOFT QUOTA 100M ON MEDISOFT;\n";
                s_sql = s_sql + "GRANT CREATE SESSION, IMP_FULL_DATABASE TO " + schema + ";\n";
                s_sql = s_sql + "GRANT JAVASYSPRIV, JAVAUSERPRIV TO " + schema + ";\n";
                s_sql = s_sql + "GRANT ALL PRIVILEGES TO " + schema + ";\n";
                s_sql = s_sql + "exit;";

                string path = "..//..//..//xml//createSchema.sql";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                FileStream stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s_sql);
                writer.Close();
                string fileName = "sqlplus.exe";
                //   string arguments = this.userid + "/" + this.password + "@" + this.service_name + " @" + path;
                string arguments = "system/11odjpir@medisoft @" + path;
                run exc = new run(fileName, arguments, true);
                exc.Launch();
                if (File.Exists(path))
                {
                    File.Delete(path);
                    tao_table(schema);
                }
            }
        }

        public void tao_table(string s_schema)
        {
            // string strSql = "connect " + userid.ToLower() + "/" + password + "@" + service_name + ";\n";               
            string strSql = "connect " + s_schema + "/" + s_schema + "@medisoft;\n";
            //strSql += " CREATE TABLE BV115.BV_DLOGIN (ID NUMBER(7,0),HOTEN NVARCHAR2(254),USERID VARCHAR2(20 BYTE),PASSWORD_ VARCHAR2(200 BYTE),"; 
            //strSql += " MANHOM NUMBER(3,0),MAKP VARCHAR2(4000 BYTE),RIGHT_ VARCHAR2(4000 BYTE),MADOITUONG VARCHAR2(254 BYTE),NHOMKHO VARCHAR2(254 BYTE),"; 
            //strSql += " CLS VARCHAR2(20 BYTE),MABS VARCHAR2(4 BYTE), MAY NVARCHAR2(254), NGAYUD DATE,LOAI NUMBER(1,0),KHU NUMBER(1,0),DECODE NUMBER(1,0),";
            //strSql += " THAYCHIDINHPTTT NUMBER(1,0),CHUYENSOLIEU NUMBER(1,0), RIGHT VARCHAR2(4000 BYTE),CONSTRAINT BV_DLOGIN_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".BV_LOGIN (ID NUMBER(7,0),HOTEN NVARCHAR2(254),USERNAME VARCHAR2(20 BYTE),PASSWORD VARCHAR2(200 BYTE),";
            strSql += " MENUITEM VARCHAR2(4000 BYTE), NGAYUD DATE,CONSTRAINT BV_LOGIN_PK PRIMARY KEY (ID));\n ";

            strSql += " CREATE TABLE " + s_schema + ".BC_DIEUKIEN (ID VARCHAR2(10 BYTE) NOT NULL ENABLE,TENBAOCAO NVARCHAR2(2000),";
            strSql += " NOIDUNG NVARCHAR2(2000),DIEUKIEN NVARCHAR2(2000),SUDUNG VARCHAR2(1 BYTE),CONSTRAINT BC_DIEUKIEN_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE  " + s_schema + ".BV_MENUITEM (ID VARCHAR2(12 BYTE),ID_GOC VARCHAR2(12 BYTE),STT NUMBER(7,0) DEFAULT 0,TEN NVARCHAR2(254),";
            strSql += " NGAYUD DATE DEFAULT sysdate,CONSTRAINT PK_BC_MENUITEM PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".BH_TILE (ID NUMBER(10,0) NOT NULL ENABLE,KYTU VARCHAR2(20 BYTE),TLDUNGTUYEN NUMBER(4,0),";
            strSql += "  TLTRAITUYEN NUMBER(4,0),ENABLE VARCHAR2(4 BYTE),TL_KTC NUMBER(4,0), CONSTRAINT BH_TILE_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".BTDKP_BHYT (MAKP VARCHAR2(3 BYTE),TENKP NVARCHAR2(254),KEHOACH NUMBER(5,0),THUCKE NUMBER(5,0),";
            strSql += " MAKPBO VARCHAR2(2 BYTE), MABA NVARCHAR2(254),LOAI NUMBER(3,0),MAVP NUMBER(7,0),LOAIVP VARCHAR2(4000 BYTE),";
            strSql += " MUCVP VARCHAR2(4000 BYTE), VIETTAT VARCHAR2(8 BYTE), CAPSO NUMBER(8,0),KEM NVARCHAR2(254),";
            strSql += " MAVPTK NUMBER(7,0),LOAICD VARCHAR2(4000 BYTE), MUCCD VARCHAR2(4000 BYTE), GIAVTTH NUMBER(10,0), NGAYUD DATE,";
            strSql += " KHU NUMBER(2,0), STT NUMBER(3,0), MAKPBC VARCHAR2(3 BYTE),CHUYENKHOA NUMBER(1,0), TINHCHENHLECH NUMBER(1,0),";
            strSql += " LOAIBCBH VARCHAR2(2 BYTE) DEFAULT 0, KHOXUAT VARCHAR2(50 BYTE), KHUVUC VARCHAR2(10 BYTE), CONSTRAINT BH_TILE_PK PRIMARY KEY (MAKP));\n";

            strSql += " CREATE TABLE " + s_schema + ".DM_NHOMBC (ID VARCHAR2(10 BYTE) NOT NULL ENABLE,NAME VARCHAR2(100 BYTE),LOAI VARCHAR2(10 BYTE),";
            strSql += " NGAYUD VARCHAR2(1 BYTE),ENABLE VARCHAR2(4000 BYTE), I_USER VARCHAR2(20 BYTE), U_USER VARCHAR2(20 BYTE),";
            strSql += " MOTA VARCHAR2(100 BYTE), CONSTRAINT DM_NHOMBBC_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".DMKHUVUC (ID VARCHAR2(10 BYTE) NOT NULL ENABLE,NAME VARCHAR2(200 BYTE),CONSTRAINT DMKHUVUC_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".DMXUTRIBA (ID NUMBER(5,0) NOT NULL ENABLE,TEN VARCHAR2(4000 BYTE),SUDUNG NUMBER(1,0), CONSTRAINT DMXUTRIBA_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".ISO_DANHMUC (ID NUMBER(2,0) NOT NULL ENABLE,TEN VARCHAR2(50 BYTE), CONSTRAINT ISO_DANHMUC_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".ISO_TIME(	MAVAOVIEN NUMBER(30,0),MABN VARCHAR2(14 BYTE), NGAY DATE, TIME_ DATE,LOAI NUMBER(2,0), ";
            strSql += " ID NUMBER(30,0) NOT NULL ENABLE, USERID VARCHAR2(15 BYTE), MAKP VARCHAR2(10 BYTE),CONSTRAINT ISO_TIME_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".M_CONFIG (	ID VARCHAR2(4 BYTE) NOT NULL ENABLE, DATE_LOCK DATE,ICD_DINHSUAT VARCHAR2(1000 BYTE),";
            strSql += " CONSTRAINT M_CONFIG_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".NHOMBC_CT(ID VARCHAR2(20 BYTE) NOT NULL ENABLE,STT NUMBER(*,0), MAVP VARCHAR2(20 BYTE),";
            strSql += " IDNHOM_XHH VARCHAR2(20 BYTE),CONSTRAINT NHOMBC_CT_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".NHOMMATHE(	ID NUMBER(*,0) NOT NULL ENABLE, MABV VARCHAR2(9 BYTE), TRAITUYEN NUMBER(*,0),";
            strSql += " TENNHOM VARCHAR2(200 BYTE), CONSTRAINT NHOMMATHE_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".NHOMXHH (ID VARCHAR2(20 BYTE) NOT NULL ENABLE, IDNHOM VARCHAR2(20 BYTE), NHOMBC NVARCHAR2(2000), ";
            strSql += " LOAIBC NVARCHAR2(2000), LOAIBANG NVARCHAR2(2000),VIETTAT NVARCHAR2(2000), XHH VARCHAR2(20 BYTE), CONSTRAINT NHOMXHH_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".QLBENHANCT (ID NUMBER(30,0) NOT NULL ENABLE, STT NUMBER(2,0) NOT NULL ENABLE, XUTRI NUMBER(3,0),";
            strSql += " NGAY DATE, GHICHU VARCHAR2(300 BYTE), USERI VARCHAR2(10 BYTE),USERU VARCHAR2(10 BYTE), NGAYUD DATE,";
            strSql += " CONSTRAINT QLBENHANCT_PK PRIMARY KEY (ID, STT));\n";

            strSql += " CREATE TABLE " + s_schema + ".QLBENHANLL (ID NUMBER(30,0) NOT NULL ENABLE, MAQL NUMBER(30,0), MAVAOVIEN NUMBER(30,0),";
            strSql += " TRANGTHAI NUMBER, KETTHUC NUMBER, KPRAVIEN VARCHAR2(3 BYTE),USERI VARCHAR2(10 BYTE),USERU VARCHAR2(10 BYTE),NGAYUD DATE,";
            strSql += " CONSTRAINT QLBENHAN_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".V_BHYTCT(ID NUMBER(30,0) NOT NULL ENABLE,STT NUMBER(5,0) NOT NULL ENABLE, NGAY DATE, MAKP VARCHAR2(3 BYTE), ";
            strSql += " MADOITUONG NUMBER(2,0),MAVP NUMBER(7,0), SOLUONG NUMBER(12,4), DONGIA NUMBER(24,10), ";
            strSql += " VAT NUMBER(7,2), VATTU NUMBER(15,4), SOTIEN NUMBER(15,4), SOTHE VARCHAR2(20 BYTE), GIAMUA NUMBER(24,10), ";
            strSql += " TRA NUMBER(24,10), NGAYTRA DATE, BHYTDUYET NUMBER(1,0), BHYTTRA NUMBER(15,4), IDTONGHOP NUMBER(30,0),";
            strSql += " MAKPTHUCHIEN VARCHAR2(3 BYTE),GIA_BH NUMBER(24,10), MIEN NUMBER(24,10), MABS VARCHAR2(4 BYTE), NGAYUD DATE, ";
            strSql += " ID_KTCAO NUMBER(30,0) NOT NULL ENABLE,IDNHOMBHYT NUMBER(2,0),THUOCK NUMBER(2,0) DEFAULT 0, CONSTRAINT V_BHYTCT_PK PRIMARY KEY (ID, STT));\n";

            strSql += " CREATE TABLE " + s_schema + ".V_BHYTDS (	ID NUMBER(30,0) NOT NULL ENABLE, MABN VARCHAR2(14 BYTE), MAVAOVIEN NUMBER(30,0),";
            strSql += " MAQL NUMBER(30,0), IDKHOA NUMBER(30,0), GIUONG VARCHAR2(20 BYTE), NGAYVAO DATE, NGAYRA DATE, CHANDOAN NVARCHAR2(1000),";
            strSql += " MAICD VARCHAR2(100 BYTE),SOTHE VARCHAR2(20 BYTE),MAPHU NUMBER(7,2),TUNGAY DATE, DENNGAY DATE, MABV VARCHAR2(9 BYTE),";
            strSql += " NOIGIOITHIEU VARCHAR2(8 BYTE), TRAITUYEN NUMBER(1,0),COMPUTER VARCHAR2(50 BYTE), USERID NUMBER(7,0),NGAYUD DATE,";
            strSql += " MAICDKT VARCHAR2(30 BYTE), CHANDOANKT NVARCHAR2(500), BCKTC VARCHAR2(3 BYTE), BCTHUOCUB VARCHAR2(3 BYTE), MAKP VARCHAR2(3 BYTE),";
            strSql += " HUONGKTC NUMBER DEFAULT 0, MANHOMTHE NUMBER(2,0), CONSTRAINT V_BHYTDS_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".V_BHYTLL (	ID NUMBER(30,0) NOT NULL ENABLE,DIEMTHU NUMBER(2,0), LOAIBN NUMBER(2,0),";
            strSql += " LOAI NUMBER(2,0),QUYENSO NUMBER(7,0), SOBIENLAI NUMBER(10,0), NGAY DATE, MAKP VARCHAR2(3 BYTE), SOTIEN NUMBER(15,4),";
            strSql += " TAMUNG NUMBER(10,0), UBNDTRA NUMBER(15,4) DEFAULT 0, BHYT NUMBER(15,4) DEFAULT 0, NOPTHEM NUMBER(15,4),";
            strSql += " THIEU NUMBER(15,4), VATTU NUMBER(15,4), LANIN NUMBER(2,0), IDTONGHOP NUMBER(30,0), CHENHLECH NUMBER(15,4),";
            strSql += " THUA NUMBER(15,4), KETOAN NUMBER(20,0), QUYENSODV NUMBER(7,0), SOBIENLAIDV NUMBER(10,0), BHYTGHICHU NVARCHAR2(254),";
            strSql += " USERID NUMBER(7,0), USERIDNL NUMBER(7,0), MIENCS NUMBER(15,4), MIENDV NUMBER(15,4), MIENCS_NGAYTT DATE,";
            strSql += " NGAYUD DATE, SOPHIEU NUMBER(30,0), QUYENSOQUYETTOAN NUMBER(7,0), KHAMBENH NUMBER(15,4), THUOC NUMBER(15,4) DEFAULT 0,";
            strSql += " MAU NUMBER(15,4) DEFAULT 0, XETNGHIEM NUMBER(15,4) DEFAULT 0, CDHA NUMBER(15,4) DEFAULT 0,DVKTTHUONG NUMBER(15,4) DEFAULT 0,";
            strSql += " DVKTCAO NUMBER(15,4) DEFAULT 0, VTTH NUMBER(15,4) DEFAULT 0, CPVC NUMBER(15,4) DEFAULT 0, TDCN NUMBER(15,4) DEFAULT 0,";
            strSql += " GIUONG NUMBER(15,4) DEFAULT 0, KHAC NUMBER(15,4) DEFAULT 0, TILETHE NUMBER(3,0) DEFAULT 0, TILEHUONG NUMBER(3,0) DEFAULT 0,";
            strSql += " THUOCK NUMBER(15,4) DEFAULT 0, THUOCK2 NUMBER(15,2) DEFAULT 0,KTC_CDHA NUMBER(15,2) DEFAULT 0, KTC_PTTT NUMBER(15,2) DEFAULT 0,";
            strSql += " MIEN NUMBER(15,2) DEFAULT 0, NGOAIDINHSUAT NUMBER(15,4) DEFAULT 0, VTYTTL NUMBER(15,4) DEFAULT 0, CONSTRAINT V_BHYTLL_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".V_GIAVPBH ( ID NUMBER(7,0) NOT NULL ENABLE, ID_TYPE VARCHAR2(20 BYTE),FILTER NUMBER(1,0),";
            strSql += " BHYT NUMBER(10,2) DEFAULT 0, CONSTRAINT V_GIAVPBH_PK PRIMARY KEY (ID));\n";

            strSql += " CREATE TABLE " + s_schema + ".BTDKP_BHYT (MAKP VARCHAR2(3 BYTE),TENKP NVARCHAR2(254),";
            strSql += " KEHOACH NUMBER(5,0),THUCKE NUMBER(5,0),MAKPBO VARCHAR2(2 BYTE),MABA NVARCHAR2(254),";
            strSql += "LOAI NUMBER(3,0),MAVP NUMBER(7,0),LOAIVP VARCHAR2(4000 BYTE),MUCVP VARCHAR2(4000 BYTE),";
            strSql += " VIETTAT VARCHAR2(8 BYTE),CAPSO NUMBER(8,0),KEM NVARCHAR2(254),MAVPTK NUMBER(7,0),";
            strSql += " LOAICD VARCHAR2(4000 BYTE),MUCCD VARCHAR2(4000 BYTE),GIAVTTH NUMBER(10,0),NGAYUD DATE,";
            strSql += " KHU NUMBER(2,0),STT NUMBER(3,0),MAKPBC VARCHAR2(3 BYTE),CHUYENKHOA NUMBER(1,0),";
            strSql += "TINHCHENHLECH NUMBER(1,0),LOAIBCBH VARCHAR2(2 BYTE) DEFAULT 0,KHOXUAT VARCHAR2(50 BYTE),KHUVUC VARCHAR2(10 BYTE));\n";

            strSql += " CREATE TABLE " + s_schema + ".D_DMBDBH (ID NUMBER(7,0) NOT NULL ENABLE,ID_TYPE VARCHAR2(20 BYTE),FILTER NUMBER(1,0),BHYT NUMBER(10,2),CONSTRAINT D_DMBDBH_PK PRIMARY KEY (ID));\n";
            strSql += " alter table " + s_schema + ".bc_dieukien add tenreport nvarchar2(50) default null;\n";
            strSql += " ALTER TABLE " + s_schema + ".BC_DIEUKIEN ADD TIEUDEEXCEL nvarchar2 (254) DEFAULT NULL;\n";
            //strSql += " alter table bv115.bv_dlogin add right varchar2(4000) \n;";       
            strSql += " create table " + s_schema + ".bv_dmphong as select * from medibv115.dmphong;\n";
            strSql += " alter table " + s_schema + ".bv_dmphong add maphongbv VARCHAR2(10 BYTE) default null;\n";
            strSql += " alter table " + s_schema + ".bv_dmphong add tenphongbv NVARCHAR2(254) default null ;\n";
            strSql += " alter table " + s_schema + ".bv_dmphong add sttbv number(3) default 0 ;\n";
            strSql += " create table " + s_schema + ".bv_dmgiuong as select * from medibv115.dmgiuong;\n";
            strSql += " alter table " + s_schema + ".bv_dmgiuong add magiuongbv VARCHAR2(10 BYTE) default null;\n";
            strSql += " alter table " + s_schema + ".bv_dmgiuong add tengiuongbv NVARCHAR2(254) default null ;\n";
            strSql += " alter table " + s_schema + ".bv_dmgiuong add sttbv number(3) default 0 ;\n";
            strSql += "commit;\n";
            strSql += "exit;";
            // string path = @"..\..\..\xml\createTable.sql";
            string path = "..//..//..//xml//createTable.sql";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(strSql);
            writer.Close();
            stream.Dispose();
            writer.Dispose();
            string fileName = "sqlplus.exe";
            //  string arguments = this.userid + "/" + password + "@" + service_name + " @" + path;//linh 06072012
            string arguments = "" + s_schema + "/" + s_schema + "@medisoft @" + path;//linh 06072012
            new run(fileName, arguments, true).Launch();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        /// <summary>
        /// Kiểm tra xem user đã tạo đươc hay chưa?
        /// </summary>
        /// <param name="Schema">Tên user</param>
        /// <returns></returns>
        public bool bSchema(string Schema)
        {
            //if (this.bKiemtra_taoschema)==> rảnh quá
            //{
            try
            {
                return (getData("select * from dba_users where username='" + Schema.ToUpper() + "'").Tables[0].Rows.Count > 0);
            }
            catch
            {
                return false;
            }
            //}
            //return true;
        }*/
        #endregion schema bv115

        public void delrec(DataTable dt, string exp)
        {
            try
            {
                DataRow[] rowArray = dt.Select(exp);
                for (int i = 0; i < rowArray.Length; i++)
                {
                    rowArray[i].Delete();
                }
            }
            catch
            {
            }
        }
   
    }
}
