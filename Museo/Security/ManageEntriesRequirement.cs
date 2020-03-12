using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Security
{
    public class ManageEntriesRequirement : IAuthorizationRequirement
    {
        public readonly string requirement;

        public ManageEntriesRequirement(string requirement)
        {
            this.requirement = requirement;
        }
    }
}
