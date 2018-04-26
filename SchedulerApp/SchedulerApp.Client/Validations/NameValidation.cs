using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client.Validations
{
    public class NameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
             return value.ToString().StartsWith("zz");
        }
    }
}