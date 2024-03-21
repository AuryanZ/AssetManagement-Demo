using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class BatteryBank
    {
        [Key]
        public int BatteryBankId { get; set; }
        public string BatteryBankName { get; set; }
        public string BatteryBankType { get; set; }
        public string BatteryBankCapacity { get; set; }
        public string BatteryBankVoltage { get; set; }
        public string GPS { get; set; }


        public int AssetID { get; set; }
        public Asset Asset { get; set; }
    }
}