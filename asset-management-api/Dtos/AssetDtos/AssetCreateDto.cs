using System.ComponentModel.DataAnnotations;
using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class AssetCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string InstallDate { get; set; }
        [Required]
        public string EstimateRetairDate { get; set; }
        [Required]
        public int SubZoneID {get; set;}
        public string GPS {get; set;}
        public string LocationDescraption {get; set;}
    }
}