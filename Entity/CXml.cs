using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entity
{
    public class CXml
    {
        private string s_filename;
        public string ReadXML(string item,string FileName)
        {
            string result="";
            try
            {
                string filename = "..//..//..//xml//"+FileName;
                DataSet ds = new DataSet();
                ds.ReadXml(filename);
                s_filename = filename; 
                result = ds.Tables[0].Rows[0][item].ToString();

            }
            catch
            {
                
            }
            return result;
        }
        public DataSet ReadXML(string FileName)
        {
            DataSet ds = new DataSet();
            try
            {
                string filename = "..//..//..//xml//" + FileName;
                s_filename = filename; 
                ds.ReadXml(filename);

               

            }
            catch
            {

            }
            return ds;
        }
        public void WriteXML(string item,string value, string FileName)
        {
          
            try
            {
                string filename = "..//..//..//xml//"+FileName;
                DataSet ds = new DataSet();
                ds.ReadXml(filename);
                s_filename = filename; 
                //MessageBox.Show(ds.Tables[0].Rows[0]["P" + item.ToString()].ToString());
                //int so = int.Parse(ds.Tables[0].Rows[0]["P" + item.ToString()].ToString());
                ds.Tables[0].Rows[0][item] = value;
              
              

                ds.WriteXml(filename);

            }
            catch
            {
               
            }
        }
        public bool WriteXML(DataSet ds, string FileName)
        {

            try
            {
                string filename = "..//..//..//xml//" + FileName;
                s_filename = filename;          
              


                ds.WriteXml(filename);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public string getfilename()
        {
            return s_filename;
        }
    }
}
