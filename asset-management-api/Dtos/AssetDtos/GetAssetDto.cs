using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class GetAssetDto
    {
        public int AssetId { get; set; }
        public string AssetLocalID { get; set; }
        public string AssetsGroupID { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string AssetOwner { get; set; }
        public string GXP { get; set; }
        public string Feeder { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime CommissionedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime DisposalDate { get; set; }
        public string DisposalReason { get; set; }
    }
}