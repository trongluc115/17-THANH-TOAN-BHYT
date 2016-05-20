using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class cdha_dvll
    {
        public long  ID;
        public int STT;
        public DateTime  NGAYCD=DateTime.Today;
        public DateTime NGAYCHUP = DateTime.Today;
        public DateTime NGAYHD = DateTime.Today;
        public DateTime NGAYTRAKQ = DateTime.Today;
        public DateTime NGAYTHUCHIEN = DateTime.Today;
        public string  MAKP="0";
        public string TRAKQ = "0";
        public string MABN = "";
        public string MADOITUONG = "1";
        public string MAVP = "0";
        public float  SOLUONG=0;
        public float DONGIA = 0;
        public string MABSCD = "-";
        public string MABSTH = "-";
        public double MIEN = 0;
        public DateTime NGAYUD = DateTime.Today;
        public string SOBL= "-";
        public string SOHD = "-";
        public string USERTN = "-";
        public string DONE = "0";
        private string cdhakhu = "";

        public string Cdhakhu
        {
            get { return cdhakhu; }
            set { cdhakhu = value; }
        }
        private string noithuchien;

        public string Noithuchien
        {
            get { return noithuchien; }
            set { noithuchien = value; }
        }


    }
}
