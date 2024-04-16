namespace AssetManagement.Dtos
{
    public class GetTransformersDto
    {
        public int AssetId { get; set; }
        public string AssetLocalID { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Gxp { get; set; }
        public string Feeder { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public string AssetOwner { get; set; }

        public string TransformerName { get; set; }
        public string SerialNumber { get; set; }
        public string GPS { get; set; }
        public string Address { get; set; }
        public string InputVotage { get; set; }
        public string OutputVotage { get; set; }
        public string LandOwner { get; set; }
        public string Manufacturer { get; set; }
        public int RegLife { get; set; }

        public DateTime CommissionedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}