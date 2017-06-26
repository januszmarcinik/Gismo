using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ExampleParent> GetAsync(int id)
        {
            return await _context.ExampleParents.FindAsync(id);
        }
            
        public async Task CreateAsync(ExampleParent entity)
        {
            _context.ExampleParents.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExampleParent entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ExampleParents.FindAsync(id);
            _context.ExampleParents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}