using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGiris.Models
{
    [Table("Employees")]
    public class Employee:BaseEntity
    {
        
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(70), Required]
        public string JobTitle { get; set; }

        
    }
}