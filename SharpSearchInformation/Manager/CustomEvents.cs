using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Manager
{
    internal class CustomEvents
    {
        internal delegate void OnFoundDelegate(TextModel text);
        internal delegate void OnFoundEventLog(EventLogModel entry);
        internal delegate void OnProgressDelegate(string message);
        

    }
}
