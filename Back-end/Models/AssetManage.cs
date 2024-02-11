using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class AssetManage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AssetName { get; set; }
        [Required]
        public string AssetType { get; set; }
        [Required]
        public string AssetDescription { get; set; }
        [Required]
        public string AssetLocation { get; set; }
        [Required]
        public string AssetStatus { get; set; }
    }
}