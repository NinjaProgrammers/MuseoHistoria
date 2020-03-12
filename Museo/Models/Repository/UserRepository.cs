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
            return context.Users.Where(x => x.Active);
        }

        public User GetById(object Id)
        {
            return context.Users.FirstOrDefault(x => x.Active && x.Id == (string)Id);
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
    }
}
