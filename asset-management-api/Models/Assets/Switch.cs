namespace AssetManagement.Models
{
    public class Switch(string assetLocalID, string category, string status, string gxp, string feeder, string location, string note, string assetOwner, string lastModifiedBy, DateTime commissionedDate)
     : Asset(assetLocalID, category, status, gxp, feeder, location, note, assetOwner, lastModifiedBy, commissionedDate)
    {
        public string SwitchName { get; set; }
        public string SerialNumber { get; set; }
        public string ControlPanelSN { get; set; }
        public string TypeOfLink { get; set; }
        public string RatedVoltage { get; set; }
        public int NumberOfPhase { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public override DateTime DisposalDate { get; set; }
        public override string DisposalReason { get; set; }
    }
}