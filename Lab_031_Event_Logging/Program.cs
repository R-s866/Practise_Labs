using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing;
using System.Diagnostics;

namespace Lab_031_Event_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "hacker man is here, hide yo kids hide yo wife",
                EventLogEntryType.Error, 5001, 1239);
        }
    }
}
