namespace AssetManagement.Dtos
{
    public class CreateAssetGroupDtos
    {
        public string GroupCategory { get; set; }
        public string GroupCode { get; set; }
        public string Location { get; set; }
        public string Terrain { get; set; }
        public string LocalCouncil { get; set; }
        public string OperatingVoltage { get; set; }
        public string Description { get; set; }
        public string Gps { get; set; }
        public int NumberOfCustomers { get; set; }
        public string ZoneSubstationName { get; set; }
        public string ZoneSubstationCode { get; set; }
        public string InputVoltage { get; set; }
        public string OutputVoltage { get; set; }
    }
}