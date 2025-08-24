using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Custom_Validations_Prj.CustomValidations
{
    public class PasswordValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password is required.");
            }

            // Regex: ^[A-Z][0-9].{5}$
            var pattern = @"^[A-Z][0-9].{5}$";
            if (!Regex.IsMatch(password, pattern))
            {
                return new ValidationResult("Password must start with an uppercase letter, followed by a digit, and then 5 characters.");
            }

            return ValidationResult.Success;
        }
    }
}