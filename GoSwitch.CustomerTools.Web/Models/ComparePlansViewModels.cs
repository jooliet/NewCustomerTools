using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GoSwitch.CustomerTools.Common.Enums;

namespace GoSwitch.CustomerTools.Web.Models
{
    public class ComparePlansViewModels
    {
        public EnumEnergyType EnergyType { get; set; } 

        public int RetailerID { get; set; }

        public string LeadID { get; set; }

        public string CRN { get; set; }
        
        public string PlanID { get; set; }

        public string OfferID { get; set; }
    }
}