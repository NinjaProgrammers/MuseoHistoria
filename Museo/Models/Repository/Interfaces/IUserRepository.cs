using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByUsername(string name);
        public IEnumerable<Tuple<int, string>> MoreActivitiesWorker(int count = 10);
    }
}
