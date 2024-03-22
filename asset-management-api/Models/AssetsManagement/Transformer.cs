using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Transformer
    {
        [Key]
        public int TransformerId { get; set; }
        public string TransformerName { get; set; }
        public string SerialNumber { get; set; }
        public string GPS { get; set; }
        public string Address { get; set; }
        public string InputVotage { get; set; }
        public string OutputVotage { get; set; }
        public string LandOwner { get; set; }
        public string Manufacturer { get; set; }
        public int RegLife { get; set; }

        public int AssetID { get; set; }
        public Asset Asset { get; set; }
    }
}