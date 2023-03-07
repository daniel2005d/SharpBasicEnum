using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Model
{
    internal class UserModel
    {
        public string Name { get; set; }    
        public bool IsAdmin { get; set; }
        public bool IsEnabled { get; set; }
        public string SID { get; set; }
    }
}
