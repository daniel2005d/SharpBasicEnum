using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Model
{
    internal class EventLogModel
    {
        public int Index { get; set; }
        public long EventLogId { get; set; }
        public string EventLogName { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}
