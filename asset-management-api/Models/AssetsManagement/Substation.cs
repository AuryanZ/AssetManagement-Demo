using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class Substation
    {
        [Key]
        public int SubstationId { get; set; }
        [Required]
        public string SubstationName { get; set; }
        public string GPS { get; set; }
        public string Address { get; set; }
        [Required]
        public string InputVotage { get; set; }
        [Required]
        public string OutputVotage { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime LastInspectionDate { get; set; }
        public string Inspactby { get; set; }

        public int AssetID { get; set; }

        //Navigation Property
        [ForeignKey("AssetID")]
        public Asset Asset { get; set; }

    }
}