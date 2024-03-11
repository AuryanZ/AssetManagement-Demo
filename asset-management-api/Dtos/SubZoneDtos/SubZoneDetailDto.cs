using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class SubZoneDetailDto
    {
        public int Id { get; set; }
        public string SiteID { get; set; }
        public string SubZoneName { get; set; }
        public string InputVotage { get; set; }
        public string OutputVotage { get; set; }
        public string GPS { get; set; }
        public IEnumerable<AssetBySzonDto> Assets { get; set; }
    }
}