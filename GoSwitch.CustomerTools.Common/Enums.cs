using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSwitch.CustomerTools.Common
{
    public class Enums
    {
        public enum EnumHouseholdSize
        {
            OnePerson = 1, 
            TwotoThreePerson = 2, 
            FourtoFivePerson = 3, 
            SmallBusiness = 4
        }

        public enum EnumLowMedHigh
        {
            Low = 1, 
            Medium = 2, 
            High = 3
        }

        public enum EnumEnergyType
        {
            Electricity = 0, 
            Gas = 1, 
            Dual = 2,
            Internet = 3
        }

        public enum EnumCustomerType
        {
            Residential = 1,
            Business = 2
        }
    }
}
