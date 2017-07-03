using JanuszMarcinik.Mvc.Domain.Models.Examples;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract
{
    public interface IExampleChildrensRepository
    {
        Task<ExampleChild> GetAsync(int id);
        IEnumerable<ExampleChild> GetByParentId(int parentId);
        Task CreateAsync(ExampleChild entity);
        Task UpdateAsync(ExampleChild entity);
        Task DeleteAsync(int id);
    }
}