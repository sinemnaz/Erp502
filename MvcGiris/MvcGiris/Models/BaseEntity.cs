﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGiris.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}