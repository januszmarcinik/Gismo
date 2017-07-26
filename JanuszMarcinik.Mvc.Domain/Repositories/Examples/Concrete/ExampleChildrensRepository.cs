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
            return _context.ExampleChildrens
                    .Where(x => x.ParentId == parentId);
        }

        public ExampleChild Get(int id)
        {
            return _context.ExampleChildrens.Find(id);
        }
            
        public void Create(ExampleChild entity)
        {
            _context.ExampleChildrens.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ExampleChild entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _context.ExampleChildrens.Remove(entity);
            _context.SaveChanges();
        }
    }
}