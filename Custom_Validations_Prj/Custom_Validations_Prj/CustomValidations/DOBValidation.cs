using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Custom_Validations_Prj.CustomValidations
{
    public class DOBValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dob)
            {
                var age = DateTime.Now.Year - dob.Year;
                if (dob > DateTime.Now.AddYears(-age)) age--;
                return age >= 21 && age < 25;
            }
            return false;
        }
    }
}