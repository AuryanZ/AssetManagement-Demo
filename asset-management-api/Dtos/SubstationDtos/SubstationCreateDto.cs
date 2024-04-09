namespace AssetManagement.Dtos
{
    public class SubstationCreateDto
    {
        public string ZoneSubstationName { get; set; }
        public string ZoneSubstationCode { get; set; }
        public string ZoneSubstationLocation { get; set; }
        public string InputVoltage { get; set; }
        public string OutputVoltage { get; set; }
        public string Gps { get; set; }
        public string ZoneSubstationDescription { get; set; }
    }
}