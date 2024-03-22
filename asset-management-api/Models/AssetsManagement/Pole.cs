using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Pole
    {
        [Key]
        public int PoleId { get; set; }
        public string PoleNumber { get; set; }
        public string PoleType { get; set; }
        public string PoleHeight { get; set; }
        public string PoleMaterial { get; set; }
        public string GPS { get; set; }
        public string Address { get; set; }
        public int RegLife { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}