using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSwitch.CustomerTools.Common
{
    public class SiteSettings
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["GoSwitchProductionNewEntities"].ConnectionString; }
        }
    }
}
