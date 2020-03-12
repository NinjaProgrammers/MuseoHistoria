using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class DocumentRepository : IDocumentRepository
    {
        ApplicationDBContext context;
        public DocumentRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Document AddEntity(Document entity)
        {
            var r = context.Documents.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public IEnumerable<DocumentCategory> AllCategories()
        {
            return context.DocumentCategories;
        }

        public Document Delete(object Id)
        {
            var document = context.Documents.FirstOrDefault(x => x.Id == (int)Id);
            if(document != null)
                context.Documents.Remove(document);
            context.SaveChanges();
            return document;
        }

        public IEnumerable<Document> GetAll()
        {
            return context.Documents;
        }

        public Document GetById(object Id)
        {
            return context.Documents.FirstOrDefault(x => x.Id == (int)Id);
        }

        public string GetCategoryNameById(int id)
        {
            return context.DocumentCategories.FirstOrDefault(x => x.Id == id).Category;
        }

        public Document Select(Document entity)
        {
            throw new NotImplementedException();
        }

        public Document Update(Document entity)
        {
            var item = context.Documents.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Author = entity.Author;
                item.Date = entity.Date;
                item.Description = entity.Description;
                item.DocumentCategory = entity.DocumentCategory;
                item.DocumentCategoryId = entity.DocumentCategoryId;
                item.Manager = entity.Manager;
                item.Name = entity.Name;
                item.PublicationDate = entity.PublicationDate;
            }
            context.SaveChanges();
            return item;
        }
    }
}
