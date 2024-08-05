using System.Linq.Expressions;

namespace Solway.Interfaces.Specification;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPaginating { get; }

    void AddInclude(Expression<Func<T, object>> include);
    void AddOrderBy(Expression<Func<T, object>> orderBy);
    void AddOrderByDescending(Expression<Func<T, object>> orderByDescending);
}