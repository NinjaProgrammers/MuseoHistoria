using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string Photo { get; set; }

        public bool Active { get; set; }
        public int AreaId { get; set; }

        public int PositionId { get; set; }
        public Area Area { get; set; }

        public Position Position { get; set; }
    }
}
