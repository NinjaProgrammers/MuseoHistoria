using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(object Id);
        public TEntity AddEntity(TEntity entity);

        public TEntity Delete(object Id);

        public TEntity Update(TEntity entity);

        public TEntity Select(TEntity entity);



    }
}
