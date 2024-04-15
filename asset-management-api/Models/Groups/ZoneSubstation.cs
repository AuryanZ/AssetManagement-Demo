namespace AssetManagement.Models
{
    public class ZoneSubstation : AssetsGroup
    {
        public string ZoneSubstationName { get; set; }
        public string ZoneSubstationCode { get; set; }
        public string InputVoltage { get; set; }
        public string OutputVoltage { get; set; }
    }
}