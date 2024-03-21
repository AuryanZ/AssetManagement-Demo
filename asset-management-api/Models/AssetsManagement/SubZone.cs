using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class SubZone
    {
        [Key]
        public int SubZoneId { get; set; }
        [Required]
        public string SubZoneName { get; set; }
        public string LocalCouncil { get; set; }
        //An array of Assets
        public ICollection<Asset> Assets { get; set; }
    }
}