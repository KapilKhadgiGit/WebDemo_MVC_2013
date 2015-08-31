using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVCDemo.Web.Models
{
    class InRiverSettingsModel
    {
        public string configFilePath { get; set; }
        public string activeConnection { get; set; }
        public List<string> allConnections { get; set; }
    }
}
