using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class v_bhytct
    {
        public long  ID;
        public int STT;
        public DateTime  NGAY=DateTime.Today;
        public string  MAKP="0";
        public string MADOITUONG = "1";
        public string MAVP = "0";
        public float  SOLUONG=0;
        public double DONGIA = 0;
        public float VAT = 0;
        public double VATTU = 0;
        public double SOTIEN = 0;
        public string SOTHE = "0";
        public double GIAMUA = 0;
        public double TRA = 0;
        public DateTime NGAYTRA;
        public int BHYTDUYET = 0;
        public double BHYTTRA = 0;
        public double UBNDTRA= 0;
        public string IDTONGHOP = "0";
        public string MAKPTHUCHIEN = "0";
        public double GIA_BH = 0;
        public double MIEN = 0;
        public string MABS = "0";
        public DateTime NGAYUD = DateTime.Today;
        public long ID_KTCAO = 0;
        public int IDNHOMBHYT = 0;
        private string tile = "";

        public string Tile
        {
            get { return tile; }
            set { tile = value; }
        }

    }
}
