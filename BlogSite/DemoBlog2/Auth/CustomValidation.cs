using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBlog2.Auth
{
    public class CustomValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

    }
}