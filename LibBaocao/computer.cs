using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Globalization;

namespace LibBaocao
{
    public class Computer
    {
        public static string getMachineName()
        {
            string result = "";
            try
            {
                result = Environment.MachineName;

            }
            catch { }

            return result;
        }
    }
}
