using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class v_bhytds
    {
        public long ID;
        public string MABN;
        public long MAVAOVIEN;
        public long MAQL;
        public long IDKHOA;
        public string GIUONG;
        public DateTime NGAYVAO;
        public DateTime NGAYRA;
        public string CHANDOAN;
        public string MAICD;
        public string SOTHE;
        public float MAPHU;
        public DateTime TUNGAY;
        public DateTime DENNGAY;
        public string MABV;
        public string NOIGIOITHIEU;
        public string TRAITUYEN;
        public string COMPUTER;
        public int USERID;
        public DateTime NGAYUD;
        public string MAICDKT;
        public string CHANDOANKT;
        public string BCKTC;
        public string BCThuocUB;
        public string MaKP="";
        public string HuongKTC = "0";
        private string _macanngheo = "";
     
        public string Macanngheo
        {
            get { return _macanngheo; }
            set { _macanngheo = value; }
        }
    


    }
}
