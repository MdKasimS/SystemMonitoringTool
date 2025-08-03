using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes.Config
{
    public class DBTypeConfig
    {
        public bool SQLite { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string DB_URL { get; set; }
    }


}
