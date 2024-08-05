using Solway.Interfaces.Models;

namespace Solway.Interfaces.Specification;

public interface ISpeficiationEvaluator<Entity>
{
    abstract static IQueryable<Entity> GetQuery(IQueryable<Entity> inputQuery, ISpecification<Entity> spec);
}