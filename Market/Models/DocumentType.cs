﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        [Display(Name = "Documento")]
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}