using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EDCAgent
{
    public class Helper
    {
        public void AddToLog(string slog, EventLogEntryType eventLogEntryType = EventLogEntryType.Information)
        {

            if (!EventLog.SourceExists("EDC"))
            {
                EventLog.CreateEventSource("EDC", "NEWEDC");
            }

            EventLog.WriteEntry("EDC", slog, eventLogEntryType);
        }
    }
}
