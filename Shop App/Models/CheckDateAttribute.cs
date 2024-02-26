using System.ComponentModel.DataAnnotations;

namespace Shop_App.Models
{
    public class CheckDateAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            return base.IsValid(value, validationContext);
        }
    }
}
