using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class CDT_history
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string mabs;

        public string Mabs
        {
            get { return mabs; }
            set { mabs = value; }
        }
        private string id_loai;

        public string Id_loai
        {
            get { return id_loai; }
            set { id_loai = value; }
        }
        private string noidung;

        public string Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }
        private DateTime tungay;

        public DateTime Tungay
        {
            get { return tungay; }
            set { tungay = value; }
        }
        private DateTime denngay;

        public DateTime Denngay
        {
            get { return denngay; }
            set { denngay = value; }
        }
        private DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        private double value = 0;

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}
