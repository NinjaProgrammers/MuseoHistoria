using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class NewsRepository : INewsRepository
    {
        ApplicationDBContext context;
        public NewsRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public News AddEntity(News entity)
        {
            var r = context.News.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public News Delete(object Id)
        {
            var news = context.News.FirstOrDefault(x => x.Id == (int)Id);
            if(news != null)
                context.News.Remove(news);
            context.SaveChanges();
            return news;
        }

        public IEnumerable<News> GetAll()
        {
            return context.News;
        }

        public News GetById(object Id)
        {
            return context.News.FirstOrDefault(x => x.Id == (int)Id);
        }

        public News Select(News entity)
        {
            throw new NotImplementedException();
        }

        public News Update(News entity)
        {
            var item = context.News.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Author = entity.Author;
                item.Description = entity.Description;
                item.Title = entity.Title;
            }
            context.SaveChanges();
            return item;
        }
    }
}
