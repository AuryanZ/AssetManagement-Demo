using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Dtos
{
    public class AssetUpdateDto
    {
        [Required]
        public string AssetName { get; set; }

        // [Required]
        // public string AssetType { get; set; }
        // [Required]
        // public string AssetDescription { get; set; }

        [Required]
        public string AssetLocation { get; set; }

        [Required]
        public string AssetStatus { get; set; }
    }
}