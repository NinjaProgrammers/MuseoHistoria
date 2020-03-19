using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AllUsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public int AreaId { get; set; }
        public int PositionId { get; set; }
        public string Area { get; set; }
        public string Position { get; set; }
        public bool Active { get; set; }

    }
}
