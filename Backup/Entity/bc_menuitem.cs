using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class bc_menuitem
    {
        private string id = "";

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string id_goc = "";

        public string Id_goc
        {
            get { return id_goc; }
            set { id_goc = value; }
        }
        private int stt = 0;

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        private string id_menu = "";

        public string Id_menu
        {
            get { return id_menu; }
            set { id_menu = value; }
        }
        private string ten = "";

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private DateTime ngayupdate = System.DateTime.Now.Date;

        public DateTime Ngayupdate
        {
            get { return ngayupdate; }
            set { ngayupdate = value; }
        } 
     
    }
}
