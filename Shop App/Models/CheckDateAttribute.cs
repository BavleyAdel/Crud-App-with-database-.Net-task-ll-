using System.ComponentModel.DataAnnotations;

namespace Shop_App.Models
{
    public class CheckDateAttribute : ValidationAttribute
    {
        private readonly DateTime _todayDate;
        public CheckDateAttribute()
        {
            _todayDate = DateTime.Now;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Blog blog = (Blog)validationContext.ObjectInstance;
            if (DateTime.Compare(blog.Date,_todayDate)< 0)
            {
                return new ValidationResult("Thish Date is not valid!");
            }
            return ValidationResult.Success;
        }
    }
}
