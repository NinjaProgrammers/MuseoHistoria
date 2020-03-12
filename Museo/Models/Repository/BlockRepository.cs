using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class BlockRepository : IBlockRepository
    {
        ApplicationDBContext context;
        public BlockRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public Block AddEntity(Block entity)
        {
            var r = context.Blocks.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Block Delete(object Id)
        {
            var block = context.Blocks.FirstOrDefault(x => x.Id == (int)Id);
            if(block != null)
                context.Blocks.Remove(block);
            context.SaveChanges();
            return block;
        }

        public IEnumerable<Block> GetAll()
        {
            return context.Blocks;
        }

        public Block GetById(object Id)
        {
            return context.Blocks.FirstOrDefault(x => x.Id == (int)Id);
        }

        public Block Select(Block entity)
        {
            throw new NotImplementedException();
        }

        public Block Update(Block entity)
        {
            var item = context.Blocks.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Date = entity.Date;
                item.State = entity.State;
                item.TotalIntents = entity.TotalIntents;
                item.UserId = entity.TotalIntents;
            }
            context.SaveChanges();
            return item;
        }
    }
}
