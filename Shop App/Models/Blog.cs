using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_App.Models
{
    public class Blog
    {
        [key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Date { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category category { get; set; }
    }
}
