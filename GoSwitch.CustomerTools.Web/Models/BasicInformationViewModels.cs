using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GoSwitch.CustomerTools.Common.Enums;

namespace GoSwitch.CustomerTools.Web.Models
{
    public class BasicInformationViewModels
    {
        public bool IsInbound { get; set; }

        public bool Website { get; set; }

        public string LeadID { get; set; }
        public string CRN { get; set; }

        public string PostCode { get; set; }
        public string Suburb { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string FullAddress { get; set; }

        public EnumCustomerType CustomerType { get; set; }            //Business or Residential 

        public EnumEnergyType EnergyType { get; set; }              //Electricity, Gas or Dual

        public bool IsTransfer { get; set; }                //true for Transfer, false for Moving in

        public string MovingDate { get; set; }

        public bool IsBill { get; set; }

        public NoBillScenario NoBill { get; set; }
        public BillScenario Bill { get; set;} 
    }

    public class NoBillScenario
    {
        public EnumHouseholdSize HouseHoldSize { get; set; }

        public bool IsSolarPanel { get; set; }
        
        public bool IsGasHeater { get; set; }

        public EnumLowMedHigh GasConsumption { get; set; }

        public string NoBillConsent
        {
            get { return "This is No Bill Consent Text"; }
        }

    }


    public class BillScenario
    {
        public string ElecBillStartDate { get; set; }
        public string ElecBillEndDate { get; set; }

        public decimal PeakUsage { get; set; }
        public decimal OffPeakUsage { get; set; }

        public decimal Shoulder1Usage { get; set; }
        public decimal Shoulder2Usage { get; set; }
        public decimal ControlLoadUsage { get; set; }


        public string GasBillStartDate { get; set; }
        public string GasBillEndDate { get; set; }
        public decimal GasUsage { get; set; }
    }


}