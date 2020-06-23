using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkUnitTestingWithAspNetWebApi
{
    public class BaseClass
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime CreatedDate {get;set;}
        [Required(ErrorMessage = "UpdatedBy is required.")]
        public string UpdatedBy { get; set; }

    }
}
