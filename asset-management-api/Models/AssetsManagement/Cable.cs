using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Cable
    {
        [Key]
        public int CableId { get; set; }
        public string CableName { get; set; }
        public string CableRole { get; set; }
        public string CableVoltage { get; set; }
        public string CableLength { get; set; }
        public int NumberOfPhases { get; set; }
        public string Address { get; set; }
        public int RegLife { get; set; }

        public int AssetID { get; set; }
        public Asset Asset { get; set; }
    }
}