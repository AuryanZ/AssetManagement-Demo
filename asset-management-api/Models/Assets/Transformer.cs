namespace AssetManagement.Models
{
    public class Transformer(string assetLocalID, string category, string status, string gxp, string feeder, string location, string note, string assetOwner, string lastModifiedBy, DateTime commissionedDate)
                             : Asset(assetLocalID, category, status, gxp, feeder, location, note, assetOwner, lastModifiedBy, commissionedDate)
    {
        public string TransformerName { get; set; }
        public string SerialNumber { get; set; }
        public string GPS { get; set; }
        public string Address { get; set; }
        public string InputVotage { get; set; }
        public string OutputVotage { get; set; }
        public string LandOwner { get; set; }
        public string Manufacturer { get; set; }
        public int RegLife { get; set; }
        public override DateTime DisposalDate { get; set; }
        public override string DisposalReason { get; set; }
    }
}