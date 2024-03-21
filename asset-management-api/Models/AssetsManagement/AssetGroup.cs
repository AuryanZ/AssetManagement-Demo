using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class AssetsGroup
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AssetsGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomersCount { get; set; }


        //Navigation Property
        public ICollection<Asset> Assets { get; set; }
    }
}