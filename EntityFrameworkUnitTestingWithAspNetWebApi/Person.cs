using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkUnitTestingWithAspNetWebApi
{
    public class Person : BaseClass
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LatName is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "ID Number is required.")]
        [RegularExpression(@"\d*", ErrorMessage = "ID Number must be numeric")]
        public string IDNumber { get; set; }
    }
}
