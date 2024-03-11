namespace AssetManagement.Dtos
{
    public class ReadSubZoneDto
    {
        public int Id { get; set; }
        public string SiteID { get; set; }
        public string SubZoneName { get; set; }
        public string InputVotage { get; set; }
        public string OutputVotage { get; set; }
        public string GPS { get; set; }
    }
}