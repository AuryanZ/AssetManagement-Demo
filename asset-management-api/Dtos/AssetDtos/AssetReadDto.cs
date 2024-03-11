using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class AssetReadDto
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public SubZone SubZone  { get; set; }
        public string Status  { get; set; }
        public string GPS  { get; set; }
        public string Location  { get; set; }
        public string LocationDescraption   { get; set; }
        public string InstallDate   { get; set; }
        public string EstimateRetairDate   { get; set; }
        public string LastInspectionDate    { get; set; }
    }
}