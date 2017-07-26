using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using System.Collections.Generic;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Data.Entity;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Concrete
{
    public class ExampleParentsRepository : IExampleParentsRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ExampleParent> ExampleParents
        {
            get { return _context.ExampleParents; }
        }

        public ExampleParent Get(int id)
        {
            return _context.ExampleParents.Find(id);
        }
            
        public void Create(ExampleParent entity)
        {
            _context.ExampleParents.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ExampleParent entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _context.ExampleParents.Remove(entity);
            _context.SaveChanges();
        }
    }
}