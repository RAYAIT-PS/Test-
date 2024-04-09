using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCAgent
{
    class Program
    {
        static Helper h = new Helper();
        static GetFileFromATM getFileFromATM = new GetFileFromATM();

        static void Main(string[] args)
        {
            try
            {
                h.AddToLog("Start EDC  V 1.0");
                getFileFromATM.GetFiles(DateTime.Now.AddDays(-30));
            }

            catch(Exception ex)
            {
                h.AddToLog($"Error when initialize program {ex.Message} + {ex.StackTrace} + {ex.StackTrace}", System.Diagnostics.EventLogEntryType.Error);
            }
        }

      



    }
}
