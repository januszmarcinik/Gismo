using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ExampleChild> GetAsync(int id)
        {
            return await _context.ExampleChildrens.FindAsync(id);
        }
            
        public async Task CreateAsync(ExampleChild entity)
        {
            _context.ExampleChildrens.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExampleChild entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ExampleChildrens.FindAsync(id);
            _context.ExampleChildrens.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}