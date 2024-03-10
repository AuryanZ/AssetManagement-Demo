using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("SubZoneID")]
        public SubZone SubZone { get; set; }
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        public string GPS { get; set; }
        [Required]
        public string Location { get; set; }
        public string LocationDescraption { get; set; }
        [Required]
        public DateTime InstallDate { get; set; }
        [Required]
        public DateTime EstimateRetairDate { get; set; }
        public DateTime LastInspectionDate { get; set; }
    }
}