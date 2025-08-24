using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Custom_Validations_Prj.CustomValidations
{
    public class DOJValidate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || !(value is DateTime doj))
            {
                return false;
            }

            return doj <= DateTime.Today;
        }
    }

}