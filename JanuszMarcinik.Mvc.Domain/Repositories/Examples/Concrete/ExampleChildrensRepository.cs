using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using System.Collections.Generic;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Concrete
{
    public class ExampleChildrensRepository : IExampleChildrensRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ExampleChild> GetByParentId(int parentId)
        {
            return this._context.Set<ExampleChild>()
                .Where(x => x.ParentId == parentId)
                .AsNoTracking();
        }

        public ExampleChild Get(int id)
        {
            return this._context.Get<ExampleChild>(id);
        }
            
        public void Create(ExampleChild entity)
        {
            this._context.Create(entity);
        }

        public void Update(ExampleChild entity)
        {
            this._context.Update(entity);
        }

        public void Delete(int id)
        {
            this._context.Delete<ExampleChild>(id);
        }
    }
}