using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSwitch.CustomerTools.Models.NewCallCenters
{
    public class ParamModels
    {
        public class ParamInsertCallCenter
        {
            public string CallCenterCode { get; set; }
            public string CallCenterName { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
