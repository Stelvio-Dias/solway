using Microsoft.EntityFrameworkCore;
using Solway.Interfaces.Specification;
using Solway.Models;

namespace Solway.DAC.Specification;

public class SpecificationEvaluator<Entity> : ISpeficiationEvaluator<Entity> where Entity : BaseEntity
{
    public static IQueryable<Entity> GetQuery(IQueryable<Entity> inputQuery, ISpecification<Entity> spec)
    {
        if (spec.Criteria is not null) inputQuery = inputQuery.Where(spec.Criteria);

        if (spec.OrderBy is not null) inputQuery = inputQuery.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending is not null) inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);

        if (spec.IsPaginating) inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);

        if (spec.Includes is not null) inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

        return inputQuery;
    }
}