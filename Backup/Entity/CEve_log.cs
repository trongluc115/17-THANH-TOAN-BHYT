using System;
using System.Collections.Generic;
using System.Text;


namespace Entity
{
    public class CEve_log
    {
        private string id;
        private string userid;
        private string computer;
        private string action;
        private string content;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Computer
        {
            get { return computer; }
            set { computer = value; }
        }
        
        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        
        public string Content
        {
            get { return content; }
            set { content = value; }
        }



    }
}
