using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharpSearchInformation.Manager.CustomEvents;

namespace SharpSearchInformation.Manager
{
    internal class EventLogManager : ManagerBase
    {
        public void SearchText(string text)
        {

            ////EventLog log = new EventLog
            List<string> categories = new List<string>() {"Application","Security", "System"} ;
            foreach (string category in categories)
            {
                
                if (this.OnProgress != null)
                {
                    this.OnProgress($"Search into {category}");
                }

                EventLog log = new EventLog(category);
                var entries = log.Entries.Cast<EventLogEntry>()
                    .Where(x => x.Message.Contains(text));
                    

                if (entries.Any())
                {
                    if (OnFound!= null)
                    {
                        foreach(var entry in entries)
                        {
                            string result = this.Find(entry.Message, text);
                            this.OnFound(new EventLogModel()
                            {
                                EventLogId = entry.InstanceId,
                                Message = result,
                                EventLogName = category,
                                UserName = entry.UserName,
                                Created = entry.TimeWritten,
                                Index = entry.Index

                            });
                        }
                        
                    }
                }
                    
                
            }
        }

        internal event OnFoundEventLog OnFound;
        internal event OnProgressDelegate OnProgress;
    }
}
