namespace AssetManagement.Models
{
    public class PillerBox
    {

        public int PillerBoxId { get; set; }
        public string PillerBoxNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Line_segment { get; set; }
        public string LandOwner { get; set; }
        public string GPS { get; set; }

        public string Address { get; set; }


        public int AssetId { get; set; }
        public Asset Asset { get; set; }

    }
}