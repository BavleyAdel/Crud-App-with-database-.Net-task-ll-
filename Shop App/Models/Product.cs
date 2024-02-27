using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_App.Models
{
    public class Product
    {
        [key]
        public int Id { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$", ErrorMessage = "Charecters are not allowed")]
        public string Name { get; set; }


        [Required(ErrorMessage= "Description is requires")]
        [Length(5,50)]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$", ErrorMessage = "Charecters are not allowed")]
        public string Description { get; set; }

        [Required]
        [Range(1,5000 , ErrorMessage ="please enter price from 1 to 5000")]
        [Utilities.CheckMaxCompanyPrice(3000)]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool EnableSize { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public Company Company { get; set; }

    }
}
