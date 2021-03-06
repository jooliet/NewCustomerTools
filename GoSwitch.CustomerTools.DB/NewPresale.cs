//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoSwitch.CustomerTools.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewPresale
    {
        public int PresaleID { get; set; }
        public int CustomerID { get; set; }
        public int EnergyTypeID { get; set; }
        public Nullable<bool> IsMoving { get; set; }
        public Nullable<System.DateTime> MovingDate { get; set; }
        public Nullable<bool> IsBill { get; set; }
        public Nullable<int> ElecUsageID { get; set; }
        public Nullable<bool> IsSolar { get; set; }
        public Nullable<bool> IsGasHeater { get; set; }
        public int GasUsageID { get; set; }
        public Nullable<System.DateTime> ElecBillStartDate { get; set; }
        public Nullable<System.DateTime> ElecBillEndDate { get; set; }
        public Nullable<double> PeakUsage { get; set; }
        public Nullable<double> OffPeakUsage { get; set; }
        public Nullable<double> Shoulder1 { get; set; }
        public Nullable<double> Shoulder2 { get; set; }
        public Nullable<double> ControlLoad1 { get; set; }
        public Nullable<double> ControlLoad2 { get; set; }
        public Nullable<System.DateTime> GasBillStartDate { get; set; }
        public Nullable<System.DateTime> GasBillEndDate { get; set; }
        public Nullable<double> GasUsageAmount { get; set; }
        public Nullable<double> ElecUsageAmount { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
    }
}
