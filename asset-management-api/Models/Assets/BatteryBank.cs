
namespace AssetManagement.Models
{
    public class BatteryBank(string assetLocalID, string category, string status, string gxp, string feeder, string location, string note, string assetOwner, string lastModifiedBy, DateTime commissionedDate)
                             : Asset(assetLocalID, category, status, gxp, feeder, location, note, assetOwner, lastModifiedBy, commissionedDate)
    {
        public string BatteryBankName { get; set; }
        public string BatteryBankType { get; set; }
        public string BatteryBankCapacity { get; set; }
        public string BatteryBankVoltage { get; set; }
        public string GPS { get; set; }
        public override DateTime DisposalDate { get; set; }
        public override string DisposalReason { get; set; }
    }
}