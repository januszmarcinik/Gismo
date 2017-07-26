using JanuszMarcinik.Mvc.Domain.Models.Examples;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract
{
    public interface IExampleParentsRepository
    {
        ExampleParent Get(int id);
        IEnumerable<ExampleParent> ExampleParents { get; }
        void Create(ExampleParent entity);
        void Update(ExampleParent entity);
        void Delete(int id);
    }
}