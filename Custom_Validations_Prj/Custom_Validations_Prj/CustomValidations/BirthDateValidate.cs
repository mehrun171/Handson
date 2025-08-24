using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Custom_Validations_Prj.CustomValidations
{
    public class BirthDateValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("BirthDate is required.");
            }

            if (!(value is DateTime birthday))
            {
                return new ValidationResult("Invalid BirthDate format.");
            }

            if (birthday.Year < 1996)
            {
                return new ValidationResult("Bit old for this job");
            }

            if (birthday.Year < 2003)
            {
                return new ValidationResult("Very young for this job");
            }

            if (birthday.Month == 4)
            {
                return new ValidationResult("Sorry, we cannot accept April borns");
            }

            return ValidationResult.Success;
        }
    }
}