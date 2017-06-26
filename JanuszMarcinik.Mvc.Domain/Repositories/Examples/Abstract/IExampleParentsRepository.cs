using JanuszMarcinik.Mvc.Domain.Models.Examples;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract
{
    public interface IExampleParentsRepository
    {
        Task<ExampleParent> GetAsync(int id);
        IEnumerable<ExampleParent> ExampleParents { get; }
        Task CreateAsync(ExampleParent entity);
        Task UpdateAsync(ExampleParent entity);
        Task DeleteAsync(int id);
    }
}