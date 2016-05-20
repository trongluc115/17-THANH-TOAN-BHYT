using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class v_giavpbh
    {
        private long _id;
        private string _id_type;
        private int _enable;
        private int _bhyt;
        private string id_byt;
        private int ktcgoi;

        public int Ktcgoi
        {
            get { return ktcgoi; }
            set { ktcgoi = value; }
        }

        public string Id_byt
        {
            get { return id_byt; }
            set { id_byt = value; }
        }
        public long ID
        {
            get { return _id; }
            set { _id = value; }

        }
        public string ID_TYPE
        {
            get { return _id_type; }
            set { _id_type = value; }

        }
        public int ENABLE
        {
            get { return _enable; }
            set { _enable = value; }

        }
        public int BHYT
        {
            get { return _bhyt; }
            set { _bhyt = value; }

        }

       
    }
}
