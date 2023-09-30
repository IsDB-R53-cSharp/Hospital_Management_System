using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DueAmountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bill = (TotalBill)validationContext.ObjectInstance;

            if (bill.Due.HasValue && bill.Due > 0.6m * bill.TotalAmount)
            {
                return new ValidationResult("Due Amount cannot exceed 60% of Bill Amount", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
