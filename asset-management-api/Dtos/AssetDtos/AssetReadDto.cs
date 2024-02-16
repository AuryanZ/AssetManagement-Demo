namespace AssetManagement.Dtos
{
    public class AssetReadDto
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        // public string AssetType { get; set; }
        public string AssetDescription { get; set; }
        public string AssetLocation { get; set; }
        public string AssetStatus { get; set; }
    }
}