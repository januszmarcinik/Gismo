using JanuszMarcinik.Mvc.Domain.Models.Examples;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract
{
    public interface IExampleChildrensRepository
    {
        ExampleChild Get(int id);
        IEnumerable<ExampleChild> GetByParentId(int parentId);
        void Create(ExampleChild entity);
        void Update(ExampleChild entity);
        void Delete(int id);
    }
}