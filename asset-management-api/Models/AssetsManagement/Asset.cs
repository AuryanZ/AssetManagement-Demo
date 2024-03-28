using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
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
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime CreatDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime CommissionedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public string LastModifiedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime DisposalDate { get; set; }
        public string DisposalReason { get; set; }


        [Required]
        public int SubZoneID { get; set; }
        // [ForeignKey("SubZoneID")]
        public SubZone SubZone { get; set; }
        public string AssetsGroupID { get; set; }
        // [ForeignKey("AssetsGroupID")]
        public AssetsGroup AssetsGroup { get; set; }

        public ICollection<BatteryBank> batteryBank { get; set; }
        public ICollection<Cable> cable { get; set; }
        public ICollection<PillerBox> pillerBox { get; set; }
        public ICollection<Pole> pole { get; set; }
        public ICollection<Transformer> Transformer { get; set; }

        public ICollection<Substation> substation { get; set; }

        // public Switchgear switchgear { get; set; }
        // public CircuitBreaker circuitBreaker { get; set; }
        // public Tapchanger tapchanger { get; set; }

    }
}