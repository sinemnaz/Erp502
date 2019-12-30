using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGiris.Models
{
    [Table("Company")]
    public class Company:BaseEntity
    {
        //Id,company name,phone,fax,address,poastal code,country,owner,create date,is active(bool-true/false)
        
        [StringLength(200), Required]

        public string CompanyName{get; set;}
        [StringLength(200),Required]

        public string Phone { get; set; }
        [StringLength(50), Required]
        public string Fax { get; set; }
        [StringLength(50), Required]
        public string Address { get; set; }

        public string PoastalCode { get; set; }
        [StringLength(50), Required]
        public string Country { get; set; }
        [StringLength(50), Required]
        public string Owner { get; set; }
        
        
        
        public bool IsActive { get; set; }

        





    }
}