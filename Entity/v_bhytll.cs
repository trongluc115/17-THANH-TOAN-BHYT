using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class v_bhytll
    {
        public long ID;
        public int DIEMTHU = 0;
        public int LOAIBN = 0;
        public int LOAI = 0;
        public string QUYENSO="0";
        public long SOBIENLAI = 0;
        public DateTime NGAY = DateTime.Today;
        public string MAKP="0";
        public double SOTIEN = 0;
        public long TAMUNG = 0;
        public double MIEN = 0;
        public double BHYT = 0;
        public double UBNDTRA = 0;
        public double NOPTHEM = 0;
        public double THIEU = 0;
        public double VATTU = 0;
        public int LANIN = 0;
        public long IDTONGHOP = 0;
        public double CHENHLECH = 0;
        public double THUA = 0;
        public string KETOAN="0";
        public string QUYENSODV="0";
        public long SOBIENLAIDV;
        public string BHYTGHICHU="0";
        public string USERID="0";
        public string USERIDNL="0";
        public double MIENCS = 0;
        public double MIENDV = 0;
        public DateTime MIENCS_NGAYTT = DateTime.Today;
        public DateTime NGAYUD = DateTime.Today;
        public string SOPHIEU="0";
        public string QUYENSOQUYETTOAN="0";
        public double KHAMBENH = 0;
        public double THUOC = 0;
        public double MAU = 0;
        public double XETNGHIEM = 0;
        public double CDHA = 0;
        public double DVKTTHUONG = 0;
        public double DVKTCAO = 0;
        public double VTTH = 0;
        public double CPVC = 0;
        public double TDCN = 0;
        public double GIUONG = 0;
        public double KHAC = 0;
        public string TILETHE ="";
        public string TILEHUONG = "";
        public double THUOCK = 0;
        private double _THUOCTL = 0;
        private double _VTYTTL = 0;

        public double VTYTTL
        {
            get { return _VTYTTL; }
            set { _VTYTTL = value; }
        }
        public double THUOCTL
        {
            get { return _THUOCTL; }
            set { _THUOCTL = value; }
        }
        

    }
}
