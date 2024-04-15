using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class AssetsGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupCategory { get; set; }
        public string GroupCode { get; set; }
        public string Location { get; set; }
        public string Terrain { get; set; }
        public string LocalCouncil { get; set; }
        public string OperatingVoltage { get; set; }
        public string Description { get; set; }
        public string Gps { get; set; }
        public int NumberOfCustomers { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}