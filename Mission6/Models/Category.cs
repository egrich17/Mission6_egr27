﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class Category
    {
        // create separate model for category
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
