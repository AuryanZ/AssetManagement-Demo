using System.ComponentModel.DataAnnotations;
using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public class AssetCreateDto
    {
        public string AssetID { get; set; }
        [Required]
        public string AssetLocalID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Status { get; set; }
        public string GXP { get; set; }
        public string Feeder { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        [Required]
        public string AssetOwner { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime CreatDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime CommissionedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime DisposalDate { get; set; }
        public string DisposalReason { get; set; }

        public int SubZoneID { get; set; }
        public string AssetsGroupID { get; set; }



        // public BatteryBank batteryBank { get; set; }
        // public Cable cable { get; set; }
        // public PillerBox pillerBox { get; set; }
        // public Pole pole { get; set; }
        // public Transformer Transformer { get; set; }

        // public Substation substation { get; set; }
    }
}