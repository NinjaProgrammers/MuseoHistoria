using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        ApplicationDBContext context;

        public UserRepository(ApplicationDBContext con)
        {
            context = con;
        }

        public User AddEntity(User entity)
        {
            entity.Active = true;
            var r = context.Users.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public User Delete(object Id)
        {
            var user = context.Users.FirstOrDefault(x => x.Active && x.Id == (string)Id);
            if (user != null)
                user.Active = false;
            context.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in context.Users)
            {
                if (item.Active) yield return item;
            }
        }

        public User GetById(object Id)
        {
            return context.Users.FirstOrDefault(x => x.Active && x.Id == (string)Id);
        }

        public User GetByUsername(string name)
        {
            return context.Users.FirstOrDefault(x => x.Active && x.UserName == name);
        }

        public User Select(User entity)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            var item = context.Users.FirstOrDefault(x => x.Active && x.Id == entity.Id);
            if (item != null)
            {
                item.Area = entity.Area;
                item.AreaId = entity.AreaId;
                item.Email = entity.Email;
                item.FullName = entity.FullName;
                item.Photo = entity.Photo;
                item.Position = entity.Position;
                item.PositionId = entity.PositionId;
                item.UserName = entity.UserName;
            }
            context.SaveChanges();
            return item;
        }

        public IEnumerable<User> MoreActivitiesWorker(int count = 10)
        {
            var act = context.Activities.ToList();
            Dictionary<string, int> user_cant = new Dictionary<string, int>();

            foreach (var item in act)
            {
                if (user_cant.ContainsKey(item.UserId))
                    user_cant[item.UserId] += 1;
                else
                    user_cant.Add(item.UserId, 1);
            }

            List<Tuple<int, string>> a = new List<Tuple<int, string>>();

            foreach (var item in user_cant)
            {
                a.Add(new Tuple<int, string>(item.Value, item.Key));
            }
            a.Sort();
            a.Reverse();


            for (int i = 0; i < count && i < a.Count; i++)
            {
                yield return context.Users.First(x => x.Id == a[i].Item2);
            }

        }

        public IEnumerable<User> ParticipActivitiesWorker(int count)
        {
            var act = context.Activities.ToList();
            List<Tuple<int, string>> a = new List<Tuple<int, string>>();

            foreach (var item in act)
            {

                int participants = item.AdultExt + item.AdultNac + item.ChildNac + item.ChildExt;
                a.Add(new Tuple<int, string>(participants, item.UserId));
            }

            a.Sort();

            for (int i = 0; i < count && i < a.Count; i++)
            {
                yield return context.Users.First(x => x.Id == a[i].Item2);
            }

        }
    }
}
