using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class DocumentCategoryRepository : IDocumentCategoryRepository
    {
        ApplicationDBContext context;
        public DocumentCategoryRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public DocumentCategory AddEntity(DocumentCategory entity)
        {
            var r = context.DocumentCategories.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public DocumentCategory Delete(object Id)
        {
            var documentcategory = context.DocumentCategories.FirstOrDefault(x => x.Id == (int)Id);
            if(documentcategory != null)
                context.DocumentCategories.Remove(documentcategory);
            context.SaveChanges();
            return documentcategory;
        }

        public IEnumerable<DocumentCategory> GetAll()
        {
            return context.DocumentCategories;
        }

        public DocumentCategory GetById(object Id)
        {
            return context.DocumentCategories.FirstOrDefault(x => x.Id == (int)Id);
        }

        public DocumentCategory Select(DocumentCategory entity)
        {
            throw new NotImplementedException();
        }

        public DocumentCategory Update(DocumentCategory entity)
        {
            var item = context.DocumentCategories.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Category = entity.Category;
                item.Description = entity.Description;                
            }
            context.SaveChanges();
            return item;
        }
    }
}

       