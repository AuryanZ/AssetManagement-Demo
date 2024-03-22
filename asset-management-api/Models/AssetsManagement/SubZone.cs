using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class SubZone
    {
        [Key]
        public int SubZoneId { get; set; }
        [Required]
        public string SubZoneName { get; set; }
        public string SubZoneCode { get; set; }
        public string SubZoneDescription { get; set; }
        public string LocalCouncil { get; set; }
        //An array of Assets
        public string LatestBiMonthRecordID { get; set; }
        public string LatestAnnualRecordID { get; set; }

        public ICollection<Asset> Assets { get; set; }

        // public ICollection<Records> Records { get; set; }
    }
}