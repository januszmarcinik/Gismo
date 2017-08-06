using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using System.Collections.Generic;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Data.Entity;
using JanuszMarcinik.Mvc.Domain.Models.Media;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Concrete
{
    public class ExampleParentsRepository : IExampleParentsRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ExampleParent> ExampleParents
        {
            get { return this._context.Set<ExampleParent>().AsNoTracking(); }
        }

        public ExampleParent Get(int id)
        {
            return this._context.Get<ExampleParent>(id);
        }

        public void Create(ExampleParent entity)
        {
            this._context.Create(entity);
        }

        public void Update(ExampleParent entity)
        {
            this._context.Update(entity);
        }

        public void Delete(int id)
        {
            this._context.Delete<ExampleParent>(id);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}