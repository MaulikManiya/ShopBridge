using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Data.Model
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter price.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid price.")]
        public decimal Price { get; set; }
    }
}
