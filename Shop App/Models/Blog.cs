using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_App.Models
{
    public class Blog
    {
        [key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$",ErrorMessage ="Charecters are not allowed")]
        public string Title { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$", ErrorMessage = "Charecters are not allowed")]
        public string Description { get; set; }

        [Required]
        [Utilities.CheckDate]
        public DateTime Date { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category? category { get; set; }
    }
}
