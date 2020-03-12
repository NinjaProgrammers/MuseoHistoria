﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class TypeAct
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El costo debe ser mayor que cero")]
        public int Cost { get; set; }

        public string Name { get; set; }
    }
}