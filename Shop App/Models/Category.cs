using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Shop_App.Models
{
    public class Category
    {
        [key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
