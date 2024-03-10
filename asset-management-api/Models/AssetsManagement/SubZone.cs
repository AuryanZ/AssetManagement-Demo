using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class SubZone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string SubZoneName { get; set; }
        [Required]
        public string InputVotage { get; set; }
        [Required]
        public string OutputVotage { get; set; }
        public string GPS { get; set; }
    }
}