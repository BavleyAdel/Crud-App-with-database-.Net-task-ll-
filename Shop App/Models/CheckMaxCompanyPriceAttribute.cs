using System.ComponentModel.DataAnnotations;

namespace Shop_App.Models
{
    public class CheckMaxCompanyPriceAttribute:ValidationAttribute
    {
        private readonly int _maxCompanyPrice;
        public CheckMaxCompanyPriceAttribute(int price)
        {
            _maxCompanyPrice = price;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;
            int price;

            if (!int.TryParse(value.ToString(),out price))
            {
                return new ValidationResult("Invalid Price Value!");
            }

            if(product.CompanyId == 1 && price > _maxCompanyPrice)
            {
                return new ValidationResult("Price must be less than 3000 for addidas!");
            }

            return ValidationResult.Success;
        }
    }
}
