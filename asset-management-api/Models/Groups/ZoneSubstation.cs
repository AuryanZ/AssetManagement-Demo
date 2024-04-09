namespace AssetManagement.Models
{
    public class ZoneSubstation
    {
        public int ZoneSubstationId { get; set; }
        public string ZoneSubstationName { get; set; }
        public string ZoneSubstationCode { get; set; }
        public string ZoneSubstationLocation { get; set; }
        public string InputVoltage { get; set; }
        public string OutputVoltage { get; set; }
        public string Gps { get; set; }
        public string ZoneSubstationDescription { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}