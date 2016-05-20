using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class CCDHA_THUOCPHIM
    {
        private string id;
        
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string stt;


        public string Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        private int mavp;

        public int Mavp
        {
            get { return mavp; }
            set { mavp = value; }
        }

        private int mabd;

        public int Mabd
        {
            get { return mabd; }
            set { mabd = value; }
        }
        private double soluong;

        public double Soluong
        {
          get { return soluong; }
          set { soluong = value; }
        }


        private double sl_phimhu;

        public double Sl_phimhu
        {
            get { return sl_phimhu; }
            set { sl_phimhu = value; }
        }
        private DateTime ngayud;


        public DateTime Ngayud
        {
            get { return ngayud; }
            set { ngayud = value; }
        }

    }
}
