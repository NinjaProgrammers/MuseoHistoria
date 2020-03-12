using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IDocumentRepository:IRepository<Document>
    {
        public IEnumerable<DocumentCategory> AllCategories();
        public string GetCategoryNameById(int id);

    }
}
