using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class GetTransformersDto
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public string GPS { get; set; }
        public string IO { get; set; }
        public string LandOwner { get; set; }
        public int AssetId { get; set; }
        public string LocalId { get; set; }
        public string AssetOwner { get; set; }
        public string Status { get; set; }
        public string GXP { get; set; }
        public string Feeder { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
    }
}