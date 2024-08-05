using Solway.Interfaces.Specification;

using System.Linq.Expressions;

namespace Solway.DAC.Specification;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDescending { get; private set; }
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPaginating { get; private set; }

    public BaseSpecification() { }

    public BaseSpecification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    public void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);

    public void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

    public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;

    public void ApplyPaginating(int take, int skip)
    {
        Take = take;
        Skip = skip;
        IsPaginating = true;
    }
}