using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EDCAgent
{
    public class Registery
    {
        Helper h = new Helper();
        
        public string getRegConfig(string valueName)
        {

            try
            {
                return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\RAYA\\EDC", valueName, "");
            }
            
            catch (Exception ex)
            {
                h.AddToLog("getRegConfig ..... " + ex.ToString(), EventLogEntryType.Error);
                return "";
            }

        }
    }
}
