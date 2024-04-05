using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public abstract class Asset
    {
        protected Asset(string assetLocalID, string category, string status, string gxp, string feeder, string location, string note, string assetOwner, string lastModifiedBy, DateTime commissionedDate)
        {
            CreatDate = DateTime.Now.Date;
            LastModifiedDate = DateTime.Now.Date;
            Status = status;
            Category = category;
            AssetLocalID = assetLocalID;
            Gxp = gxp;
            Feeder = feeder;
            Location = location;
            Note = note;
            AssetOwner = assetOwner;
            LastModifiedBy = lastModifiedBy;
            CommissionedDate = commissionedDate;
        }
        [Key]
        public int AssetId { get; set; }
        public string AssetLocalID { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Gxp { get; set; }
        public string Feeder { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public string AssetOwner { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime CommissionedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public abstract DateTime DisposalDate { get; set; }
        public abstract string DisposalReason { get; set; }
    }
}